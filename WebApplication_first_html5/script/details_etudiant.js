function document_ready() {
    var id = location.search.substring(1, location.search.length);
    $.ajax({
        url: "../server/Web_service_site_etudiant.asmx/get_all_etudiant_details",
        type: "POST",
        data: "{'id':'" + id + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (msg) {
            document.getElementById('first-name').value = msg.d.First_name;
            document.getElementById('last-name').value = msg.d.Last_name;
            document.getElementById('age_number').value = msg.d.Age;
            document.getElementById('phone').value = msg.d.Phone;
            document.getElementById('section_select').value = msg.d.Section;
            document.getElementById('email-address').value = msg.d.Email;
            document.getElementById('id').value = id;
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
    window.location.replace('../Afficherlisteetudiant.html');
}



function Mise_a_jour_etudiant() {
    document.getElementById("date_of_modification").value = Date();    
    return true;
}