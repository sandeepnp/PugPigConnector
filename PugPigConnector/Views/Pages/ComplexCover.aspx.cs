using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using PugPigConnector.Models.Pages;


namespace PugPigConnector.Views.Pages
{
    [TemplateDescriptor(Path = "~/Views/Pages/ComplexCover.aspx")]
    public partial class ComplexCover : TemplatePage<ComplexCoverPage>
    {
    }
}