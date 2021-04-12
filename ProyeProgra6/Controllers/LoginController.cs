using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyeProgra6.Models;

namespace ProyeProgra6.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// coneccion a la base de datos
        /// </summary>
        proyectoprogra6Entities modeloBD = new proyectoprogra6Entities();

        // GET: Login
        public ActionResult InicioSesion()
        {
            return View();
        }

        public ActionResult Validar(string pCorreo, string pContrasenia)
        {
            bool result = this.Validarusuario(pCorreo, pContrasenia);

            return Json(new
            {

                resultado = result

            });
        }

        private bool Validarusuario(string pcorreo, string pcontrasenia)
        {
            //Session["correoVista"] = correo;
            //string url = "";
            //string mensaje = "";
            //try
            {
                List<sp_RetornaUsuarios_Result> datosCliente = new List<sp_RetornaUsuarios_Result>();
                datosCliente = modeloBD.sp_RetornaUsuarios(null, null).ToList();

                bool UsuarioVerificado = false;

                for (int i = 0; i < datosCliente.Count; i++)
                {
                    if (datosCliente[i].Correo.Equals(pcorreo)&& datosCliente[i].Contrasenia.Equals(pcontrasenia))
                    {
                        this.Session.Add("idclienteLogueado", datosCliente[i].idUsuario);
                        this.Session.Add("tipocliente", datosCliente[i].TipoUsuario);

                    }

                }

                return UsuarioVerificado;


            }
        }
    }
}