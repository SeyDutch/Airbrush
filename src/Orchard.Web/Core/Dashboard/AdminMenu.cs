﻿using Orchard.Localization;
using Orchard.Security;
using Orchard.UI.Navigation;

namespace Orchard.Core.Dashboard {
    public class AdminMenu : INavigationProvider {
        public Localizer T { get; set; }
        public string MenuName { get { return "admin"; } }

        public void GetNavigation(NavigationBuilder builder) {
            builder.Add(T("Orchard"), "0",
                        menu => menu.Add(T("Dashboard"), "0", item => item.Action("Index", "Admin", new { area = "Dashboard" }).Permission(StandardPermissions.AccessAdminPanel)));
        }
    }
}