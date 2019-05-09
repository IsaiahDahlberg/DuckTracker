var app = angular.module('mamaAddNoteModule', []);

app.controller('mamaAddNoteController', ['$scope', '$location', '$http', function ($scope, $location, $http) {
    $scope.note = { Note: "", NoteTitle: "", MamaDogId: null }
    $http.get('http://localhost:64286/api/mama/get/' + $location.path().substring(14)).then(function (response) {
        $scope.mama = JSON.parse(response.data);
    }).then(() => $scope.note.MamaDogId = $scope.mama.MamaDogId);

    $scope.submit = function () {
        $http.post('http://localhost:64286/api/note/mama/create', $scope.note).then(function (response) { $location.path("/Mama/" + $scope.mama.MamaDogId)});
    }

    $scope.back = function () {
        $location.path("/Mama/" + $scope.mama.MamaDogId);
    }
}]);