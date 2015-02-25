
function TestJs1() {
    alert("rouge");
    var res = confirm("voulez vous coucher avec moi ce soir");
}

function afficher_text()
{
    var text_box1 = document.getElementById("first-name");
    if (text_box1.value != "") {
        confirm("yeah voila le nom de la textbox id first-name :" + text_box1.value);
    }
    else {
        alert("rien dans la case first name");
    } 

}