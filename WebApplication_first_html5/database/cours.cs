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
    
    public partial class cours
    {
        public cours()
        {
            this.association_etudiant_cours = new HashSet<association_etudiant_cours>();
            this.association_prof_cours = new HashSet<association_prof_cours>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<association_etudiant_cours> association_etudiant_cours { get; set; }
        public virtual ICollection<association_prof_cours> association_prof_cours { get; set; }
    }
}
