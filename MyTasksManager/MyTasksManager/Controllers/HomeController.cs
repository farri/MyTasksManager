using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTasksManager.Models;

namespace MyTasksManager.Controllers
{
    public class HomeController : Controller
    {
        private TasksDetailContext db = new TasksDetailContext();

        public ActionResult Index()
        {
           return RedirectToAction("Index", "TasksDetails");
        }
    }
}
