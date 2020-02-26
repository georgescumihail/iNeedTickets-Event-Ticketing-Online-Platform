//price display

var typePicker = document.getElementById("type-picker");
var numberPicker = document.getElementById("number-picker");
var priceLabel = document.getElementById("total-price-value");

var selectedPrice = typePicker.options[typePicker.selectedIndex].value;
var ticketsNo = numberPicker.options[typePicker.selectedIndex].value;

updatePrice();

typePicker.addEventListener("change", e => {
    selectedPrice = e.target.value;
    updatePrice();
});

numberPicker.addEventListener("change", e => {
    ticketsNo = e.target.value;
    updatePrice();
});

function updatePrice(){
    priceLabel.textContent = selectedPrice * ticketsNo;
}

document.getElementById("buy-button")
    .addEventListener("click", () => {
        alert(`Order placed for a total of ${selectedPrice * ticketsNo}`);
});

//map handling

var coords = [locationData.latitude, locationData.longitude];
var isPopupOpen = false;

var eventMap = L.map("event-map").setView([locationData.latitude, locationData.longitude], 14);

L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(eventMap);

L.marker([locationData.latitude, locationData.longitude]).addTo(eventMap)
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