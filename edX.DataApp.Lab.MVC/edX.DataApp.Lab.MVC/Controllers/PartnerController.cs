using edX.DataApp.Lab.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace edX.DataApp.Lab.MVC.Controllers
{
    public class PartnerController : Controller
    {
        // GET: Partners
        public ActionResult Index()
        {
            List<Partner> model = new List<Partner>();
            using (ContosoContext context = new ContosoContext())
            {
                model.AddRange(context.Partners);
                return View(model);
            }
        }

        // GET: Partner Details
        public ActionResult Details(int id)
        {
            Partner model;
            using (ContosoContext context = new ContosoContext())
            {
                model = context.Partners.Find(id);
                return View(model);
            }
        }

        // GET: Question 1 Answer
        public ActionResult Question1()
        {
            List<Partner> model = new List<Partner>();
            using (ContosoContext context = new ContosoContext())
            {
                model.AddRange(context.Partners.Where(p => !p.IsOpen)
                    .OrderBy(p => p.Name));
                return View(model);
            }
        }

        // GET: Question 3 Answer
        public ActionResult Question3()
        {
            string name = "Comtour";
            Partner model;
            using (ContosoContext context = new ContosoContext())
            {
                model = context.Partners
                    .FirstOrDefault(p => String.Equals(p.Name, name));
                return View(model);
            }
        }
    }
}