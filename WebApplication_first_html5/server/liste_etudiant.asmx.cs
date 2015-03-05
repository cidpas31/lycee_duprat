using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebApplication_first_html5.database;

namespace WebApplication_first_html5.server
{
    /// <summary>
    /// Summary description for liste_etudiant1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class liste_etudiant1 : System.Web.Services.WebService
    {

        public class mon_etudiant_Json
        {
            public int id { get; set; }
            public string date { get; set; }
            public string First_name { get; set; }
            public string Last_name { get; set; }
            public string Age { get; set; }
            public string Phone { get; set; }
            public string Section { get; set; }
            public string Email { get; set; }
        }

        [WebMethod]
        public List<mon_etudiant_Json> get_all_etudiant()
        {
            Site_gestion_etudiantEntities context = new Site_gestion_etudiantEntities();

            List<Etudiants> Ma_list_etudiant = new List<Etudiants>();
            List<mon_etudiant_Json> Ma_list_etudiant_Json = new List<mon_etudiant_Json>();

            Ma_list_etudiant = context.Etudiants.ToList();
            foreach (Etudiants e in Ma_list_etudiant)
            {
                mon_etudiant_Json Mon_etudiant_Json_courant = new mon_etudiant_Json();
                Mon_etudiant_Json_courant.Last_name = e.Last_name;
                Mon_etudiant_Json_courant.First_name = e.First_name;
                Mon_etudiant_Json_courant.id = e.id;
                Ma_list_etudiant_Json.Add(Mon_etudiant_Json_courant);
            }

            return Ma_list_etudiant_Json;
        }


        [WebMethod]
        public mon_etudiant_Json get_all_etudiant_details(string id)
        {
            int id_mon_etudiant;
            id_mon_etudiant = Convert.ToInt32(id);
            Site_gestion_etudiantEntities context = new Site_gestion_etudiantEntities();
            Etudiants Mon_etudiant = new Etudiants();
            mon_etudiant_Json Mon_etudiant_Json_courant = new mon_etudiant_Json();
            Mon_etudiant = context.Etudiants.Where(e => e.id == id_mon_etudiant).FirstOrDefault();
            Mon_etudiant_Json_courant.id = Mon_etudiant.id;
            Mon_etudiant_Json_courant.date = Mon_etudiant.date;
            Mon_etudiant_Json_courant.First_name = Mon_etudiant.First_name;
            Mon_etudiant_Json_courant.Last_name = Mon_etudiant.Last_name;
            Mon_etudiant_Json_courant.Age = Mon_etudiant.Age;
            Mon_etudiant_Json_courant.Phone = Mon_etudiant.Phone;
            Mon_etudiant_Json_courant.Section = Mon_etudiant.Section;
            Mon_etudiant_Json_courant.Email = Mon_etudiant.Email;
            return Mon_etudiant_Json_courant;
        }
    }
}
