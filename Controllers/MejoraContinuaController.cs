using Hubbell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hubbell.Controllers
{
    public class MejoraContinuaController : Controller
    {
        [HttpGet]
        public ActionResult Proyectos()
        {
            using (HubbellContext db = new HubbellContext())
            {
                var proyectos = db.MejoraContinuaProyectos.OrderBy(x => x.FechaInicio).ToList();
                return View(proyectos);
            }
        }

        [HttpGet]
        public ActionResult CrearProyecto()
        {
            using (HubbellContext db = new HubbellContext())
            {   
                return View();
            }
        }

        [HttpPost]
        public ActionResult CrearProyecto(
            string titulo,
            string categorias,
            string integrantes,
            string recolecionDatos,
            string causaPotencial,
            string causaRaiz,
            string fechaInicio,
            string SituacionActualFoto
        )
        {
            using (HubbellContext db = new HubbellContext())
            {
                var proyectos = db.MejoraContinuaProyectos.OrderBy(x => x.FechaInicio).ToList();
                MejoraContinuaProyectos proyecto = new MejoraContinuaProyectos();
                proyecto.Titulo = titulo;
                proyecto.Categoria = categorias;
                proyecto.Integrantes = integrantes;
                proyecto.RecoleccionDatos = recolecionDatos;
                proyecto.CausaPotencial = causaPotencial;
                proyecto.CausaRaiz = causaRaiz;
                proyecto.FechaInicio = fechaInicio;
                proyecto.SituacionActualFoto = SituacionActualFoto;
                db.MejoraContinuaProyectos.Add(proyecto);
                db.SaveChanges();
                return RedirectToAction("Proyectos", proyectos);
            }
        }
    }
}
