
var deleteButton = document.getElementById("delete-event");

deleteButton.addEventListener("click", handleEventDelete);

function handleEventDelete() {
    fetch("/admin/manager/DeleteEvent/" + eventId)
        .then(res => res.json())
        .then(res => handleDeleteResponse(res));
}

function handleDeleteResponse() {
    window.location.href = "/admin/manager";
}