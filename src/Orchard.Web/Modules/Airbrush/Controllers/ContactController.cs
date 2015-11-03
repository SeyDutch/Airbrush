using System.Web.Mvc;
using Orchard.Localization;
using Orchard;
using Orchard.Themes;
using Orchard.UI.Notify;
using Airbrush.ViewModels;
using Orchard.Security;
using Airbrush.Services;
using System;

namespace Airbrush.Controllers {
    [Themed]
    public class ContactController : Controller {

        private readonly INotifier _notifier;
        private readonly IAuthorizer _authorizer;
        private readonly IContactInfoService _cIS;
        private readonly IContactFormService _cFS;

        public IOrchardServices Services { get; set; }
        protected Localizer T { get; set; }

        public ContactController(IOrchardServices services, IContactInfoService cis, IContactFormService cfs, INotifier notifier, IAuthorizer auth) {
            Services = services;
            _notifier = notifier;
            _authorizer = auth;
            _cIS = cis;
            _cFS = cfs;
            T = NullLocalizer.Instance;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var data = _cIS.GetInfo();
            return View(_cIS.Convert(data) ?? new ContactPageViewModel());
        }

        // should never be called????
        [HttpPost]
        public ActionResult Edit(ContactPageViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var dm = _cIS.EditInfo(_cIS.Convert(model));
            _notifier.Add(NotifyType.Information, T(dm == null ? "Contact info saving failed" : "Opslaan gelukt."));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(ContactFormEntryViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Subject))
                model.Subject = T("Contact verzoek").Text;

            model.CreatedUtc = DateTime.UtcNow;
            if (!ModelState.IsValid)
                return View(model);

            var dm = _cFS.StoreEntry(_cFS.Convert(model));
            if(dm == null)
            {
                _notifier.Add(NotifyType.Warning, T("Er is iets mis gegenaamn tijdens de verwerking van uw bericht."));
                return RedirectToAction("Failed");
            }

            return RedirectToAction("Confirmation");
        }

        public ActionResult Confirmation()
        {
            return View();
        }

        public ActionResult Failed()
        {
            return View();
        }
    }
}
