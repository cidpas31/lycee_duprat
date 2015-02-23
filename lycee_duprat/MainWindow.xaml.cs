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
using System.Windows.Navigation;
using System.Windows.Shapes;

using lycee_duprat_data;
using lycee_duprat_business;

using System.Collections.ObjectModel;
using System.Diagnostics;

namespace lycee_duprat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private view_model_Etudiant _my_view_etudiant = view_model_Etudiant.get_instance_view_model_Etudiant();
        private view_model_Cours _my_view_cours = view_model_Cours.get_instance_view_model_Cours();
        private string _mon_Tbi_courant = "";


        public MainWindow()
        {
            InitializeComponent();

            LaBi_etudiant.Header = Constante_data.Header_Labi_Etudiant;
            LaBi_cours.Header = Constante_data.Header_Labi_Cours;
            LaBi_professeur.Header = Constante_data.Header_Labi_Professeur;
            LaBi_section.Header = Constante_data.Header_Labi_Section;
            LaBi_examen.Header = Constante_data.Header_Labi_Examen;

            string[] val = Enum.GetNames(typeof(lycee_duprat_data.Constante_data.cour));
            foreach (string st in val)
                ComboBox_cours_a_ajouter.Items.Add(st);


            LaBi_etudiant.Focus();
            LaBi_etudiant.DataContext = _my_view_etudiant;
            LaBi_cours.DataContext = _my_view_cours;


        }

        //public void changement_de_context_car_autre_windows(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    DataContext = null;
        //    DataContext = view_model_Etudiant.get_instance_view_model_Etudiant();
        //}

        private void Btn_ajout_Click(object sender, RoutedEventArgs e)
        {
            switch (_mon_Tbi_courant)
            {
                case Constante_data.Header_Labi_Etudiant:
                    //je suis dans mon onglet etudiant j'instancie my view model etudaint class
                    _my_view_etudiant.Add(new etudiants
                    {
                        Nom = TextBox_Nom_Etudiant.Text.ToString(),
                        Prenom = TextBox_Prenom_Etudiant.Text.ToString()
                    });
                    TextBox_Nom_Etudiant.Clear();
                    TextBox_Prenom_Etudiant.Clear();
                    LaBi_etudiant.DataContext = null;
                    LaBi_etudiant.DataContext = _my_view_etudiant;
                    _my_view_etudiant.rafraichissement_list_de_cour_apres_modification();
                    LaBi_etudiant.Focus();


                    break;
                case Constante_data.Header_Labi_Professeur:




                    break;
                case Constante_data.Header_Labi_Cours:

                    _my_view_cours.Add(new cours
                    {
                        Nom_du_cours = ComboBox_cours_a_ajouter.SelectedItem.ToString(),
                        durée = Convert.ToInt16(TextBox_duree_du_cours.Text)
                    });
                    TextBox_duree_du_cours.Clear();
                    LaBi_cours.DataContext = null;
                    LaBi_cours.DataContext = _my_view_cours;
                    _my_view_cours.rafraichissement_list_de_etudiant_apres_modification();
                    LaBi_cours.Focus();


                    break;
                case Constante_data.Header_Labi_Section:



                    break;
                case Constante_data.Header_Labi_Examen:



                    break;
            }
        }


        private void Btn_modif_Click(object sender, RoutedEventArgs e)
        {
            switch (_mon_Tbi_courant)
            {
                case Constante_data.Header_Labi_Etudiant:
                    //je suis dans mon onglet etudiant j'instancie my view model etudaint class
                    if (_my_view_etudiant.etudiant_selectionne_main_view_etudiant.Nom != null ||
                        _my_view_etudiant.etudiant_selectionne_main_view_etudiant.Prenom != null)
                    {
                        _my_view_etudiant.Modification(new etudiants
                        {
                            Nom = TextBox_Nom_Etudiant.Text,
                            Prenom = TextBox_Prenom_Etudiant.Text,
                        });
                        TextBox_Nom_Etudiant.Clear();
                        TextBox_Prenom_Etudiant.Clear();
                        DataContext = null;
                        DataContext = _my_view_etudiant;
                        LaBi_etudiant.Focus();
                    }
                    else
                    {
                        MessageBox.Show("vous n'avez pas choisi d'etudiant dans la liste pour le modifier");
                    }



                    break;
                case Constante_data.Header_Labi_Professeur:




                    break;
                case Constante_data.Header_Labi_Cours:



                    break;
                case Constante_data.Header_Labi_Section:



                    break;
                case Constante_data.Header_Labi_Examen:



                    break;
            }
        }


        private void Btn_efface_Click(object sender, RoutedEventArgs e)
        {
            switch (_mon_Tbi_courant)
            {
                case Constante_data.Header_Labi_Etudiant:
                    //je suis dans mon onglet etudiant 
                    if (_my_view_etudiant.etudiant_selectionne_main_view_etudiant.Nom != null ||
                        _my_view_etudiant.etudiant_selectionne_main_view_etudiant.Prenom != null)
                    {
                        _my_view_etudiant.Remove();
                        TextBox_Nom_Etudiant.Clear();
                        TextBox_Prenom_Etudiant.Clear();
                        DataContext = null;
                        DataContext = _my_view_etudiant;
                        _my_view_etudiant.rafraichissement_list_de_cour_apres_modification();
                        LaBi_etudiant.Focus();
                    }
                    else
                    {
                        MessageBox.Show("vous n'avez choisi d'etudiant dans la liste pour l'enlever");
                    }



                    break;
                case Constante_data.Header_Labi_Professeur:




                    break;
                case Constante_data.Header_Labi_Cours:

                    //je suis dans mon onglet cours 
                    if (_my_view_cours.cours_selectionne_main_view_cours.Nom_du_cours != null||
                        _my_view_cours.cours_selectionne_main_view_cours.durée != null)
                    {
                        _my_view_cours.Remove();
                        TextBox_duree_du_cours.Clear();
                        LaBi_cours.DataContext = null;
                        LaBi_cours.DataContext = _my_view_cours;
                        _my_view_cours.rafraichissement_list_de_etudiant_apres_modification();
                        LaBi_cours.Focus();
                    }
                    else
                    {
                        MessageBox.Show("vous n'avez choisi d'etudiant dans la liste pour l'enlever");
                    }

                    break;
                case Constante_data.Header_Labi_Section:



                    break;
                case Constante_data.Header_Labi_Examen:



                    break;
            }
        }






        private void onglet_selectionne(object sender, RoutedEventArgs e)
        {
            TabItem mon_table_item = (TabItem)sender;

            switch (mon_table_item.Header.ToString())
            {
                case Constante_data.Header_Labi_Etudiant:
                    //je suis dans mon onglet etudiant j'instancie my view model etudaint class
                    DataContext = view_model_Etudiant.get_instance_view_model_Etudiant();
                    _mon_Tbi_courant = Constante_data.Header_Labi_Etudiant;

                    break;
                case Constante_data.Header_Labi_Professeur:



                    break;
                case Constante_data.Header_Labi_Cours:
                    DataContext = null;
                    DataContext = view_model_Cours.get_instance_view_model_Cours();
                    _mon_Tbi_courant = Constante_data.Header_Labi_Cours;

                    break;
                case Constante_data.Header_Labi_Section:



                    break;
                case Constante_data.Header_Labi_Examen:



                    break;
            }
        }

        private void Btn_modif_cours_de_l_etudiant_Click(object sender, RoutedEventArgs e)
        {
            /////////////////////////utiliser pour tester la fenetre etudiant 
            if (_my_view_etudiant.etudiant_selectionne_main_view_etudiant.Nom != null ||
                _my_view_etudiant.etudiant_selectionne_main_view_etudiant.Prenom != null)
            {
                Windows_etudiant_cours Windows_etudiant_cours = new Windows_etudiant_cours(_my_view_etudiant);
                if (Windows_etudiant_cours.ShowDialog() == true)
                {                    
                    DataContext = null;                        
                    DataContext = _my_view_etudiant;
                }
                _my_view_etudiant.rafraichissement_list_de_cour_apres_modification();
            }
            else
            {
                MessageBox.Show("vous n'avez pas choisi d'etudiant, pas de cours à modifier");
            }

        }


        //code pour evite le prob de not selected item de ma liste box car elle fait parti d'un item tab
        //qui renoie event a sont parent soit tab control.
        private void Liste_Box_base_de_donne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
        }

    }
}
