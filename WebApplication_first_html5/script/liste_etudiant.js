//var new_element = jquery("<il>?</il>");

function document_ready() {

    $.ajax({
        url: "server/liste_etudiant.aspx/get_all", //ressource cyble
        type: "POST", //type de requet get par default
        data: {},//'__type':"",'id':"",'date': "", '&First_name': "", '&Last_name': "", '&Age': "", '&Phone': "", '&Section': "", '&Email': "" 
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        //success: function (code_json, statut) { // code_json contient le HTML renvoyé
        //    $(code_json).appendTo("#ul_liste_etudiant").append(new_element);
        //},
        //error: function (resultat, statut, erreur) {

        //},
        //complete: function (resultat, statut) {

        //}

        success: function (msg) {
            //alert("1" + JSON.stringify(msg));

            for (var i = 0; i < msg.d.length; i++) {

                document.getElementById('ul_liste_etudiant').innerHTML += "<li onclick='afficher_list_de_cours()'>" + msg.d[i].First_name + msg.d[i].Last_name + "</li>";
                //document.getElementById('ul_liste_etudiant').innerHTML += "<li hidden='hidden' id='etudiant" + First_name + ">" + msg.d[i].id + "</li>";
            }

        },
        complete: function (msg) {
            //alert("2");
        },
        error: function (msg) {
            //alert("3");
            alert("3" + JSON.stringify(msg));
        },
        send: function (msg) {
            //alert("4");
        },
        stop: function (msg) {
            //alert("5");
        },
        start: function (msg) {
            //alert("6");
        }
    });

}

function afficher_list_de_cours() {
    $.ajax({
        url: "server/liste_etudiant.aspx/get_all_cours", //ressource cyble
        type: "POST", //type de requet get par default
        data: {},//'__type':"",'id':"",'date': "", '&First_name': "", '&Last_name': "", '&Age': "", '&Phone': "", '&Section': "", '&Email': "" 
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        //success: function (code_json, statut) { // code_json contient le HTML renvoyé
        //    $(code_json).appendTo("#ul_liste_etudiant").append(new_element);
        //},
        //error: function (resultat, statut, erreur) {

        //},
        //complete: function (resultat, statut) {

        //}

        success: function (msg) {
            //alert("1" + JSON.stringify(msg));

            for (var i = 0; i < msg.d.length; i++) {

                document.getElementById('ul_liste_etudiant').innerHTML += "<li onclick='afficher_list_de_cours()>" + msg.d[i].First_name + msg.d[i].Last_name + "</li>";
                document.getElementById('ul_liste_etudiant').innerHTML += "<li hidden='hidden' id='etudiant" + First_name + ">" + msg.d[i].id +"</li>";
            }

        },
        complete: function (msg) {
            //alert("2");
        },
        error: function (msg) {
            //alert("3");
            alert("3" + JSON.stringify(msg));
        },
        send: function (msg) {
            //alert("4");
        },
        stop: function (msg) {
            //alert("5");
        },
        start: function (msg) {
            //alert("6");
        }
    });
}