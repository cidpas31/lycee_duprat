﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication_first_html5.database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Site_gestion_etudiantEntities : DbContext
    {
        public Site_gestion_etudiantEntities()
            : base("name=Site_gestion_etudiantEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<association_etudiant_cours> association_etudiant_cours { get; set; }
        public virtual DbSet<association_prof_cours> association_prof_cours { get; set; }
        public virtual DbSet<cours> cours { get; set; }
        public virtual DbSet<Etudiants> Etudiants { get; set; }
        public virtual DbSet<Name_Password> Name_Password { get; set; }
        public virtual DbSet<Professeurs> Professeurs { get; set; }
    }
}
