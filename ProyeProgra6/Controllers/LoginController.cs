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

            string mensaje=""; 

            if (result)
            {
                mensaje = "Inicio de Sesion Correcto";
            }else
            {
                mensaje = "Inicio de Sesion Incorrecto";
            }

            return Json(new
            {

                resultado = mensaje,
                estado = result

            }); 
        }

        private bool Validarusuario(string pcorreo, string pcontrasenia)
        {

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
                        UsuarioVerificado = true;
                    }

                }
            
                return UsuarioVerificado;


            }
        }
        public ActionResult CerrarSesionCliente()
        {
            int idUsuarioLogueado = Convert.ToInt32(this.Session["idclienteLogueado"]);

            string msj = "";
            if (idUsuarioLogueado > 0)
            {
                msj = "L";
                this.Session.Add("idClienteLoguedo", 0);
            }

            return Json(new
            {
                resultado = msj
            });
        }
        public ActionResult MostrarInfoUsuario()
        {
            int idUsuarioLogueado = Convert.ToInt32(this.Session["idClienteLogueado"]);
            List<sp_RetornaUsuarios_ID_Result> modeloCliente = this.modeloBD.sp_RetornaUsuarios_ID(idUsuarioLogueado).ToList();

            string msj = "";
            int idUsuario = 0;
            string tipoUsuarioConectado;
            ///Validar Si La Variable De Session Esta Vacia
            if (this.Session["tipoCliente"] == null)
            {
                tipoUsuarioConectado = "vacio";
            }
            else
            {
                tipoUsuarioConectado = this.Session["tipoCliente"].ToString();
            }

            ///Del Usuario Que Inicio Sesion, Por Medio
            ///De La variable De Sesion Obtener Los Datos.
            /// Recorrer Lista De Usuario Obtenido Por ID
            /// Obtener ID y El Nombre De Usuario
            for (int i = 0; i < modeloCliente.Count; i++)
            {
                msj = modeloCliente[i].Nombre+" "+modeloCliente[i].Apellido1+" "+ modeloCliente[i].Apellido2;
                idUsuario = modeloCliente[i].idUsuario;
            }

            return Json(new
            {
                resultado = msj,
                usuarioActual = idUsuario,
                tipoUsuario = tipoUsuarioConectado
            });
        }

    }
}



