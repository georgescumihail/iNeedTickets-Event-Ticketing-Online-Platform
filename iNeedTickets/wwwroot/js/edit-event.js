
var submitButton = document.getElementById("submit-button");
var deleteButton = document.getElementById("delete-button");

submitButton.addEventListener("click", submitChanges);
deleteButton.addEventListener("click", handleEventDelete);

var areasList = [];

function submitChanges() {

    for (var areaNr = 1; areaNr <= areasCount; areaNr++) {
        areasList.push({
            id: document.getElementById("area-id-" + areaNr).value,
            name: document.getElementById("area-name-" + areaNr).value,
            price: document.getElementById("area-price-" + areaNr).value,
            capacity: document.getElementById("area-capacity-" + areaNr).value
        });
    }

    var areasData = JSON.stringify(areasList);
    var eventName = document.getElementById("name-field").value;
    var eventDescription = document.getElementById("description-field").value;
    var eventDate = document.getElementById("date-field").value;
    var eventTags = document.getElementById("tags-field").value;
    

    fetch("/admin/manager/editevent", {
        method: "POST",
        headers: { "Content-type": "application/json" },
        credentials: 'include',
        body: JSON.stringify({
            id: eventId,
            name: eventName,
            description: eventDescription,
            date: eventDate,
            tags: eventTags,
            areas: areasData
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