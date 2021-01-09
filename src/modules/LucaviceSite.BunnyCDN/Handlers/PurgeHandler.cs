using Lucavice.BunnyCDN.Options;
using Lucavice.BunnyCDN.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OrchardCore.ContentManagement.Handlers;
using System.Threading.Tasks;

namespace Lucavice.BunnyCDN.Handlers
{
    public class PurgeHandler : ContentHandlerBase
    {
        private PurgeService purgeService { get; set; }
        public PurgeHandler(PurgeService purgeService)
        {
            this.purgeService = purgeService;
        }

        public override async Task PublishedAsync(PublishContentContext context)
        {
            var autoroutePart = context.ContentItem.Content.AutoroutePart;
            if (autoroutePart == null) return;

            switch (context.ContentItem.ContentType)
            {
                case "BlogPost":
                    await purgeService.PurgeAsync(new string[] {
                        $"{autoroutePart.Path}", //The blog post path
                        "" //The homepage with the list of posts
                    });
                    break;
                default:
                    await purgeService.PurgeAsync(new string[] {
                        $"{autoroutePart.Path}" //for default case, the url of the content page is purged
                    });
                    break;
            }
      
        }
    }
}