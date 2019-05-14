var app = angular.module("litterUpdateModule", []);

app.controller("litterUpdateController", ['$scope', '$http', '$location', function ($scope, $http, $location) {
    $http.get('http://localhost:64286/api/litter/get/' + $location.path().substring(15)).then(function (response) {
        $scope.litter = JSON.parse(response.data);
        $scope.litter.BirthDate = new Date($scope.litter.BirthDate);
    });

    $http.get('http://localhost:64286/api/mama/getall').then(function (response) {
        $scope.mamas = JSON.parse(response.data);
    });
    $http.get('http://localhost:64286/api/papa/getall').then(function (response) {
        $scope.papas = JSON.parse(response.data);
    });

    $scope.submit = function () {
        $http.post('http://localhost:64286/api/litter/update', $scope.litter).then(
            function (response) {
                var data = JSON.parse(response.data)
                $location.path("/Litter/" + data)
            });
    }

    $scope.back = function () {
        $location.path("/Litter/" + $scope.litter.LitterId);
    }

    $scope.delete = function () {
        if (confirm("WARNING! Are you sure you want to delete this litter? This will delete ALL notes associated with this litter.")) {
            $http.delete('http://localhost:64286/api/litter/delete/' + $scope.litter.LitterId).then(function (response) { $location.path("/Litter") });
        }
    }
}]);