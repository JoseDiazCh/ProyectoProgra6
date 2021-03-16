﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class proyectoprogra6Entities : DbContext
    {
        public proyectoprogra6Entities()
            : base("name=proyectoprogra6Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Canton> Canton { get; set; }
        public DbSet<DetalleFactura> DetalleFactura { get; set; }
        public DbSet<Distrito> Distrito { get; set; }
        public DbSet<EncabezadoFactura> EncabezadoFactura { get; set; }
        public DbSet<MarcaVehiculos> MarcaVehiculos { get; set; }
        public DbSet<PaisFabricante> PaisFabricante { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<ServicioOProducto> ServicioOProducto { get; set; }
        public DbSet<TiposVehiculos> TiposVehiculos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Vehiculos> Vehiculos { get; set; }
    
        public virtual int sp_selectUsuFactu(string cedula)
        {
            var cedulaParameter = cedula != null ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_selectUsuFactu", cedulaParameter);
        }
    
        public virtual ObjectResult<sp_SelectVehiculo_Result> sp_SelectVehiculo(Nullable<int> idVehiculo)
        {
            var idVehiculoParameter = idVehiculo.HasValue ?
                new ObjectParameter("idVehiculo", idVehiculo) :
                new ObjectParameter("idVehiculo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SelectVehiculo_Result>("sp_SelectVehiculo", idVehiculoParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_EliminaPaisFabricante(Nullable<int> idPaisFabricante)
        {
            var idPaisFabricanteParameter = idPaisFabricante.HasValue ?
                new ObjectParameter("idPaisFabricante", idPaisFabricante) :
                new ObjectParameter("idPaisFabricante", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EliminaPaisFabricante", idPaisFabricanteParameter);
        }
    
        public virtual int sp_EliminarMarcaVehiculo(Nullable<int> idMarcaVehiculos)
        {
            var idMarcaVehiculosParameter = idMarcaVehiculos.HasValue ?
                new ObjectParameter("idMarcaVehiculos", idMarcaVehiculos) :
                new ObjectParameter("idMarcaVehiculos", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EliminarMarcaVehiculo", idMarcaVehiculosParameter);
        }
    
        public virtual int sp_EliminarTipoServProduc(Nullable<int> idServProduc)
        {
            var idServProducParameter = idServProduc.HasValue ?
                new ObjectParameter("idServProduc", idServProduc) :
                new ObjectParameter("idServProduc", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EliminarTipoServProduc", idServProducParameter);
        }
    
        public virtual int sp_EliminarUsuario(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EliminarUsuario", idUsuarioParameter);
        }
    
        public virtual int sp_EliminarVehiculo(Nullable<int> idVehiculos)
        {
            var idVehiculosParameter = idVehiculos.HasValue ?
                new ObjectParameter("idVehiculos", idVehiculos) :
                new ObjectParameter("idVehiculos", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EliminarVehiculo", idVehiculosParameter);
        }
    
        public virtual int sp_InsertaPaísFabricante(string codigo, string pais)
        {
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            var paisParameter = pais != null ?
                new ObjectParameter("Pais", pais) :
                new ObjectParameter("Pais", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertaPaísFabricante", codigoParameter, paisParameter);
        }
    
        public virtual int sp_InsertarMarcaVehiculos(string codigo, string tipo, Nullable<int> idPaisFabricante)
        {
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(string));
    
            var idPaisFabricanteParameter = idPaisFabricante.HasValue ?
                new ObjectParameter("idPaisFabricante", idPaisFabricante) :
                new ObjectParameter("idPaisFabricante", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertarMarcaVehiculos", codigoParameter, tipoParameter, idPaisFabricanteParameter);
        }
    
        public virtual int sp_ModificaMarcaVehiculos(Nullable<int> idMarcaVehiculos, string codigo, string tipo, Nullable<int> idPaisFabricante)
        {
            var idMarcaVehiculosParameter = idMarcaVehiculos.HasValue ?
                new ObjectParameter("idMarcaVehiculos", idMarcaVehiculos) :
                new ObjectParameter("idMarcaVehiculos", typeof(int));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(string));
    
            var idPaisFabricanteParameter = idPaisFabricante.HasValue ?
                new ObjectParameter("idPaisFabricante", idPaisFabricante) :
                new ObjectParameter("idPaisFabricante", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ModificaMarcaVehiculos", idMarcaVehiculosParameter, codigoParameter, tipoParameter, idPaisFabricanteParameter);
        }
    
        public virtual int sp_ModificaPaisFabricante(Nullable<int> idPaisFabricante, string codigo, string pais)
        {
            var idPaisFabricanteParameter = idPaisFabricante.HasValue ?
                new ObjectParameter("idPaisFabricante", idPaisFabricante) :
                new ObjectParameter("idPaisFabricante", typeof(int));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            var paisParameter = pais != null ?
                new ObjectParameter("Pais", pais) :
                new ObjectParameter("Pais", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ModificaPaisFabricante", idPaisFabricanteParameter, codigoParameter, paisParameter);
        }
    
        public virtual int sp_ModificaUsuarios(Nullable<int> idUsuario, Nullable<int> cedula, string genero, Nullable<System.DateTime> fechaNacimiento, string nombre, string apellido1, string apellido2, string correo, string tipoUsuario, Nullable<int> id_Provincia, Nullable<int> id_Canton, Nullable<int> id_Distrito, string contrasenia)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(int));
    
            var generoParameter = genero != null ?
                new ObjectParameter("Genero", genero) :
                new ObjectParameter("Genero", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(System.DateTime));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellido1Parameter = apellido1 != null ?
                new ObjectParameter("Apellido1", apellido1) :
                new ObjectParameter("Apellido1", typeof(string));
    
            var apellido2Parameter = apellido2 != null ?
                new ObjectParameter("Apellido2", apellido2) :
                new ObjectParameter("Apellido2", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var tipoUsuarioParameter = tipoUsuario != null ?
                new ObjectParameter("TipoUsuario", tipoUsuario) :
                new ObjectParameter("TipoUsuario", typeof(string));
    
            var id_ProvinciaParameter = id_Provincia.HasValue ?
                new ObjectParameter("id_Provincia", id_Provincia) :
                new ObjectParameter("id_Provincia", typeof(int));
    
            var id_CantonParameter = id_Canton.HasValue ?
                new ObjectParameter("id_Canton", id_Canton) :
                new ObjectParameter("id_Canton", typeof(int));
    
            var id_DistritoParameter = id_Distrito.HasValue ?
                new ObjectParameter("id_Distrito", id_Distrito) :
                new ObjectParameter("id_Distrito", typeof(int));
    
            var contraseniaParameter = contrasenia != null ?
                new ObjectParameter("Contrasenia", contrasenia) :
                new ObjectParameter("Contrasenia", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ModificaUsuarios", idUsuarioParameter, cedulaParameter, generoParameter, fechaNacimientoParameter, nombreParameter, apellido1Parameter, apellido2Parameter, correoParameter, tipoUsuarioParameter, id_ProvinciaParameter, id_CantonParameter, id_DistritoParameter, contraseniaParameter);
        }
    
        public virtual ObjectResult<sp_RetornaCantones_Result> sp_RetornaCantones(string nombre, Nullable<int> id_Provincia)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var id_ProvinciaParameter = id_Provincia.HasValue ?
                new ObjectParameter("id_Provincia", id_Provincia) :
                new ObjectParameter("id_Provincia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaCantones_Result>("sp_RetornaCantones", nombreParameter, id_ProvinciaParameter);
        }
    
        public virtual ObjectResult<sp_RetornaCantones_ID_Result> sp_RetornaCantones_ID(Nullable<int> id_Canton)
        {
            var id_CantonParameter = id_Canton.HasValue ?
                new ObjectParameter("id_Canton", id_Canton) :
                new ObjectParameter("id_Canton", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaCantones_ID_Result>("sp_RetornaCantones_ID", id_CantonParameter);
        }
    
        public virtual ObjectResult<sp_RetornaMarcaVehiculo_ID_Result> sp_RetornaMarcaVehiculo_ID(Nullable<int> idMarcaVehiculos)
        {
            var idMarcaVehiculosParameter = idMarcaVehiculos.HasValue ?
                new ObjectParameter("idMarcaVehiculos", idMarcaVehiculos) :
                new ObjectParameter("idMarcaVehiculos", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaMarcaVehiculo_ID_Result>("sp_RetornaMarcaVehiculo_ID", idMarcaVehiculosParameter);
        }
    
        public virtual ObjectResult<sp_RetornaPaísFabricante_Result> sp_RetornaPaísFabricante(string codigo, string pais)
        {
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            var paisParameter = pais != null ?
                new ObjectParameter("Pais", pais) :
                new ObjectParameter("Pais", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaPaísFabricante_Result>("sp_RetornaPaísFabricante", codigoParameter, paisParameter);
        }
    
        public virtual ObjectResult<sp_RetornaPaísFabricante_ID_Result> sp_RetornaPaísFabricante_ID(Nullable<int> idPaisFabricante)
        {
            var idPaisFabricanteParameter = idPaisFabricante.HasValue ?
                new ObjectParameter("idPaisFabricante", idPaisFabricante) :
                new ObjectParameter("idPaisFabricante", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaPaísFabricante_ID_Result>("sp_RetornaPaísFabricante_ID", idPaisFabricanteParameter);
        }
    
        public virtual ObjectResult<sp_RetornaProvincias_Result> sp_RetornaProvincias(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaProvincias_Result>("sp_RetornaProvincias", nombreParameter);
        }
    
        public virtual int sp_RetornaProvincias_ID(Nullable<int> id_Provincia)
        {
            var id_ProvinciaParameter = id_Provincia.HasValue ?
                new ObjectParameter("id_Provincia", id_Provincia) :
                new ObjectParameter("id_Provincia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_RetornaProvincias_ID", id_ProvinciaParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<sp_RetornaDistritos_Result> sp_RetornaDistritos(string nombre, Nullable<int> id_Canton)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var id_CantonParameter = id_Canton.HasValue ?
                new ObjectParameter("id_Canton", id_Canton) :
                new ObjectParameter("id_Canton", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaDistritos_Result>("sp_RetornaDistritos", nombreParameter, id_CantonParameter);
        }
    
        public virtual ObjectResult<sp_RetornaDistritos_ID_Result> sp_RetornaDistritos_ID(Nullable<int> id_Distrito)
        {
            var id_DistritoParameter = id_Distrito.HasValue ?
                new ObjectParameter("id_Distrito", id_Distrito) :
                new ObjectParameter("id_Distrito", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaDistritos_ID_Result>("sp_RetornaDistritos_ID", id_DistritoParameter);
        }
    
        public virtual int sp_InsertaUsuarios(Nullable<int> cedula, string genero, Nullable<System.DateTime> fechaNacimiento, string nombre, string apellido1, string apellido2, string correo, string tipoUsuario, Nullable<int> id_Provincia, Nullable<int> id_Canton, Nullable<int> id_Distrito, string contrasenia)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(int));
    
            var generoParameter = genero != null ?
                new ObjectParameter("Genero", genero) :
                new ObjectParameter("Genero", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(System.DateTime));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellido1Parameter = apellido1 != null ?
                new ObjectParameter("Apellido1", apellido1) :
                new ObjectParameter("Apellido1", typeof(string));
    
            var apellido2Parameter = apellido2 != null ?
                new ObjectParameter("Apellido2", apellido2) :
                new ObjectParameter("Apellido2", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var tipoUsuarioParameter = tipoUsuario != null ?
                new ObjectParameter("TipoUsuario", tipoUsuario) :
                new ObjectParameter("TipoUsuario", typeof(string));
    
            var id_ProvinciaParameter = id_Provincia.HasValue ?
                new ObjectParameter("id_Provincia", id_Provincia) :
                new ObjectParameter("id_Provincia", typeof(int));
    
            var id_CantonParameter = id_Canton.HasValue ?
                new ObjectParameter("id_Canton", id_Canton) :
                new ObjectParameter("id_Canton", typeof(int));
    
            var id_DistritoParameter = id_Distrito.HasValue ?
                new ObjectParameter("id_Distrito", id_Distrito) :
                new ObjectParameter("id_Distrito", typeof(int));
    
            var contraseniaParameter = contrasenia != null ?
                new ObjectParameter("Contrasenia", contrasenia) :
                new ObjectParameter("Contrasenia", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertaUsuarios", cedulaParameter, generoParameter, fechaNacimientoParameter, nombreParameter, apellido1Parameter, apellido2Parameter, correoParameter, tipoUsuarioParameter, id_ProvinciaParameter, id_CantonParameter, id_DistritoParameter, contraseniaParameter);
        }
    
        public virtual ObjectResult<sp_RetornaTiposVehiculos_ID_Result> sp_RetornaTiposVehiculos_ID(Nullable<int> idTipoVehiculo)
        {
            var idTipoVehiculoParameter = idTipoVehiculo.HasValue ?
                new ObjectParameter("idTipoVehiculo", idTipoVehiculo) :
                new ObjectParameter("idTipoVehiculo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaTiposVehiculos_ID_Result>("sp_RetornaTiposVehiculos_ID", idTipoVehiculoParameter);
        }
    
        public virtual ObjectResult<sp_RetornaVehiculos_Result> sp_RetornaVehiculos(string placa)
        {
            var placaParameter = placa != null ?
                new ObjectParameter("Placa", placa) :
                new ObjectParameter("Placa", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaVehiculos_Result>("sp_RetornaVehiculos", placaParameter);
        }
    
        public virtual ObjectResult<sp_RetornaMarcaVehiculo_Result> sp_RetornaMarcaVehiculo(string codigo, string tipo)
        {
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaMarcaVehiculo_Result>("sp_RetornaMarcaVehiculo", codigoParameter, tipoParameter);
        }
    
        public virtual ObjectResult<sp_RetornaTiposVehiculos_Result> sp_RetornaTiposVehiculos(string codigo, string tipo)
        {
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaTiposVehiculos_Result>("sp_RetornaTiposVehiculos", codigoParameter, tipoParameter);
        }
    
        public virtual int sp_ModificaTiposVehiculos(Nullable<int> idTipoVehiculo, string codigo, string tipo)
        {
            var idTipoVehiculoParameter = idTipoVehiculo.HasValue ?
                new ObjectParameter("idTipoVehiculo", idTipoVehiculo) :
                new ObjectParameter("idTipoVehiculo", typeof(int));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ModificaTiposVehiculos", idTipoVehiculoParameter, codigoParameter, tipoParameter);
        }
    
        public virtual int sp_InsertaTiposVehiculos(string codigo, string tipo)
        {
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertaTiposVehiculos", codigoParameter, tipoParameter);
        }
    
        public virtual int sp_EliminaTipoVehiculos(Nullable<int> idTipoVehiculo)
        {
            var idTipoVehiculoParameter = idTipoVehiculo.HasValue ?
                new ObjectParameter("idTipoVehiculo", idTipoVehiculo) :
                new ObjectParameter("idTipoVehiculo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EliminaTipoVehiculos", idTipoVehiculoParameter);
        }
    
        public virtual int sp_InsertaVehiculos(string placa, Nullable<int> numeroPuertas, Nullable<int> numeroRuedas, Nullable<int> idMarcaVehiculos, Nullable<int> idTipoVehiculo)
        {
            var placaParameter = placa != null ?
                new ObjectParameter("Placa", placa) :
                new ObjectParameter("Placa", typeof(string));
    
            var numeroPuertasParameter = numeroPuertas.HasValue ?
                new ObjectParameter("NumeroPuertas", numeroPuertas) :
                new ObjectParameter("NumeroPuertas", typeof(int));
    
            var numeroRuedasParameter = numeroRuedas.HasValue ?
                new ObjectParameter("NumeroRuedas", numeroRuedas) :
                new ObjectParameter("NumeroRuedas", typeof(int));
    
            var idMarcaVehiculosParameter = idMarcaVehiculos.HasValue ?
                new ObjectParameter("idMarcaVehiculos", idMarcaVehiculos) :
                new ObjectParameter("idMarcaVehiculos", typeof(int));
    
            var idTipoVehiculoParameter = idTipoVehiculo.HasValue ?
                new ObjectParameter("idTipoVehiculo", idTipoVehiculo) :
                new ObjectParameter("idTipoVehiculo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertaVehiculos", placaParameter, numeroPuertasParameter, numeroRuedasParameter, idMarcaVehiculosParameter, idTipoVehiculoParameter);
        }
    
        public virtual int sp_InsertaServProduc(string codigo, string descripcion, string precio, string tipo)
        {
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var precioParameter = precio != null ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(string));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertaServProduc", codigoParameter, descripcionParameter, precioParameter, tipoParameter);
        }
    
        public virtual ObjectResult<sp_RetornaServicioOProducto_Result> sp_RetornaServicioOProducto(string descripcion, string tipo)
        {
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaServicioOProducto_Result>("sp_RetornaServicioOProducto", descripcionParameter, tipoParameter);
        }
    
        public virtual ObjectResult<sp_RetornaVehiculos_ID_Result> sp_RetornaVehiculos_ID(Nullable<int> idVehiculo)
        {
            var idVehiculoParameter = idVehiculo.HasValue ?
                new ObjectParameter("idVehiculo", idVehiculo) :
                new ObjectParameter("idVehiculo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaVehiculos_ID_Result>("sp_RetornaVehiculos_ID", idVehiculoParameter);
        }
    
        public virtual int sp_ModificaVehiculo(Nullable<int> idVehiculo, string placa, Nullable<int> numeroPuertas, Nullable<int> numeroRuedas, Nullable<int> idMarcaVehiculos, Nullable<int> idTipoVehiculo)
        {
            var idVehiculoParameter = idVehiculo.HasValue ?
                new ObjectParameter("idVehiculo", idVehiculo) :
                new ObjectParameter("idVehiculo", typeof(int));
    
            var placaParameter = placa != null ?
                new ObjectParameter("Placa", placa) :
                new ObjectParameter("Placa", typeof(string));
    
            var numeroPuertasParameter = numeroPuertas.HasValue ?
                new ObjectParameter("NumeroPuertas", numeroPuertas) :
                new ObjectParameter("NumeroPuertas", typeof(int));
    
            var numeroRuedasParameter = numeroRuedas.HasValue ?
                new ObjectParameter("NumeroRuedas", numeroRuedas) :
                new ObjectParameter("NumeroRuedas", typeof(int));
    
            var idMarcaVehiculosParameter = idMarcaVehiculos.HasValue ?
                new ObjectParameter("idMarcaVehiculos", idMarcaVehiculos) :
                new ObjectParameter("idMarcaVehiculos", typeof(int));
    
            var idTipoVehiculoParameter = idTipoVehiculo.HasValue ?
                new ObjectParameter("idTipoVehiculo", idTipoVehiculo) :
                new ObjectParameter("idTipoVehiculo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ModificaVehiculo", idVehiculoParameter, placaParameter, numeroPuertasParameter, numeroRuedasParameter, idMarcaVehiculosParameter, idTipoVehiculoParameter);
        }
    
        public virtual ObjectResult<sp_RetornaServicioOProducto_ID_Result> sp_RetornaServicioOProducto_ID(Nullable<int> idServProduc)
        {
            var idServProducParameter = idServProduc.HasValue ?
                new ObjectParameter("idServProduc", idServProduc) :
                new ObjectParameter("idServProduc", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaServicioOProducto_ID_Result>("sp_RetornaServicioOProducto_ID", idServProducParameter);
        }
    
        public virtual int sp_ModificaTipoServProduc(Nullable<int> idServProduc, string codigo, string descripcion, string precio, string tipo)
        {
            var idServProducParameter = idServProduc.HasValue ?
                new ObjectParameter("idServProduc", idServProduc) :
                new ObjectParameter("idServProduc", typeof(int));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var precioParameter = precio != null ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(string));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ModificaTipoServProduc", idServProducParameter, codigoParameter, descripcionParameter, precioParameter, tipoParameter);
        }
    
        public virtual ObjectResult<sp_RetornaUsuarios_ID_Result> sp_RetornaUsuarios_ID(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaUsuarios_ID_Result>("sp_RetornaUsuarios_ID", idUsuarioParameter);
        }
    
        public virtual ObjectResult<sp_RetornaUsuarios_Result> sp_RetornaUsuarios(string apellido1, string nombre)
        {
            var apellido1Parameter = apellido1 != null ?
                new ObjectParameter("Apellido1", apellido1) :
                new ObjectParameter("Apellido1", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaUsuarios_Result>("sp_RetornaUsuarios", apellido1Parameter, nombreParameter);
        }
    }
}
