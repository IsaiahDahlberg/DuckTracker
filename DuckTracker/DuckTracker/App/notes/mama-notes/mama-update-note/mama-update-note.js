var app = angular.module('mamaUpdateNoteModule', []);

app.controller('mamaUpdateNoteController', ['$scope', '$location', '$http', function ($scope, $location, $http) {
    $http.get('http://localhost:64286/api/note/mama/get/' + $location.path().substring(18)).then(function (response) {
        $scope.note = JSON.parse(response.data);
    });

    $scope.submit = function () {
        $http.post('http://localhost:64286/api/note/mama/update', $scope.note).then(function (response) { $location.path("/Mama/" + $scope.note.MamaDogId) });
    }

    $scope.back = function () {
        $location.path("/Mama/" + $scope.note.MamaDogId);
    }
}]);