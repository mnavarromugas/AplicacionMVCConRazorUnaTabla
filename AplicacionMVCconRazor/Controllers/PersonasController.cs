using System.Collections.Generic;
using System.Web.Mvc;
using AplicacionMVCconRazor.Models;

namespace AplicacionMVCconRazor.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Index()
        {
            GestorPersonas gestorPersonas = new GestorPersonas();

            List<Persona> lista = gestorPersonas.ObtenerPersonas();

            return View(lista);
        }

        public ActionResult Eliminar(int Id)
        {
            GestorPersonas gestorPersonas = new GestorPersonas();
            gestorPersonas.Eliminar(Id);
            
            List<Persona> lista = gestorPersonas.ObtenerPersonas();
            return View("Index", "", lista);
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            Persona p = new Persona();
            return View(p);
        }

        [HttpPost]
        public ActionResult Agregar(Persona p)
        {
            GestorPersonas gestorPersonas = new GestorPersonas();
            gestorPersonas.AgregarPersona(p);

            List<Persona> lista = gestorPersonas.ObtenerPersonas();
            return View("Index", "", lista);
        }
        
        [HttpGet]
        public ActionResult Modificar(int id)
        {
            GestorPersonas gestorPersonas = new GestorPersonas();
            Persona p = gestorPersonas.ObtenerPorId(id);

            return View(p);
        }

        [HttpPost]
        public ActionResult Modificar(Persona p)
        {
            GestorPersonas gestorPersonas = new GestorPersonas();
            gestorPersonas.ModificarPersona(p);

            List<Persona> lista = gestorPersonas.ObtenerPersonas();
            return View("Index", "", lista);
        }
    }
}