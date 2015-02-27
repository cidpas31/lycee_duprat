using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_first_html5.server
{
    public partial class gestion_des_etudiants : System.Web.UI.Page
    {
        public class Etudiant
        {
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string age { get; set; }
            public string phone { get; set; }
            public string section { get; set; }
            public string email_adresse { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Etudiant Mon_etudiant = new Etudiant();
            //attention dans La reqest IL faut mettre le name de ma Text box html tout ce qui passe est un string
            Mon_etudiant.first_name = Request.Form["FirstName"];
            Mon_etudiant.last_name = Request.Form["LastName"];
            Mon_etudiant.age = Request.Form["Age"];
            Mon_etudiant.phone = Request.Form["Phone"];
            Mon_etudiant.section = Request.Form["section_select"];
            Mon_etudiant.email_adresse = Request.Form["EmailAddress"];
            lbl.Text = "Mon etudiant :" + Mon_etudiant.first_name +
                ", " + Mon_etudiant.last_name + ". il a :" + Mon_etudiant.age +
                ". On peut le joindre au " + Mon_etudiant.phone + 
                ". Il est en " + Mon_etudiant.section + ". Son adresse mail est : " + Mon_etudiant.email_adresse; 
        }
    }
}