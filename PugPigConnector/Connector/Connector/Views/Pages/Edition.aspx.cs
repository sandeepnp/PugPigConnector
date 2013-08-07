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
    [TemplateDescriptor(Path = "~/Views/Pages/Edition.aspx")]
    public partial class Edition : EPiServer.TemplatePage<EditionPage>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                publishLabel.Visible = false;
                publishButton.Enabled = true;
            }
        }

        protected void publishButton_Click(object sender, EventArgs e)
        {
            try
            {
                Publish();
                
                publishLabel.Text = "This edition has been successfully published!";
            }
            catch(Exception ex)
            {
                publishLabel.Text = "Sorry. This edition could not be published!";
            }
            finally
            {
                publishLabel.Visible = true;
                publishButton.Enabled = false; 
            }            
        }

        private void Publish()
        {
            var publisher = new Publisher();

            publisher.PublishEdition();
        }
    }
}