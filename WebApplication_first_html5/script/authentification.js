function document_ready() {
    //if (sessionStorage == null) {
    //    alert("Storage non supporté par le navigateur");
    //}
    //else {
    //    alert("Storage supporté par le navigateur")
    //}
    document.getElementById("Date").innerHTML = Date();

}


function authentification_submit() {
    //window.sessionStorage.login = document.getElementById("idnameauthentification");
    //window.sessionStorage.password = document.getElementById("idpasswordauthentification");
    return true;
}

function redirection_authentification() {
    document.location.href = "../authentification_gestion_des_etudiant.html"
}