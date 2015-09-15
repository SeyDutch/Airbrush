using System.Web.Mvc;
using Orchard.Localization;
using Orchard;
using Orchard.UI.Notify;
using Orchard.ContentManagement;
using System.Linq;
using System.Collections.Generic;
using Airbrush.ViewModels;

namespace Airbrush.Controllers {
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
        { //MediaLibraryPickerField ff;
            var galleryItems = Services.ContentManager.Query("GalleryItem").List();
            var parts = galleryItems.Select(g => g.Parts.Single(x => x.Fields.Any(f => f.Name == "Image")));
            var vm = new GalleryViewModel();

            parts.ToList().ForEach(p => vm.GalleryItems.Add(new GalleryViewModel.GalleryItemViewModel(
                ((dynamic)p.Fields.SingleOrDefault(x => x.Name == "Image")).MediaParts[0].MediaUrl)));
            
            return View(vm);
        }
    }
}
