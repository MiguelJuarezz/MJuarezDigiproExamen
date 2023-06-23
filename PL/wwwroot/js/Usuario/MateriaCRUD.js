$(document).ready(function () {
    GetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5283/api/Materia/GetAll',
        success: function (result) {//200 OK
            $('#tblMateria tbody').empty();
            $.each(result.objects, function (i, materia) {
                var filas =
                    '<tr>'
                    + '<td class="text-center"> '
                    + '<a class="btn btn-warning glyphicon glyphicon-edit" href="#" onclick="GetById(' + materia.idMateria + ')">'
                    + '<i class="bi bi-pencil-square"></i>'
                    + '</a> '
                    + '</td>'
                    + "<td  id='id' class='text-center' style='display: none;'>" + materia.idMateria + "</td>"
                    + "<td class='text-center'>" + materia.nombre + "</td>"
                    + "<td class='text-center'>" + materia.costo + "</td>"

                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + materia.idMateria + ')"><i class="bi bi-trash3-fill"></i></button></td>'

                    + "</tr>";


                $("#tblMateria tbody").append(filas);

                //CreteRow(empleado);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
}

function Modal() {
    IniciarMateria() 
    var mostrar = $('#ModalForm').modal('show');
    /*    InitializeControls();*/
    /*IniciarEmpleado();*/

}
function hideModal() {
    var mostrar = $('#ModalForm').modal('hide');

}

function Guardar() {

    var materia = {
        idMateria: $('#txtIdMateria').val(),
        nombre: $('#txtNombre').val(),
        costo: $('#txtCosto').val(),
        //estado: {
        //    IdEstado: $('#ddlEstados').val()
        //}
    }
    if ($('#txtIdMateria').val() == "") {
        materia.idMateria = 0
        Add(materia);
    }
    else {
        Update(materia);
    }

};

function Add(materia) {
    if (confirm("Se esta agregando una materia, ¿Estas seguro?")) {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:5283/api/Materia/Add',
            dataType: 'json',
            data: JSON.stringify(materia),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                $('#myModal').modal();
                $('#ModalForm').modal('hide');
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });
    };

}

function GetById(IdMateria) {
    
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5283/api/Materia/GetById/' + IdMateria,
        success: function (result) {
            $('#txtIdMateria').val(result.object.idMateria);
            $('#txtNombre').val(result.object.nombre);
            $('#txtCosto').val(result.object.costo);
            /*  $('#ddlEstados').val(result.Object.Estado.IdEstado);*/

            $('#ModalForm').modal('show');
            $('#lblTitulo').modal('Modificar Materia');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }

    });

}


function IniciarMateria() {

    var materia = {
        idMateria: $('#txtIdMateria').val(''),
        nombre: $('#txtNombre').val(''),
        costo: $('#txtCosto').val('')
        //estado: {
        //    idEstado: $('#ddlEstados').val(0)
        //}
    }

};

function Eliminar(idMateria) {

    if (confirm("¿Estas seguro de eliminar la materia seleccionada?")) {
        $.ajax({
            type: 'DELETE',
            url: 'http://localhost:5283/api/Materia/Delete/' + idMateria,
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    };
};


function Update(materia) {

    $.ajax({
        type: 'PUT',
        url: 'http://localhost:5283/api/Materia/Update',
        dataType: 'json',
        data: JSON.stringify(materia),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalForm').modal('hide');
            GetAll();

            //CatEntidadFederativGetAll();
            //EstadoGetAll();
            //Console(respond);
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });

};