var app = angular.module('papaListModule', []);

app.controller('papaListController', ['$scope', function ($scope) {
    $scope.list = 'papa!';
}]);