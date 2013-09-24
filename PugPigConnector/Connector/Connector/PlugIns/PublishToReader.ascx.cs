using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI.WebControls;
using EPiServer.Personalization;
using EPiServer.PlugIn;
using EPiServer.Security;
using EPiServer.Util.PlugIns;
using System.Web.UI;
using System.Text;
using System.IO;
using EPiServer;
using EPiServer.DataAnnotations;
using EPiServer.DataAbstraction.PageTypeAvailability;
using Connector.Models.Pages;
using EPiServer.Core;
using EPiServer.UI.Edit;
using Connector;
using System.Web;
using System.Text.RegularExpressions;

namespace Connector.PlugIns
{
    [GuiPlugIn(DisplayName = "Publish To Reader", 
               Description = "",              
               Area = PlugInArea.EditPanel,
               Url = "~/PlugIns/PublishToReader.ascx")]
    public partial class PublishToReader : UserControlBase, ICustomPlugInLoader
    {
        #region ICustomPlugInLoader

        public PlugInDescriptor[] List()
        {
            // hook LoadComplete-event on EditPanel page
            var editPanel = HttpContext.Current.Handler as EditPanel;            

            if (null != editPanel)
            {
                if (Common.IsEditionPage(editPanel.CurrentPage))
                {
                    // Display plugin only if current page is an edition page
                    PlugInDescriptor descriptor = PlugInDescriptor.Load(GetType());

                    return new PlugInDescriptor[] { descriptor };
                }
            }

            // Hide plugin if current page is NOT an edition page
            return new PlugInDescriptor[0];
        }

        #endregion

        protected void publishButton_Click(object sender, EventArgs e)
        {
            try
            {
                Publish();

                publishLabel.Text = "This edition has been successfully published!";
            }
            catch (Exception ex)
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
            IPublisher publisher = new Publisher();

            publisher.PublishEdition();
        }
    }
}