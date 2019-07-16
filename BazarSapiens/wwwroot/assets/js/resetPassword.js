$(function () {
    if (document.getElementById("Input_Password") !== null) {
        document.getElementById("Input_Password").onchange = validatePassword;
        document.getElementById("Input_ConfirmPassword").onkeyup = validatePassword;
    }
});

function validatePassword() {

    var pass2 = document.getElementById("Input_ConfirmPassword").value;
    var pass1 = document.getElementById("Input_Password").value;
    if (pass1 !== pass2) {
        document.getElementById("Input_ConfirmPassword").setCustomValidity("Senhas não conferem");
    } else {
        document.getElementById("Input_ConfirmPassword").setCustomValidity('');
    }
}

