var map;
function initialize() {
    var directionsService = new google.maps.DirectionsService();
    var directionsRenderer = new google.maps.DirectionsRenderer();
    var latlng = new google.maps.LatLng(10.8437824, 106.6113905);
    var latlng1 = new google.maps.LatLng(10.8521201, 106.6279337);
    var options = {
        zoom: 15, center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
    };
    var map = new google.maps.Map(document.getElementById
        ("map"), options);
    directionsRenderer.setMap(map);


    var request = {
        origin: latlng,
        destination: latlng1,
        travelMode: 'DRIVING'

    };
    directionsService.route(request, function (response, status) {
        if (status == 'OK') {
            directionsRenderer.setDirections(response);
        }
    });
}
