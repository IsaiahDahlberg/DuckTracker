var app = angular.module('litterListModule', []);

app.controller('litterListController', ['$scope', function ($scope) {
    $scope.list = 'Litter!';
}]);