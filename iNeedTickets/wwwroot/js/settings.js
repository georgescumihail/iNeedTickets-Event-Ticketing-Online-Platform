
var usernameMessage = document.getElementById("username-message");
var emailMessage = document.getElementById("email-message");
var passwordMessage = document.getElementById("password-message");

document.getElementById("submit-username")
    .addEventListener("click", () => {

        var username = document.getElementById("username-field").value;

        if (username.length > 0) {
            fetch("/account/changeUsername", {
                method: "POST",
                headers: { "Content-type": "application/json" },
                credentials: 'include',
                body: JSON.stringify({ username })
            })
                .then(res => res.json())
                .then(res => handleUsernameResponse(res));
        }
        else {
            usernameMessage.innerText = "Invalid username!";
        }
    });

document.getElementById("submit-email")
    .addEventListener("click", () => {

        var email = document.getElementById("email-field").value;

        if (email.includes("@") && email.length > 6) {
            fetch("/account/changeEmail", {
                method: "POST",
                headers: { "Content-type": "application/json" },
                credentials: 'include',
                body: JSON.stringify({ email })
            })
                .then(res => res.json())
                .then(res => handleEmailResponse(res));
        }
        else {
            emailMessage.innerText = "Invalid email!";
        }
    });

document.getElementById("submit-password")
    .addEventListener("click", () => {

        var newPassword = document.getElementById("new-password-field").value;
        var confirmedPassword = document.getElementById("confirm-password-field").value;
        var oldPassword = document.getElementById("old-password-field").value;

        if (newPassword === confirmedPassword) {
            fetch("/account/changePassword", {
                method: "POST",
                headers: { "Content-type": "application/json" },
                credentials: 'include',
                body: JSON.stringify({
                    newPassword: newPassword,
                    oldPassword: oldPassword
                })
            })
                .then(res => res.json())
                .then(res => handlePasswordResponse(res));
        }
        else {
            passwordMessage.innerText = "Passwords do not match!";
        }
    });

function handleUsernameResponse(res) {
    if (res.isSuccess) {
        usernameMessage.innerText = "User changed successfully";
    }
    else {
        usernameMessage.innerText = "User change error!";
    }
}

function handleEmailResponse(res) {
    if (res.isSuccess) {
        emailMessage.innerText = "Email changed successfully";
    }
    else {
        emailMessage.innerText = "Email change error!";
    }
}

function handlePasswordResponse(res) {
    if (res.isSuccess) {
        passwordMessage.innerText = "Password changed successfully";
    }
    else {
        passwordMessage.innerText = "Password change error!";
    }
}