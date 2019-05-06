var app = angular.module('mamaListModule', []);

app.controller('mamaListController', ['$scope', function ($scope) {
    $scope.list = 'Hola!';
}]);