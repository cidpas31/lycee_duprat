function porf_existe() {
    $.ajax({
        url: "server/Web_service_site_etudiant.asmx/get_all_prof", //ressource cyble id ="+ id + "
        type: "POST", //type de requet get par default
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (msg) {
            if (msg.d.length == 0) {
                window.location.replace('/popup/popup_prof_existe.html');
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
    window.location.replace('../CreerProfesseur.html');
}

function document_ready() {
    porf_existe();
    $.ajax({
        url: "server/Web_service_site_etudiant.asmx/get_all_prof", //ressource cyble id ="+ id + "
        type: "POST", //type de requet get par default
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (msg) {

            for (var i = 0; i < msg.d.length; i++) {
                document.getElementById('Prof_select').innerHTML += "<option value='"+ msg.d[i].id + "'>" +
                    msg.d[i].First_name + " " + msg.d[i].Last_name + "</option> ";
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
    $.ajax({
        url: "server/Web_service_site_etudiant.asmx/get_all_cours_prof", //ressource cyble id ="+ id + "
        type: "POST", //type de requet get par default
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (msg) {
            if (msg.d.length != 0)
            {
                for (var i = 0; i < msg.d.length; i++) {
                    document.getElementById('ul_liste_cours').innerHTML += "<li>" + msg.d[i].Cours.Name +
                        ". prof : " + msg.d[i].Prof.First_name + " " + msg.d[i].Prof.Last_name + "</li>";
                }
            }
            else {
                document.getElementById('ul_liste_cours').innerHTML += "<li> pas de cours associé à un prof en base de donnée </li>";
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

