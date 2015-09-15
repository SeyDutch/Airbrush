using System.Web.Mvc;
using Orchard.Localization;
using Orchard;
using Orchard.UI.Admin;
using Orchard.Settings;
using Orchard.Data;
using Airbrush.Services;
using Orchard.DisplayManagement;
using Orchard.UI.Navigation;
using System.Linq;
using Airbrush.ViewModels;
using Orchard.Mvc;
using Orchard.Core.Common.Models;
using Orchard.ContentManagement;

namespace Airbrush.Controllers {
    [Admin]
    public class ContactAdminController : Controller {
        private readonly ISiteService _siteService;

        private readonly IContactFormService _contactFormService;
        private readonly IContactInfoService _contactInfoService;

        public ContactAdminController(ISiteService siteService, IContactInfoService cIS, IContactFormService cFS, IShapeFactory shapeFactory) {
            _siteService = siteService;
            _contactFormService = cFS;
            _contactInfoService = cIS;
            T = NullLocalizer.Instance;
            Shape = shapeFactory;
        }

        public Localizer T { get; set; }
        public dynamic Shape { get; set; }

        [HttpGet, ActionName("Index"), Admin]
        public ActionResult Index(PagerParameters pagerParameters)
        {
            Pager pager = new Pager(_siteService.GetSiteSettings(), pagerParameters);
            var contactEntryCount = _contactFormService.GetEntries().Count();
            var entries = _contactFormService.GetEntries().ToList();//.Select(e => _contactFormService.Convert(e)).ToList(); // TODO add paging;
            var pagerShape = Shape.Pager(pager).TotalItemsCount(contactEntryCount);


            var vm = new ContactFormEntryListViewModel { ContactFormEntries = entries, Pager = pager };
            return View(vm);
            //return null;
        }

        [HttpGet, ActionName("List"), Admin]
        public ActionResult List()
        {
            // can add pager
            var entries = _contactFormService.GetEntries().OrderByDescending(x => x.As<CommonPart>().CreatedUtc).ToList();
            var vm = new ContactFormEntryListViewModel { ContactFormEntries = entries };

            return View(vm);
        }

        [HttpGet, Admin]
        public ActionResult Edit()
        {
            var contactInfo = _contactInfoService.GetInfo();
            return View(_contactInfoService.Convert(contactInfo));
        }

        [HttpPost, Admin]
        public ActionResult Edit(ContactPageViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _contactInfoService.EditInfo(_contactInfoService.Convert(model));
            return View(model);
        }

        [ActionName("Delete"), Admin]
        public ActionResult DeleteContactFormEntry(int id)
        {
            var entry = _contactFormService.GetEntry(id);
            if(entry == null)
            {
                ModelState.AddModelError("ContactFormEntry", T("Could not find the ContactFormEntry to delete.").ToString());
                return RedirectToAction("List");
            }

            _contactFormService.DeleteEntry(entry);
            return RedirectToAction("List");
        }
    }
}
