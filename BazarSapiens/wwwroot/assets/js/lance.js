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
    var usuario = $('#userName').val();
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
            if (data.id !== 0) {
                $('#usuarioUltimoLance').html(data.usuario);
                $('#valorUltimoLance').html(data.valorLance);
                $('#valorLance').val(data.valorLance + 1);
                swal({
                    title: "Lance Efetivado",
                    text: data.usuario + ", seu lance foi registrado",
                    type: "success"
                });
            } else {
                swal({
                    title: "Erro no lance",
                    text: "Seu lance não foi registrado",
                    type: "error"
                });
            }
        },
        error: function (ex) {
            swal({
                title: "Erro",
                text: data.usuario + "Seu lance não foi registrado, tente novamente",
                type: "error"
            });
        }
    });
}