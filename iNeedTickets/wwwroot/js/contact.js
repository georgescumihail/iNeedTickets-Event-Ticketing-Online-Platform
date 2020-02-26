
var contactMap = L.map("contact-map").setView([44.4271, 26.15807], 14);

L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(contactMap);

L.marker([44.4271, 26.15807]).addTo(contactMap)
    .bindPopup("Somewhere around here. Quack!");