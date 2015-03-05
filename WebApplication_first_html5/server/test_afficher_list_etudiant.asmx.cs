using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebApplication_first_html5.database;

namespace WebApplication_first_html5.server
{
    /// <summary>
    /// Summary description for test_afficher_list_etudiant
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class test_afficher_list_etudiant : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        private static Site_gestion_etudiantEntities context = new Site_gestion_etudiantEntities();

        [WebMethod]
        public List<string> get_all_name()
        {
            List<Etudiants> Ma_list_etudiant = new List<Etudiants>();
            List<string> Ma_list_de_nom = new List<string>();
            Ma_list_etudiant = context.Etudiants.ToList();
            foreach (Etudiants etu in Ma_list_etudiant)
            {
                Ma_list_de_nom.Add(etu.First_name.ToString());
            }
            return Ma_list_de_nom;
        }
    }
}
