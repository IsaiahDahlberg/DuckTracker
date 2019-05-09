var app = angular.module("litterAddModule", []);

app.controller("litterAddController", ['$scope', '$http', function ($scope, $http) {
    $http.get('http://localhost:64286/api/litter/get').then(function (response) {
        $scope.litters = JSON.parse(response.data);
    });
}]);