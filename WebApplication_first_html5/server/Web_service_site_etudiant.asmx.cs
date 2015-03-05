using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebApplication_first_html5.database;

namespace WebApplication_first_html5.server
{
    /// <summary>
    /// Summary description for Web_service_site_etudiant
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Web_service_site_etudiant : System.Web.Services.WebService
    {
        public class Cours_prof_Json
        {
            public Cours_prof_Json()
            {
                Cours = new Cours_Json();
                Prof = new Professeurs_Json();
            }

            public Cours_Json Cours { get; set; }
            public Professeurs_Json Prof { get; set; }
        }
        
        
        public class Cours_Json
        {
            public string Name { get; set; }
        }

        public class Professeurs_Json
        {
            public int id { get; set; }
            public string First_name { get; set; }
            public string Last_name { get; set; }
        }

        public class etudiant_Json
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
        public List<etudiant_Json> get_all_etudiant()
        {
            Site_gestion_etudiantEntities context = new Site_gestion_etudiantEntities();

            List<Etudiants> Ma_list_etudiant = new List<Etudiants>();
            List<etudiant_Json> Ma_list_etudiant_Json = new List<etudiant_Json>();

            Ma_list_etudiant = context.Etudiants.ToList();
            foreach (Etudiants e in Ma_list_etudiant)
            {
                etudiant_Json Mon_etudiant_Json_courant = new etudiant_Json();
                Mon_etudiant_Json_courant.Last_name = e.Last_name;
                Mon_etudiant_Json_courant.First_name = e.First_name;
                Mon_etudiant_Json_courant.id = e.id;
                Ma_list_etudiant_Json.Add(Mon_etudiant_Json_courant);
            }

            return Ma_list_etudiant_Json;
        }


        [WebMethod]
        public etudiant_Json get_all_etudiant_details(string id)
        {
            int id_mon_etudiant;
            id_mon_etudiant = Convert.ToInt32(id);
            Site_gestion_etudiantEntities context = new Site_gestion_etudiantEntities();
            Etudiants Mon_etudiant = new Etudiants();
            etudiant_Json Mon_etudiant_Json_courant = new etudiant_Json();
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



        [WebMethod]
        public List<Professeurs_Json> get_all_prof()
        {
            Site_gestion_etudiantEntities context = new Site_gestion_etudiantEntities();

            List<Professeurs> Ma_list_professeur = new List<Professeurs>();
            List<Professeurs_Json> Ma_list_etudiant_Json = new List<Professeurs_Json>();

            Ma_list_professeur = context.Professeurs.ToList();
            foreach (Professeurs prof in Ma_list_professeur)
            {
                Professeurs_Json Mon_prof_Json_courant = new Professeurs_Json();
                Mon_prof_Json_courant.Last_name = prof.Last_name;
                Mon_prof_Json_courant.First_name = prof.First_name;
                Mon_prof_Json_courant.id = prof.id;
                Ma_list_etudiant_Json.Add(Mon_prof_Json_courant);
            }

            return Ma_list_etudiant_Json;
        }


        [WebMethod]
        public List<Cours_prof_Json> get_all_cours_prof()
        {
            Site_gestion_etudiantEntities context = new Site_gestion_etudiantEntities();

            List<Cours_prof_Json> Ma_list_porf_cours_Json = new List<Cours_prof_Json>();
            List<association_prof_cours> Ma_list_porf_cours = new List<association_prof_cours>();
            List<cours> Ma_list_cours = new List<cours>();
            Ma_list_porf_cours = context.association_prof_cours.ToList();
            foreach (association_prof_cours c_p in Ma_list_porf_cours)
            {
                Cours_prof_Json Mon_cours_prof_Json_courant = new Cours_prof_Json();
                Mon_cours_prof_Json_courant.Cours.Name = context.cours.Where(c => c.id == c_p.FK_Cours).FirstOrDefault().name;
                Mon_cours_prof_Json_courant.Prof.First_name = context.Professeurs.Find(c_p.FK_Professeur).First_name;
                Mon_cours_prof_Json_courant.Prof.Last_name = context.Professeurs.Find(c_p.FK_Professeur).Last_name;
                Ma_list_porf_cours_Json.Add(Mon_cours_prof_Json_courant);
            }

            return Ma_list_porf_cours_Json;
        }
    }
}
