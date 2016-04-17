using System.Web.Mvc;
using Orchard.Localization;
using Orchard;
using Orchard.Themes;
using Orchard.UI.Notify;

namespace Airbrush.Controllers {

    [Themed]
    public class HomeController : Controller {
        public IOrchardServices Services { get; set; }
        private readonly INotifier _notifier;

        public HomeController(IOrchardServices services, INotifier notifier) {
            Services = services;
            _notifier = notifier;
            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
