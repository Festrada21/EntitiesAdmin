$(document).ready(function () {
    $("#mensaje").ready(function () {

        var mensaje = $("#mensaje").val();
        var status = $("#status").val();
                
        if (mensaje !== "") {
            swal(
                'Information',
                mensaje,
                status
            );

        }

    });
});