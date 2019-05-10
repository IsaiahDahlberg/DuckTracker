var app = angular.module("homePageModule", []);

app.controller("homePageContrller", ['$scope', '$http', '$location', function ($scope, $http, $location) {
    $http.get('http://localhost:64286/api/note/getall').then(function (response) {
        $scope.notess = JSON.parse(response.data);
    });
}]);