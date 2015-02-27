function date_picker_function() {
    $("#datepicker").datepicker();
}

function document_ready()
{
    date_picker_function();
    document.getElementById("Date").innerHTML = Date();
}

function bouton_test_jquery()
{
    $("#p").toggle();
    $("#span1").toggle();
    $("#div1").toggle();
    $("#span2").ext();
    $("#span3").html();
    $("#span4").val(); //(avec et sans parametre);
    $("#span5").append();
    $("#span6").prepend();
    $("#span7").before();
    $("#span8").after();
}



