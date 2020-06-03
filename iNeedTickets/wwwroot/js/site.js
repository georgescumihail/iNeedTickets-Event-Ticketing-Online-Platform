// Search box effects

var searchBox = document.getElementById("search-box");

searchBox.addEventListener("focus", () => {
    searchBox.style.width = "370px";
});

searchBox.addEventListener("blur", () => {
    searchBox.style.width = "270px";
});

// Search button status

var searchButton = document.getElementById("search-button");

searchBox.addEventListener("input", () => {
    if (searchBox.value.length === 0) {
        searchButton.disabled = true;
    }
    else {
        searchButton.disabled = false;
    }
});

function savePurchaseDetails(orderId, payerId, payerName, orderDate, paymentAmount, currency){
    fetch("/purchase/saveDetails", {
        method: "POST",
        headers: { "Content-type": "application/json" },
        credentials: 'include',
        body: JSON.stringify({
            orderId,
            payerId,
            payerName,
            orderDate,
            paymentAmount,
            currency
        })
    });
}