var app = angular.module('litterListModule', []);

app.controller('litterListController', ['$scope', '$http', function ($scope, $http) {
    $http.get('http://localhost:64286/api/litter/get').then(function (response) {
        $scope.litters = JSON.parse(response.data);     
    });
}]);