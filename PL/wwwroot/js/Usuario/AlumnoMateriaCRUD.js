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
                    + '<a class="btn btn-warning glyphicon glyphicon-edit" href="#" onclick="GetAllMateriaAsignada(' + alumno.idAlumno + ')">'
                    + '<i class="bi bi-eye-fill"></i>'
                    + '</a> '
                    + '</td>'
                    + "<td  id='id' class='text-center' style='display: none;'>" + alumno.idAlumno + "</td>"
                    + "<td class='text-center'>" + alumno.nombre + "</td>"
                    + "<td class='text-center'>" + alumno.apellidoPaterno + "</td>"
                    + "<td class='text-center'>" + alumno.apellidoMaterno + "</td>"
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

function GetAllMateriaAsignada(IdAlumno) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5283/api/AlumnoMateria/MateriaGetAsignada/' + IdAlumno ,
        success: function (result) {//200 OK
            $('#tblMateriaAsignada tbody').empty();
            $.each(result.objects, function (i, materia) {
                var filas =
                    '<tr>'
                    + "<td  id='id' class='text-center' style='display: none;'>" + materia.materia.idMateria + "</td>"
                    + "<td class='text-center'>" + materia.materia.nombre + "</td>"
                    + "<td class='text-center'>" + materia.materia.costo + "</td>"

                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + materia.materia.idMateria + ')"><i class="bi bi-trash3-fill"></i></button></td>'

                    + "</tr>";


                $("#tblMateriaAsignada tbody").append(filas);
                $("#txtApellidoPaterno ").val(IdAlumno);

               
                //CreteRow(empleado);
            });

            $("#btnAgregar").show();
            $("#tblMateriaNoAsignada").hide();
            $("#tblMateriaAsignada").show();
            $("#btnMandar").hide();
            $("#divTotal").hide();


            Modal()
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
}

function GetAllMateriaNoAsignada() {
   var IdAlumno= $("#txtApellidoPaterno ").val();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5283/api/AlumnoMateria/MateriaGetNoAsignada/' + IdAlumno ,
        success: function (result) {
            $('#tblMateriaNoAsignada tbody').empty();
            $.each(result.objects, function (i, materia) {
                var filas =
                    '<tr>'
                    + "<td  id='id' class='text-center' style='display: none;'>" + materia.materia.idMateria + "</td>"
                    + "<td class='text-center' id ='find - table'><label><input type='checkbox' name='cbox1' id='thSelec' onclick='Sumar(this.checked, " + materia.materia.costo +" )', value='" + materia.materia.idMateria +"'></label></td>"
                    + "<td class='text-center'>" + materia.materia.nombre + "</td>"
                    + "<td class='text-center'>" + materia.materia.costo + "</td>"
                    + "</tr>";


                $("#tblMateriaNoAsignada tbody").append(filas);
              


                //CreteRow(empleado);
            });
            $("#btnAgregar").hide();
            $("#tblMateriaAsignada").hide();
            $("#tblMateriaNoAsignada").show();
            $("#divTotal").show();
            $("#btnMandar").show();
/*            $("#btnMandar").attr('onclick', 'ListaMaterias( ' + idAlumno + ')');*/
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
}

function Modal() {
    var mostrar = $('#ModalForm').modal('show');
    /*    InitializeControls();*/

}

function hideModal() {
    var mostrar = $('#ModalForm').modal('hide');

}


function ListaMaterias() {
    var IdAlumno = $("#txtApellidoPaterno ").val();
    $('#tblMateriaNoAsignada').find('input[type="checkbox"]').each(function () {
        if ($(this).is(':checked')) {
            var idMateria = $(this).val();
            Add(IdAlumno, idMateria)
        }
    });
};
function Sumar(check, valor) {
    var total = 0;
    total = parseInt($('#total').text());
    if (check == true) {
        total = total + valor;
    }
    else {
        total = total - valor;
    }
    $('#total').text(total) 
};

function Add(idAlumno, idMateria) {
    var alumnoMateria = {
        IdAlumno: idAlumno,
        IdMateria: idMateria,

    }
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5283/api/AlumnoMateria/Add/' + idAlumno + '/' + idMateria,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#ModalForm').modal('hide');
            GetAll();
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
};

function Eliminar(idMateria) {
    var idAlumno = $("#txtApellidoPaterno").val();

    if (confirm("¿Estas seguro de eliminar la materia seleccionada?")) {
        $.ajax({
            type: 'DELETE',
            url: 'http://localhost:5283/api/AlumnoMateria/Delete/' + idAlumno + '/' + idMateria,
            success: function (result) {
                $('#myModal').modal();
                GetAllMateriaAsignada(idAlumno)

            },
            error: function (result) {
                alert('Error en la consulta.');
            }
        });
    };
};

