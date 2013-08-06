using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using EPiServer;
using EPiServer.Core;

namespace Connector.Business
{
    public class Common
    {

        private const string _editionPageTypeName = "EditionPage";
        private const string _editionContainerPageTypeName = "EditionContainerPage";
        
        private static string[] _connectorPageTypeNames =
        {
          _editionPageTypeName,
          _editionContainerPageTypeName                
        };        
        
        public static string GetFriendlyURL(PageData p)
        {
            UrlBuilder pageURLBuilder = new UrlBuilder(p.LinkURL);
            EPiServer.Global.UrlRewriteProvider.ConvertToExternal(pageURLBuilder, p.PageLink, UTF8Encoding.UTF8);

            //string pageURL = pageURLBuilder.ToString();
            //UriBuilder uriBuilder = new UriBuilder(EPiServer.Configuration.Settings.Instance.SiteUrl);
            //uriBuilder.Path = pageURL;

            string friendlyURL = string.Empty;

            if (ConfigurationManager.AppSettings["SiteRoot"] != null)
            {
                friendlyURL = ConfigurationManager.AppSettings["SiteRoot"] + pageURLBuilder.Path;
                friendlyURL = friendlyURL.Substring(0, (friendlyURL.Length - 1));
            }

            return friendlyURL;
        }

        /// <summary>
        /// Is the page used to generate a connector feed?
        /// </summary>
        /// <param name="pageData">the page data</param>
        /// <returns>true if the page is used to generate a connector feed</returns>
        public static bool IsEditionPage(PageData page)
        {
            if (_connectorPageTypeNames.Contains<string>(page.PageTypeName))
            {
                return true;
            }

            return false;
        }
    }
}