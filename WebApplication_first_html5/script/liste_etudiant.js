function etudiant_existe() {
    $.ajax({
        url: "server/Web_service_site_etudiant.asmx/get_all_etudiant", //ressource cyble id ="+ id + "
        type: "POST", //type de requet get par default
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (msg) {
            if (msg.d.length == 0) {
                window.location.replace('/popup/popup_etudiant_existe.html');
            }
        },
        complete: function (msg) {
            //alert("2");
        },
        error: function (msg) {
            //alert("3");
            //alert("3" + JSON.stringify(msg));
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

function close_windows_popup() {
    window.location.replace('../CreerEtudiant.html');
}

function document_ready() {
    etudiant_existe();
    $.ajax({
        url: "server/Web_service_site_etudiant.asmx/get_all_etudiant", //ressource cyble
        type: "POST", //type de requet get par default
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (msg) {
            //alert("1" + JSON.stringify(msg));

            for (var i = 0; i < msg.d.length; i++) {

                document.getElementById('ul_liste_etudiant').innerHTML += "<li onclick='afficher_details_etudiant(" + msg.d[i].id + ")' >" + msg.d[i].First_name +" "+ msg.d[i].Last_name + "</li>";
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

function afficher_details_etudiant(id) {
    window.location.replace("/popup/popup_etudiant_details.html" + "?" + id, "");

}






