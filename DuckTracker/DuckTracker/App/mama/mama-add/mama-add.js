var app = angular.module("mamaAddModule", []);

app.controller('mamaAddController', ['$scope', '$location', '$http', function ($scope, $location, $http) {
    $scope.submit = function () {
        $http.post('http://localhost:64286/api/mama/create', $scope.mama).then(
            function (response) {
                var data = JSON.parse(response.data)
                $location.path("/Mama/" + data)
            });
    }

    $scope.back = function () {
        $location.path("/Mama/list");
    }
}]);