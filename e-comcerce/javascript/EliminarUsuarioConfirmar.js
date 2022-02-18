var ConfirmDelete = function () {

    var emailValue = $("#PerfilEmail").val();

    $("#PerfilEmail").val(emailValue);
    $("#myModal").modal('show');

}

var DeleteEmployee = function () {



    var email = $("#PerfilEmail").val();

    $.ajax({

        type: "POST",
        url: "PerfilUsuario/EliminarUsuario",
        data: { Id: email },
        success: function (result) {

            $("#myModal").modal("hide");
            $("#row_" + empId).remove();

        }

    })

}