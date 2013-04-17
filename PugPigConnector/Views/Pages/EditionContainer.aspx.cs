using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using PugPigConnector.Models.Pages; 

namespace PugPigConnector.Views.Pages
{
    [TemplateDescriptor(Path = "~/Views/Pages/EditionContainer.aspx")]
    public partial class EditionContainer : TemplatePage<EditionContainerPage>
    {
        public EditionContainer()
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
            PageDataCollection editionsForFeed;

            try
            {
                editionsForFeed = GetChildren(CurrentPage.PageLink);
            }
            catch
            {
                editionsForFeed = new PageDataCollection();
            }

            if (editionsForFeed != null)
            {
                GenerateFeed(editionsForFeed);
            }
        }

        private void GenerateFeed(PageDataCollection editions)
        {  
            XmlDocument doc = new XmlDocument();

            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaration);

            XmlNode outerNode = doc.CreateElement("editionList");
            doc.AppendChild(outerNode);

            XmlNode pageIdNode = doc.CreateElement("pageId");
            pageIdNode.InnerText = CurrentPage.PageGuid.ToString();
            outerNode.AppendChild(pageIdNode);

            XmlNode titleNode = doc.CreateElement("title");
            titleNode.InnerText = CurrentPage.PageName;
            outerNode.AppendChild(titleNode);

            XmlNode updatedNode = doc.CreateElement("updated");
            updatedNode.InnerText = editions.Count == 0 ? "1970-01-01" : editions.Max(pd => pd.StartPublish).ToString("o");
            outerNode.AppendChild(updatedNode);

            XmlNode authorNameNode = doc.CreateElement("authorname");
            authorNameNode.InnerText = CurrentPage.CreatedBy;
            outerNode.AppendChild(authorNameNode);

            XmlNode hrefNode = doc.CreateElement("href");
            //hrefNode.InnerText = Server.HtmlEncode(CurrentPage.LinkURL);
            //hrefNode.InnerText = GetExternalLink(CurrentPage);
            hrefNode.InnerText = UriSupport.AbsoluteUrlBySettings(CurrentPage.LinkURL);
            outerNode.AppendChild(hrefNode);

            foreach (PageData edition in editions)
            {
                CreateEditionList(doc, edition, outerNode);
            }

            ApplyTransform(doc.InnerXml); ;
        }

        private void ApplyTransform(string feedXml)
        {
            // Transform XML
            XslCompiledTransform transformer = new XslCompiledTransform();
            StringWriter stringWriter = new StringWriter();

            transformer.Load(Server.MapPath("//XSLT//EditionContainer.xslt"));

            using (XmlReader xmlReader = XmlReader.Create(new StringReader(feedXml)))
            {
                transformer.Transform(xmlReader, null, stringWriter);
            }

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(stringWriter.ToString());
            xmlDocument.Save(Response.OutputStream);
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
            editionTermsIssuedNode.InnerText = ((DateTime) edition["Issued"]).ToString("yyyy-MM-dd");
            entryNode.AppendChild(editionTermsIssuedNode);

            XmlNode editionSummaryNode = doc.CreateElement("summary");
            editionSummaryNode.InnerText = edition["Summary"].ToString();
            entryNode.AppendChild(editionSummaryNode);

            XmlNode coverImageHref = doc.CreateElement("imagehref");
            coverImageHref.InnerText = Server.HtmlEncode(UriSupport.AbsoluteUrlBySettings(edition["Image"].ToString()));
            entryNode.AppendChild(coverImageHref);

            XmlNode editionContentHref = doc.CreateElement("editionContent");
            //editionContentHref.InnerText = Server.HtmlEncode(edition.LinkURL);
            //editionContentHref.InnerText = GetExternalLink(edition);
            editionContentHref.InnerText = UriSupport.AbsoluteUrlBySettings(edition.LinkURL);
            entryNode.AppendChild(editionContentHref);

            XmlNode alternateHref = doc.CreateElement("alternatehref");
            //alternateHref.InnerText = Server.HtmlEncode(edition.LinkURL);
            //alternateHref.InnerText = GetExternalLink(edition);
            alternateHref.InnerText = UriSupport.AbsoluteUrlBySettings(edition.LinkURL);
            entryNode.AppendChild(alternateHref);
        }

        private static string GetExternalLink(PageData p)
        {
            UrlBuilder pageURLBuilder = new UrlBuilder(p.LinkURL);

            EPiServer.Global.UrlRewriteProvider.ConvertToExternal(pageURLBuilder, p.PageLink, UTF8Encoding.UTF8);

            string pageURL = pageURLBuilder.ToString();

            UriBuilder uriBuilder = new UriBuilder(EPiServer.Configuration.Settings.Instance.SiteUrl);

            uriBuilder.Path = pageURL;

            return uriBuilder.Uri.AbsoluteUri;
        }

        //private void CreateAtomFeed(PageDataCollection editions)
        //{
        //    XmlDocument doc = new XmlDocument();

        //    XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        //    doc.AppendChild(declaration);

        //    XmlNode outerNode = doc.CreateElement("feed");

        //    XmlAttribute uriInfo = doc.CreateAttribute("xmlns");
        //    uriInfo.Value = "http://www.w3.org/2005/Atom";
        //    outerNode.Attributes.Append(uriInfo);

        //    XmlAttribute termsInfo = doc.CreateAttribute("xmlns:dcterms");
        //    termsInfo.Value = "http://purl.org/dc/terms/";
        //    outerNode.Attributes.Append(termsInfo);

        //    XmlAttribute specInfo = doc.CreateAttribute("xmlns:opds");
        //    specInfo.Value = "http://opds-spec.org/2010/catalog";
        //    outerNode.Attributes.Append(specInfo);

        //    XmlAttribute appInfo = doc.CreateAttribute("xmlns:app");
        //    appInfo.Value = "http://www.w3.org/2007/app";
        //    outerNode.Attributes.Append(appInfo);

        //    doc.AppendChild(outerNode);

        //    XmlNode idNode = doc.CreateElement("id");
        //    idNode.InnerText = CurrentPage.PageGuid.ToString();
        //    outerNode.AppendChild(idNode);

        //    XmlNode linkNode = doc.CreateElement("link");
        //    XmlAttribute rel = doc.CreateAttribute("rel");
        //    rel.Value = "self";
        //    linkNode.Attributes.Append(rel);

        //    XmlAttribute type = doc.CreateAttribute("type");
        //    type.Value = "application/atom+xml;profile=opds-catalog;kind=acquisition";
        //    linkNode.Attributes.Append(type);

        //    XmlAttribute href = doc.CreateAttribute("href");
        //    href.Value = Server.HtmlEncode(UriSupport.AbsoluteUrlBySettings(CurrentPage.LinkURL));
        //    linkNode.Attributes.Append(href);

        //    outerNode.AppendChild(linkNode);

        //    XmlNode authorNode = doc.CreateElement("author");
        //    XmlNode nameNode = doc.CreateElement("name");
        //    nameNode.InnerText = CurrentPage.CreatedBy;
        //    authorNode.AppendChild(nameNode);

        //    outerNode.AppendChild(authorNode);

        //    XmlNode titleNode = doc.CreateElement("title");
        //    titleNode.InnerText = CurrentPage.PageName;
        //    outerNode.AppendChild(titleNode);

        //    XmlNode updatedNode = doc.CreateElement("updated");
        //    updatedNode.InnerText = editions.Count == 0 ? "1970-01-01" : editions.Max(pd => pd.StartPublish).ToString("o");
        //    outerNode.AppendChild(updatedNode);

        //    foreach (PageData edition in editions)
        //    {
        //        CreateEdition(doc, edition, outerNode);
        //    }

        //    doc.Save(Response.OutputStream);
        //}

        //private void CreateEdition(XmlDocument doc, PageData edition, XmlNode outerNode)
        //{
        //    XmlNode entryNode = doc.CreateNode(XmlNodeType.Element, "entry", null);

        //    XmlNode editionTitleNode = doc.CreateElement("title");
        //    editionTitleNode.InnerText = edition.PageName;
        //    entryNode.AppendChild(editionTitleNode);

        //    XmlNode editionIdNode = doc.CreateElement("id");
        //    editionIdNode.InnerText = edition.PageGuid.ToString();
        //    entryNode.AppendChild(editionIdNode);

        //    XmlNode editionUpdatedNode = doc.CreateElement("updated");
        //    editionUpdatedNode.InnerText = edition.StartPublish.ToString("o");
        //    entryNode.AppendChild(editionUpdatedNode);

        //    XmlNode editionTermsIssuedNode = doc.CreateElement("dcterms:issued");
        //    editionTermsIssuedNode.InnerText = ((DateTime)edition["Issued"]).ToString("yyyy-MM-dd");
        //    entryNode.AppendChild(editionTermsIssuedNode);

        //    XmlNode editionAuthorNode = doc.CreateElement("author");
        //    XmlNode editionNameNode = doc.CreateElement("name");
        //    editionNameNode.InnerText = edition.CreatedBy;
        //    editionAuthorNode.AppendChild(editionNameNode);
        //    entryNode.AppendChild(editionAuthorNode);

        //    XmlNode editionSummaryNode = doc.CreateElement("summary");
        //    entryNode.AppendChild(editionSummaryNode);

        //    XmlNode coverImageLinkNode = doc.CreateElement("link");
        //    XmlAttribute coverImageRel = doc.CreateAttribute("rel");
        //    coverImageRel.Value = "http://opds-spec.org/image";
        //    coverImageLinkNode.Attributes.Append(coverImageRel);

        //    XmlAttribute coverImageType = doc.CreateAttribute("type");
        //    coverImageType.Value = "image/jpg";
        //    coverImageLinkNode.Attributes.Append(coverImageType);

        //    XmlAttribute coverImageHref = doc.CreateAttribute("href");

        //    coverImageHref.Value = Server.HtmlEncode(UriSupport.AbsoluteUrlBySettings(edition["Image"].ToString()));
        //    coverImageLinkNode.Attributes.Append(coverImageHref);

        //    entryNode.AppendChild(coverImageLinkNode);

        //    XmlNode editionContentLinkNode = doc.CreateElement("link");
        //    XmlAttribute editionContentRel = doc.CreateAttribute("rel");
        //    editionContentRel.Value = "http://opds-spec.org/acquisition";
        //    editionContentLinkNode.Attributes.Append(editionContentRel);

        //    XmlAttribute editionContentType = doc.CreateAttribute("type");
        //    editionContentType.Value = "application/atom+xml";
        //    editionContentLinkNode.Attributes.Append(editionContentType);

        //    XmlAttribute editionContentHref = doc.CreateAttribute("href");
        //    editionContentHref.Value = Server.HtmlEncode(edition.LinkURL);
        //    editionContentLinkNode.Attributes.Append(editionContentHref);

        //    entryNode.AppendChild(editionContentLinkNode);

        //    XmlNode alternateLinkNode = doc.CreateElement("link");
        //    XmlAttribute alternateRel = doc.CreateAttribute("rel");
        //    alternateRel.Value = "alternate";
        //    alternateLinkNode.Attributes.Append(alternateRel);

        //    XmlAttribute alternateType = doc.CreateAttribute("type");
        //    alternateType.Value = "application/atom+xml";
        //    alternateLinkNode.Attributes.Append(alternateType);

        //    XmlAttribute alternateHref = doc.CreateAttribute("href");
        //    alternateHref.Value = Server.HtmlEncode(edition.LinkURL);
        //    alternateLinkNode.Attributes.Append(alternateHref);

        //    entryNode.AppendChild(alternateLinkNode);

        //    outerNode.AppendChild(entryNode);
        //}
    }
}