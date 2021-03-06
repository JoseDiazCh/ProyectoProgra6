﻿using System;
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
        //---------------------------------------------------------------
        /// <summary>
        /// retorna servicio cliente
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RetornaServicioCliente()
        {
            List<sp_ReporteSC_Result> listaservicio =
               this.modeloBD.sp_ReporteSC("", "").ToList();
            return Json(new

            {
                resultado = listaservicio
            });

        }
        /// <summary>
        /// retorna  vehiculo cliente
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RetornaServicioVehiculo()
        { List<sp_ReporteSV_Result> lista =
               this.modeloBD.sp_ReporteSV("").ToList();
            return Json(new

            {
                resultado = lista
            });
           

        }
        /// <summary>
        /// REtorna servicio vehiculo
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RetornaSerVehiculo()
        {
           List<sp_ReporteVC_Result> lista =
               this.modeloBD.sp_ReporteVC("").ToList();
            return Json(new

            {
                resultado = lista
            }); 

        }

    }
    
}
