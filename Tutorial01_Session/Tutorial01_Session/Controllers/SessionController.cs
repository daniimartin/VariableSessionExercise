using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tutorial01_Session.Controllers
{
    public class SessionController : Controller
    {

        // GET: Index
        public ActionResult Index(String ingrediente)
        {

            if (ingrediente != null)
            {
                List<String> lista;

                //Almaceno en la session
                if (Session["PIZZA"] != null)
                {
                    lista = Session["PIZZA"] as List<String>;    
                }
                else
                {
                    //Creamos una nueva lista
                    lista = new List<string>();
                }

                lista.Add(ingrediente);
                //Almacenamos los cambios en la sesión
                Session["PIZZA"] = lista;
            }

            return View();
        }

        //GET: Compra
        public ActionResult Compra()
        {

            return View(Session["PIZZA"]);
        }

        //ActionResult del link de eliminar Session
        public ActionResult Borrar()
        {
            Session["PIZZA"] = null;

            return RedirectToAction("Index");
        }
    }
}