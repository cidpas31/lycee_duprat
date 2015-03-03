using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication_first_html5.database;

namespace WebApplication_first_html5.server
{
    public partial class gestion_des_etudiants : System.Web.UI.Page
    {
        
        private Site_gestion_etudiantEntities context = new Site_gestion_etudiantEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            Etudiants Mon_etudiant = new Etudiants();
            //attention dans La reqest IL faut mettre le name de ma Text box html tout ce qui passe est un string
            Mon_etudiant.date = Request.Form["dateofsubscription"];
            Mon_etudiant.First_name = Request.Form["FirstName"];
            Mon_etudiant.Last_name = Request.Form["LastName"];
            Mon_etudiant.Age = Request.Form["Age"];
            Mon_etudiant.Phone = Request.Form["Phone"];
            Mon_etudiant.Section = Request.Form["section_select"];
            Mon_etudiant.Email = Request.Form["EmailAddress"];
            context.Etudiants.Add(Mon_etudiant);
            context.SaveChanges();
            Response.Redirect("../CreerEtudiant.html");
            //lbl.Text = "Mon etudiant :" + Mon_etudiant.first_name +
            //    ", " + Mon_etudiant.last_name + ". il a :" + Mon_etudiant.age +
            //    ". On peut le joindre au " + Mon_etudiant.phone + 
            //    ". Il est en " + Mon_etudiant.section + ". Son adresse mail est : " + Mon_etudiant.email_adresse; 
            //if(Mon_etudiant.date_de_souscription != null)
            //{
            //    lbl.Text += ". L'enregistrement a eu lieu à :" + Mon_etudiant.date_de_souscription;
            //}

        }
    }
}