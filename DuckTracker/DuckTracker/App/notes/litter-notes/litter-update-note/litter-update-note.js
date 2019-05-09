var app = angular.module('litterUpdateNoteModule', []);

app.controller('litterUpdateNoteController', ['$scope', '$location', '$http', function ($scope, $location, $http) {
    $http.get('http://localhost:64286/api/note/litter/get/' + $location.path().substring(18)).then(function (response) {
        $scope.note = JSON.parse(response.data);
    });

    $scope.submit = function () {
        $http.post('http://localhost:64286/api/note/litter/update', $scope.note).then(function (response) { }).then(
            $location.path("/Litter/" + $scope.note.LitterId));
    }

    $scope.back = function () {
        $location.path("/Litter/" + $scope.note.LitterId);
    }
}]);