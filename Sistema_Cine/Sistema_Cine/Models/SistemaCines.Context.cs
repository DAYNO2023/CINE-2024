﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sistema_Cine.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class dbSsitemascinesEntities5 : DbContext
    {
        public dbSsitemascinesEntities5()
            : base("name=dbSsitemascinesEntities5")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbPantalla_Roles> tbPantalla_Roles { get; set; }
        public virtual DbSet<tbPantallas> tbPantallas { get; set; }
        public virtual DbSet<tbRoles> tbRoles { get; set; }
        public virtual DbSet<tbUsuarios> tbUsuarios { get; set; }
        public virtual DbSet<tbCarteleras> tbCarteleras { get; set; }
        public virtual DbSet<tbEntradas> tbEntradas { get; set; }
        public virtual DbSet<tbSucursales> tbSucursales { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tbFacturas_Detalles> tbFacturas_Detalles { get; set; }
        public virtual DbSet<tbFacturas_Encabezados> tbFacturas_Encabezados { get; set; }
        public virtual DbSet<tbButacas_Salas> tbButacas_Salas { get; set; }
        public virtual DbSet<tbCargos> tbCargos { get; set; }
        public virtual DbSet<tbDepartamentos> tbDepartamentos { get; set; }
        public virtual DbSet<tbEstado_Civil> tbEstado_Civil { get; set; }
        public virtual DbSet<tbGeneros> tbGeneros { get; set; }
        public virtual DbSet<tbMunicipio> tbMunicipio { get; set; }
        public virtual DbSet<tbPrecios> tbPrecios { get; set; }
        public virtual DbSet<tbPromociones> tbPromociones { get; set; }
        public virtual DbSet<tbSalas> tbSalas { get; set; }
        public virtual DbSet<tbTipo_Pagos> tbTipo_Pagos { get; set; }
        public virtual DbSet<tbClientes> tbClientes { get; set; }
        public virtual DbSet<tbEmpleados> tbEmpleados { get; set; }
    
        public virtual ObjectResult<SP_tbUsuarios_InicioSesion_Result> SP_tbUsuarios_InicioSesion(string usuario, string contra)
        {
            var usuarioParameter = usuario != null ?
                new ObjectParameter("Usuario", usuario) :
                new ObjectParameter("Usuario", typeof(string));
    
            var contraParameter = contra != null ?
                new ObjectParameter("Contra", contra) :
                new ObjectParameter("Contra", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_tbUsuarios_InicioSesion_Result>("SP_tbUsuarios_InicioSesion", usuarioParameter, contraParameter);
        }
    }
}
