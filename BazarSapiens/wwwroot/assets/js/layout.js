$(function () {
    $('.cpf').mask('000.000.000-00', { reverse: true });
    $('.celular').mask("(00) 00000-0000", { placeholder: "(  )      -    " });

    document.getElementById("registerPassword").onchange = validatePassword;
    document.getElementById("registerConfirmation").onkeyup = validatePassword;
});

function validatePassword() {

    var pass2 = document.getElementById("registerConfirmation").value;
    var pass1 = document.getElementById("registerPassword").value;
    if (pass1 !== pass2) {
        document.getElementById("registerConfirmation").setCustomValidity("Senhas não conferem");
    } else {
        document.getElementById("registerConfirmation").setCustomValidity('');
    }
}

