using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lycee_duprat_data;
using System.Collections.ObjectModel;

namespace lycee_duprat_business
{
    public class view_model_Etudiant_cours
    {


        //singleton
        private static view_model_Etudiant_cours _instance_view_model_Etudiant_cours;

        //private view_model_Etudiant _view_model_Etudiant;

        public static view_model_Etudiant_cours get_instance_view_model_Etudiant_cours(view_model_Etudiant mon_view_modele_etudiant)
        {

            if (_instance_view_model_Etudiant_cours == null)
            {
                _instance_view_model_Etudiant_cours = new view_model_Etudiant_cours(mon_view_modele_etudiant);
            }
            return _instance_view_model_Etudiant_cours;
        }

        public static view_model_Etudiant_cours get_instance_view_model_Etudiant_cours()
        {
            return _instance_view_model_Etudiant_cours;
        }

        private SchoolDataBaseEntities context = new SchoolDataBaseEntities();

        //binding debut
        private cours _cours_selection_de_la_liste_de_cour_main_view_etudiantcours = new cours();

        public cours cours_selection_de_la_liste_de_cour_main_view_etudiantcours
        {
            get
            {
                return _cours_selection_de_la_liste_de_cour_main_view_etudiantcours;
            }
            set
            {
                _cours_selection_de_la_liste_de_cour_main_view_etudiantcours = value;
                if (liste_cours_observable_de_main_view_etudiant_cours.Count != 0)
                {
                    bool present_dans_la_liste = false;
                    foreach (cours cour in liste_cours_observable_de_main_view_etudiant_cours)
                    {
                        if (cour.Nom_du_cours == value.Nom_du_cours)
                        {
                            present_dans_la_liste = true;
                        }
                    }
                    if (!present_dans_la_liste)
                    {
                        liste_cours_observable_de_main_view_etudiant_cours.Add(value);
                    }
                }
                else
                {
                    liste_cours_observable_de_main_view_etudiant_cours.Add(value);
                }

            }

        }

        private cours _cours_a_effacer_main_view_etudiantcours = new cours();

        public cours cours_a_effacer_main_view_etudiantcours
        {
            get
            {
                return _cours_a_effacer_main_view_etudiantcours;
            }
            set
            {
                _liste_cours_observable_de_main_view_etudiant_cours.Remove(value);
            }
        }


        private etudiants _mon_etudiant = new etudiants();

        private ObservableCollection<cours> _liste_cours_observable_de_main_view_etudiant_cours = new ObservableCollection<cours>();

        public ObservableCollection<cours> liste_cours_observable_de_main_view_etudiant_cours
        {
            get
            {
                return _liste_cours_observable_de_main_view_etudiant_cours;
            }
            set
            {
                _liste_cours_observable_de_main_view_etudiant_cours = value;
            }

        }


        //methode
        public List<cours> liste_de_cours_data_base { get; set; }

        public view_model_Etudiant_cours(view_model_Etudiant view_etudiant)
        {
            //liste_de_cours_data_base = context.cours.ToList();
            //_mon_etudiant = view_etudiant.etudiant_selectionne_main_view_etudiant;
            //get_List_Courses_select_etudiant(_mon_etudiant);
            //_view_model_Etudiant = view_etudiant;
        }


        private void get_List_Courses_select_etudiant(etudiants etudiant_selectionne)
        {
            _mon_etudiant = etudiant_selectionne;
            liste_de_cours_data_base = context.cours.ToList();
            if (liste_cours_observable_de_main_view_etudiant_cours.Count > 0)
            {
                liste_cours_observable_de_main_view_etudiant_cours.Clear();
            }
            List<etudiant_cours> my_cours = context.etudiant_cours.Where(sc => sc.FK_etudiant == etudiant_selectionne.ld).ToList();
            foreach (etudiant_cours c in my_cours)
            {
                liste_cours_observable_de_main_view_etudiant_cours.Add(c.cours);
            }


        }

        public void raffraichissement_list_de_cours_de_l_etudaint(etudiants etudiant_selectionne)
        {
            get_List_Courses_select_etudiant(etudiant_selectionne);
        }

        public void set_List_Courses_select_etudiant()
        {
            bool change = false;
            bool existe = false;
            //check pour savoir si l'etudiant a une association de cour dans la data base
            if (null != context.etudiant_cours.Where(FK_e => FK_e.FK_etudiant == _mon_etudiant.ld).FirstOrDefault())
            {
                //il faut que je sauvegarde ma list de cours du context avant de commencer a le modifier
                // car pour faire le remove j'ai besoin de savoir ce qu il y avait avant les modificaiton
                //sinon je vais ajouter des chose dans mon context avant de vouloir les enlever
                List<etudiant_cours> list_backup_etudiant_cours_du_context = new List<etudiant_cours>();
                List<cours> list_backup_cours_du_context = new List<cours>();
                list_backup_etudiant_cours_du_context = context.etudiant_cours.Where(FK_e => FK_e.FK_etudiant == _mon_etudiant.ld).ToList();
                //se foreeachen sert arien

                foreach (etudiant_cours etucours in list_backup_etudiant_cours_du_context)
                {
                    list_backup_cours_du_context.Add(etucours.cours);
                }

                // si je passe ici c est que j'ai bien une association d etudaint cours dans ma table cours etudiant
                //je peux balayer mes cours

                //dans ce foreach j'ajouter des cours à un etudiant 
                foreach (cours cour_de_la_list_de_etudiant in _liste_cours_observable_de_main_view_etudiant_cours)
                {

                    foreach (cours cour_en_data_base in list_backup_cours_du_context)
                    {
                        if (cour_de_la_list_de_etudiant == cour_en_data_base)
                        {
                            existe = true;
                        }
                    }
                    if (!existe)
                    {
                        etudiant_cours mon_etudiant_cours = new etudiant_cours() { FK_etudiant = _mon_etudiant.ld };
                        //ici je rajoute des cour dans ma data base
                        mon_etudiant_cours.FK_cour = cour_de_la_list_de_etudiant.Id;
                        context.etudiant_cours.Add(mon_etudiant_cours);
                        change = true;
                    }
                    existe = false;
                }
                //dans ce foreach j enleve les cours en trop a mon etudiant 
                foreach (cours cour_en_data_base in list_backup_cours_du_context)
                {
                    foreach (cours cour_de_la_list_de_etudiant in _liste_cours_observable_de_main_view_etudiant_cours)
                    {
                        if (cour_en_data_base == cour_de_la_list_de_etudiant)
                        {
                            existe = true;
                        }
                    }
                    if (!existe)
                    {
                        etudiant_cours mon_etudiant_cours = new etudiant_cours() { FK_etudiant = _mon_etudiant.ld };
                        mon_etudiant_cours = context.etudiant_cours.Where(FK_e => FK_e.FK_etudiant == _mon_etudiant.ld &&
                                                                 FK_e.FK_cour == cour_en_data_base.Id).FirstOrDefault();
                        context.etudiant_cours.Remove(mon_etudiant_cours);
                        change = true;
                    }
                    existe = false;
                }

            }
            else
            {
                foreach (cours cour in _liste_cours_observable_de_main_view_etudiant_cours)
                {
                    etudiant_cours mon_etudiant_cours = new etudiant_cours() { FK_etudiant = _mon_etudiant.ld, FK_cour = cour.Id };
                    context.etudiant_cours.Add(mon_etudiant_cours);
                    change = true;
                }


            }
            if (change)
            {
                context.SaveChanges();

            }
        }
    }
}
