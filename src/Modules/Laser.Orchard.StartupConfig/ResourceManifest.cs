﻿using Orchard;
using Orchard.Environment.Features;
using Orchard.UI.Resources;
using System.Linq;
namespace Laser.Orchard.StartupConfig {
    public class ResourceManifest : IResourceManifestProvider {
        private readonly IFeatureManager _featureManager;
        public ResourceManifest(IFeatureManager featureManager) {
            _featureManager = featureManager;
        }
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            //manifest.DefineStyle("FontAwesome").SetUrl("font-awesome/css/font-awesome.min.css");
            manifest.DefineStyle("FontAwesome430").SetUrl("//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css");
            manifest.DefineStyle("FontAwesome430.ie7").SetUrl("//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome-ie7.min.css");

            //maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css

            // color picker
            manifest.DefineScript("spectrum").SetUrl("spectrum.js").SetDependencies("jQuery");

            // tabulator (currently v3.4.4)
            manifest.DefineScript("tabulator")
                .SetUrl("tabulator\\tabulator.min.js", "tabulator\\tabulator.js")
                .SetDependencies("jQueryUI");
            manifest.DefineStyle("tabulator")
                .SetUrl("tabulator\\tabulator.min.css", "tabulator\\tabulator.css");
            manifest.DefineStyle("tabulatorBootstrap")
                .SetUrl("tabulator\\bootstrap\\tabulator_bootstrap.min.css", "tabulator\\bootstrap\\tabulator_bootstrap.css")
                .SetDependencies("Bootstrap");

            // content picker creation
            manifest.DefineScript("ContentPickerCreation")
                .SetUrl("contentPickerCreation\\ContentPickerCreation.js", "contentPickerCreation\\ContentPickerCreation.js")
                .SetDependencies("jQueryUI");
            manifest.DefineStyle("ContentPickerCreation")
                .SetUrl("contentPickerCreation\\ContentPickerCreation.css", "contentPickerCreation\\ContentPickerCreation.css");
            manifest.DefineScript("ContentPickerThemeHiding")
                .SetUrl("contentPickerCreation\\ContentPickerThemeHiding.js", "contentPickerCreation\\ContentPickerThemeHiding.js")
                .SetDependencies("jQueryUI");
            manifest.DefineStyle("ContentPickerThemeHiding")
                .SetUrl("contentPickerCreation\\ContentPickerThemeHiding.css", "contentPickerCreation\\ContentPickerThemeHiding.css");

            // tinymce enhancement
            if(_featureManager.GetEnabledFeatures().Any(x => x.Id == "Laser.Orchard.StartupConfig.TinyMceEnhancement")) {
                // replace standard orchard init with custom init
                manifest.DefineScript("OrchardTinyMce").SetUrl("laser-tinymce.js").SetDependencies("TinyMce");
            }
        }
    }
}