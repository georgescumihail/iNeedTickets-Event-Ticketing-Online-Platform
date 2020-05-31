
document.getElementById("recovery-button")
    .addEventListener("click", () => {

        var email = document.getElementById("email-field").value;

        if (email != null && email.length > 0) {
            fetch("/account/recovery", {
                method: "POST",
                headers: { "Content-type": "application/json" },
                credentials: 'include',
                body: JSON.stringify({email})
            })
                .then(res => res.json())
                .then(res => handleEmailResponse(res));
        }
    });

var displayMessage = document.getElementById("display-message");

function handleEmailResponse(res) {
    if (res.isSuccess) {

        displayMessage.innerText = "Email sent";
    }
    else {
        displayMessage.innerText = res.message;
    }
}