using Umbraco.Core;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;
using Umbraco.Core.Services;

namespace ConsistentValidation.Umb
{
    public class UmbracoPublishHandler : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            ContentService.Published += ContentServicePublished;
        }

        private void ContentServicePublished(IPublishingStrategy sender, PublishEventArgs<IContent> args)
        {
            Configuration.MessageCache.ClearCache();
        }
    }
}