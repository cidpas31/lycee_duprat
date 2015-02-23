using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using lycee_duprat_data;
using System.Windows;

namespace lycee_duprat_business
{
    public class view_model_Cours
    {
        private static view_model_Cours _instance_view_model_Cours;

        public static view_model_Cours get_instance_view_model_Cours()
        {
            if (_instance_view_model_Cours == null)
            {
                _instance_view_model_Cours = new view_model_Cours();
            }
            return _instance_view_model_Cours;
        }




        //private string _Nom_de_modification = null;

        public List<cours> liste_de_cours_main_view_cours { get; set; }

        private ObservableCollection<etudiants> _liste_etudiant_observable_de_main_view_cours;

        public ObservableCollection<etudiants> liste_etudiant_observable_de_main_view_cours
        {
            get
            {
                return _liste_etudiant_observable_de_main_view_cours;
            }
            set
            {
                _liste_etudiant_observable_de_main_view_cours = value;
            }

        }

        public ObservableCollection<cours> cours_selectionne_observable_main_view_cours { get; set; }
        // methode appeler losque je clic sur mon etudiant dans la liste box de la windows

        private cours _cours_selectionne_observable_main_view_cours = new cours();

        public cours cours_selectionne_main_view_cours
        {
            get
            {
                return _cours_selectionne_observable_main_view_cours;
            }
            set
            {
                _cours_selectionne_observable_main_view_cours = value;
                cours_selectionne_observable_main_view_cours.Clear();
                cours_selectionne_observable_main_view_cours.Add(value);
                get_List_Etudiant_select_etudiant(_cours_selectionne_observable_main_view_cours);
            }

        }

        private void get_List_Etudiant_select_etudiant(cours cours_selectionne)
        {
            liste_etudiant_observable_de_main_view_cours.Clear();
            List<etudiant_cours> my_cours = context.etudiant_cours.Where(sc => sc.FK_cour == cours_selectionne.Id).ToList();
            foreach (etudiant_cours e in my_cours)
            {
                liste_etudiant_observable_de_main_view_cours.Add(e.etudiants);
            }
        }

        public void rafraichissement_list_de_etudiant_apres_modification()
        {
            get_List_Etudiant_select_etudiant(_cours_selectionne_observable_main_view_cours);
        }

        private SchoolDataBaseEntities context = new SchoolDataBaseEntities();

        public view_model_Cours()
        {
            liste_de_cours_main_view_cours = context.cours.ToList();
            cours_selectionne_observable_main_view_cours = new ObservableCollection<cours>();
            liste_etudiant_observable_de_main_view_cours = new ObservableCollection<etudiants>();
        }

        public void Add(cours nouveau_cours)
        {
            cours cou = null;
            cou = context.cours.Where(c => c.Nom_du_cours == nouveau_cours.Nom_du_cours).FirstOrDefault();
            if (cou != null)
            {
                MessageBox.Show("le cours :" + nouveau_cours.Nom_du_cours +
                     ", existe dejà. Inutile de la rajouter");
                //Debug.WriteLine("l'etudiant :" + nouveau_etudiant.Nom +
                //    " " + nouveau_etudiant.Prenom + ",existe dejà. Inutile de la rajouter");
            }
            else
            {
                if (nouveau_cours.Nom_du_cours != null)
                {
                    if (nouveau_cours.durée != null)
                    {
                        context.cours.Add(nouveau_cours);
                        context.SaveChanges();
                        MessageBox.Show("le cours de " + nouveau_cours.Nom_du_cours +
                            ", à été rajouté");
                        //une fois l'etudaint ajouter en base de donnée je rechage la la abse de donnée
                        //pour afficher la nouvelle liste
                        cours_selectionne_observable_main_view_cours.Clear();

                        liste_de_cours_main_view_cours.Clear();
                        liste_de_cours_main_view_cours = context.cours.ToList();
                    }
                    else
                    {
                        MessageBox.Show("vous n'avez pas rentré de durée pour le cours de " + nouveau_cours.Nom_du_cours);
                    }

                }
                else
                {
                    MessageBox.Show("vous n'avez pas rentré de cours");
                }

            }
        }

        public void Remove()
        {
            //le check pour savoir si l'etudaint et bien dans la liste est fait 
            //avant car il faut cliquer sur la liste pour choisir l'etudiant à enlever

            List<etudiant_cours> list_etudiant_cours = new List<etudiant_cours>();
            //dans ce foreach j enleve les cours en trop a mon etudiant              
            list_etudiant_cours = context.etudiant_cours.Where(FK_c => FK_c.FK_cour == _cours_selectionne_observable_main_view_cours.Id).ToList();
            if (list_etudiant_cours != null)
            {
                foreach (etudiant_cours etucours in list_etudiant_cours)
                {
                    context.etudiant_cours.Remove(etucours);
                }
            }

            context.cours.Remove(_cours_selectionne_observable_main_view_cours);
            context.SaveChanges();


            MessageBox.Show("le cours :" + _cours_selectionne_observable_main_view_cours.Nom_du_cours +
                            ", à été enlevé ainsi que ces associations d'etudiant si elles existaient");
            //            Debug.WriteLine("l'etudiant :" + nouveau_etudiant.Nom +
            //" " + nouveau_etudiant.Prenom + ", à ete enleve");
            liste_de_cours_main_view_cours = null;
            liste_de_cours_main_view_cours = context.cours.ToList();
            cours_selectionne_observable_main_view_cours.Clear();

        }

        //public void Modification(cours modifiaction)
        //{
        //    //le check pour savoir si l'etudaint et bien dans la liste est fait 
        //    //avant car il faut cliquer sur la liste pour choisir l'etudiant à enlever
        //    bool change = false;
        //    etudiants etudiant_anvant_modif = new etudiants();
        //    etudiant_anvant_modif.Prenom = _cours_selectionne_observable_main_view_cours.Prenom.ToString();
        //    etudiant_anvant_modif.Nom = _cours_selectionne_observable_main_view_cours.Nom.ToString();
        //    if (modifiaction.Nom != "" && _cours_selectionne_observable_main_view_cours.Nom != modifiaction.Nom)
        //    {
        //        if (modifiaction.Prenom != "" && _cours_selectionne_observable_main_view_cours.Prenom != modifiaction.Prenom)
        //        {
        //            context.etudiants.Find(_cours_selectionne_observable_main_view_cours.ld).Nom = modifiaction.Nom;
        //            context.etudiants.Find(_cours_selectionne_observable_main_view_cours.ld).Prenom = modifiaction.Prenom;
        //            change = true;
        //        }
        //        else
        //        {
        //            context.etudiants.Find(_cours_selectionne_observable_main_view_cours.ld).Nom = modifiaction.Nom;
        //            change = true;

        //        }
        //    }
        //    else
        //    {
        //        if (modifiaction.Prenom != "" && _cours_selectionne_observable_main_view_cours.Prenom != modifiaction.Prenom)
        //        {
        //            context.etudiants.Find(_cours_selectionne_observable_main_view_cours.ld).Prenom = modifiaction.Prenom;
        //            change = true;
        //        }
        //        else
        //        {
        //            MessageBox.Show("vous n'avez rentré aucun modifiaction pour l'etudiant :" +
        //                            _cours_selectionne_observable_main_view_cours.Nom + ", " +
        //                            _cours_selectionne_observable_main_view_cours.Prenom);
        //        }
        //    }
        //    if (change)
        //    {
        //        context.SaveChanges();
        //        MessageBox.Show("vous avez modifié l'etudiant :" +
        //                        etudiant_anvant_modif.Nom + ", " +
        //                        etudiant_anvant_modif.Prenom + " en " +
        //                        _cours_selectionne_observable_main_view_cours.Nom + ", " + _cours_selectionne_observable_main_view_cours.Prenom);


        //        liste_de_cours_main_view_etudiant.Clear();
        //        liste_de_cours_main_view_etudiant = context.etudiants.ToList();
        //        cours_selectionne_observable_main_view_cours.Clear();

        //    }
        //}
    }
}

