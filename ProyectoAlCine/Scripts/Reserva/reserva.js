$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: urls.buscarPeliculas,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            debugger;

            var options = $("#cmbPelicula");
            $.each(response, function (key, val) {
                options.append('<option value=' + val.ID + '>' + val.Name + '</option>');
            });
        }
    });
});

function buscarReservas() {
    var pelicula = $("#cmbPelicula").val();
    var fechaInicio = new Date($("#fechaInicio").val());
    var fechaFin = new Date($("#fechaFin").val());
    var diasDif = fechaFin.getTime() - fechaInicio.getTime();
    var dias = Math.round(diasDif / (1000 * 60 * 60 * 24));

    if (fechaInicio > fechaFin) {
        alert("La Fecha de Inicio no puede ser mayor a la fecha de Fin");
        return;
    }
    if (dias >= 30) {
        alert("La diferencia entre la Fecha de Inicio y la Fecha de Fin no puede ser mayor a 30 dias")
        return
    }

    $.ajax({
        type: "GET",
        url: urls.obtenerReservas,
        data: {
            'pelicula': pelicula,
            'fechaInicio': $("#fechaInicio").val(),
            'fechaFin': $("#fechaFin").val()
        },
        dataType: "html",
        success: function (response) {            

        }


    });
}
