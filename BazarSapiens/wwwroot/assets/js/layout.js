$(function () {
    $('.cpf').mask('000.000.000-00', { reverse: true });
    $('.celular').mask("(00) 00000-0000", { placeholder: "(  )      -    " });

    if (document.getElementById("registerPassword") !== null) {
        document.getElementById("registerPassword").onchange = validatePassword;
        document.getElementById("registerConfirmation").onkeyup = validatePassword;
    }

    if (document.getElementById("registerCpf") !== null) {
        document.getElementById("registerCpf").onkeyup = testaCPF;
    }
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

function testaCPF() {
    var strCPF = document.getElementById("registerCpf").value;
    strCPF = strCPF.replace(/\D+/g, "");
    var erro = "";
    var Soma;
    var Resto;
    Soma = 0;
    if (strCPF === "00000000000") erro = "CPF inválido";

    for (i = 1; i <= 9; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto === 10) || (Resto === 11)) Resto = 0;
    if (Resto !== parseInt(strCPF.substring(9, 10))) erro = "CPF inválido";

    Soma = 0;
    for (i = 1; i <= 10; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto === 10) || (Resto === 11)) Resto = 0;
    if (Resto !== parseInt(strCPF.substring(10, 11))) erro = "CPF inválido";

    document.getElementById("registerCpf").setCustomValidity(erro);
}
