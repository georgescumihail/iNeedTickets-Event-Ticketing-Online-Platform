
var eventsTable = document.getElementById("events-table");

var filteredList = [];

function handleTableClick(id) {
    window.location.href = "manager/editEvent/" + id;
}

function filterEvents(query) {
    eventsTable.innerHTML = "";
    var newContent = `<tr class="table-head">
        <th> Name</th>
        <th>Location</th>
        <th>Date</th>
        </tr >`;
    filteredList = eventList.filter(e => e.name.toLowerCase().includes(query) || e.location.toLowerCase().includes(query));
    if (filteredList.length > 0) {
        filteredList.forEach(e => {
            newContent += `<tr onclick="handleTableClick(${e.id})" id="'event-' + e.id">
                    <td>${e.name}</td>
                    <td>${e.location}</td>
                    <td>${e.date}</td>
                    </tr>`;
        });
        eventsTable.innerHTML = newContent;
    }
    else {
        eventsTable.innerHTML = "<div>No results</div>"
    }
}

document.getElementById("table-search")
    .addEventListener("keyup", e => filterEvents(e.target.value));

document.getElementById("add-button")
    .addEventListener("click", () => {
        window.location.href = "manager/addEvent/";
    });