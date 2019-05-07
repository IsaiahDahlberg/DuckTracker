var app = angular.module('mamaListModule', []);

app.controller('mamaListController', ['$scope', '$http', function ($scope, $http) {
    $http.get('http://localhost:64286/api/mama/getall').then(function (response) {
        $scope.mamas = JSON.parse(response.data);
        });  
}]);