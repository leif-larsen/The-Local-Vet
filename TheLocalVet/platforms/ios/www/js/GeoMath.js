angular.module('thelocalvet.geomath', [])
.service('geomath', function() {
    var self = this;
    var R = 6371; // earth's radius in km

    /**
     * calculate distance
     * @param geo1 lat
     * @param geo1 long
     * @param geo2 lat
     * @param geo2 long
     * @returns {Number}
     */
    this.calculateDistance = function(geo1Lat, geo1Long, geo2Lat, geo2Long) {
        var dLat = self.toRad(geo1Lat - geo2Lat);
        var dLon = self.toRad(geo1Long - geo2Long);
        var lat1 = self.toRad(geo2Lat);
        var lat2 = self.toRad(geo1Lat);

        var a = Math.sin(dLat/2) * Math.sin(dLat/2) +
            Math.sin(dLon/2) * Math.sin(dLon/2) * Math.cos(lat1) * Math.cos(lat2);
        var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a));
        return Math.round((R * c)*10) / 10;
    }

    /**
     * math util to convert lat/long to radians
     * @param value
     * @returns {number}
     */
    this.toRad = function(value) {
        return value * Math.PI / 180;
    }

    /**
     * math util to convert radians to latlong/degrees
     * @param value
     * @returns {number}
     */
    this.toDeg = function(value) {
        return value * 180 / Math.PI;
    }

});