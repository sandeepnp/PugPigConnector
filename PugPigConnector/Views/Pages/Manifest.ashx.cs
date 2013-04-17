using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using EPiServer.Core;

namespace PugPigConnector.Views.Pages
{
    /// <summary>
    /// Summary description for Manifest
    /// </summary>
    public class Manifest : IHttpHandler
    {

        /// <summary>
        /// Defines the file types that should be included in the Manifest file when it is
        /// created.
        /// All other file types are excluded.
        /// </summary>
        const string FileTypes =
                     "*.aspx;*.htm;*.js;*.css;*.gif;*.png;*.jp*g;*.ico;*.txt;*.tif";
        /// <summary>
        /// Determines the version number contained in the Manifest.  This could also be set
        /// to something
        /// dynamic such as the date, depending on your requirements.
        /// </summary>
        const string ManifestVersion = "v1";
        /// <summary>
        /// A list of folder names in the root directory to include in the Manifest file.
        /// </summary>
        HashSet<string> includeFolders = new HashSet<string> { "css", "elements", "inc" };
        /// <summary>
        /// A list of file names in any folder to exclude from the Manifest file.
        /// </summary>
        HashSet<string> excludeFiles = new HashSet<string> { "Manifest.txt" };

        /// <summary>
        /// This property determines if the application is in DEBUG or RELEASE mode.
        /// </summary>
        public static bool IsDebug
        {
//            get
//            {
//                bool debug = false;
//                try
//                {
//#if DEBUG
//                    debug = true;
//#endif
//                }
//                catch
//                {
//                    debug = false;
//                }
//                return debug;
//            }

            get { return true; }

        }

        public bool IsReusable
        {
            get { return true; }
        }

        //public void ProcessRequest(HttpContext context)
        //{
        //    HttpRequest request = context.Request;
        //    HttpResponse response = context.Response;
        //    response.ContentType = "text/cache-manifest";
        //    response.Write("CACHE MANIFEST\n");

        //    //if (TestWebSvc.Properties.Settings.Default.ForceUpdate)
        //    //{
        //        response.Write(string.Format("# This file was generated at {0} {1}\n", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()));
        //    //}

        //    response.Write("CACHE:\n");
        //    string[] filePatterns = FileTypes.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

        //    List<string> cacheFileList = new List<string>();

        //    foreach (string filePattern in filePatterns)
        //    {
        //        cacheFileList.AddRange(Directory.GetFiles(request.PhysicalApplicationPath, filePattern, SearchOption.AllDirectories));
        //    }

        //    cacheFileList.Sort();

        //    foreach (string filePath in cacheFileList)
        //    {
        //        response.Write(String.Format("{0}/{1}\n", request.ApplicationPath, filePath.Replace(request.PhysicalApplicationPath, "").Replace(@"\", "/")));
        //    }

        //    response.Flush();
        //    response.Close();
        //}

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            StringBuilder SB = new StringBuilder();

            response.ContentType = "text/cache-manifest";
            SB.AppendLine("CACHE MANIFEST");

            SB.AppendLine("# " + ManifestVersion);
            SB.AppendLine("# Root Path: " + request.PhysicalApplicationPath);
            SB.AppendLine(string.Format("# This file was generated at {0} {1}\n", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()));

            SB.AppendLine();


            SB.AppendLine("CACHE:");
            SB.AppendLine();

            SB.AppendLine("# Site Content");
            string[] filePatterns = FileTypes.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            List<string> cacheFileList = new List<string>();

            foreach (string filePattern in filePatterns)
            {
                cacheFileList.AddRange(Directory.GetFiles(request.PhysicalApplicationPath, filePattern, SearchOption.AllDirectories));
            }

            cacheFileList.Sort();

            foreach (string filePath in cacheFileList)
            {
                response.Write(String.Format("{0}/{1}\n", request.ApplicationPath, filePath.Replace(request.PhysicalApplicationPath, "").Replace(@"\", "/")));
            }
            
            SB.AppendLine();

            //Create an updated manifest file
            using (StreamWriter writer = new StreamWriter(request.PhysicalApplicationPath + "Manifest.txt"))
            {
                writer.Write(SB.ToString());
            }

            //Create a response from the contents of the Manifest.txt file.
            //This file was dynamically created by this process, if in DEBUG mode.
            context.Response.ContentType = "text/cache-manifest";
            context.Response.WriteFile(context.Server.MapPath("Manifest.txt"));
        }

    }
}