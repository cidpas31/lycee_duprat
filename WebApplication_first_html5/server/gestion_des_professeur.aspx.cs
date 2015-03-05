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
    public partial class gestion_des_professeur : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Site_gestion_etudiantEntities context = new Site_gestion_etudiantEntities();
            Professeurs Mon_prof = new Professeurs();
            //attention dans La reqest IL faut mettre le name de ma Text box html tout ce qui passe est un string
            Mon_prof.First_name = Request.Form["FirstName"];
            Mon_prof.Last_name = Request.Form["LastName"];
            Mon_prof.Age = Convert.ToInt32(Request.Form["Age"]);
            Mon_prof.Phone = Request.Form["Phone"];
            Mon_prof.Email = Request.Form["EmailAddress"];
            context.Professeurs.Add(Mon_prof);
            context.SaveChanges();
            MessageBox.Show("porf ajouté en database");
            Response.Redirect("../CreerProfesseur.html");

        }
    }
}