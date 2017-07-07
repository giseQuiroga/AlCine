$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: urls.buscarPeliculas,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var options = $("#cmbPelicula");
            options.append('<option value=""> Seleccione un valor  </option>');
            $.each(response, function (key, val) {

                options.append('<option value=' + val.ID + '>' + val.Name + '</option>');
            });
        }
    });
});

function buscarReservas() {

    var pelicula = $("#cmbPelicula").val();
    var fechaIni = $("#fechaInicio").val() == "" ? null : $("#fechaInicio").val();
    var fechaF = $("#fechaFin").val() == "" ? null : $("#fechaFin").val();


    var urlt = urls.obtenerReservas;

    if (pelicula == "") {
        alert("Por favor Seleccione una pelicula");
        return;
    }
    else if (fechaIni == null) {
        alert("Por favor ingrese la Fecha de Inicio");
        return;
    }
    else if (fechaF == null) {
        alert("Por favor ingrese la Fecha de Fin");
        return;
    }
    else if (new Date(fechaIni) > new Date(fechaF)) {
        alert("La Fecha de Inicio no puede ser mayor a la fecha de Fin");
        return;
    }
    else {
        var diasDif = new Date(fechaIni).getTime() - new Date(fechaF).getTime();
        var dias = Math.round(diasDif / (1000 * 60 * 60 * 24));

        if (dias >= 30) {
            alert("La diferencia entre la Fecha de Inicio y la Fecha de Fin no puede ser mayor a 30 dias")
            return
        }
    }

    $('tbody').empty();

    $.ajax({
        type: "GET",
        url: urls.obtenerReservas,
        data: {
            pelicula: pelicula,
            fechaInicio: fechaIni,
            fechaFin: fechaF
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            if (response != null && response.length > 0) {

                var tr;

                for (var i = 0; i < response.length; i++) {
                    tr = $('<tr/>');
                    tr.append("<td>" + response[i].Pelicula + "</td>");
                    tr.append("<td>" + response[i].Sede + "</td>");
                    tr.append("<td>" + response[i].Version + "</td>");
                    tr.append("<td>" + response[i].Precio + "</td>");
                    $('table').append(tr);
                }
            }
            else {

            }
        },
        error: function (ex) {
            alert('Failed to retrieve states.' + ex);
        }
    });
}

function ChangeSede() {

    var IdSede = $('#IdSede').val() == "" ? 0 : $('#IdSede').val();
    var IdPelicula = $('#IdPelicula').val();

    if (IdSede != 0 && IdVersion != 0 && IdPelicula != 0) {

        $.ajax({
            url: '/Reserva/ChangeSede',
            type: "GET",
            dataType: "JSON",
            data: { IdSede: IdSede, IdPelicula: IdPelicula },
            success: function (response) {

                if (response != null && response.length > 0) {

                    $('#IdVersion').prop("disabled", false);
                    $("#IdVersion").find('option').not(':first').remove();

                    var options = $("#IdVersion");

                    $.each(response, function (key, val) {
                        options.append('<option value=' + val.Value + '>' + val.Text + '</option>');
                    });
                }
                else {
                    $('#IdVersion').prop("disabled", true);
                }
            },
            error: function (ex) {
                alert('Failed to retrieve states.' + ex);
            }
        });
    }


    $("#IdVersion").find('option').not(':first').remove();
    $("#IdDias").find('option').not(':first').remove();
    $("#IdHoraInicio").find('option').not(':first').remove();

    $('#IdVersion').prop("disabled", true);
    $('#IdDias').prop("disabled", true);
    $('#IdHoraInicio').prop("disabled", true);
}


function ChangeVersion() {
    var IdSede = $('#IdSede').val() == "" ? 0 : $('#IdSede').val();
    var IdVersion = $('#IdVersion').val() == "" ? 0 : $('#IdVersion').val();
    var IdPelicula = $('#IdPelicula').val() == "" ? 0 : $('#IdPelicula').val();

    if (IdSede != 0 && IdVersion != 0 && IdPelicula != 0) {
        $.ajax({
            url: '/Reserva/ChangeVersion',
            type: "GET",
            dataType: "JSON",
            data: { IdSede: IdSede, Idversion: IdVersion, IdPelicula: IdPelicula },
            success: function (response) {

                if (response != null && response.length > 0) {

                    $('#IdDias').prop("disabled", false);
                    $("#IdDias").find('option').not(':first').remove();

                    var options = $("#IdDias");

                    $.each(response, function (key, val) {

                        options.append('<option value=' + val.Valor + '>' + val.Descripcion + '</option>');
                    });
                }
                else {
                    $('#IdDias').prop("disabled", true);
                }
            },
            error: function (ex) {
                alert('Failed to retrieve states.' + ex);
            }
        });
    }
    else {
        $("#IdHoraInicio").find('option').not(':first').remove();
        $("#IdDias").find('option').not(':first').remove();

        $('#IdDias').prop("disabled", true);
        $('#IdHoraInicio').prop("disabled", true);
    }

}

function ChangeDia() {

    var IdSede = $('#IdSede').val() == "" ? 0 : $('#IdSede').val();
    var IdVersion = $('#IdVersion').val() == "" ? 0 : $('#IdVersion').val();
    var IdPelicula = $('#IdPelicula').val() == "" ? 0 : $('#IdPelicula').val();
    var IdDias = $('#IdDias').val() == "" ? 0 : $('#IdDias').val();

    if (IdSede != 0 && IdVersion != 0 && IdPelicula != 0 && IdDias != 0) {
        $.ajax({
            url: '/Reserva/ChangeDia',
            type: "GET",
            dataType: "JSON",
            data: { IdSede: IdSede, Idversion: IdVersion, IdPelicula: IdPelicula },
            success: function (response) {

                if (response != null && response.length > 0) {

                    $('#IdHoraInicio').prop("disabled", false);
                    $("#IdHoraInicio").find('option').not(':first').remove();

                    var options = $("#IdHoraInicio");

                    $.each(response, function (key, val) {
                        options.append('<option value=' + val + '>' + val + '</option>');
                    });
                }
                else {
                    $('#IdHoraInicio').prop("disabled", true);
                }
            },
            error: function (ex) {
                alert('Failed to retrieve states.' + ex);
            }
        });
    }
    else {
        $("#IdHoraInicio").find('option').not(':first').remove();

        $('#IdHoraInicio').prop("disabled", true);
    }
}



