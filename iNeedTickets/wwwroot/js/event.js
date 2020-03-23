//price display

var typePicker = document.getElementById("type-picker");
var numberPicker = document.getElementById("number-picker");
var priceValueField = document.getElementById("total-price-value");
var priceRow = document.getElementById("total-price");
var ticketsAlert = document.getElementById("tickets-alert");
var buyButton = document.getElementById("buy-button");

var ticketsNo = numberPicker.options[typePicker.selectedIndex].value;

var selectedType;
var selectedPrice;

updateDetails();

typePicker.addEventListener("change", e => {
    selectedPrice = e.target.value;
    updateDetails();
});

numberPicker.addEventListener("change", e => {
    ticketsNo = e.target.value;
    updatePrice();
});

function updateDetails() {
    selectedType = typePicker.options[typePicker.selectedIndex].value;
    console.log(selectedType);
    selectedPrice = optionsList.find(o => o.id == selectedType).price;
    ticketsLeft = optionsList.find(o => o.id == selectedType).ticketsLeft;

    updatePrice();


    if (ticketsLeft == 0) {
        ticketsAlert.innerText = `No tickets left!`;
        ticketsAlert.style.visibility = "visible";
        buyButton.disabled = true;
        numberPicker.disabled = true;
        priceRow.style.visibility = "hidden";

    }
    else if (ticketsLeft <= 100) {
        ticketsAlert.innerText = `Only ${ticketsLeft} tickets left!`;
        ticketsAlert.style.visibility = "visible";
        buyButton.disabled = false;
        numberPicker.disabled = false;
        priceRow.style.visibility = "hidden";
    }
    else {
        ticketsAlert.innerText = "";
        ticketsAlert.style.visibility = "hidden";
        buyButton.disabled = false;
        numberPicker.disabled = false;
        priceRow.style.visibility = "hidden";
    }

    var nrOfAvailableTickets = 4;
    if (ticketsLeft < nrOfAvailableTickets) {
        nrOfAvailableTickets = ticketsLeft;
    }
    numberPicker.options.length = 0;
    for (var ticketsNr = 1; ticketsNr <= nrOfAvailableTickets; ticketsNr++) {
        numberPicker.options[numberPicker.options.length] = new Option(ticketsNr, ticketsNr);
    }
}

function updatePrice() {
    priceValueField.textContent = selectedPrice * ticketsNo;
}


buyButton.addEventListener("click", () => {
    alert(`Order placed for a total of ${selectedPrice * ticketsNo}`);
});



//map handling

var coords = [locationData.latitude, locationData.longitude];
var isPopupOpen = false;

var eventMap = L.map("event-map").setView(coords, 14);

L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(eventMap);

L.marker(coords).addTo(eventMap)
    .bindPopup(locationData.name);

document.getElementById("map-toggle")
    .addEventListener("click", () => {
        document.getElementById("map-global-container").style.display = "block";
        eventMap.invalidateSize();
        isPopupOpen = true;
});

document.getElementById("close-map-button")
    .addEventListener("click", () => {
    if (isPopupOpen == true) {
        document.getElementById("map-global-container").style.display = "none";
    }
});