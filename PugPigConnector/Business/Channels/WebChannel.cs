﻿using System.Web;
using EPiServer.Web;

namespace PugPigConnector.Business.Channels
{
    /// <summary>
    /// Defines the 'Web' content channel
    /// </summary>
    public class WebChannel : DisplayChannel
    {
        public override string ChannelName
        {
            get
            {
                return LocalizationService.GetString("/channels/web");
            }
        }

        public override bool IsActive(HttpContextBase context)
        {
            return !context.Request.Browser.IsMobileDevice;
        }

    }
}