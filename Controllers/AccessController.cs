using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;
namespace CursoMVC.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string pass)
        {

            try
            {
                using (CursomvcEntities1 db = new CursomvcEntities1())
                {
                    var lista = from d in db.User
                                where d.correo == user && d.password == pass && d.idState == 1
                                select d;
                    if (lista.Count() > 0)
                    {
                        User oUser = lista.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario invalido..");
                    }

                }

           
            }
            catch(Exception ex)
            {
                return Content("Ocurrio un error " + ex.Message);
            }
        }
    }
}