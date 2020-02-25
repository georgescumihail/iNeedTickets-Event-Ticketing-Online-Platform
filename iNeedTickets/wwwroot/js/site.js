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