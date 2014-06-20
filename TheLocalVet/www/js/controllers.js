angular.module('thelocalvet.controllers', [])

.controller('MainCtrl', function($scope, $state) {
  $scope.searchMyLocation = function () {
    $state.go('MyLoc')
  }
})

.controller('MyLocCtrl', function ($scope) {
})
