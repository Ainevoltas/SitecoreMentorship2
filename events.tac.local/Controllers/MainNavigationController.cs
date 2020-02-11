using events.tac.local.Models;
using Sitecore.Data;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class MainNavigationController : Controller
    {
        // GET: MainNavigation
        public ActionResult Index()
        {
            var climbingEventsFolder = RenderingContext
                                            .Current
                                            .PageContext
                                            .Database
                                            .GetItem(new ID("{724C5CE9-7814-4C38-9D56-0C0662BDFCAB}"));
            var hikingEventsFolder = RenderingContext
                                            .Current
                                            .PageContext
                                            .Database
                                            .GetItem(new ID("{4098B7A3-4D00-4077-AF01-5332C14EE180}"));

            var navigationListItems = climbingEventsFolder
                                            .GetChildren()
                                            .Where(i => i.Fields["ExcludeFromNavigation"].Value != "1")
                                            .Concat(
                                                        hikingEventsFolder
                                                            .GetChildren()
                                                            .Where(i => i.Fields["ExcludeFromNavigation"].Value != "1")
                                                    )
                                            .ToList();          
            return View(navigationListItems);
        }
    }
}