using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;

namespace lycee_duprat_mvvm.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>

        private string _String_test_mvvm_prop { get; set; }   
        public string String_test_mvvm
        {
            get
            {
                return _String_test_mvvm_prop;
            }
            set
            {
                _String_test_mvvm_prop = value;
                RaisePropertyChanged(_String_test_mvvm_prop);
            }
        }
        public MainViewModel()
        {
            String_test_mvvm = "bonjour_voila mon premiere string afficher en mvvm";
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            CreateClick_Bouton_ajoute_relay_command();
            Click_Bouton_ajoute_relay_command_paramter = new RelayCommand<object>(On_Click_Bouton_ajoute_relay_command_paramter);


        }

 

        private string _String_relay_commande_prop { get; set; }
        public string String_relay_commande
        {
            get
            {
                return _String_relay_commande_prop;
            }
            set
            {
                _String_relay_commande_prop = value;
                RaisePropertyChanged("String_relay_commande");
            }
        }
        public ICommand Click_Bouton_ajoute_relay_command { get; set; }


        private void CreateClick_Bouton_ajoute_relay_command()
        {
            Click_Bouton_ajoute_relay_command = new RelayCommand(SaveExecute);
        }

        public void SaveExecute()
        {
            String_relay_commande = "tu as appuyer sur le bouton save!";
        }





        private string _String_input_text_relay_commande_parameter_bouton_ajouté_prop { get; set; }

        public string String_input_text_relay_commande_parameter_bouton_ajouté
        {
            get
            {
                return _String_input_text_relay_commande_parameter_bouton_ajouté_prop;
            }
            set
            {
                _String_input_text_relay_commande_parameter_bouton_ajouté_prop = value;
                //RaisePropertyChanged(_String_input_text_relay_commande_parameter_bouton_ajouté_prop);
            }
        }

        private string _String_output_text_relay_commande_parameter { get; set; }
        public string String_output_text_relay_commande_parameter
        {
            get
            {
                return _String_output_text_relay_commande_parameter;
            }
            set
            {
                _String_output_text_relay_commande_parameter = value;
                RaisePropertyChanged("String_output_text_relay_commande_parameter");
            }
        }
        public RelayCommand<object> Click_Bouton_ajoute_relay_command_paramter { get; set; }


        private void On_Click_Bouton_ajoute_relay_command_paramter(object obj)
        {
            String_output_text_relay_commande_parameter = obj.ToString();
        }
    }
}