angular.module('thelocalvet.controllers', [])

.controller('MainCtrl', function($scope, $state) {
  navigator.geolocation.getCurrentPosition( function(pos) {
    // Just initializing geolocation, so it can access the phones geolocation
  });
  
  $scope.searchMyLocation = function () {
    $state.go('MyLoc')
  }
  
  $scope.placeSearch = function () {
    $state.go('PlaceSearch')
  }
})

.controller('MyLocCtrl', function ($scope, $state, Azureservice, $ionicLoading, geomath) {
  $scope.vets = [];
  
  // Show loading bar to indicate that vets are loading
  $scope.loading = $ionicLoading.show({
    content: 'Henter dyrleger',
    showBackdrop: false
  });
  
  // Get the current position of the device
    navigator.geolocation.getCurrentPosition( function(pos) {
      $scope.lat = pos.coords.latitude;
      $scope.lon = pos.coords.longitude;
    });
    
  // Fetch vets from Azure mobile service, using Azure Service module
  Azureservice.getAll('Vet')
  .then(function(vets) {
    console.log('Query Successful');
    $scope.temp = vets;
    
    for(vet in $scope.temp) {
      var distance = geomath.calculateDistance($scope.lat, $scope.lon, vet.lat, vet.lon);
      $scope.vets.push()
    }
    
    $ionicLoading.hide();
  }, function(err) {
    console.error('Azure Error: ' + err);
  })
})

.controller('DetailCtrl', function ($scope, $state, $stateParams, Azureservice) {
  Azureservice.getById('Vet', $stateParams.vetid)
  .then(function(vet) {
    console.log('Query Successful!');
    $scope.vetItem = vet;
  }, function (err) {
    console.error('Azure Error: ' + err);
  })
  
  $scope.callVet = function(phone) {
    phonedialer.dial(phone, function(err){
      console.log("calling: " + phone);
      if (err == "feature") {
        alert("Din mobil st&oslash;tter ikke denne handlingen");
      }
      if (err == "empty") {
        alert("Ukjent nummer");
      }
    });
  }
})

.controller('PlaceSearchCtrl', function($scope, $state, Azureservice, $ionicPopup) {
  $scope.query = "";
  
  var doSearch = ionic.debounce(function(query) {
    console.log('search for ' + query)
    Azureservice.query('Vet', {
      criteria: {
        adr_cli_place: query
      }
    })
    .then (function(vets) {
      console.log('success');
      $scope.vetItems = vets;
    }, function(err) {
      console.error('Azure Error: ' + err)
    })
    
  }, 500)
  
  $scope.search = function(data) {
    console.log(data)
    doSearch($scope.data);
  }

  $scope.showAlert = function() {
    alert(test);
     var alertPopup = $ionicPopup.alert({
       title: 'Don\'t eat that!',
       template: 'It might taste good'
     })
     alertPopup.then(function(res) {
       console.log('Thank you for not eating my delicious ice cream cone');
     });
  };
});