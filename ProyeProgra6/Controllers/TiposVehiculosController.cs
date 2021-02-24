using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyeProgra6.Models;

namespace ProyeProgra6.Controllers
{
    public class TiposVehiculosController : Controller
    {
        

        proyectoprogra6Entities modeloBD = new proyectoprogra6Entities();

        public ActionResult TiposVehiculosLista()
        {
            //creamos la variable que contiene los registros obtenidos
            ///al invocar los procesos almacenados
            List<sp_RetornaTiposVehículos_Result> modeloVista =
                new List<sp_RetornaTiposVehículos_Result>();

            ///asignar a la variable el resultado de 'llamas el procedimiento almacenado

            modeloVista = this.modeloBD.sp_RetornaTiposVehículos("").ToList();
            //enviar a la vista el modelo
            return View(modeloVista);

        }
    }
}