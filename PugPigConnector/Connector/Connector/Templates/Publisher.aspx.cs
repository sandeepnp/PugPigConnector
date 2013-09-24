using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;
using EPiServer.Web.WebControls;
using EPiServer.Shell.ViewComposition;
using EPiServer.UI;
using EPiServer.Web;
using System;

namespace Connector.Templates
{
    [IFrameComponent(Url = "~/Templates/Publisher.aspx", 
                     ReloadOnContextChange = true,
                     PlugInAreas = "/episerver/cms/assets",
                     Title = "Iframe test",
                     Categories = "cms",
                     MinHeight = 100,
                     MaxHeight = 500)]
    public partial class Publisher : ContentBaseWebForm
    {
        protected void publishButton_Click(object sender, EventArgs e)
        {
        }
    }
}