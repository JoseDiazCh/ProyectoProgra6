using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyeProgra6.Models;
namespace ProyeProgra6.Controllers
{
    public class RegistrarseController : Controller
    {

        //conexxion a la base datos
        proyectoprogra6Entities modeloBD = new proyectoprogra6Entities();

        // GET: Registrarse
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// retorna todas las provincias
        /// </summary>
        /// <returns></returns>
        public ActionResult RetornaProvincias()
        {
            List<sp_RetornaProvincias_Result> provincias =
                this.modeloBD.sp_RetornaProvincias(null).ToList();
            return Json(provincias);
        }

        /// <summary>
        ///  Metodo que retorna todos los cantones cuando se selecciona una provincia
        /// </summary>
        /// <param name = "id_Provincias" ></ param >
        /// < returns ></ returns >
        public ActionResult RetornaCantones(int id_Provincia)
        {
            List<sp_RetornaCantones_Result> cantones =
                this.modeloBD.sp_RetornaCantones(null, id_Provincia).ToList();
            return Json(cantones);
        }

        ///// <summary>
        //////Metodo queretorna todos los cantones cuando se selecciona una provincia
        /// </summary>
        /// <param name = "id_Canton" ></ param >
        /// < returns ></ returns >
        public ActionResult RetornaDistritos(int id_Canton)
        {
            List<sp_RetornaDistritos_Result> distritos =
                this.modeloBD.sp_RetornaDistritos(null, id_Canton).ToList();
            return Json(distritos);
        }
        public ActionResult Registrar()
        {
            return View();
        }

        /// <summary>
        /// metodo de registrarse
        /// /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public ActionResult Registrar(
         int pCedula,
         string pGenero,
         DateTime pFechaNacimiento,
        string pNombre,
        string pApellido1,
         string pApellido2,
        string pCorreo,
        string pTipoUsuario,
        int pid_Provincia,
        int pid_Canton,
        int pid_Distrito,
        string pContrasenia
        )
        {
            /// variable que registra la cantidad de registros afectados
            ///si un procedimiento que se ejecuta insert,update,delete
            ///no afecta registros implica que hubo un error



            int cantidadRegistroAfectados = 0;
            string resultado = " ";



            try
            {
                cantidadRegistroAfectados =
                this.modeloBD.sp_InsertaUsuarios(
                pCedula,
                pGenero,
                pFechaNacimiento,
                pNombre,
                pApellido1,
                pApellido2,
                pCorreo,
                pTipoUsuario,
                pid_Provincia,
                pid_Canton,
                pid_Distrito,
                pContrasenia

                );
            }
            catch (Exception error)
            {
                resultado = "Ocurrio un error: " + error.Message;



            }
            finally
            {
                if (cantidadRegistroAfectados > 0)
                {
                    resultado = " El Registro Se Inserto Correctamente";
                }
                else
                {
                    resultado += ".No se pudo Insertar ";
                }
            }

            return Json(resultado);
        }

    }
}

