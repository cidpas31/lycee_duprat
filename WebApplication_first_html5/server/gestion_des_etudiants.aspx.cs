using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication_first_html5.database;
using System.Windows.Forms;

namespace WebApplication_first_html5.server
{
    public partial class gestion_des_etudiants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Site_gestion_etudiantEntities context = new Site_gestion_etudiantEntities();
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
            MessageBox.Show("etudiant ajouté en database");
            Response.Redirect("../CreerEtudiant.html");
        }

    }
}