using System.Web.Mvc;
using Orchard.Localization;
using Orchard;
using Orchard.UI.Notify;
using Orchard.ContentManagement;
using System.Linq;
using System.Collections.Generic;
using Airbrush.ViewModels;
using Orchard.Themes;

namespace Airbrush.Controllers {
    [Themed]
    public class GalleryController : Controller {
        public IOrchardServices Services { get; set; }
        private readonly INotifier _notifier;

        public GalleryController(IOrchardServices services, INotifier notifier) {
            Services = services;
            T = NullLocalizer.Instance;
            _notifier = notifier;
        }

        public Localizer T { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            var vm = new GalleryViewModel();
            var galleryItems = Services.ContentManager.Query("GalleryItem").List();
            if(galleryItems.Any())
            {
                var parts = galleryItems.Select(g => g.Parts.Single(x => x.Fields.Any(f => f.Name == "Imagepicker")));
                parts.ToList().ForEach(p => vm.GalleryItems.Add(new GalleryViewModel.GalleryItemViewModel(
                    ((dynamic)p.Fields.SingleOrDefault(x => x.Name == "Imagepicker")).MediaParts[0].MediaUrl)));
            }
            /*
            var test = galleryItems.Select(g => g.Parts.Single(x => x.Fields.Any(f => f.Name == "Imagepicker")))
                        .First().Fields.ToList();

            var test2 = (ContentField)((dynamic)galleryItems.Select(g => g.Parts.Single(x => x.Fields.Any(f => f.Name == "Imagepicker")))
                        .First().Fields.SingleOrDefault(x => x.Name == "Imagepicker"));
                        */
            return View(vm);
        }
    }
}
