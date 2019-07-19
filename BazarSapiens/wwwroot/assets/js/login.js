$(function () {
    document.getElementById("linkRegister").onclick = linkRegisterUser;
    document.getElementById("linkRecovery").onclick = linkForgotPassword;

});

function linkRegisterUser() {
    $('#linkTabLogin').removeClass("active");
    $('#ms-login-tab').removeClass("active show");

    $('#linkTabRegister').addClass("active");
    $('#ms-register-tab').addClass("active show");

    $('#linkTabRecovery').removeClass("active");
    $('#ms-recovery-tab').removeClass("active show");
}

function linkForgotPassword() {
    $('#linkTabLogin').removeClass("active");
    $('#ms-login-tab').removeClass("active show");

    $('#linkTabRegister').removeClass("active");
    $('#ms-register-tab').removeClass("active show");

    $('#linkTabRecovery').addClass("active");
    $('#ms-recovery-tab').addClass("active show");
}