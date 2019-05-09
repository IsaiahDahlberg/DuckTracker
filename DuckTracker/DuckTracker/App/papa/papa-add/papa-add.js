var app = angular.module("papaAddModule", []);

app.controller('papaAddController', ['$scope', '$location', '$http', function ($scope, $location, $http) {
    $scope.submit = function () {
        $http.post('http://localhost:64286/api/papa/create', $scope.papa).then(
            function (response) {
                var data = JSON.parse(response.data)
                $location.path("/Papa/" + data)
            });
    }

    $scope.back = function () {
        $location.path("/Papa/list");
    }
}]);