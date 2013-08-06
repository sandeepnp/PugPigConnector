using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using EPiServer;
using EPiServer.Core;

namespace Connector
{
    public static class Common
    {
        private const string _pageTypeName = "EditionPage";

        private const int DEFAULT_PORT = 80;

        public static string GetFriendlyURL(PageData pageData)
        {
            UrlBuilder pageURLBuilder = new UrlBuilder(pageData.LinkURL);
            EPiServer.Global.UrlRewriteProvider.ConvertToExternal(pageURLBuilder, pageData.PageLink, UTF8Encoding.UTF8);

            string friendlyURL = string.Empty;

            if (ConfigurationManager.AppSettings["SiteRoot"] != null)
            {
                friendlyURL = ConfigurationManager.AppSettings["SiteRoot"] + pageURLBuilder.Path;
                friendlyURL = friendlyURL.Substring(0, (friendlyURL.Length - 1));
            }

            return friendlyURL;
        }

        public static bool IsEditionPage(PageData pageData)
        {   
            if (_pageTypeName == pageData.PageTypeName)
            {
                return true;
            }

            return false;
        }

        public static void Publish()
        {
            // Publish Edition List feed
            //PublishEditionListFeed();

            // Publish Edition feed
            PublishEditionFeed();          
            
        }

        //private static void PublishEditionListFeed()
        //{

        //}

        private static void PublishEditionFeed()
        {
           var pageBase = HttpContext.Current.Handler as PageBase;

            if (pageBase != null)
            {
                PageData page = pageBase.CurrentPage;

                // Ensure there exists a location to publish the edition
                string publishLocation = GetEditionFolder(page.Name);

                if (!string.IsNullOrEmpty(publishLocation))
                {
                    GenerateEditionFeed(publishLocation);
                    PublishEditionPages(page, publishLocation);
                    //PublishManifest();
                }
             }
        }

        private static void PublishEditionPages(PageData page, string publishLocation)
        {
            PageDataCollection editionPages = DataFactory.Instance.GetChildren(page.PageLink);

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

        private static void GenerateEditionFeed(string publishLocation)
        {
            var publisher = new Publisher();

            publisher.GenerateEditionFeed(publishLocation);
            publisher.GenerateManifest(publishLocation);
            publisher.GenerateEditionListFeed();
        }

        
        /// <summary>
        /// Checks if edition folder exists, creates it if it does not.
        /// </summary>
        /// <param name="folder"></param>
        /// <returns>Returns a valid physical path like C:\EPiServer\Sites\Connector\Editions</returns>
        public static string GetEditionFolder(string folder)
        {
            string folderPath = string.Empty;
            string publishLocation = HttpContext.Current.Server.MapPath("~") + 
                "\\" + ConfigurationManager.AppSettings["RootPublishLocation"];

            if (!string.IsNullOrEmpty(publishLocation))
            {
                folderPath = publishLocation + "\\" + folder;

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }                
            }

            return folderPath;
        }

        private static string GetPageContent(string url)
        {
            string result = "";

            System.Net.WebRequest objRequest = System.Net.HttpWebRequest.Create(url.Trim());

            using (StreamReader sr = new StreamReader(objRequest.GetResponse().GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();

                return HtmlAppRelativeUrlsToAbsoluteUrls(result);
            }

            return result;
        }

        private static string HtmlAppRelativeUrlsToAbsoluteUrls(this string html)
        {
            if (string.IsNullOrEmpty(html))
                return html;

            const string htmlPattern = "(?<attrib>\\shref|\\ssrc|\\sbackground)\\s*?=\\s*?"
                                      + "(?<delim1>[\"'\\\\]{0,2})(?!#|http|ftp|mailto|javascript)"
                                      + "/(?<url>[^\"'>\\\\]+)(?<delim2>[\"'\\\\]{0,2})";

            var htmlRegex = new Regex(htmlPattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            html = htmlRegex.Replace(html, m => htmlRegex.Replace(m.Value, "${attrib}=${delim1}" + ("~/" + m.Groups["url"].Value).ToAbsoluteUrl() + "${delim2}"));

            const string cssPattern = "@import\\s+?(url)*['\"(]{1,2}"
                                      + "(?!http)\\s*/(?<url>[^\"')]+)['\")]{1,2}";

            var cssRegex = new Regex(cssPattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            html = cssRegex.Replace(html, m => cssRegex.Replace(m.Value, "@import url(" + ("~/" + m.Groups["url"].Value).ToAbsoluteUrl() + ")"));

            return html;
        }

        private static string ToAbsoluteUrl(this string relativeUrl)
        {
            if (string.IsNullOrEmpty(relativeUrl))
                return relativeUrl;

            if (HttpContext.Current == null)
                return relativeUrl;

            if (relativeUrl.StartsWith("/"))
                relativeUrl = relativeUrl.Insert(0, "~");
            if (!relativeUrl.StartsWith("~/"))
                relativeUrl = relativeUrl.Insert(0, "~/");

            var url = HttpContext.Current.Request.Url;
            var port = url.Port != 80 ? (":" + url.Port) : String.Empty;

            return string.Format("{0}://{1}{2}{3}", url.Scheme, url.Host, port, VirtualPathUtility.ToAbsolute(relativeUrl));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A virtual path for the root publishing folder</returns>
        public static string GetRootPublishLocationPath()
        {
            string host = string.Empty;
            var url = HttpContext.Current.Request.Url;
            var port = url.Port != DEFAULT_PORT ? (":" + url.Port) : String.Empty;            

            string publishLocation = ConfigurationManager.AppSettings["RootPublishLocation"];

            if (Directory.Exists(HttpContext.Current.Server.MapPath("~") + "\\" + publishLocation))
            {
                host = string.Format("{0}://{1}{2}/{3}", url.Scheme, url.Host, port, publishLocation);;
            }            

            return host;
        }
    }
}