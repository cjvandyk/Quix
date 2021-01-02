#pragma warning disable IDE1006, IDE0017, CS0162, IDE0060, IDE0079 // Naming Styles, Simplify declaration (FQCN used), break after return, Remove unused (string[] args, Remove unnecessary suppression)

/// <summary>
/// Author: Cornelius J. van Dyk blog.cjvandyk.com @cjvandyk
/// This code is provided under GNU GPL 3.0 and is a copyrighted work of the
/// author and contributors.  Please see:
/// https://github.com/cjvandyk/Quix/blob/master/LICENSE
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Approval.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
