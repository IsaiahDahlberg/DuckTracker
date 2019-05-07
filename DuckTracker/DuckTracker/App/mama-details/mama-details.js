var app = angular.module('mamaDetailsModule', []);

app.controller('mamaDetailsController', ['$scope', '$http', '$location', function ($scope, $http, $location) {
    $http.get('http://localhost:64286/api/mama/get/' + $location.path().substring(6)).then(function (response) {
        $scope.mama = JSON.parse(response.data);
    });
    $http.get('http://localhost:64286/api/litter/getbymamaid/' + $location.path().substring(6)).then(function (response) {
        $scope.litters = JSON.parse(response.data);
    }); 
}]);