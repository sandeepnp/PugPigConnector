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
using PugPigConnector.Models.Pages;

namespace PugPigConnector.Views.Pages
{
    [TemplateDescriptor(Path = "~/Views/Pages/RegularE.aspx")]
    public partial class RegularE : EPiServer.TemplatePage<RegularPageE>
    {
    }
}