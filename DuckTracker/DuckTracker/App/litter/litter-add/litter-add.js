var app = angular.module("litterAddModule", []);

app.controller("litterAddController", ['$scope', '$http', '$location', function ($scope, $http, $location) {
    $http.get('http://localhost:64286/api/mama/getall').then(function (response) {
        $scope.mamas = JSON.parse(response.data);
    });
    $http.get('http://localhost:64286/api/papa/getall').then(function (response) {
        $scope.papas = JSON.parse(response.data);
    });

    $scope.submit = function () {
        $http.post('http://localhost:64286/api/litter/create', $scope.litter).then(
            function (response) {
                var data = JSON.parse(response.data)
                $location.path("/Litter/" + data)
            });
    }

    $scope.back = function () {
        $location.path("/Litter/list");
    }
}]);