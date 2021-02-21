using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyeProgra6.Models;

namespace ProyeProgra6.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        proyectoprogra6Entities modeloBD = new proyectoprogra6Entities();

        public ActionResult UsuariosLista()
        {
            //creamos la variable que contiene los registros obtenidos
            ///al invocar los procesos almacenados
            List<sp_RetornaUsuarios_Result> modeloVista =
                new List<sp_RetornaUsuarios_Result>();

            ///asignar a la variable el resultado de 'llamas el procedimiento almacenado

            modeloVista = this.modeloBD.sp_RetornaUsuarios("", "").ToList();
            //enviar a la vista el modelo
            return View(modeloVista);

        }


    }
}