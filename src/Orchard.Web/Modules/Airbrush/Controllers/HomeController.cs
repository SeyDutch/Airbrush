using System.Web.Mvc;
using Orchard.Localization;
using Orchard;
using Orchard.Themes;

namespace Airbrush.Controllers {

    [Themed]
    public class HomeController : Controller {
        public IOrchardServices Services { get; set; }

        public HomeController(IOrchardServices services) {
            Services = services;
            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        
        [HttpGet]
        public ActionResult Index()
        {
            return null;
        }
    }
}
