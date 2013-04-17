using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using PugPigConnector.Models.Pages;

namespace PugPigConnector.Views.Pages
{
    [TemplateDescriptor(Path = "~/Views/Pages/Edition.aspx")]
    public partial class Edition : TemplatePage<EditionPage>
    {
        public Edition()
            : base(0, EPiServer.Web.PageExtensions.ContextMenu.OptionFlag)
        {
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            Response.ContentType = "text/xml";
            Response.Clear();

            GenerateFeed();

            Response.End();
        }

        private void GenerateFeed()
        {
            XmlDocument doc = new XmlDocument();

            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaration);

            XmlNode outerNode = doc.CreateElement("edition");
            doc.AppendChild(outerNode);

            XmlNode editionIdNode = doc.CreateElement("pageId");
            editionIdNode.InnerText = CurrentPage.PageGuid.ToString();
            outerNode.AppendChild(editionIdNode);

            XmlNode editionLinkNode = doc.CreateElement("href");
            //editionLinkNode.InnerText = Server.HtmlEncode(CurrentPage.LinkURL);
            editionLinkNode.InnerText = UriSupport.AbsoluteUrlBySettings(CurrentPage.LinkURL);
            outerNode.AppendChild(editionLinkNode);

            XmlNode editionTitleNode = doc.CreateElement("title");
            editionTitleNode.InnerText = CurrentPage.PageName;
            outerNode.AppendChild(editionTitleNode);

            XmlNode editionSubTitleNode = doc.CreateElement("subtitle");
            editionSubTitleNode.InnerText = CurrentPage["SubTitle"].ToString();
            outerNode.AppendChild(editionSubTitleNode);

            XmlNode editionAuthorNameNode = doc.CreateElement("authorname");
            editionAuthorNameNode.InnerText = CurrentPage.CreatedBy;
            outerNode.AppendChild(editionAuthorNameNode);

            XmlNode editionUpdatedNode = doc.CreateElement("updated");
            editionUpdatedNode.InnerText = CurrentPage.StartPublish.ToString("o");
            outerNode.AppendChild(editionUpdatedNode);

            List<PageData> childPages = GetAllChildrenFilteredByPageType(CurrentPage);

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
                //pageLinkNode.InnerText = childPage.LinkURL;
                //pageLinkNode.InnerText = GetExternalLink(childPage);
                pageLinkNode.InnerText = UriSupport.AbsoluteUrlBySettings(childPage.LinkURL);
                itemNode.AppendChild(pageLinkNode);

                XmlNode manifestLinkNode = doc.CreateElement("manifestLink");
                manifestLinkNode.InnerText = UriSupport.AbsoluteUrlBySettings("/page.manifest?pageId=" + childPage.PageLink);
                //manifestLinkNode.InnerText = "page.manifest";

                itemNode.AppendChild(manifestLinkNode);

                outerNode.AppendChild(itemNode);
            }

            ApplyTransform(doc.InnerXml);
        }

        private void ApplyTransform(string feedXml)
        {
            // Transform XML
            XslCompiledTransform transformer = new XslCompiledTransform();
            StringWriter stringWriter = new StringWriter();

            transformer.Load(Server.MapPath("//XSLT//Edition.xslt"));

            using (XmlReader xmlReader = XmlReader.Create(new StringReader(feedXml)))
            {
                transformer.Transform(xmlReader, null, stringWriter);
            }

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(stringWriter.ToString());
            xmlDocument.Save(Response.OutputStream);
        }

        //private void GenerateFeed()
        //{
        //    XmlDocument doc = new XmlDocument();

        //    XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        //    doc.AppendChild(declaration);

        //    XmlNode outerNode = doc.CreateElement("feed");

        //    XmlAttribute uriInfo = doc.CreateAttribute("xmlns");
        //    uriInfo.Value = "http://www.w3.org/2005/Atom";
        //    outerNode.Attributes.Append(uriInfo);

        //    doc.AppendChild(outerNode);

        //    XmlNode idNode = doc.CreateElement("id");
        //    idNode.InnerText = CurrentPage.PageGuid.ToString();
        //    outerNode.AppendChild(idNode);

        //    XmlNode linkNode = doc.CreateElement("link");
        //    XmlAttribute rel = doc.CreateAttribute("rel");
        //    rel.Value = "self";
        //    linkNode.Attributes.Append(rel);

        //    XmlAttribute type = doc.CreateAttribute("type");

        //    type.Value = "application/atom+xml";
        //    linkNode.Attributes.Append(type);

        //    XmlAttribute href = doc.CreateAttribute("href");
        //    href.Value = Server.HtmlEncode(UriSupport.AbsoluteUrlBySettings(GetFriendlyURL(CurrentPage)));
        //    linkNode.Attributes.Append(href);

        //    outerNode.AppendChild(linkNode);

        //    XmlNode authorNode = doc.CreateElement("author");
        //    XmlNode nameNode = doc.CreateElement("name");
        //    nameNode.InnerText = CurrentPage.CreatedBy;
        //    authorNode.AppendChild(nameNode);

        //    outerNode.AppendChild(authorNode);

        //    XmlNode titleNode = doc.CreateElement("title");

        //    XmlAttribute editionTitleTypeAttribute = doc.CreateAttribute("type");
        //    editionTitleTypeAttribute.Value = "text";
        //    titleNode.Attributes.Append(editionTitleTypeAttribute);

        //    titleNode.InnerText = CurrentPage.PageName;
        //    outerNode.AppendChild(titleNode);

        //    XmlNode subTitleNode = doc.CreateElement("subtitle");

        //    XmlAttribute subTitleTypeAttribute = doc.CreateAttribute("type");
        //    subTitleTypeAttribute.Value = "text";
        //    subTitleNode.Attributes.Append(subTitleTypeAttribute);

        //    subTitleNode.InnerText = CurrentPage["SubTitle"].ToString();
        //    outerNode.AppendChild(subTitleNode);

        //    XmlNode updatedNode = doc.CreateElement("updated");
        //    updatedNode.InnerText = CurrentPage.StartPublish.ToString("o");
        //    outerNode.AppendChild(updatedNode);

        //    List<PageData> childPages = GetAllChildrenFilteredByPageType(CurrentPage);

        //    foreach (PageData childPage in childPages)
        //    {
        //        XmlNode entryNode = doc.CreateNode(XmlNodeType.Element, "entry", null);

        //        XmlNode editionTitleNode = doc.CreateElement("title");

        //        XmlAttribute titleTypeAttribute = doc.CreateAttribute("type");
        //        titleTypeAttribute.Value = "text";
        //        editionTitleNode.Attributes.Append(titleTypeAttribute);

        //        editionTitleNode.InnerText = childPage.PageName;
        //        entryNode.AppendChild(editionTitleNode);

        //        XmlNode editionIdNode = doc.CreateElement("id");
        //        editionIdNode.InnerText = childPage.PageGuid.ToString();
        //        entryNode.AppendChild(editionIdNode);

        //        XmlNode editionUpdatedNode = doc.CreateElement("updated");
        //        editionUpdatedNode.InnerText = childPage.StartPublish.ToString("o");
        //        entryNode.AppendChild(editionUpdatedNode);

        //        XmlNode editionSummaryNode = doc.CreateElement("summary");

        //        XmlAttribute summaryTypeAttribute = doc.CreateAttribute("type");
        //        summaryTypeAttribute.Value = "text";
        //        editionSummaryNode.Attributes.Append(summaryTypeAttribute);

        //        editionSummaryNode.InnerText = childPage["Summary"].ToString();
        //        entryNode.AppendChild(editionSummaryNode);

        //        // Add links to html and manifest here

        //        outerNode.AppendChild(entryNode);
        //    }

        //    doc.Save(Response.OutputStream);
        //}

        private List<PageData> GetAllChildrenFilteredByPageType(PageData parent)
        {
            List<PageData> allChildren = new List<PageData>();

            PageDataCollection children = DataFactory.Instance.GetChildren(parent.PageLink);

            foreach (PageData child in children)
            {
                allChildren.Add(child);

                if (DataFactory.Instance.GetChildren(child.PageLink).Count > 0)
                {
                    allChildren.AddRange(GetAllChildrenFilteredByPageType(child));
                }
            }
            return allChildren;
        }

        public static string GetExternalLink(PageData p)
        {
            UrlBuilder pageURLBuilder = new UrlBuilder(p.LinkURL);

            EPiServer.Global.UrlRewriteProvider.ConvertToExternal(pageURLBuilder, p.PageLink, UTF8Encoding.UTF8);

            string pageURL = pageURLBuilder.ToString();

            UriBuilder uriBuilder = new UriBuilder(EPiServer.Configuration.Settings.Instance.SiteUrl);

            uriBuilder.Path = pageURL;

            return uriBuilder.Uri.AbsoluteUri;
        }
    }
}


