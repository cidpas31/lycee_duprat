using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using lycee_duprat_data;
using System.Windows;

namespace lycee_duprat_business
{
    public partial class view_model_Etudiant
    {
        private static view_model_Etudiant _instance_view_model_Etudiant;

        public static view_model_Etudiant get_instance_view_model_Etudiant()
        {
            if (_instance_view_model_Etudiant == null)
            {
                _instance_view_model_Etudiant = new view_model_Etudiant();
            }
            return _instance_view_model_Etudiant;
        }




        //private string _Nom_de_modification = null;

        public List<etudiants> liste_d_etudiant_main_view_etudiant { get; set; }

        private ObservableCollection<cours> _liste_cours_observable_de_main_view_etudiant;

        public ObservableCollection<cours> liste_cours_observable_de_main_view_etudiant
        {
            get
            {
                return _liste_cours_observable_de_main_view_etudiant;
            }
            set
            {
                _liste_cours_observable_de_main_view_etudiant = value;
            }

        }

        public ObservableCollection<etudiants> etudiant_selectionne_observable_main_view_etudiant { get; set; }
        // methode appeler losque je clic sur mon etudiant dans la liste box de la windows

        private etudiants _etudiant_selectionne_main_view_etudiant = new etudiants();

        public etudiants etudiant_selectionne_main_view_etudiant
        {
            get
            {
                return _etudiant_selectionne_main_view_etudiant;
            }
            set
            {
                _etudiant_selectionne_main_view_etudiant = value;
                etudiant_selectionne_observable_main_view_etudiant.Clear();
                etudiant_selectionne_observable_main_view_etudiant.Add(value);
                get_List_Courses_select_etudiant(_etudiant_selectionne_main_view_etudiant);
            }

        }

        private void get_List_Courses_select_etudiant(etudiants etudiant_selectionne)
        {
            liste_cours_observable_de_main_view_etudiant.Clear();
            List<etudiant_cours> my_cours = context.etudiant_cours.Where(sc => sc.FK_etudiant == etudiant_selectionne.ld).ToList();
            foreach (etudiant_cours c in my_cours)
            {
                liste_cours_observable_de_main_view_etudiant.Add(c.cours);
            }
        }

        public void rafraichissement_list_de_cour_apres_modification()
        {
            get_List_Courses_select_etudiant(_etudiant_selectionne_main_view_etudiant);
        }

        private SchoolDataBaseEntities context = new SchoolDataBaseEntities();

        public view_model_Etudiant()
        {
            liste_d_etudiant_main_view_etudiant = context.etudiants.ToList();
            etudiant_selectionne_observable_main_view_etudiant = new ObservableCollection<etudiants>();
            liste_cours_observable_de_main_view_etudiant = new ObservableCollection<cours>();
        }

        public void Add(etudiants nouveau_etudiant)
        {
            etudiants etu = null;
            etu = context.etudiants.Where(e => e.Nom == nouveau_etudiant.Nom && e.Prenom == nouveau_etudiant.Prenom).FirstOrDefault();
            if (etu != null)
            {
                MessageBox.Show("l'etudiant :" + nouveau_etudiant.Nom +
                    " " + nouveau_etudiant.Prenom + ",existe dejà. Inutile de la rajouter");
                //Debug.WriteLine("l'etudiant :" + nouveau_etudiant.Nom +
                //    " " + nouveau_etudiant.Prenom + ",existe dejà. Inutile de la rajouter");
            }
            else
            {
                if (nouveau_etudiant.Nom != null)
                {
                    if (nouveau_etudiant.Prenom != null)
                    {
                        context.etudiants.Add(nouveau_etudiant);
                        context.SaveChanges();
                        MessageBox.Show("l'etudiant :" + nouveau_etudiant.Nom +
                           " " + nouveau_etudiant.Prenom + ", à ete rajoute");
                        //une fois l'etudaint ajouter en base de donnée je rechage la la abse de donnée
                        //pour afficher la nouvelle liste
                        etudiant_selectionne_observable_main_view_etudiant.Clear();

                        liste_d_etudiant_main_view_etudiant.Clear();
                        liste_d_etudiant_main_view_etudiant = context.etudiants.ToList();
                    }
                    else
                    {
                        MessageBox.Show("vous n'avez pas rentré de prenom");
                    }

                }
                else
                {
                    MessageBox.Show("vous n'avez pas rentré de nom");
                }

                //Debug.WriteLine("l'etudiant :" + nouveau_etudiant.Nom +
                //   " " + nouveau_etudiant.Prenom + ", à ete rajoute");
            }
        }

        public void Remove()
        {
            //le check pour savoir si l'etudaint et bien dans la liste est fait 
            //avant car il faut cliquer sur la liste pour choisir l'etudiant à enlever

            List<etudiant_cours> list_etudiant_cours = new List<etudiant_cours>();
            //dans ce foreach j enleve les cours en trop a mon etudiant              
            list_etudiant_cours = context.etudiant_cours.Where(FK_e => FK_e.FK_etudiant == _etudiant_selectionne_main_view_etudiant.ld).ToList();
            if (list_etudiant_cours != null)
            {
                foreach (etudiant_cours etucours in list_etudiant_cours)
                {
                    context.etudiant_cours.Remove(etucours);
                }
            }

            context.etudiants.Remove(_etudiant_selectionne_main_view_etudiant);
            context.SaveChanges();


            MessageBox.Show("l'etudiant :" + _etudiant_selectionne_main_view_etudiant.Nom +
                            " " + _etudiant_selectionne_main_view_etudiant.Prenom + ", à ete enleve " +
                            "ainsi que ces association de cours si elle existait");
            //            Debug.WriteLine("l'etudiant :" + nouveau_etudiant.Nom +
            //" " + nouveau_etudiant.Prenom + ", à ete enleve");
            liste_d_etudiant_main_view_etudiant = null;
            liste_d_etudiant_main_view_etudiant = context.etudiants.ToList();
            etudiant_selectionne_observable_main_view_etudiant.Clear();

        }

        public void Modification(etudiants modifiaction)
        {
            //le check pour savoir si l'etudaint et bien dans la liste est fait 
            //avant car il faut cliquer sur la liste pour choisir l'etudiant à enlever
            bool change = false;
            etudiants etudiant_anvant_modif = new etudiants();
            etudiant_anvant_modif.Prenom = _etudiant_selectionne_main_view_etudiant.Prenom.ToString();
            etudiant_anvant_modif.Nom = _etudiant_selectionne_main_view_etudiant.Nom.ToString();
            if (modifiaction.Nom != "" && _etudiant_selectionne_main_view_etudiant.Nom != modifiaction.Nom)
            {
                if (modifiaction.Prenom != "" && _etudiant_selectionne_main_view_etudiant.Prenom != modifiaction.Prenom)
                {
                    context.etudiants.Find(_etudiant_selectionne_main_view_etudiant.ld).Nom = modifiaction.Nom;
                    context.etudiants.Find(_etudiant_selectionne_main_view_etudiant.ld).Prenom = modifiaction.Prenom;
                    change = true;
                }
                else
                {
                    context.etudiants.Find(_etudiant_selectionne_main_view_etudiant.ld).Nom = modifiaction.Nom;
                    change = true;

                }
            }
            else
            {
                if (modifiaction.Prenom != "" && _etudiant_selectionne_main_view_etudiant.Prenom != modifiaction.Prenom)
                {
                    context.etudiants.Find(_etudiant_selectionne_main_view_etudiant.ld).Prenom = modifiaction.Prenom;
                    change = true;
                }
                else
                {
                    MessageBox.Show("vous n'avez rentré aucun modifiaction pour l'etudiant :" +
                                    _etudiant_selectionne_main_view_etudiant.Nom + ", " +
                                    _etudiant_selectionne_main_view_etudiant.Prenom);
                }
            }
            if (change)
            {
                context.SaveChanges();
                MessageBox.Show("vous avez modifié l'etudiant :" +
                                etudiant_anvant_modif.Nom + ", " +
                                etudiant_anvant_modif.Prenom + " en " +
                                _etudiant_selectionne_main_view_etudiant.Nom + ", " + _etudiant_selectionne_main_view_etudiant.Prenom);


                liste_d_etudiant_main_view_etudiant.Clear();
                liste_d_etudiant_main_view_etudiant = context.etudiants.ToList();
                etudiant_selectionne_observable_main_view_etudiant.Clear();

            }
        }
    }
}

