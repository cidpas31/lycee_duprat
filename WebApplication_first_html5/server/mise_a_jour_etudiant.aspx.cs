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
    public partial class mise_a_jour_etudiant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Etudiants Mon_etudiant_modifié = new Etudiants();
            //attention dans La reqest IL faut mettre le name de ma Text box html tout ce qui passe est un string
            Mon_etudiant_modifié.date_modif = Request.Form["dateofmodification"];
            Mon_etudiant_modifié.First_name = Request.Form["FirstName"];
            Mon_etudiant_modifié.Last_name = Request.Form["LastName"];
            Mon_etudiant_modifié.Age = Request.Form["Age_number"];
            Mon_etudiant_modifié.Phone = Request.Form["Phone"];
            Mon_etudiant_modifié.Section = Request.Form["Section_select"];
            Mon_etudiant_modifié.Email = Request.Form["EmailAddress"];
            Mon_etudiant_modifié.id = Convert.ToInt32(Request.Form["Id"]);

            bool change = false;
            Etudiants etudiant_avant_modif = new Etudiants();
            Site_gestion_etudiantEntities context = new Site_gestion_etudiantEntities();
            etudiant_avant_modif = context.Etudiants.Where(etu => etu.id == Mon_etudiant_modifié.id).FirstOrDefault();
            //maintenant il faut que je trouve la modificaiton faite sur mon etudaint je compare les champ u a un
            if (Mon_etudiant_modifié.First_name != etudiant_avant_modif.First_name)
            {
                context.Etudiants.Find(Mon_etudiant_modifié.id).First_name = Mon_etudiant_modifié.First_name;
                change = true;
            }
            if (Mon_etudiant_modifié.Last_name != etudiant_avant_modif.Last_name)
            {
                context.Etudiants.Find(Mon_etudiant_modifié.id).Last_name = Mon_etudiant_modifié.Last_name;
                change = true;
            }
            if (Mon_etudiant_modifié.Age != etudiant_avant_modif.Age)
            {
                context.Etudiants.Find(Mon_etudiant_modifié.id).Age = Mon_etudiant_modifié.Age;
                change = true;
            }
            if (Mon_etudiant_modifié.Phone != etudiant_avant_modif.Phone)
            {
                context.Etudiants.Find(Mon_etudiant_modifié.id).Phone = Mon_etudiant_modifié.Phone;
                change = true;
            }
            if (Mon_etudiant_modifié.Section != etudiant_avant_modif.Section)
            {
                context.Etudiants.Find(Mon_etudiant_modifié.id).Section = Mon_etudiant_modifié.Section;
                change = true;
            }
            if (Mon_etudiant_modifié.Email != etudiant_avant_modif.Email)
            {
                context.Etudiants.Find(Mon_etudiant_modifié.id).Email = Mon_etudiant_modifié.Email;
                change = true;
            }
            if (change)
            {
                context.SaveChanges();
                MessageBox.Show("etudaint mise à jour");
            }
            else
            {
                MessageBox.Show("pas de mise à jour effectué car pas de modification apportée à l'etudiant");
            }
            Response.Redirect("../popup_etudiant_details.html" + "?" + Mon_etudiant_modifié.id);


        }
    }
}