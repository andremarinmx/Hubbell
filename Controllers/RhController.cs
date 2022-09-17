using Hubbell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hubbell.Controllers
{
    public class RhController : Controller
    {
        [HttpGet]
        public ActionResult EmpleadosMes()
        {
            using (HubbellContext db = new HubbellContext())
            {   
                var empleados = db.EmpleadosMes.OrderBy(x => x.NumReloj).ToList();
                return View(empleados);
            }
              
        }

        [HttpGet]
        public ActionResult AgregarEmpleado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarEmpleado(int numReloj, DateTime fecha)
        {
            using (HubbellContext db = new HubbellContext())
            {
                EmpleadosMes empleadoMes = new EmpleadosMes();
                empleadoMes.NumReloj = numReloj;
                empleadoMes.Fecha = fecha;
                db.EmpleadosMes.Add(empleadoMes);
                db.SaveChanges();
                return View("EmpleadosMes");
            }
        }
    }
}