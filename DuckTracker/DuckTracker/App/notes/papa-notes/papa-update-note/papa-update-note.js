var app = angular.module('papaUpdateNoteModule', []);

app.controller('papaUpdateNoteController', ['$scope', '$location', '$http', function ($scope, $location, $http) {
    $http.get('http://localhost:64286/api/note/papa/get/' + $location.path().substring(18)).then(function (response) {
        $scope.note = JSON.parse(response.data);
    });

    $scope.submit = function () {
        $http.post('http://localhost:64286/api/note/papa/update', $scope.note).then(function (response) { $location.path("/Papa/" + $scope.note.PapaDogId) });
    }

    $scope.back = function () {
        $location.path("/Papa/" + $scope.note.PapaDogId);
    }
}]);