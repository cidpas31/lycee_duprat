﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lycee_duprat_data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SchoolDataBaseEntities : DbContext
    {
        public SchoolDataBaseEntities()
            : base("name=SchoolDataBaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cours> cours { get; set; }
        public virtual DbSet<etudiant_cours> etudiant_cours { get; set; }
        public virtual DbSet<etudiants> etudiants { get; set; }
        public virtual DbSet<examens> examens { get; set; }
        public virtual DbSet<professeur_cours> professeur_cours { get; set; }
        public virtual DbSet<professeurs> professeurs { get; set; }
        public virtual DbSet<sections> sections { get; set; }
    }
}
