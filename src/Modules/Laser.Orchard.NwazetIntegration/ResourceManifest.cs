﻿using Orchard.UI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laser.Orchard.NwazetIntegration {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();

            manifest
                .DefineScript("NwazetIntegration.Addresses")
                .SetUrl("ship.min.js", "ship.js")
                .SetDependencies("jQuery");

            manifest
                .DefineScript("NwazetIntegration.AddressConfiguration")
                .SetUrl("address-configuration.min.js", "address-configuration.js")
                .SetDependencies("jQuery");

            manifest
                .DefineStyle("NwazetIntegration.Admin")
                .SetUrl("admin-style.min.css", "admin-style.css");
        }
    }
}