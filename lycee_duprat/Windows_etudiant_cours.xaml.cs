using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using lycee_duprat_business;

namespace lycee_duprat
{
    /// <summary>
    /// Interaction logic for Windows_etudiant_cours.xaml
    /// </summary>
    /// 
    public partial class Windows_etudiant_cours : Window
    {

        private view_model_Etudiant_cours _my_view_etudiant_cours = view_model_Etudiant_cours.get_instance_view_model_Etudiant_cours(new view_model_Etudiant());
        public Windows_etudiant_cours(view_model_Etudiant view_model_etudiant)
        {
            InitializeComponent();

            DataContext = view_model_Etudiant_cours.get_instance_view_model_Etudiant_cours(view_model_etudiant);
            //ici je fais en sorte que la liste afficher de l'etudiant soit correcte
            _my_view_etudiant_cours = view_model_Etudiant_cours.get_instance_view_model_Etudiant_cours(view_model_etudiant);
            _my_view_etudiant_cours.raffraichissement_list_de_cours_de_l_etudaint(view_model_etudiant.etudiant_selectionne_main_view_etudiant);
        }

        private void Btn_modifier_Click(object sender, RoutedEventArgs e)
        {
            _my_view_etudiant_cours.set_List_Courses_select_etudiant();
            DataContext = null;
            DataContext = view_model_Etudiant_cours.get_instance_view_model_Etudiant_cours();
            DialogResult = true;
            this.Close();
        }

    }
}
