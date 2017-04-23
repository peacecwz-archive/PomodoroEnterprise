using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PomodoroEnterprise.API.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Trello()
        {
            return View();
        }
    }
}