using OrchardCore.ResourceManagement;

namespace Lucavice.TailwindTheme
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(IResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest
                .DefineStyle("lucavice-css")
                .SetUrl("~/Lucavice.TailwindTheme/assets/dist/css/lucavice.css", "~/Lucavice.TailwindTheme/assets/dist/css/lucavice.css");

            manifest
                .DefineStyle("highlight")
                .SetCdn("https://cdnjs.cloudflare.com/ajax/libs/highlight.js/10.5.0/styles/darcula.min.css"); 

            manifest
                .DefineStyle("merriweather-font")
                .SetCdn("https://fonts.googleapis.com/css2?family=Merriweather:wght@300&display=swap");
        }
    }
}
