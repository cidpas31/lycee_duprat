//var Etudiant = function (firstName, lastName, age, phone, section, email_adresse) {
//    this.firstName = firstName;
//    this.lastName = lastName;
//    this.age = age;
//    this.phone = phone;
//    this.section = section;
//    this.email_adresse = email_adresse;
//};

function submission_etudiant() {
    var text_FirstName = document.getElementById("first-name");
    var text_LastName = document.getElementById("last-name");
    //var text_Age = document.getElementById("age");
    //var text_Phone = document.getElementById("phone");
    //var text_radio_seconde = document.getElementById("radio_seconde");
    //var text_radio_premiere = document.getElementById("radio_premiere");
    //var text_radio_terminal = document.getElementById("radio_terminal");
    //var text_section;
    //if (text_radio_seconde.checked)
    //{
    //    text_section = "seconde";
    //}
    //if (text_radio_premiere.checked) {
    //    text_section = "premiere";
    //}
    //if (text_radio_terminal.checked) {
    //    text_section = "terminal";
    //}
    //var text_section_select = document.getElementById("section_select");
    //var text_email_adresse = document.getElementById("email-address");
    //var Mon_etudiant = new Etudiant(text_FirstName.value, text_LastName.value, text_Age.value, text_Phone.value, text_section, text_email_adresse.value);
    //Mon_etudiant.FirstName = text_FirstName.value;
    //Mon_etudiant.LastName = text_LastName.value;
    //Mon_etudiant.Age = text_Age.value;
    //Mon_etudiant.Phone = text_Phone.value;
    //Mon_etudiant.Section = text_section.value;
    //Mon_etudiant.email_adresse = text_email_adresse.value;

    var ma_liste_etudiant = document.getElementById("ma_liste_etudiant");
    if (ma_liste_etudiant != null)
    {
        ma_liste_etudiant.innerText = text_FirstName.value;

    }

    //document.getElementById["ma_liste_etudiant"].innerText = text_FirstName.value;
    return false;
}
