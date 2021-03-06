﻿using Laser.Orchard.MailCommunication.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;
using Orchard.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laser.Orchard.MailCommunication.Handlers
{
    [OrchardFeature("Laser.Orchard.MailerUtility")]
    public class MailerSiteSettingsHandler : ContentHandler
    {
        public MailerSiteSettingsHandler()
        {
            T = NullLocalizer.Instance;

            Filters.Add(new ActivatingFilter<MailerSiteSettingsPart>("Site"));
            OnInitializing<MailerSiteSettingsPart>((context, part) =>
            {
                part.MailPriority = MailPriorityValues.Low;
                part.RecipientsPerJsonFile = 1000;
                part.TokenValidity = 2;
            });
        }

        public Localizer T { get; set; }

        protected override void GetItemMetadata(GetContentItemMetadataContext context) {
            if (context.ContentItem.ContentType != "Site")
                return;
            base.GetItemMetadata(context);
            context.Metadata.EditorGroupInfo.Add(new GroupInfo(T("Mailer")));
        }
    }
}