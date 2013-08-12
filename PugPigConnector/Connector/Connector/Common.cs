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

            return GetSiteRoot() + pageURLBuilder.Path;
        }

        public static bool IsEditionPage(PageData pageData)
        {   
            if (_pageTypeName == pageData.PageTypeName)
            {
                return true;
            }

            return false;
        }

        public static string GetConfigSettingValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A virtual path for the root publishing folder</returns>
        public static string GetRootPublishLocationPath()
        {
            string host = string.Empty;
            string publishLocation = ConfigurationManager.AppSettings["RootPublishLocation"];

            if (Directory.Exists(HttpContext.Current.Server.MapPath("~") + "\\" + publishLocation))
            {
                host = string.Format("{0}/{1}", GetSiteRoot(), publishLocation);;
            }            

            return host;
        }

        private static string GetSiteRoot()
        {
            string host = string.Empty;
            var url = HttpContext.Current.Request.Url;
            var port = url.Port != DEFAULT_PORT ? (":" + url.Port) : String.Empty;

            host = string.Format("{0}://{1}{2}", url.Scheme, url.Host, port);    

            return host;
        }

        //public static string HtmlAppRelativeUrlsToAbsoluteUrls(this string html)
        //{
        //    if (string.IsNullOrEmpty(html))
        //        return html;

        //    const string htmlPattern = "(?<attrib>\\shref|\\ssrc|\\sbackground)\\s*?=\\s*?"
        //                              + "(?<delim1>[\"'\\\\]{0,2})(?!#|http|ftp|mailto|javascript)"
        //                              + "/(?<url>[^\"'>\\\\]+)(?<delim2>[\"'\\\\]{0,2})";

        //    var htmlRegex = new Regex(htmlPattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
        //    html = htmlRegex.Replace(html, m => htmlRegex.Replace(m.Value, "${attrib}=${delim1}" + ("~/" + m.Groups["url"].Value).ToAbsoluteUrl() + "${delim2}"));

        //    const string cssPattern = "@import\\s+?(url)*['\"(]{1,2}"
        //                              + "(?!http)\\s*/(?<url>[^\"')]+)['\")]{1,2}";

        //    var cssRegex = new Regex(cssPattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
        //    html = cssRegex.Replace(html, m => cssRegex.Replace(m.Value, "@import url(" + ("~/" + m.Groups["url"].Value).ToAbsoluteUrl() + ")"));

        //    return html;
        //}

        //public static string ToAbsoluteUrl(this string relativeUrl)
        //{
        //    if (string.IsNullOrEmpty(relativeUrl))
        //        return relativeUrl;

        //    if (HttpContext.Current == null)
        //        return relativeUrl;

        //    if (relativeUrl.StartsWith("/"))
        //        relativeUrl = relativeUrl.Insert(0, "~");
        //    if (!relativeUrl.StartsWith("~/"))
        //        relativeUrl = relativeUrl.Insert(0, "~/");

        //    var url = HttpContext.Current.Request.Url;
        //    var port = url.Port != DEFAULT_PORT ? (":" + url.Port) : String.Empty;

        //    return string.Format("{0}://{1}{2}{3}", url.Scheme, url.Host, port, VirtualPathUtility.ToAbsolute(relativeUrl));
        //}
    }
}