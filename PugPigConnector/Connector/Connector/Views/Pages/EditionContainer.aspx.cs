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
using Connector.Models.Pages;

namespace Connector.Views.Pages
{
    [TemplateDescriptor(Path = "~/Views/Pages/EditionContainer.aspx")]
    public partial class EditionContainer : EPiServer.TemplatePage<EditionContainerPage>
    {
    }
}