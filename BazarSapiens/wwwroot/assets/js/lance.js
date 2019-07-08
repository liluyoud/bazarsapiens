$(function () {
    var valorAtual = parseInt($('#Produto_ValorAtual').val());
    var valorLance = parseInt($('#Produto_ValorLance').val());
    var valorMinimo = valorAtual + 1;
    var valorNovoLance = valorAtual + valorLance;
    $('#valorLance').attr('min', valorMinimo);
    $('#valorLance').val(valorNovoLance);
});


function clickEfetuar() {
    var produtoId = $('#Produto_Id').val();
    var valorLance = $('#valorLance').val();
    var usuario = "Liluyoud";
    efetuarLance(produtoId, valorLance, usuario);
}

function efetuarLance(produtoId, valorLance, usuario) {
    //var urlSistema = window.location.protocol + "/" + window.location.host;
    var urlServico = "/api/lances?produtoId=" + produtoId + "&valorLance=" + valorLance + "&usuario=" + usuario;
    $.ajax({
        type: 'GET',
        url: urlServico,
        dataType: 'json',
        success: function (data) {
            alert("Seu lance foi efetuado, " + data.usuario);
        },
        error: function (ex) {
            alert('Não foi possível registrar seu lance');
        }
    });
}