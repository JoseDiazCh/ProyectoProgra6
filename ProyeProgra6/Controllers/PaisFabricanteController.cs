using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyeProgra6.Models;

namespace ProyeProgra6.Controllers
{
    public class PaisFabricanteController : Controller
    {
        proyectoprogra6Entities modeloBD = new proyectoprogra6Entities();

        /// <summary>
        /// controlador que me LISTA los paises de fabricacion
        /// </summary>
        /// <returns></returns>
        public ActionResult PaisFabricanteLista()
        {
            //creamos la variable que contiene los registros obtenidos
            ///al invocar los procesos almacenados
            List<sp_RetornaPaísFabricante_Result> modeloVista =
                new List<sp_RetornaPaísFabricante_Result>();

            ///asignar a la variable el resultado de 'llamas el procedimiento almacenado

            modeloVista = this.modeloBD.sp_RetornaPaísFabricante("", "").ToList();
            //enviar a la vista el modelo
            return View(modeloVista);
        }

        /// <summary>
        /// controlador que me INSERTA los paises de fabricacion
        /// </summary>
        /// <returns></returns>
        public ActionResult PaisFabricacionNuevo()
        {
            return View();
        }


        /// insert Pais Fabricacion tipo httpPost
        [HttpPost]
        public ActionResult PaisFabricacionNuevo(sp_RetornaPaísFabricante_Result modeloVista)
        {
            ///registra la cantidad de  registros afectados
            ///si un prrocedimiento se ejecuta INSERT, UPDATE, DELETE
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_InsertaPaísFabricante(
                        modeloVista.Codigo,
                        modeloVista.Pais

                        );
            }
            catch (Exception error)
            {

                resultado = "Ocurrio un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado = "Registro insertado correctamente";
                }
                else
                {
                    resultado = "No se pudo insertar";
                }
            }
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");


            return View();
        }
        /// <summary>
        /// controlador que MODIFICA un Pais de fabricacion
        /// </summary>
        /// <param name="idPaisFabricante"></param>
        /// <returns></returns>
        public ActionResult ModificaPaisFabricacion(int idPaisFabricante)
        {
            ///obtener el registro que se debe modificar
            ///utilizando el parametro idPaisFabricante
            sp_RetornaPaísFabricante_ID_Result modeloVista = new sp_RetornaPaísFabricante_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaPaísFabricante_ID(idPaisFabricante).FirstOrDefault();

            //enviar el modelo a la vista
            return View(modeloVista);
        }
        /// Modifica Pais tipo httpPost
        [HttpPost]
        public ActionResult ModificaPaisFabricacion(sp_RetornaPaísFabricante_ID_Result modeloVista)
        {
            ///registra la cantidad de  registros afectados
            ///si un prrocedimiento se ejecuta INSERT, UPDATE, DELETE
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_ModificaPaisFabricante(
                        modeloVista.idPaisFabricante,
                        modeloVista.Codigo,
                        modeloVista.Pais
                        );
            }
            catch (Exception error)
            {

                resultado = "Ocurrio un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)

                    resultado = "Registro Modificado Correctamente";

                else
                    resultado = "No se pudo Modificar el Dato";

            }
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");

            return View(modeloVista);
        }
        /// <summary>
        /// controlador que ELIMINA una Pais de fabricacion
        /// </summary>
        /// <param name="id_Persona"></param>
        /// <returns></returns>
        public ActionResult EliminaPaisFabricacion(int idPaisFabricante)
        {
            ///obtener el registro que se debe eliminar
            ///utilizando el parametro idPaisFabricante
            sp_RetornaPaísFabricante_ID_Result modeloVista = new sp_RetornaPaísFabricante_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaPaísFabricante_ID(idPaisFabricante).FirstOrDefault();

            //enviar el modelo a la vista
            return View(modeloVista);
        }
        /// ELIMINA Pais tipo httpPost
        [HttpPost]
        public ActionResult EliminaPaisFabricacion(sp_RetornaPaísFabricante_ID_Result modeloVista)
        {
            ///registra la cantidad de  registros afectados
            ///si un prrocedimiento se ejecuta INSERT, UPDATE, DELETE
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_EliminaPaisFabricante(modeloVista.idPaisFabricante);

            }
            catch (Exception error)
            {

                resultado = "Ocurrio un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)

                    resultado = "Registro Eliminado Correctamente";

                else
                    resultado = "No se pudo Eliminar el Registro";

            }
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);
        }
    }
}


    
