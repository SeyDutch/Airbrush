using Orchard;
using Orchard.Security;
using Orchard.UI.Navigation;
using Orchard.Localization;
using Airbrush.Services;
using System.Linq;

namespace Airbrush.Providers.Menu
{
    public class AdminMenu : Component, INavigationProvider
    {

        private readonly IContactFormService _contactFormService;
        private readonly IContactInfoService _contactInfoService;
        private readonly IAuthorizer _authorizer;

        public AdminMenu(IContactInfoService contactInfoService, IContactFormService contactFormService, IAuthorizer authorizer)
        {
            _contactFormService = contactFormService;
            _contactInfoService = contactInfoService;
            _authorizer = authorizer;
        }
            
        public Localizer T { get; set; }

        public string MenuName
        {
            get { return "admin"; }
        }

        public void GetNavigation(NavigationBuilder builder){
            builder.Add(T("Contact"), "5", BuildMenu);
        }

        public void BuildMenu(NavigationItemBuilder menu)
        {
            //menu.Add(T("List"), "1.0", item =>
            //    item.Action("List", "Admin", new { area = "Contents", id = "Contact" }));

            menu.Add(T("Contact Info"), "1.1", item =>
                    item.Action("Edit", "ContactAdmin", new { area = "Airbrush" }))
                .Add(T("Reacties ({0})", _contactFormService.GetEntries().Count()), "1.2", item =>
                    item.Action("List", "ContactAdmin", new { area = "Airbrush" }));

            //menu.Add(T("Edit Contact"), "1.1", item =>
            //item.Action("Edit", "ContactAdmin", new { area = "Airbrush" }));

            //menu.Add(T("Reacties ({0})", _contactFormService.GetEntries().Count()), "1.2", item =>
            //    item.Action("List", "ContactAdmin", new { area = "Airbrush" }));
        }

    }
}