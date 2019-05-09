var app = angular.module('papaAddNoteModule', []);

app.controller('papaAddNoteController', ['$scope', '$location', '$http', function ($scope, $location, $http) {
    $scope.note = { Note: "", NoteTitle: "", PapaDogId: null }
    $http.get('http://localhost:64286/api/papa/get/' + $location.path().substring(14)).then(function (response) {
        $scope.papa = JSON.parse(response.data);
    }).then(() => $scope.note.PapaDogId = $scope.papa.PapaDogId);

    $scope.submit = function () {
        $http.post('http://localhost:64286/api/note/papa/create', $scope.note).then(function (response) { $location.path("/Papa/" + $scope.papa.PapaDogId) });
    }

    $scope.back = function () {
        $location.path("/Papa/" + $scope.papa.PapaDogId);
    }
}]);