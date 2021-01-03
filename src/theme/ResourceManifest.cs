using OrchardCore.ResourceManagement;

namespace LucaviceTailwindTheme
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(IResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest
                .DefineScript("lucavice-css")
                .SetUrl("~/lucavice-tailwind-theme/assets/dist/css/lucavice.css", "~/lucavice-tailwind-theme/assets/dist/css/lucavice.css")
                .SetVersion("1.0");

        }
    }
}
