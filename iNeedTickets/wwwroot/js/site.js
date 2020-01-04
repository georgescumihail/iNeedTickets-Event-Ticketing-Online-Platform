var searchBox = document.getElementById("search-box");

searchBox.addEventListener("focus", () => {
    searchBox.style.width = "370px";
});

searchBox.addEventListener("blur", () => {
    searchBox.style.width = "270px";
});