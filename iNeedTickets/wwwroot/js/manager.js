
function handleTableClick(id) {
    window.location.href = "manager/editEvent/" + id;
}

document.getElementById("add-button")
    .addEventListener("click", () => {
        window.location.href = "manager/addEvent/";
    });