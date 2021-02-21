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

        ////--------------------------------------------------------------------------------------------
        ///
        /// 

        public ActionResult UsuarioNuevo()
        {
            AgregaProvinciasViewBag();
            AgregaCantonesViewBag();
            AgregaDistritosViewgBag();
            return View();
        }

        /// //agrega provincias al viewbag
        /// <summary>
        /// para que sean accedidas desde la vista
        /// es case sensitive
        /// </summary>
        void AgregaProvinciasViewBag()
        {
            this.ViewBag.ListaProvincias =
                    this.modeloBD.sp_RetornaProvincias("").ToList();
        }

        void AgregaCantonesViewBag()
        {
            this.ViewBag.ListaCantones =
                    this.modeloBD.sp_RetornaCantones("",null).ToList();
        
        }

        void AgregaDistritosViewgBag()
        {
            this.ViewBag.ListaDistritos =
                this.modeloBD.sp_RetornaDistritos("", null);
        }
        /// <summary>
        /// este envia la persona nueva
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UsuarioNuevo(sp_RetornaUsuarios_Result modeloVista)
        {
            ///registra cantidad de registros afectados.
            ///
            int cantRegistrosafectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosafectados =
                    this.modeloBD.sp_InsertaUsuarios(
                        modeloVista.Cedula,
                        modeloVista.descripcionGenero,
                        modeloVista.FechaNacimiento,
                        modeloVista.Nombre,
                        modeloVista.Apellido1,
                        modeloVista.Apellido2,
                        modeloVista.Correo,
                        modeloVista.TipoUsuario ,
                        modeloVista.id_Provincia,
                        modeloVista.id_Canton,
                        modeloVista.id_Distrito,
                        modeloVista.Contrasenia
                        );
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error:" + error.Message;

            }
            finally
            {
                if (cantRegistrosafectados > 0)
                {
                    resultado = "Registro insertado";

                }
                else
                {
                    resultado += ".No se Pudo insertas";
                }
            }

            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            this.AgregaProvinciasViewBag();
            this.AgregaCantonesViewBag();
            this.AgregaDistritosViewgBag();
            return View();
        }


    }
}