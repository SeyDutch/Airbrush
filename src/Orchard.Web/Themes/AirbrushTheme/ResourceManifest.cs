using Orchard.UI.Resources;

namespace AirbrushTheme
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();
            manifest.DefineStyle("Site").SetUrl("Site.min.css");
            manifest.DefineStyle("CarouselWidget").SetUrl("Carousel.Widget.css");
            manifest.DefineScript("CarouselWidget").SetUrl("carousel_widget_init.js").SetDependencies("jQuery", "Bootstrap");
            //manifest.DefineScript("BackgroundChange").SetUrl("bgchange.js").SetDependencies("jQuery");
        }
    }
}
