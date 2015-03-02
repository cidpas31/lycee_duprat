using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication_first_html5.database;

namespace WebApplication_first_html5.server
{
    public partial class authentification : System.Web.UI.Page
    {
        public class Authentification_login
        {
            public string Authentification_name { get; set; }
            public string Authentification_password { get; set; }            
        }

        private Site_gestion_etudiantEntities context = new Site_gestion_etudiantEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            Authentification_login Logincurrent = new Authentification_login();
            Logincurrent.Authentification_name = Request.Form["name_authentification"];
            Logincurrent.Authentification_password = Request.Form["password_authentification"];
            //mettre ici le traitement du password: est ce que le password existe en base de donnée
            //si oui ok on peut rentrer dans le site
            //si non authentification refusé
            Name_Password N_P = new Name_Password();
            N_P = context.Name_Password.Where(n => n.Name == Logincurrent.Authentification_name
                                                                    && n.Password == Logincurrent.Authentification_password).FirstOrDefault();
            if (N_P == null)
            {
                //je n'est pas trouver dans ma database le nom et le password de l'utilisateur courant il ne peut pas ce connecter au site
                lbl.Text = "Vous ne pouvez pas vous connecter à ce site. contacter l'administrateur pour obtenir le droit d'acces"; 
            }
            else
            {
                Response.Redirect("../page_navigation_gestion_etudiant.html");
            }

        }


    }
}