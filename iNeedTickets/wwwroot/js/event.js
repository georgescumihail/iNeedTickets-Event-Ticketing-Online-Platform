//price display

var areaPicker = document.getElementById("area-picker");
var numberPicker = document.getElementById("number-picker");
var priceValueField = document.getElementById("total-price-value");
var priceRow = document.getElementById("total-price");
var ticketsAlert = document.getElementById("tickets-alert");
var buyButton = document.getElementById("buy-button");
var spinner = document.getElementById("loading-spinner");

var selectedTicketsNo = numberPicker.options[numberPicker.selectedIndex].value;

var selectedArea;
var selectedPrice;
var selectedName;
var totalPrice;
var isConfirmPopupOpen = false;

updateDetails();

areaPicker.addEventListener("change", e => {
    selectedPrice = e.target.value;
    updateDetails();
});

numberPicker.addEventListener("change", e => {
    selectedTicketsNo = e.target.value;
    updatePrice();
});

function updateDetails() {
    selectedArea = areaPicker.options[areaPicker.selectedIndex].value;
    selectedPrice = optionsList.find(o => o.id == selectedArea).price;
    selectedName = optionsList.find(o => o.id == selectedArea).areaName;
    ticketsLeft = optionsList.find(o => o.id == selectedArea).ticketsLeft;

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
        priceRow.style.visibility = "visible";
    }
    else {
        ticketsAlert.innerText = "";
        ticketsAlert.style.visibility = "hidden";
        buyButton.disabled = false;
        numberPicker.disabled = false;
        priceRow.style.visibility = "visible";
    }

    var nrOfAvailableTickets = 4;
    if (ticketsLeft < nrOfAvailableTickets) {
        nrOfAvailableTickets = ticketsLeft;
    }
    numberPicker.options.length = 0;
    for (var ticketsNr = 1; ticketsNr <= nrOfAvailableTickets; ticketsNr++) {
        numberPicker.options[numberPicker.options.length] = new Option(ticketsNr, ticketsNr);
    }

    if (ticketsLeft > 0) {
        selectedTicketsNo = numberPicker.options[0].value;
        updatePrice();
    }
}

function updatePrice() {
    totalPrice = selectedPrice * selectedTicketsNo
    priceValueField.textContent = totalPrice;
}

buyButton.addEventListener("click", () => {
    if (isUserLoggedIn) {
        isConfirmPopupOpen = true;
        document.getElementById("confirm-purchase-global-container").style.display = "block";
        document.getElementById("confirm-message").innerText = `${selectedTicketsNo} x ${eventName} - ${selectedName}`;
        document.getElementById("popup-price-tag").innerText = `${selectedPrice} lei`;
        document.getElementById("popup-price-total").innerText = `Total price: ${totalPrice} lei`;
    }
    else {
        redirectToLogin();
    }
});

document.getElementById("confirm-button")
    .addEventListener("click", () => {

        spinner.style.visibility = "visible";

        fetch("/purchase/execute", {
            method: "POST",
            headers: { "Content-type": "application/json" },
            credentials: 'include',
            body: JSON.stringify({
                ticketTypeId: selectedArea,
                ticketsCount: selectedTicketsNo
            })
        })
            .then(res => res.json())
            .then(res => handlePurchaseResponse(res));
});

function handlePurchaseResponse(res) {

    spinner.style.visibility = "hidden";

    if (res.isSuccess) {
        document.getElementById("success-buttons").style.display = "block";
        document.getElementById("confirm-button").style.display = "none";
        document.getElementById("purchase-success-message").style.display = "block";
    }
    else {
        document.getElementById("purchase-error-message").style.display = "block";
    }
}


//map handling

var coords = [locationData.latitude, locationData.longitude];
var isMapPopupOpen = false;

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
        isMapPopupOpen = true;
    });

document.getElementById("close-map")
    .addEventListener("click", () => {
        if (isMapPopupOpen == true) {
        document.getElementById("map-global-container").style.display = "none";
        }
    });

document.getElementById("close-purchase")
    .addEventListener("click", () => {
        if (isConfirmPopupOpen == true) {
            document.getElementById("confirm-purchase-global-container").style.display = "none";
        }
    });
