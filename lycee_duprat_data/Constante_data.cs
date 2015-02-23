using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lycee_duprat_data
{
    public static class Constante_data
    {
        public const string Header_Labi_Etudiant = "etudiant";
        public const string Header_Labi_Professeur = "professeur";
        public const string Header_Labi_Cours = "cours";
        public const string Header_Labi_Section = "section";
        public const string Header_Labi_Examen = "examen";

        public enum cour
        {
            dessin,
            histoire,
            geographie,
            français,
            sport,
            physique,
            chimie,
            mathématique,
            biologie,
            musique            
        }

        public enum examen
        {
            bac_de_français,
            bac_général
        }
    }
}
