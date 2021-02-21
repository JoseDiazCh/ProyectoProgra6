using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyeProgra6.Models;

namespace ProyeProgra6.Controllers
{
    public class MarcaVehiculoController : Controller
    {
        proyectoprogra6Entities modeloBD = new proyectoprogra6Entities();

        public ActionResult MarcaVehiculoLista()
        {
            //creamos la variable que contiene los registros obtenidos
            ///al invocar los procesos almacenados
            List<sp_RetornaMarcaVehiculo_Result> modeloVista =
                new List<sp_RetornaMarcaVehiculo_Result>();

            ///asignar a la variable el resultado de 'llamas el procedimiento almacenado

            modeloVista = this.modeloBD.sp_RetornaMarcaVehiculo("", "").ToList();
            //enviar a la vista el modelo
            return View(modeloVista);

        }
    }
}