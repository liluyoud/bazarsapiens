function clickExcluirFoto(link) {
    var foto = link.title;
    link.parentElement.parentElement.parentElement.style.display = 'none';
    excluirFoto(foto);
}

function excluirFoto(foto) {
    var urlServico = "/api/produtos?foto=" + foto;
    $.ajax({
        type: 'GET',
        url: urlServico,
        dataType: 'json',
        success: function () {
        },
        error: function () {
            if (data !== false) {
                swal({
                    title: "Erro",
                    text: "Não foi possível excluir o arquivo",
                    type: "error"
                });
            } 
        }
    });
}