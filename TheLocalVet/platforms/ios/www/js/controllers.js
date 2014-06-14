angular.module('starter.controllers', [])

.controller('MainCtrl', function($scope, $state) {
  $scope.searchMyLocation = function () {
    $state.go('mylocation')
  }
})

.controller('MyLocCtrl', function ($scope) {
})
