var app = angular.module("litterDetailsModule", []);

app.controller("litterDetailsController", ['$scope', '$http', '$location', function ($scope, $http, $location) {
    $http.get('http://localhost:64286/api/litter/get/' + $location.path().substring(8)).then(function (response) {
        $scope.litter = JSON.parse(response.data);

        $http.get('http://localhost:64286/api/mama/get/' + $scope.litter.MamaDogId).then(function (response) {
            $scope.mama = JSON.parse(response.data);
        });
        $http.get('http://localhost:64286/api/papa/get/' + $scope.litter.PapaDogId).then(function (response) {
            $scope.papa = JSON.parse(response.data);
        });
    });
    $http.get('http://localhost:64286/api/note/litter/getbylitterid/' + $location.path().substring(8)).then(function (response) {
        $scope.notes = JSON.parse(response.data);
    });
    $scope.delete = function (id) {
        $http.delete('http://localhost:64286/api/note/litter/delete/' + id).then(() => {
            $http.get('http://localhost:64286/api/note/litter/getbylitterid/' + $location.path().substring(8)).then(function (response) {
                $scope.notes = JSON.parse(response.data);
            }).then($route.reload());
        });
    }
}]);