var map;
var title;
title = '<span style="font-family:\'Roboto\';"><strong>Hyundai Cầu Diễn</strong></span><br /><span style="font-family:\'Roboto\';">Ô số 2, lô 1, cụm CN Lai Xá, Kim Chung, Hoài Đức, Hà Nội.<br /></span>Hot line Bán hàng: <strong>0904 639 909</strong><br />';
var infowindow = new google.maps.InfoWindow({ size: new google.maps.Size(150, 50) });
function initialize() {
    var mapOptions = {
        zoom: 16,
        center: new google.maps.LatLng(21.058588, 105.727344),
    };
    var latlng = new google.maps.LatLng(21.058588, 105.727344);
    map = new google.maps.Map(document.getElementById('map-canvas'),
        mapOptions);
    createMarkerMaps(latlng, title);
}
function createMarkerMaps(latlng, html) {

    var contentString = html;
    var marker = new google.maps.Marker({
        position: latlng,
        map: map,
        animation: google.maps.Animation.BOUNCE,
        zIndex: Math.round(latlng.lat() * -100000) << 5
    });

    infowindow.setContent(contentString);
    infowindow.open(map, marker);

    google.maps.event.addListener(marker, 'click', function () {
        infowindow.setContent(contentString);
        infowindow.open(map, marker);
    });
    //    gmarkers.push(marker);
}
google.maps.event.addDomListener(window, 'load', initialize);