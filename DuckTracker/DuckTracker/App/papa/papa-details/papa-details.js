var app = angular.module('papaDetailsModule', []);

app.controller('papaDetailsController', ['$scope', '$route','$http', '$location', function ($scope, $route, $http, $location) {
    $http.get('http://localhost:64286/api/papa/get/' + $location.path().substring(6)).then(function (response) {
        $scope.papa = JSON.parse(response.data);
    });
    $http.get('http://localhost:64286/api/litter/getbypapaid/' + $location.path().substring(6)).then(function (response) {
        $scope.litters = JSON.parse(response.data);
    });
    $http.get('http://localhost:64286/api/note/papa/getbypapaid/' + $location.path().substring(6)).then(function (response) {
        $scope.notes = JSON.parse(response.data);
    });
    $scope.delete = function (id) {
        $http.delete('http://localhost:64286/api/note/papa/delete/' + id).then(() => {
            $http.get('http://localhost:64286/api/note/papa/getbypapaid/' + $location.path().substring(6)).then(function (response) {
                $scope.notes = JSON.parse(response.data);
            }).then($route.reload());
        });
    }
}]);