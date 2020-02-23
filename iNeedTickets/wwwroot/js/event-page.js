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

function updatePrice() {
    priceLabel.textContent = selectedPrice * ticketsNo;
}

document.getElementById("buy-button")
        .addEventListener("click", () => {
        alert(`Order placed for a total of ${selectedPrice * ticketsNo}`);
    });
