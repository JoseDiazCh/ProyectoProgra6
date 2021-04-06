using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyeProgra6.Models;

namespace ProyeProgra6.Controllers
{
    public class PrincipalController : Controller
    {

        proyectoprogra6Entities modeloBD = new proyectoprogra6Entities();

        // GET: Principal
        public ActionResult PaginaPrincipal()
        {
            return View();
        }
    }
}