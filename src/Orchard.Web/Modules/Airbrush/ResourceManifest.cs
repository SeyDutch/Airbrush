using Orchard.UI.Resources;

namespace Airbrush
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();
            manifest.DefineStyle("Slideshow").SetUrl("pgwslideshow.min.css");
            manifest.DefineScript("PgwSlideshow").SetUrl("pgwslideshow.min.js").SetDependencies("jQuery", "Bootstrap");
            manifest.DefineScript("Slideshow").SetUrl("slideshow_init.js").SetDependencies("PgwSlideshow");
        }
    }
}