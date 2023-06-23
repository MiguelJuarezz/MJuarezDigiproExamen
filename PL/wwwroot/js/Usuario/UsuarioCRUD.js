$(document).ready(function () {
    GetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5283/api/Alumno/GetAll',
        success: function (result) {//200 OK
            $('#tblAlumno tbody').empty();
            $.each(result.objects, function (i, alumno) {
                var filas =
                    '<tr>'
                    + '<td class="text-center"> '
                    + '<a class="btn btn-warning glyphicon glyphicon-edit" href="#" onclick="GetById(' + alumno.idAlumno + ')">'
                    + '<i class="bi bi-pencil-square"></i>'
                    + '</a> '
                    + '</td>'
                    + "<td  id='id' class='text-center' style='display: none;'>" + alumno.idAlumno + "</td>"
                    + "<td class='text-center'>" + alumno.nombre + "</td>"
                    + "<td class='text-center'>" + alumno.apellidoPaterno + "</td>"
                    + "<td class='text-center'>" + alumno.apellidoMaterno + "</td>"

                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + alumno.idAlumno + ')"><i class="bi bi-trash3-fill"></i></button></td>'

                    + "</tr>";


                $("#tblAlumno tbody").append(filas);

                //CreteRow(empleado);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
}


function Modal() {
    IniciarAlumno()
    var mostrar = $('#ModalForm').modal('show');
    /*    InitializeControls();*/
    /* IniciarEmpleado();*/

}
function hideModal() {
    var mostrar = $('#ModalForm').modal('hide');

}

function Guardar() {

    var alumno = {
        idAlumno: $('#txtIdAlumno').val(),
        nombre: $('#txtNombre').val(),
        apellidoPaterno: $('#txtApellidoPaterno').val(),
        apellidoMaterno: $('#txtApellidoMaterno').val(),
        //estado: {
        //    IdEstado: $('#ddlEstados').val()
        //}
    }
    if ($('#txtIdAlumno').val() == "") {
        alumno.idAlumno = 0
        Add(alumno);
    }
    else {
        Update(alumno);
    }

};

function Add(alumno) {
    if (confirm("Se esta agregando un alumno, ¿Estas seguro?")) {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:5283/api/Alumno/Add',
            dataType: 'json',
            data: JSON.stringify(alumno),
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

};

function GetById(IdAlumno) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5283/api/Alumno/GetById/' + IdAlumno,
        success: function (result) {
            $('#txtIdAlumno').val(result.object.idAlumno);
            $('#txtNombre').val(result.object.nombre);
            $('#txtApellidoPaterno').val(result.object.apellidoPaterno);
            $('#txtApellidoMaterno').val(result.object.apellidoMaterno);
          /*  $('#ddlEstados').val(result.Object.Estado.IdEstado);*/

            $('#ModalForm').modal('show');
            $('#lblTitulo').modal('Modificar Alumno');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }

    });

}

function IniciarAlumno() {

    var alumno = {
        idAlumno: $('#txtIdAlumno').val(''),
        nombre: $('#txtNombre').val(''),
        apellidoPaterno: $('#txtApellidoPaterno').val(''),
        apellidoMaterno: $('#txtApellidoMaterno').val('')
        //estado: {
        //    idEstado: $('#ddlEstados').val(0)
        //}
    }

};


function Eliminar(idAlumno) {

    if (confirm("¿Estas seguro de eliminar al alumno seleccionado?")) {
        $.ajax({
            type: 'DELETE',
            url: 'http://localhost:5283/api/Alumno/Delete/' + idAlumno,
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

function Update(alumno) {

    $.ajax({
        type: 'PUT',
        url: 'http://localhost:5283/api/Alumno/Update',
        dataType: 'json',
        data: JSON.stringify(alumno),
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