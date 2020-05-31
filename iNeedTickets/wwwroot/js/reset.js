﻿
var passwordInput = document.getElementById("new-password");
var confirmInput = document.getElementById("confirm-password");

passwordInput.addEventListener("keyup", validatePasswords);
confirmInput.addEventListener("keyup", validatePasswords);

function validatePasswords() {
    console.log(passwordInput.value + confirmInput.value);
    if (passwordInput.value !== confirmInput.value) {
        document.getElementById("submit-reset").disabled = true;
    }
    else {
        document.getElementById("submit-reset").disabled = false;
    }
}