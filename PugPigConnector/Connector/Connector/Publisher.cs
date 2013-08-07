using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using System.Configuration;
using Connector.Models.Pages;
using Connector;
using System.Web;
using System.Linq;

namespace Connector
{
    public class Publisher
    {
        #region Instance Variables

        private PageData currentPage;
        private PageData editionListPage;
        private HttpRequest request;

        #endregion

        /// <summary>
        /// Defines the file types that should be included in the Manifest file when it is
        /// created.
        /// All other file types are excluded.
        /// </summary>
        const string FILE_TYPES = "*.js;*.css;*.gif;*.png;*.jp*g;*.ico";

        #region Public Methods

        public Publisher()
        {            
            currentPage = ((PageBase)HttpContext.Current.Handler).CurrentPage;
            editionListPage = DataFactory.Instance.GetPage(currentPage.ParentLink);
            request = HttpContext.Current.Request;            
        }

        public void PublishEdition()
        {
            GenerateEditionPages();

            GenerateEditionFeed();

            GenerateManifest();

            GenerateEditionListFeed();
        }

        public void GenerateEditionPages()
        {
            // Ensure there exists a location to publish the edition
            string publishLocation = Common.GetEditionFolder(currentPage.Name);

            if (!string.IsNullOrEmpty(publishLocation))
            {
                PageDataCollection editionPages = DataFactory.Instance.GetChildren(currentPage.PageLink);

                if (editionPages != null)
                {
                    foreach (PageData editionPage in editionPages)
                    {
                        string pageURL = Common.GetFriendlyURL(editionPage);

                        string pageContent = GetPageContent(pageURL);

                        using (StreamWriter streamWriter = new StreamWriter(publishLocation + "\\" + editionPage.Name + ".html"))
                        {
                            streamWriter.Write(pageContent);
                            streamWriter.Close();
                        }
                    }
                }
            }
        }

        public void GenerateEditionFeed()
        {
            XmlDocument doc = new XmlDocument();

            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaration);

            XmlNode outerNode = doc.CreateElement("edition");
            doc.AppendChild(outerNode);

            XmlNode editionIdNode = doc.CreateElement("pageId");
            editionIdNode.InnerText = currentPage.PageGuid.ToString();
            outerNode.AppendChild(editionIdNode);

            XmlNode editionLinkNode = doc.CreateElement("href");
            editionLinkNode.InnerText = string.Format("{0}/{1}/{2}.xml", Common.GetRootPublishLocationPath(), currentPage.Name, currentPage.Name);                        
            outerNode.AppendChild(editionLinkNode);

            XmlNode editionTitleNode = doc.CreateElement("title");
            editionTitleNode.InnerText = currentPage.PageName;
            outerNode.AppendChild(editionTitleNode);

            XmlNode editionSubTitleNode = doc.CreateElement("subtitle");
            editionSubTitleNode.InnerText = currentPage["SubTitle"].ToString();
            outerNode.AppendChild(editionSubTitleNode);

            XmlNode editionAuthorNameNode = doc.CreateElement("authorname");
            editionAuthorNameNode.InnerText = currentPage.CreatedBy;
            outerNode.AppendChild(editionAuthorNameNode);

            XmlNode editionUpdatedNode = doc.CreateElement("updated");
            editionUpdatedNode.InnerText = currentPage.StartPublish.ToString("o");
            outerNode.AppendChild(editionUpdatedNode);

            PageDataCollection childPages = DataFactory.Instance.GetChildren(currentPage.PageLink);

            foreach (PageData childPage in childPages)
            {
                XmlNode itemNode = doc.CreateNode(XmlNodeType.Element, "page", null);

                XmlNode pageIdNode = doc.CreateElement("pageId");
                pageIdNode.InnerText = childPage.PageGuid.ToString();
                itemNode.AppendChild(pageIdNode);

                XmlNode pageTitleNode = doc.CreateElement("title");
                pageTitleNode.InnerText = childPage.PageName;
                itemNode.AppendChild(pageTitleNode);

                XmlNode pageSummaryNode = doc.CreateElement("summary");
                pageSummaryNode.InnerText = childPage["Summary"].ToString();
                itemNode.AppendChild(pageSummaryNode);

                XmlNode pageUpdatedNode = doc.CreateElement("updated");
                pageUpdatedNode.InnerText = childPage.StartPublish.ToString("o");
                itemNode.AppendChild(pageUpdatedNode);

                // Add links to html and manifest here

                XmlNode pageLinkNode = doc.CreateElement("pageLink");
                pageLinkNode.InnerText = childPage.Name + ".html";
                itemNode.AppendChild(pageLinkNode);

                XmlNode manifestLinkNode = doc.CreateElement("manifestLink");
                manifestLinkNode.InnerText = currentPage.Name + ".manifest";
                itemNode.AppendChild(manifestLinkNode);

                outerNode.AppendChild(itemNode);
            }

            ApplyEditionTransform(doc.InnerXml);
        }

        public void GenerateManifest()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("CACHE MANIFEST");
            stringBuilder.AppendLine();

            stringBuilder.Append(string.Format("# This file was generated at {0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()));
            stringBuilder.AppendLine();
            stringBuilder.AppendLine();

            stringBuilder.Append("CACHE:");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine();

            // List site content
            stringBuilder.Append(ListSiteContent());
            stringBuilder.AppendLine();

            //List page properties
            stringBuilder.Append(ListPageContent());

            using (StreamWriter streamWriter = new StreamWriter(Common.GetEditionFolder(currentPage.Name) + "\\" + currentPage.Name + ".manifest"))
            {
                streamWriter.Write(stringBuilder.ToString());
                streamWriter.Close();
            }
        }

        public void GenerateEditionListFeed()
        {
            PageDataCollection editions;

            // Get siblings of the current edition page
            if (currentPage.ParentLink != PageReference.EmptyReference)
            {
                editions = DataFactory.Instance.GetChildren(currentPage.ParentLink);
                ProcessEditionListFeed(editions);
            }
        }

        #endregion

        #region Private Methods

        private static string GetPageContent(string url)
        {
            string result = "";

            System.Net.WebRequest objRequest = System.Net.HttpWebRequest.Create(url.Trim());

            using (StreamReader sr = new StreamReader(objRequest.GetResponse().GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();

                return Common.HtmlAppRelativeUrlsToAbsoluteUrls(result);
            }

            return result;
        }

        private void ApplyEditionTransform(string feedXml)
        {
            // Transform XML
            XslCompiledTransform transformer = new XslCompiledTransform();
            StringWriter stringWriter = new StringWriter();

            transformer.Load(HttpContext.Current.Server.MapPath("//XSLT//Edition.xslt"));

            using (XmlReader xmlReader = XmlReader.Create(new StringReader(feedXml)))
            {
                transformer.Transform(xmlReader, null, stringWriter);
            }

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(stringWriter.ToString());
            xmlDocument.Save(Common.GetEditionFolder(currentPage.Name) + "\\" + currentPage.Name + ".xml");
        }

        //private List<PageData> GetAllChildrenFilteredByPageType(PageData parent)
        //{
        //    List<PageData> allChildren = new List<PageData>();

        //    PageDataCollection children = DataFactory.Instance.GetChildren(parent.PageLink);

        //    foreach (PageData child in children)
        //    {
        //        allChildren.Add(child);

        //        if (DataFactory.Instance.GetChildren(child.PageLink).Count > 0)
        //        {
        //            allChildren.AddRange(GetAllChildrenFilteredByPageType(child));
        //        }
        //    }
        //    return allChildren;
        //}               

        /// <summary>
        /// Creates a list of properties from all pages within an edition
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <returns></returns>
        private string ListPageContent()
        {
            var stringBuilder = new StringBuilder();
            var editionPages = DataFactory.Instance.GetChildren(currentPage.PageLink);

            stringBuilder.Append("# Page Content");
            stringBuilder.AppendLine();

            if (editionPages != null)
            {
                foreach (PageData editionPage in editionPages)
                {
                    foreach (PropertyData property in from property in editionPage.Property
                                                      let type = property.Name
                                                      where type == "Image"
                                                      select property)
                    {
                        if (property.Value != null)
                        {
                            stringBuilder.Append(UriSupport.AbsoluteUrlBySettings(property.Value.ToString()));
                            stringBuilder.AppendLine();
                        }
                    }
                }
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Creates a list of static site content
        /// </summary>
        /// <returns></returns>
        private string ListSiteContent()
        {
            var stringBuilder = new StringBuilder();
            
            stringBuilder.Append("# Site Content");
            stringBuilder.AppendLine();

            string[] filePatterns = FILE_TYPES.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            List<string> cacheFileList = new List<string>();

            foreach (string filePattern in filePatterns)
            {
                cacheFileList.AddRange(Directory.GetFiles(request.PhysicalApplicationPath, filePattern, SearchOption.AllDirectories));
            }

            cacheFileList.Sort();

            foreach (string filePath in cacheFileList)
            {
                stringBuilder.Append(UriSupport.AbsoluteUrlBySettings((String.Format("{0}/{1}", request.ApplicationPath, filePath.Replace(request.PhysicalApplicationPath, "")
                    .Replace(@"\", "/"))).Replace("//", "/")));

                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }        

        private void ProcessEditionListFeed(PageDataCollection editions)
        {
            XmlDocument doc = new XmlDocument();            

            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaration);

            XmlNode outerNode = doc.CreateElement("editionList");
            doc.AppendChild(outerNode);

            XmlNode pageIdNode = doc.CreateElement("pageId");
            pageIdNode.InnerText = editionListPage.PageGuid.ToString();
            outerNode.AppendChild(pageIdNode);

            XmlNode titleNode = doc.CreateElement("title");
            titleNode.InnerText = editionListPage.PageName;
            outerNode.AppendChild(titleNode);

            XmlNode updatedNode = doc.CreateElement("updated");
            updatedNode.InnerText = editions.Count == 0 ? "1970-01-01" : editions.Max(pd => pd.StartPublish).ToString("o");
            outerNode.AppendChild(updatedNode);

            XmlNode authorNameNode = doc.CreateElement("authorname");
            authorNameNode.InnerText = editionListPage.CreatedBy;
            outerNode.AppendChild(authorNameNode);

            XmlNode hrefNode = doc.CreateElement("href");            
            hrefNode.InnerText = string.Format("{0}/{1}.xml", Common.GetRootPublishLocationPath(), editionListPage.Name);
            outerNode.AppendChild(hrefNode);

            foreach (PageData edition in editions)
            {
                CreateEditionList(doc, edition, outerNode);
            }

            ApplyEditionListTransform(doc.InnerXml); ;
        }        

        private void CreateEditionList(XmlDocument doc, PageData edition, XmlNode outerNode)
        {
            XmlNode entryNode = doc.CreateNode(XmlNodeType.Element, "edition", null);

            XmlNode editionTitleNode = doc.CreateElement("title");
            editionTitleNode.InnerText = edition.PageName;
            entryNode.AppendChild(editionTitleNode);
            outerNode.AppendChild(entryNode);

            XmlNode editionIdNode = doc.CreateElement("id");
            editionIdNode.InnerText = edition.PageGuid.ToString();
            entryNode.AppendChild(editionIdNode);

            XmlNode editionUpdatedNode = doc.CreateElement("updated");
            editionUpdatedNode.InnerText = edition.StartPublish.ToString("o");
            entryNode.AppendChild(editionUpdatedNode);

            XmlNode editionAuthorNameNode = doc.CreateElement("authorname");
            editionAuthorNameNode.InnerText = edition.CreatedBy;
            entryNode.AppendChild(editionAuthorNameNode);

            XmlNode editionTermsIssuedNode = doc.CreateElement("issued");
            editionTermsIssuedNode.InnerText = ((DateTime)edition["Issued"]).ToString("yyyy-MM-dd");
            entryNode.AppendChild(editionTermsIssuedNode);

            XmlNode editionSummaryNode = doc.CreateElement("summary");
            editionSummaryNode.InnerText = edition["Summary"].ToString();
            entryNode.AppendChild(editionSummaryNode);

            XmlNode coverImageHref = doc.CreateElement("imagehref");
            coverImageHref.InnerText = HttpContext.Current.Server.HtmlEncode(UriSupport.AbsoluteUrlBySettings(edition["Image"].ToString()));
            entryNode.AppendChild(coverImageHref);

            XmlNode editionContentHref = doc.CreateElement("editionContent");
            editionContentHref.InnerText = string.Format("{0}/{1}/{2}.xml", Common.GetRootPublishLocationPath(), edition.Name, edition.Name);                                    
            entryNode.AppendChild(editionContentHref);

            XmlNode alternateHref = doc.CreateElement("alternatehref");
            alternateHref.InnerText = string.Format("{0}/{1}/{2}.xml", Common.GetRootPublishLocationPath(), edition.Name, edition.Name);
            entryNode.AppendChild(alternateHref);
        }

        private void ApplyEditionListTransform(string feedXml)
        {
            // Transform XML
            XslCompiledTransform transformer = new XslCompiledTransform();
            StringWriter stringWriter = new StringWriter();

            transformer.Load(HttpContext.Current.Server.MapPath("//XSLT//EditionContainer.xslt"));

            using (XmlReader xmlReader = XmlReader.Create(new StringReader(feedXml)))
            {
                transformer.Transform(xmlReader, null, stringWriter);
            }

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(stringWriter.ToString());
            xmlDocument.Save(Common.GetEditionFolder(string.Empty) + "\\" + editionListPage.Name + ".xml");
        }

        #endregion
    }
}