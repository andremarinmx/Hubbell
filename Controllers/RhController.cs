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
                var empleados = db.EmpleadosMes.OrderBy(x => x.Fecha).ToList();
                var fotos = db.FotoEmpleadosMes.ToList();
                ViewBag.fotos = fotos;
                return View(empleados);
            }
              
        }

        [HttpGet]
        public ActionResult AgregarEmpleado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarEmpleado(int numReloj, string fecha)
        {
            using (HubbellContext db = new HubbellContext())
            {
                var empleados = db.EmpleadosMes.OrderBy(x => x.Fecha).ToList();
                EmpleadosMes empleadoMes = new EmpleadosMes();
                empleadoMes.NumReloj = numReloj;
                empleadoMes.Fecha = fecha;
                db.EmpleadosMes.Add(empleadoMes);
                db.SaveChanges();
                return RedirectToAction("EmpleadosMes", empleados);
            }
        }

        [HttpGet]
        public ActionResult EliminarEmpleadoMes(int id)
        {
            using (HubbellContext db = new HubbellContext())
            {
                var empleados = db.EmpleadosMes.OrderBy(x => x.Fecha).ToList();
                EmpleadosMes empleadoMes = db.EmpleadosMes.Find(id);
                db.EmpleadosMes.Remove(empleadoMes);
                db.SaveChanges();
                return RedirectToAction("EmpleadosMes", empleados);
            }
        }

        [HttpGet]
        public ActionResult AgregarImagen()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarImagen(string fecha, string fotografia)
        {
            using (HubbellContext db = new HubbellContext())
            {
                var fotos = db.FotoEmpleadosMes.OrderBy(x => x.Fecha).ToList();
                FotoEmpleadosMes foto = new FotoEmpleadosMes();
                foto.Fecha = fecha;
                foto.Img = fotografia;
                db.FotoEmpleadosMes.Add(foto);
                db.SaveChanges();
                return RedirectToAction("EmpleadosMes");
            }
        }

        [HttpGet]
        public ActionResult EliminarFotoEmpleadoMes(int id)
        {
            using (HubbellContext db = new HubbellContext())
            {
                FotoEmpleadosMes foto = db.FotoEmpleadosMes.Find(id);
                db.FotoEmpleadosMes.Remove(foto);
                db.SaveChanges();
                return RedirectToAction("EmpleadosMes");
            }
        }
    }
}