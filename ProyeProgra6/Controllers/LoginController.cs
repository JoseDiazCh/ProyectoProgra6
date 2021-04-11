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

        public ActionResult Validar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Validar(string correo, string contrasenia)
        {
            Session["correoVista"] = correo;
            string url = "";
            string mensaje = "";
            try
            {
                sp_RetornaUsuarios_Result datosCliente = new sp_RetornaUsuarios_Result();
                datosCliente = modeloBD.sp_RetornaUsuarios(correo, contrasenia).FirstOrDefault();

                if (datosCliente == null)
                {
                    Response.Write("<script>alert('Datos Invalidos')</script>"); ;
                    this.Session.Add("Nombre", null);
                    this.Session.Add("Tipo", null);
                    this.Session.Add("Fecha", null);
                    this.Session.Add("UsuarioLogeado", null);
                }
                else
                {

                    Session.Add("Nombre", datosCliente.@Nombre);
                    Session.Add("Tipo", datosCliente.@TipoUsuario);
                    Session.Add("Fecha", datosCliente.@FechaNacimiento);
                    Session.Add("UsuarioLogeado", true);

                    if (Convert.ToInt32(this.Session["Tipo"]) == 1)
                    {
                        url = Url.Action("Inicio", "Home");
                        //Response.Redirect("~/Factura/ListaPreFactura");
                    }
                    else if (Convert.ToInt32(this.Session["Tipo"]) == 2)
                    {
                        url = Url.Action("ClientesVistaLista", "ClienteVista");
                        //this.Response.Redirect("~/Servicios/ServicioLista");
                    }
                    mensaje = "Usted ha ingresado: " + Session["Nombre"];
                }
            }
            catch (Exception excepcionCapturada)
            {
                mensaje += $"Ocurrio un error:{excepcionCapturada.Message}";
            }

            return Json(new { resultado = mensaje, validado = Session["UsuarioLogeado"], url = url });


        }
    }
}
