using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChristianLifeChurch.BackOffice.Controllers
{
    public class EventController : Controller
    {
        //
        // GET: /Event/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GoogleCalendar()
        {
            return Redirect("https://www.google.com/calendar");
        }
	}
}