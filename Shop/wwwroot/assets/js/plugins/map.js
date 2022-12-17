// Initialize and add the map
function initMap() {
    // The location of Uluru 
    //10.038004678784368, 105.78266325280373
    const uluru = { lat: 10.038004678784368, lng: 105.78266325280373 };
    // The map, centered at Uluru
    const map = new google.maps.Map(document.getElementById("google-map"), {
        zoom: 15,
        center: uluru,
    });
    // The marker, positioned at Uluru
    const marker = new google.maps.Marker({
        position: uluru,
        map: map,
    });
}