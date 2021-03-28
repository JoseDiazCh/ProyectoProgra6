using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyeProgra6.Models;

namespace ProyeProgra6.Controllers
{
    public class GridKendoController : Controller
    {
     /// <summary>
     /// coneccion a la base datos
     /// </summary>
        proyectoprogra6Entities modeloBD = new proyectoprogra6Entities();
        // GET: GridKendo
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Reporte de servicios por cliente
        /// </summary>
        /// <returns></returns>
        public ActionResult ServicioCliente()
        {
            return View();
        }

        /// <summary>
        ///Reporte de vehículos por cliente
        /// </summary>
        /// <returns></returns>
        public ActionResult VehiculoCliente()
        {
            return View();
        }
        /// <summary>
        ///Reporte de servicios por vehículo:
        /// </summary>
        /// <returns></returns>
        public ActionResult ServicioVehiculo()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RetornaServicio()
        {
            List<sp_RetornaServicioOProducto_Result> listaservicio =
               this.modeloBD.sp_RetornaServicioOProducto("", "").ToList();
            return Json(new

            {
                resultado = listaservicio
            });
          
        }
        public ActionResult RetornaCliente()
        {
            List<sp_RetornaUsuarios_Result> listacliente =
               this.modeloBD.sp_RetornaUsuarios("", "").ToList();
            return Json(new
            {
                resultado = listacliente
            });
        }

    }
}