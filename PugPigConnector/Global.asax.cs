﻿using System;

namespace PugPigConnector
{
    public class Global : EPiServer.Global
    {
        protected void Application_Start()
        {
        }

        /// <summary>
        /// Group names for content types and properties
        /// </summary>
        public static class GroupNames
        {
            public const string Contact = "Contact";
            public const string Default = "Default";
            public const string MetaData = "Metadata";
            public const string News = "News";
            public const string Products = "Products";
            public const string SiteSettings = "SiteSettings";
            public const string Specialized = "Specialized";
        }

        /// <summary>
        /// Tags to use for the main widths used in the Bootstrap HTML framework
        /// </summary>
        public static class ContentAreaTags
        {
            public const string FullWidth = "span12";
            public const string TwoThirdsWidth = "span8";
            public const string HalfWidth = "span6";
            public const string OneThirdWidth = "span4";
        }

        /// <summary>
        /// Main widths used in the Bootstrap HTML framework
        /// </summary>
        public static class ContentAreaWidths
        {
            public const int FullWidth = 12;
            public const int TwoThirdsWidth = 8;
            public const int HalfWidth = 6;
            public const int OneThirdWidth = 4;
        }

        /// <summary>
        /// Names used for UIHint attributes to map specific rendering controls to page properties
        /// </summary>
        public static class SiteUIHints
        {
            public const string Contact = "contact";
            public const string Strings = "StringList";
        }

        /// <summary>
        /// Virtual path to folder with static graphics, such as "~/Static/gfx/"
        /// </summary>
        public const string StaticGraphicsFolderPath = "~/Static/gfx/";
    }
}