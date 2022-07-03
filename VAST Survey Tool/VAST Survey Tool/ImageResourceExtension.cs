using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VAST_Survey_Tool.ImageResourceExtension
{
    [ContentProperty (nameof(Source))]
    internal class ImageResourceExtension : IMarkupExtension
    {
        
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(Source))
                return null;
            return ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
        }

    }
}
