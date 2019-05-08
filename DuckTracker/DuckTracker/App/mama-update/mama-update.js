var app = angular.module('mamaUpdateModule', []);

app.controller('mamaUpdateController', ['$scope', '$http', '$location', function ($scope, $http, $location) {
    $http.get('http://localhost:64286/api/mama/get/' + $location.path().substring(13)).then(function (response) {
        $scope.mama = JSON.parse(response.data);
        $scope.Name = $scope.mama.Name;
        $scope.mama.BirthDate = $scope.mama.BirthDate.substring(0, 10);
        $scope.newInfo = $scope.mama;
    });

    $scope.submit = function () {
        $http.post('http://localhost:64286/api/mama/update', $scope.newInfo).then(
        $location.path("/Mama/" + $scope.mama.MamaDogId));
    }

    $scope.back = function () {
        $location.path("/Mama/" + $scope.mama.MamaDogId);
    }
}]);