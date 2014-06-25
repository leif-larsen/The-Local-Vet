angular.module('thelocalvet.controllers', [])

.controller('MainCtrl', function($scope, $state) {
  $scope.searchMyLocation = function () {
    $state.go('MyLoc')
  }
  
  $scope.placeSearch = function () {
    $state.go('PlaceSearch')
  }
})

.controller('MyLocCtrl', function ($scope, $state, Azureservice) {
  Azureservice.getAll('Vet')
  .then(function(vets) {
    console.log('Query Successful');
    $scope.vets = vets;
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