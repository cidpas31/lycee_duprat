//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class association_etudiant_cours
    {
        public int FK_cours { get; set; }
        public int FK_etudians { get; set; }
        public string association_table { get; set; }
    
        public virtual cours cours { get; set; }
        public virtual Etudiants Etudiants { get; set; }
    }
}
