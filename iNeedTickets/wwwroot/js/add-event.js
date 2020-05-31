
var addAreaButton = document.getElementById("add-area");
var submitEventButton = document.getElementById("add-event-button");
var nameField = document.getElementById("name-field");
var dateField = document.getElementById("date-field");
var locationField = document.getElementById("location-field");
var categoryField = document.getElementById("category-field");
var descriptionField = document.getElementById("description-field");
var tagsField = document.getElementById("tags-field");
var isSeated = document.getElementById("seated-check");
var photoField = document.getElementById("photo-field");
var errorMessage = document.getElementById("error-message");

var areasCounter = 1;
var areasData = [];

addAreaButton.addEventListener("click", addType);
submitEventButton.addEventListener("click", submitData);

function submitData() {

    for (var typeNo = 1; typeNo <= areasCounter; typeNo++) {
        areasData.push({
            name: document.getElementById("area-name-" + typeNo).value,
            price: document.getElementById("area-price-" + typeNo).value,
            capacity: document.getElementById("area-capacity-" + typeNo).value
        });
    }

    var formData = new FormData();

    formData.append("name", nameField.value);
    formData.append("date", dateField.value);
    formData.append("location", locationField.options[locationField.selectedIndex].value);
    formData.append("category", categoryField.options[categoryField.selectedIndex].value);
    formData.append("description", descriptionField.value);
    formData.append("tags", tagsField.value);
    formData.append("seated", isSeated.checked);
    formData.append("image", photoField.files[0]);
    formData.append("areas", JSON.stringify(areasData));

    fetch("/admin/manager/AddEvent", {
        method: "POST",
        credentials: 'include',
        body: formData
    })
        .then(res => res.json())
        .then(res => handleAddResponse(res));

    areasData = [];
}

function handleAddResponse(res) {

    if (res.isSuccess) {
        window.location.href = "/admin/manager";
    }
    else {
        errorMessage.innerText = "Please complete all the fields!";
        errorMessage.style.visibility = "visible";
    }
}

function addType() {

    areasCounter++;

    var newType = document.createElement("div");
    newType.classList.add("type-container");
    newType.innerHTML = `<span>Area ${areasCounter}:</span>
                    <input id="area-name-${areasCounter}" class="area-details form-control" placeholder="Name" />
                    <input id="area-price-${areasCounter}" class="area-details form-control" placeholder="Price" />
                    <input id="area-capacity-${areasCounter}" class="area-details form-control" placeholder="Capacity" />`;

    document.getElementById("types-container").appendChild(newType);
}