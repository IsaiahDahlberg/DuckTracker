var app = angular.module('litterAddNoteModule', []);

app.controller('litterAddNoteController', ['$scope', '$location', '$http', function ($scope, $location, $http) {
    $scope.note = { Note: "", NoteTitle: "", LitterId: null }
    $http.get('http://localhost:64286/api/litter/get/' + $location.path().substring(17)).then(function (response) {
        $scope.litter = JSON.parse(response.data);
    }).then(() => $scope.note.LitterId = $scope.litter.LitterId);

    $scope.submit = function () {
        $http.post('http://localhost:64286/api/note/litter/create', $scope.note).then(function (response) { $location.path("/Litter/" + $scope.litter.LitterId) });
    }

    $scope.back = function () {
        $location.path("/Litter/" + $scope.litter.LitterId);
    }
}]);