using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyeProgra6.Models;

namespace ProyeProgra6.Controllers
{
    public class ServicioOProductoController : Controller
    {
        proyectoprogra6Entities modeloBD = new proyectoprogra6Entities();

        public ActionResult ServicioOProductoLista()
        {
            //creamos la variable que contiene los registros obtenidos
            ///al invocar los procesos almacenados
            List<sp_RetornaServicioOProducto_Result> modeloVista =
                new List<sp_RetornaServicioOProducto_Result>();

            ///asignar a la variable el resultado de 'llamas el procedimiento almacenado

            modeloVista = this.modeloBD.sp_RetornaServicioOProducto("", null).ToList();
            //enviar a la vista el modelo
            return View(modeloVista);

        }

        /// <summary>
        /// controlador que me insetar un nuevo producto
        /// </summary>
        /// <returns></returns>
        public ActionResult ServicioOproductoNuevo()
        {
            return View();
        }
    
        /// insert servicio tipo httpPost
        [HttpPost]
        public ActionResult ServicioOproductoNuevo(sp_RetornaServicioOProducto_Result modeloVista)
        {
            ///registra la cantidad de  registros afectados
            ///si un prrocedimiento se ejecuta INSERT, UPDATE, DELETE
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_InsertaServProduc(
                        modeloVista.Codigo,
                        modeloVista.Descripcion,
                        modeloVista.Precio,
                        modeloVista.Tipo
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

        public ActionResult ServicioOproductoModifica(int idServProduc)
        {
            ///obtener el registro que se debe modificar
            ///utilizando el parametro
            sp_RetornaServicioOProducto_ID_Result modeloVista = new sp_RetornaServicioOProducto_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaServicioOProducto_ID(idServProduc).FirstOrDefault();

            //enviar el modelo a la vista
            return View(modeloVista);
        }
        /// Modifica Tipo VEhiculo tipo httpPost
        [HttpPost]
        public ActionResult ServicioOproductoModifica(sp_RetornaServicioOProducto_ID_Result modeloVista)
        {
            ///registra la cantidad de  registros afectados
            ///si un prrocedimiento se ejecuta INSERT, UPDATE, DELETE
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_ModificaTipoServProduc(
                        modeloVista.idServProduc,
                        modeloVista.Codigo,
                        modeloVista.Descripcion,
                        modeloVista.Precio,
                        modeloVista.Tipo
                        );
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error:" + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado = "Registro insertado";

                }
                else
                {
                    resultado += ".No se Pudo insertar";
                }
            }
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");

            return View(modeloVista);
        }
        /// <summary>
        /// controlador que ELIMINA un Tipo VEhiculo
        /// </summary>
        /// <param name="idTipoVehiculo"></param>
        /// <returns></returns>
        public ActionResult ServicioOproductoElimina(int idServProduc)
        {
            ///obtener el registro que se debe eliminar
            ///utilizando el parametro 
            sp_RetornaServicioOProducto_ID_Result modeloVista = new sp_RetornaServicioOProducto_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaServicioOProducto_ID(idServProduc).FirstOrDefault();

            //enviar el modelo a la vista
            return View(modeloVista);
        }
        /// ELIMINA Tipo VEhiculo tipo httpPost
        [HttpPost]
        public ActionResult ServicioOproductoElimina(sp_RetornaServicioOProducto_ID_Result modeloVista)
        {
            ///registra la cantidad de  registros afectados
            ///si un prrocedimiento se ejecuta INSERT, UPDATE, DELETE
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_EliminarTipoServProduc(modeloVista.idServProduc);

            }
            catch (Exception error)
            {

                resultado = "Ocurrio un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado = "Registro Eliminado Correctamente";

                }
                else
                {
                    resultado = "No se pudo Eliminar el Registro";
                }
            }
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);
        }
    }
}