using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Editor.TinyMCE;

namespace PugPigConnector
{
    //[TinyMCEPluginNonVisual(AlwaysEnabled = true,  EditorInitConfigurationOptions = "{ extended_valid_elements: 'header[h1]', forced_root_block : false, schema: 'html5', paste_auto_cleanup_on_paste : false, paste_remove_styles : false, paste_strip_class_attributes: false, paste_remove_styles_if_webkit: false, paste_strip_class_attributes: false }")]
    [TinyMCEPluginNonVisual(AlwaysEnabled = true, EditorInitConfigurationOptions = "{ extended_valid_elements: 'section[class], header, article, figure[class]', forced_root_block : false }")]
    public class TinyMceExtendedValidElements
    {
    }
}