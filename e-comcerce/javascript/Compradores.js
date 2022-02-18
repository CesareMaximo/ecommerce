// =================================================================================== //

function templateRow() {
    var template = "<tr>";
    template += ("<td>" + "123" + "</td>");
    template += ("<td>" + "Nicolas" + "</td>");
    template += ("<td>" + "Lopez" + "</td>");
    template += ("<td>" + "123" + "</td>");
    template += ("<td>" + "456" + "</td>");
    template += ("<td>" + "789" + "</td>");    
    template += "</tr>";
    return template;
}

// =================================================================================== //

function addRow() {
    var template = templateRow();
    for (var i = 0; i < 10; i++) {
        $("#tbl_body_table").append(template);
    }
}

// =================================================================================== //

var tabla, data;

function addRowDT(data) {
    tabla = $("#usuariosList").dataTable({
        "aaSorting": [[0, 'desc']],
        "bSort": true,
        "bDestroy": true,
        "aoColumns": [
            null,
            null,
            null,
            null,
            null,
            null            
        ]
    });

    tabla.fnClearTable();

    for (var i = 0; i < data.length; i++) {
        tabla.fnAddData([
            data[i].Nombre,
            data[i].Apellido,
            data[i].Documento,
            data[i].Domicilio,
            data[i].Celular,
            data[i].Email
        ]);
    }
    //  ((data[i].Estado == true) ? "Activo" : "Inactivo")
}

// =================================================================================== //

function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "ListadoCompradores.aspx/ListarUsuarios",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            addRowDT(data.d);
        }
    });
}

// =================================================================================== //

// Llamando a la funcion de ajax al cargar el documento.
sendDataAjax();

