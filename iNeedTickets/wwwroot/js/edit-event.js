
var submitButton = document.getElementById("submit-button");
var deleteButton = document.getElementById("delete-button");

submitButton.addEventListener("click", submitChanges);
deleteButton.addEventListener("click", handleEventDelete);

function submitChanges() {

    var eventName = document.getElementById("name-field").value;
    var eventDescription = document.getElementById("description-field").value;

    console.log("aici?")

    fetch("/admin/manager/editevent", {
        method: "POST",
        headers: { "Content-type": "application/json" },
        credentials: 'include',
        body: JSON.stringify({
            id: eventId,
            name: eventName,
            description: eventDescription
            })
        })
        .then(res => res.json())
        .then(res => handleEditResponse(res));
}

function handleEditResponse() {
    window.location.href = "/admin/manager";
}

function handleEventDelete() {
    fetch("/admin/manager/deleteevent/" + eventId)
        .then(res => res.json())
        .then(res => handleDeleteResponse(res));
}

function handleDeleteResponse() {
    window.location.href = "/admin/manager";
}