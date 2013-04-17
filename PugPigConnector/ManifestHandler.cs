using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using EPiServer;
using EPiServer.Core;

namespace PugPigConnector
{
    public class ManifestHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        /// <summary>
        /// Defines the file types that should be included in the Manifest file when it is
        /// created.
        /// All other file types are excluded.
        /// </summary>
        const string FileTypes =
                     "*.js;*.css;*.gif;*.png;*.jp*g;*.ico";
        /// <summary>
        /// Determines the version number contained in the Manifest.  This could also be set
        /// to something
        /// dynamic such as the date, depending on your requirements.
        /// </summary>
        const string ManifestVersion = "v1";

        ///// <summary>
        ///// A list of folder names in the root directory to include in the Manifest file.
        ///// </summary>
        //HashSet<string> includeFolders = new HashSet<string> { "css", "elements", "inc" };
        ///// <summary>
        ///// A list of file names in any folder to exclude from the Manifest file.
        ///// </summary>
        //HashSet<string> excludeFiles = new HashSet<string> { "Manifest.txt" };

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            response.ContentType = "text/cache-manifest";

            response.Write("CACHE MANIFEST\n");
            response.Write(Environment.NewLine);
            response.Write(string.Format("# This file was generated at {0} {1}\n", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()));
            response.Write(Environment.NewLine);
            response.Write(Environment.NewLine);

            response.Write("CACHE:\n");
            response.Write(Environment.NewLine);
            response.Write(Environment.NewLine);
            response.Write("# Site Content");
            response.Write(Environment.NewLine);

            string[] filePatterns = FileTypes.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            List<string> cacheFileList = new List<string>();

            foreach (string filePattern in filePatterns)
            {
                cacheFileList.AddRange(Directory.GetFiles(request.PhysicalApplicationPath, filePattern, SearchOption.AllDirectories));
            }

            cacheFileList.Sort();

            foreach (string filePath in cacheFileList)
            {
                response.Write(UriSupport.AbsoluteUrlBySettings((String.Format("{0}/{1}", request.ApplicationPath, filePath.Replace(request.PhysicalApplicationPath, "")
                    .Replace(@"\", "/"))).Replace("//", "/")));

                response.Write(Environment.NewLine);
            }

            //Page properties.
            response.Write(Environment.NewLine);
            response.Write("# Page Content");
            response.Write(Environment.NewLine);

            string pageId = request["pageId"];

            PageData page = EPiServer.DataFactory.Instance.GetPage(PageReference.Parse(pageId));

            foreach (PropertyData property in from property in page.Property
                                              let type = property.Name
                                              where type == "Image"
                                              select property)
            {
                if (property.Value != null)
                {
                    response.Write(UriSupport.AbsoluteUrlBySettings(property.Value.ToString()));
                    response.Write(Environment.NewLine);
                }
            }

            response.Flush();
            response.Close();
        }

        //public void ProcessRequest(HttpContext context)
        //{
        //    HttpRequest request = context.Request;
        //    HttpResponse response = context.Response;

        //    string content = string.Empty;

        //    if (!string.IsNullOrEmpty(request["pageId"]))
        //    {
        //        content = GenerateManifest(EPiServer.DataFactory.Instance.GetPage(PageReference.Parse(request["pageId"])), request);
        //    }

        //    //Create a response for the manifest
        //    response.ContentType = "text/cache-manifest";
        //    response.Write(content);
        //    response.Flush();
        //}

        //private string GenerateManifest(PageData page, HttpRequest request)
        //{
        //    StringBuilder stringBuilder = new StringBuilder();

        //    stringBuilder.AppendLine("CACHE MANIFEST");
        //    stringBuilder.AppendLine();

        //    page = EPiServer.DataFactory.Instance.GetPage(PageReference.Parse(request["pageId"]));
        //    stringBuilder.AppendLine("# Page: " + page.PageName + " (" + page.PageTypeName + ")");

        //    stringBuilder.AppendLine(string.Format("# This file was generated at {0} {1}\n",
        //                                            DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()));
        //    stringBuilder.AppendLine();

        //    stringBuilder.AppendLine("CACHE:");
        //    stringBuilder.AppendLine();

        //    stringBuilder.AppendLine("# Site Content");
        //    stringBuilder.AppendLine();

        //    string[] filePatterns = FileTypes.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
        //    List<string> cacheFileList = new List<string>();

        //    foreach (string filePattern in filePatterns)
        //    {
        //        cacheFileList.AddRange(Directory.GetFiles(request.PhysicalApplicationPath, filePattern, SearchOption.AllDirectories));
        //    }

        //    cacheFileList.Sort();

        //    foreach (string filePath in cacheFileList)
        //    {
        //        stringBuilder.AppendLine((String.Format("{0}/{1}\n", request.ApplicationPath, filePath.Replace(request.PhysicalApplicationPath, "")
        //            .Replace(@"\", "/"))).Replace("//", "/"));
        //    }

        //    //Page properties.
        //    stringBuilder.AppendLine();
        //    stringBuilder.AppendLine("# Page Content");
        //    stringBuilder.AppendLine();

        //    foreach (PropertyData property in from property in page.Property
        //                                      let type = property.Name
        //                                      where type == "Image"
        //                                      select property)
        //    {
        //        if (property.Value != null)
        //            stringBuilder.AppendLine(property.Value.ToString());
        //    }

        //    //Add NETWORK section to the mainfest file.
        //    //stringBuilder.AppendLine();
        //    //stringBuilder.AppendLine("NETWORK:");
        //    //stringBuilder.AppendLine("http://*");
        //    //stringBuilder.AppendLine("https://*");

        //    return stringBuilder.ToString();
        //}

        //public void ProcessRequest(HttpContext context)
        //{
        //    HttpRequest request = context.Request;
        //    HttpResponse response = context.Response;
           
        //    string pageId = request["pageId"];

        //    if (!string.IsNullOrEmpty(pageId))
        //    {
        //        PageData page = EPiServer.DataFactory.Instance.GetPage(PageReference.Parse(pageId));
        //        StringBuilder stringBuilder = new StringBuilder();

        //        response.ContentType = "text/cache-manifest";
        //        stringBuilder.AppendLine("CACHE MANIFEST");
        //        stringBuilder.AppendLine(string.Format("# This file was generated at {0} {1}\n", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()));
        //        stringBuilder.AppendLine();


        //        stringBuilder.AppendLine("CACHE:");
        //        stringBuilder.AppendLine();

        //        stringBuilder.AppendLine("# Site Content");
        //        string[] filePatterns = FileTypes.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

        //        List<string> cacheFileList = new List<string>();

        //        foreach (string filePattern in filePatterns)
        //        {
        //            cacheFileList.AddRange(Directory.GetFiles(request.PhysicalApplicationPath, filePattern, SearchOption.AllDirectories));
        //        }

        //        cacheFileList.Sort();

        //        foreach (string filePath in cacheFileList)
        //        {
        //            stringBuilder.AppendLine((String.Format("{0}/{1}\n", 
        //                request.ApplicationPath, 
        //                filePath.Replace(request.PhysicalApplicationPath, "").Replace(@"\", "/")))
        //                .Replace("//", "/" ));
        //        }

        //        stringBuilder.AppendLine();

        //        //Page properties.
        //        stringBuilder.AppendLine();
        //        stringBuilder.AppendLine("# Page Content");
        //        stringBuilder.AppendLine();

        //        foreach (PropertyData property in from property in page.Property
        //                                          let type = property.Name
        //                                          where type == "Image"
        //                                          select property)
        //        {
        //            if (property.Value != null)
        //                stringBuilder.AppendLine(property.Value.ToString());
        //        }

        //        string fileName = "page" + pageId + ".manifest";

        //        //Create an updated manifest file
        //        using (StreamWriter writer = new StreamWriter(request.PhysicalApplicationPath + fileName))
        //        {
        //            writer.Write(stringBuilder.ToString());
        //        }

        //        //Create a response from the contents of the Manifest.txt file.
        //        //This file was dynamically created by this process, if in DEBUG mode.
        //        context.Response.ContentType = "text/cache-manifest";
        //        context.Response.WriteFile(context.Server.MapPath(fileName));
        //    }
        //}

        #endregion
    }
}
