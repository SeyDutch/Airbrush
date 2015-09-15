using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;


namespace Airbrush
{
    public class Routes : IRouteProvider
    {
        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[] {
                new RouteDescriptor {
                    Name = "HomeRouteDescriptor",
                    Priority = 1,
                    Route = new Route("Home",
                                new RouteValueDictionary{
                                    {"area", "Airbrush"},
                                    {"controller", "Home"},
                                    {"action", "Index"}
                                },
                                new RouteValueDictionary(),
                                new RouteValueDictionary{
                                    {"area", "Airbrush"}
                                },
                                new MvcRouteHandler())

                },
                new RouteDescriptor {
                    Name = "ContactRouteDescriptor",
                    Priority = 1,
                    Route = new Route("Contact",
                                new RouteValueDictionary{
                                    {"area", "Airbrush"},
                                    {"controller", "Contact"},
                                    {"action", "Index"}
                                },
                                new RouteValueDictionary(),
                                new RouteValueDictionary{
                                    {"area", "Airbrush"}
                                },
                                new MvcRouteHandler())

                },
                new RouteDescriptor {
                    Name = "ContactFormRouteDescriptor",
                    Priority = 1,
                    Route = new Route("Contact/Form",
                                new RouteValueDictionary{
                                    {"area", "Airbrush"},
                                    {"controller", "Contact"},
                                    {"action", "Form"}
                                },
                                new RouteValueDictionary(),
                                new RouteValueDictionary{
                                    {"area", "Airbrush"}
                                },
                                new MvcRouteHandler())

                },
                new RouteDescriptor{
                    Name = "ContactAdminRouteDescriptor",
                    Priority = 1,
                    Route = new Route("Admin/Contact/Delete/{id}",
                                    new RouteValueDictionary{
                                        {"area", "Airbrush"},
                                        {"controller", "ContactAdmin"},
                                        {"action", "Delete"}//,
                                        //{"id", UrlParameter.Optional }
                                    },
                                    new RouteValueDictionary(),
                                    new RouteValueDictionary{
                                        {"area", "Airbrush"}
                                    },
                                    new MvcRouteHandler())
                 },
                new RouteDescriptor {
                     Name = "ContactAdminListRouteDescriptor",
                     Priority = 1,
                     Route = new Route("Admin/Contact/List",
                                new RouteValueDictionary {
                                        {"area", "Airbrush"},
                                        {"controller", "ContactAdmin" },
                                        {"action" , "List"}
                                    },
                                    new RouteValueDictionary(),
                                    new RouteValueDictionary {
                                        {"area",  "Airbrush" }
                                    },
                                    new MvcRouteHandler())
                 },
                 new RouteDescriptor {
                     Name = "ContactAdminEditRouteDescriptor",
                     Priority = 1,
                     Route = new Route("Admin/Contact/Edit",
                                new RouteValueDictionary {
                                        {"area", "Airbrush"},
                                        {"controller", "ContactAdmin" },
                                        {"action" , "Edit"}
                                    },
                                    new RouteValueDictionary(),
                                    new RouteValueDictionary {
                                        {"area",  "Airbrush" }
                                    },
                                    new MvcRouteHandler())
                 },
                 new RouteDescriptor {
                     Name = "GalleryIndexRouteDescriptor",
                     Priority = 1,
                     Route = new Route("Gallery",
                                new RouteValueDictionary {
                                        {"area", "Airbrush"},
                                        {"controller", "Gallery" },
                                        {"action" , "Index"}
                                    },
                                    new RouteValueDictionary(),
                                    new RouteValueDictionary {
                                        {"area",  "Airbrush" }
                                    },
                                    new MvcRouteHandler())
                 }
            };
        }

        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach(var route in GetRoutes()){
                routes.Add(route);
            };
        }

    }

    
}