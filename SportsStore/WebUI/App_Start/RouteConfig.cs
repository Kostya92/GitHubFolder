using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "", //соответствует только пустым url)
                new
                {
                    controller = "Product",
                    action = "List",
                    category = (string) null,
                    page = 1
                });

            routes.MapRoute(null,
                "Page{page}", //Соответствует Page2, Page123, но не Pagexzy)
                new {controller = "Product", action = "List", category = (string) null},
                new {page = @"\d+"} //Страница должна быть чесловой
                );

            routes.MapRoute(null,
                "{category}", //соответствует /Footaball или /AnythingWithNoSlash)
                new {controller = "Product", action = "List", page = 1});

            routes.MapRoute(null,
                "{category}/Page/{page}", //соответствует /Football/Page23)
                new {controller = "Product", action = "List"}, //По умолчанию
                new {page = @"\d+"}); //Ораничение, страница должна быть числовой
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}