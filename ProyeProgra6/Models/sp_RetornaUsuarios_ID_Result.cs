//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyeProgra6.Models
{
    using System;
    
    public partial class sp_RetornaUsuarios_ID_Result
    {
        public int idUsuario { get; set; }
        public int Cedula { get; set; }
        public string Genero { get; set; }
        public string descripcionGenero { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Correo { get; set; }
        public string TipoUsuario { get; set; }
        public int id_Provincia { get; set; }
        public string nombreProvincia { get; set; }
        public int id_Canton { get; set; }
        public string nombreCanton { get; set; }
        public int id_Distrito { get; set; }
        public string nombreDistrito { get; set; }
        public string Contrasenia { get; set; }
    }
}
