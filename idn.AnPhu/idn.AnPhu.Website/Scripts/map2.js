//var map;
//var map2;
//var title;
//var title2;

////title2 = '';
//title2 = '<span style="font-family:\'Roboto\';"><strong>Hyundai An Lạc</strong></span><br /><span style="font-family:\'Roboto\';">563 Kinh Dương Vương, An Lạc, Bình Tân, Hồ Chí Minh, Vietnam<br /></span></strong><br />';
//title = '<span style="font-family:\'Roboto\';"><strong>Đại lý xe ô tô Hyundai Cầu Diễn</strong></span><br /><span style="font-family:\'Roboto\';">327 QL13, Hiệp Bình Phước, Hồ Chí Minh, Vietnam<br /></span></strong><br />';

////var infowindow = new google.maps.InfoWindow({ size: new google.maps.Size(150, 50) });








//function initialize() {

//    var mapOptions = {
//        zoom: 200,
//        center: new google.maps.LatLng(10.733870, 106.612659),
//    };
//    var latlng = new google.maps.LatLng(10.733870, 106.612659);
//    map = new google.maps.Map(document.getElementById('map-canvas2'),
//        mapOptions);
//    createMarkerMaps(latlng, title);
//}


//function createMarkerMaps(latlng, html) {

//    var contentString = html;
//    var marker = new google.maps.Marker({
//        position: latlng,
//        map: map,
//        title: '<span style="font-family:\'Roboto\';"><strong>Đại lý xe ô tô Hyundai Cầu Diễn</strong></span><br /><span style="font-family:\'Roboto\';">327 QL13, Hiệp Bình Phước, Hồ Chí Minh, Vietnam<br /></span></strong><br />',
//        animation: google.maps.Animation.BOUNCE,
//        zIndex: Math.round(latlng.lat() * -100000) << 5
//    });


//    var infowindow = new google.maps.InfoWindow();
//    infowindow.setContent(title2);
//    infowindow.open(map, marker);
//}
//google.maps.event.addDomListener(window, 'load', initialize);




////var infowindow2 = new google.maps.InfoWindow({ size: new google.maps.Size(150, 50) });
////function initialize2() {

////    var mapOptions = {
////        zoom: 200,
////        center: new google.maps.LatLng(10.733870, 106.612659),
////    };
////    var latlng2 = new google.maps.LatLng(10.733870, 106.612659);
////    map2 = new google.maps.Map(document.getElementById('map-canvas2'),
////        mapOptions);
////    createMarkerMaps(latlng2, title2);
////}
////function createMarkerMaps2(latlng, html) {

////    var contentString = html;
////    var marker = new google.maps.Marker({
////        position: latlng2,
////        map: map2,
////        animation: google.maps.Animation.BOUNCE,
////        zIndex: Math.round(latlng2.lat() * -100000) << 5
////    });

////    infowindow2.setContent(contentString);
////    infowindow2.open(map2, marker);

////    google.maps.event.addListener(marker, 'click', function () {
////        infowindow2.setContent(contentString);
////        infowindow2.open(map2, marker);
////    });
////    //    gmarkers.push(marker);
////}
////google.maps.event.addDomListener(window, 'load', initialize2);






////function initialize() {

////    var myLatlngOH = new google.maps.LatLng(10.838558, 106.714809);

////    var myLatlngCA = new google.maps.LatLng(10.733870, 106.612659);

////    var infowindow = new google.maps.InfoWindow();
////    infowindow.setContent(title);
////    infowindow.open(map, marker);


////    var mapOptionsOH = {

////        zoom: 200,

////        center: myLatlngOH,

////        mapTypeId: google.maps.MapTypeId.ROADMAP,

////        mapTypeControl: 0

////    }

////    var mapOptionsCA = {

////        zoom: 200,

////        center: myLatlngCA,

////        mapTypeId: google.maps.MapTypeId.ROADMAP,

////        mapTypeControl: 0

////    }



////    var mapOH = new google.maps.Map(document.getElementById('map-canvas'), mapOptionsOH);

////    var mapCA = new google.maps.Map(document.getElementById('map-canvas2'), mapOptionsCA);


////       var markerOH = new google.maps.Marker({

////        position: myLatlngOH,

////        map: mapOH,
////        animation: google.maps.Animation.BOUNCE,

////        title: 'Company Office - Ohio',




////    });


////    var markerCA = new google.maps.Marker({

////        position: myLatlngCA,

////        map: mapCA,
////        animation: google.maps.Animation.BOUNCE,

////        title: 'Company Office - California'

////    });



////}

////google.maps.event.addDomListener(window, 'load', initialize);







