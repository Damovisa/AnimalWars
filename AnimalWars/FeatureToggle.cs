using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AnimalWars
{
    public static class FeatureToggle
    {
        public static bool ShowPreviewFeatures
        {
            get
            {
                var previewFeatures = ConfigurationManager.AppSettings["PreviewFeatures"];
                return (previewFeatures != null &&
                        previewFeatures.Equals("ON", StringComparison.InvariantCultureIgnoreCase));
            }
        }
    }
}