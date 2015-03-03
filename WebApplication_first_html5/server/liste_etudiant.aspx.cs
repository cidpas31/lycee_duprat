using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication_first_html5.database;

namespace WebApplication_first_html5.server
{
    [System.Web.Script.Services.ScriptService]
    public partial class liste_etudiant : System.Web.UI.Page
    {
       


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static List<Etudiants> get_all()
        {
            Site_gestion_etudiantEntities context = new Site_gestion_etudiantEntities();
            List<Etudiants> Ma_list_etudiant = new List<Etudiants>();

            Ma_list_etudiant = context.Etudiants.ToList();

            return Ma_list_etudiant;
        }


        [System.Web.Services.WebMethod]
        public static List<cours> get_all_cours(int id)
        {
            Site_gestion_etudiantEntities context = new Site_gestion_etudiantEntities();
            List<association_etudiant_cours> Ma_list_etudiant_cours = new List<association_etudiant_cours>();
            List<cours> Ma_list_cours = new List<cours>();
            Ma_list_etudiant_cours = context.association_etudiant_cours.Where(e => e.FK_etudians == id).ToList();
            foreach (association_etudiant_cours c in Ma_list_etudiant_cours)
            {
                Ma_list_cours.Add(c.cours);
            }
            return Ma_list_cours;
        }
    }
}