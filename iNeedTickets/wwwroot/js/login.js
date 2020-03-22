
var emailField = document.getElementById("email-field");
var passwordField = document.getElementById("password-field");
var loginButton = document.getElementById("login-button");
var errorMessage = document.getElementById("error-message");

loginButton.addEventListener("click", () => {

    var email = emailField.value;
    var password = passwordField.value;

    if (email != "" && password != "") {

        hideErrorMessage();
        fetch("/account/login", {
            method: "POST",
            headers: { "Content-type": "application/json" },
            credentials: 'include',
            body: JSON.stringify({
                email: email,
                password: password
            })
        })
            .then(res => res.json())
            .then(res => displayErrorMessage(res.message));
    }
    else {
        displayErrorMessage("Please complete all fields!");
    }
});

displayErrorMessage = message => {
    errorMessage.style.visibility = "visible";
    errorMessage.innerText = message;
}

hideErrorMessage = () => {
    errorMessage.style.visibility = "hidden";
    errorMessage.innerText = null;
}