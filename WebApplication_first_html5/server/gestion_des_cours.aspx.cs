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
    public partial class gestion_des_cours : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Site_gestion_etudiantEntities context = new Site_gestion_etudiantEntities();
            cours Mon_cours = new cours();
            int id_prof;
            int id_cours;
            //attention dans La reqest IL faut mettre le name de ma Text box html tout ce qui passe est un string
            Mon_cours.name = Request.Form["Nomducours"];
            id_prof = Convert.ToInt32(Request.Form["prof_select"]);
            context.cours.Add(Mon_cours);
            context.SaveChanges();
            //en faite je sui obliger de sauver mon context pour mon cours puisse avoir un id que je recupere ensuite
            id_cours = context.cours.Where(cour => cour.name == Mon_cours.name).FirstOrDefault().id;
            association_prof_cours mon_prof_cours = new association_prof_cours() { FK_Cours = id_cours, FK_Professeur = id_prof };
            context.association_prof_cours.Add(mon_prof_cours);
            context.SaveChanges();
            MessageBox.Show("cours ajouté en database et associé");
            Response.Redirect("../Creercours.html");
        }
    }
}