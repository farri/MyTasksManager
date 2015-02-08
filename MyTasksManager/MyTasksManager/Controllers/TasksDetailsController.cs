using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using MyTasksManager.Models;

namespace MyTasksManager.Controllers
{
    public class TasksDetailsController : Controller
    {
        private TasksDetailContext db = new TasksDetailContext();

        // Search: title

        [HttpGet]
        public ViewResult Index(string strSearch)
        {

            //Select all tasks records
            var tasks = from t in db.TasksDetails
                        select t;

            //Search records by Title  
            if (!string.IsNullOrEmpty(strSearch))
                tasks = tasks.Where(m => m.title.Contains(strSearch));

            return View(tasks);
        }

        // GET: TasksDetails/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TasksDetail tasksDetail = db.TasksDetails.Find(id);

            if (tasksDetail == null)
            {
                return HttpNotFound();
            }
            return View(tasksDetail);
        }

        // GET: TasksDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TasksDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,title,description,dueDate,hoursLeft,priority")] TasksDetail tasksDetail)
        {
            if (ModelState.IsValid)
            {
                db.TasksDetails.Add(tasksDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tasksDetail);
        }

        // GET: TasksDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TasksDetail tasksDetail = db.TasksDetails.Find(id);
            if (tasksDetail == null)
            {
                return HttpNotFound();
            }
            return View(tasksDetail);
        }

        // POST: TasksDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,title,description,dueDate,hoursLeft,priority")] TasksDetail tasksDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tasksDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tasksDetail);
        }

        // GET: TasksDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TasksDetail tasksDetail = db.TasksDetails.Find(id);
            if (tasksDetail == null)
            {
                return HttpNotFound();
            }
            return View(tasksDetail);
        }

        // POST: TasksDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TasksDetail tasksDetail = db.TasksDetails.Find(id);
            db.TasksDetails.Remove(tasksDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult DrawChart()
        {
            //Select all tasks records
            var tasks = from t in db.TasksDetails
                        select t;

            //Get list of tasks Description
            var hoursLeftList = from c in tasks
                                orderby c.hoursLeft
                                select c.hoursLeft;

            //Get list of tasks Description
            var TitleList = from c in tasks
                            orderby c.title
                            select c.title;

            var chart = new Chart(width: 300, height: 200, theme: ChartTheme.Vanilla)
            .AddTitle("Title Vs HoursLeft")
                .AddSeries(
                            chartType: "bar",
                            xValue: TitleList,
                            yValues: hoursLeftList)
                            .GetBytes("png");

            return File(chart, "image/bytes");
        }
    }
}
