﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TelerikGridMVC.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class TelerikEntities : DbContext
    {
        public TelerikEntities()
            : base("name=TelerikEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Product> Products { get; set; }
    
        public virtual ObjectResult<SelectAllProducts_Result> SelectAllProducts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectAllProducts_Result>("SelectAllProducts");
        }
    }
}
