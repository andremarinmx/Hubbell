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
        public ActionResult EditarEmpleadoMes(int id)
        {
            using (HubbellContext db = new HubbellContext())
            {
                EmpleadosMes empleadoMes = db.EmpleadosMes.Find(id);
                return View(empleadoMes);
            }
        }

        [HttpPost]
        public ActionResult EditarEmpleadoMes(EmpleadosMes empleado)
        {
            using (HubbellContext db = new HubbellContext())
            {
                EmpleadosMes empleadoMes = db.EmpleadosMes.Find(empleado.Id);
                empleadoMes.NumReloj = empleado.NumReloj;
                empleadoMes.Fecha = empleado.Fecha;
                db.SaveChanges();
                return RedirectToAction("EmpleadosMes");
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

        [HttpGet]
        public ActionResult VacantesPlanta1()
        {
            using (HubbellContext db = new HubbellContext())
            {
                var vacantes = db.Vacantes.Where(x => x.Planta == "Planta1").ToList().OrderBy(x => x.Fecha);
                return View(vacantes);
            }

        }

        [HttpGet]
        public ActionResult VacantesPlanta2()
        {
            using (HubbellContext db = new HubbellContext())
            {
                var vacantes = db.Vacantes.Where(x => x.Planta == "Planta2").ToList().OrderBy(x => x.Fecha);
                return View(vacantes);
            }

        }

        [HttpGet]
        public ActionResult CrearVacante()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearVacante(string fotografia, string fecha, string planta)
        {
            using (HubbellContext db = new HubbellContext())
            {
                var vacantes = db.Vacantes.OrderBy(x => x.Fecha).ToList();
                Vacantes vacante = new Vacantes();
                vacante.Img = fotografia;
                vacante.Fecha = fecha;
                vacante.Planta = planta;
                db.Vacantes.Add(vacante);
                db.SaveChanges();
                if(planta == "Planta1")
                {
                    return RedirectToAction("VacantesPlanta1", vacantes);
                }
                else
                {
                    return RedirectToAction("VacantesPlanta2", vacantes);
                }
            }
        }

        [HttpGet]
        public ActionResult EliminarVacante(int id, string planta)
        {
            using (HubbellContext db = new HubbellContext())
            {
                Vacantes Vacante = db.Vacantes.Find(id);
                db.Vacantes.Remove(Vacante);
                db.SaveChanges();
                if (planta == "Planta1")
                {
                    return RedirectToAction("VacantesPlanta1");
                }
                else
                {
                    return RedirectToAction("VacantesPlanta2");
                }
            }
        }
    }
}