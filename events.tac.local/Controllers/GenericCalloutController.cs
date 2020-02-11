using events.tac.local.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class GenericCalloutController : Controller
    {
        private readonly IGenericCalloutService _genericCalloutService;

        public GenericCalloutController(IGenericCalloutService genericCalloutService)
        {
            _genericCalloutService = genericCalloutService;
        }
        // GET: GenericCallout
        public ActionResult Index()
        {
            return View();
        }        
    }
}