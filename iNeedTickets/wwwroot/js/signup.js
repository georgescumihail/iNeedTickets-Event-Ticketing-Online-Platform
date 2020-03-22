
var emailField = document.getElementById("email-field");
var usernameField = document.getElementById("username-field");
var passwordField = document.getElementById("password-field");
var repeatField = document.getElementById("repeat-field");
var signupButton = document.getElementById("signup-button");
var errorMessage = document.getElementById("error-message");

signupButton.addEventListener("click", () => {

    var isDataValid = validateSignupInput();

    if (isDataValid) {

        var email = emailField.value;
        var password = passwordField.value;
        var username = usernameField.value;

        fetch("/account/create", {
            method: "POST",
            headers: { "Content-type": "application/json" },
            credentials: 'include',
            body: JSON.stringify({
                email: email,
                password: password,
                username: username
            })
        })
            .then(res => res.json())
            .then(res => handleResponse(res));
    }
});

handleResponse = res => {
    if (res.success == true) {
        window.location.href = "/";
    }
    else {
        displayErrorMessage(res.message);
    }
}

validateSignupInput = () => {
    var isValid = true;
    if (emailField == "" || usernameField == "" || passwordField == "" || repeatField == "") {
        isValid = false;
        displayErrorMessage("Please complete all fields!");
    }
    if (passwordField.value !== repeatField.value) {
        isValid = false;
        displayErrorMessage("Passwords do not match!");
    }
    if (!emailField.value.includes("@") || emailField.value.length < 6) {
        isValid = false;
        displayErrorMessage("Email format is invalid!");
    }
    if (passwordField.value.length < 5) {
        isValid = false;
        displayErrorMessage("Password is too short!");
    }
    return isValid;
}

displayErrorMessage = message => {
    errorMessage.style.visibility = "visible";
    errorMessage.innerText = message;
}

hideErrorMessage = () => {
    errorMessage.style.visibility = "hidden";
    errorMessage.innerText = null;
}