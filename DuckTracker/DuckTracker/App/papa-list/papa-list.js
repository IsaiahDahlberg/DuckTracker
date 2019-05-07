var app = angular.module('papaListModule', []);

app.controller('papaListController', ['$scope', '$http', function ($scope, $http) {
    $http.get('http://localhost:64286/api/papa/getall').then(function (response) {
        $scope.papas = JSON.parse(response.data);
    });
}]);