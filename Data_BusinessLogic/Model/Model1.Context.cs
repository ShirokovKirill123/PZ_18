﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data_BusinessLogic.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EquipmentRepairSystemEntities4 : DbContext
    {
        public EquipmentRepairSystemEntities4()
            : base("name=EquipmentRepairSystemEntities4")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<Masters> Masters { get; set; }
        public virtual DbSet<RepairParts> RepairParts { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Specializations> Specializations { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
