// Initialize and add the map
function initMap() {
    // The location of Uluru
    const uluru = { lat: 10.87766170295706, lng: 106.80162579128859 };
    // The map, centered at Uluru
    const map = new google.maps.Map(document.getElementById("google-map"), {
        zoom: 4,
        center: uluru,
    });
    // The marker, positioned at Uluru
    const marker = new google.maps.Marker({
        position: uluru,
        map: map,
    });
}