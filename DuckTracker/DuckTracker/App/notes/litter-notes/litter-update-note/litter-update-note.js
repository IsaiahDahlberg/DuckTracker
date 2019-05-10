var app = angular.module('litterUpdateNoteModule', []);

app.controller('litterUpdateNoteController', ['$scope', '$location', '$http', function ($scope, $location, $http) {
    $http.get('http://localhost:64286/api/note/litter/get/' + $location.path().substring(20)).then(function (response) {
        $scope.note = JSON.parse(response.data);
    });

    $scope.submit = function () {
        $http.post('http://localhost:64286/api/note/litter/update', $scope.note).then(function (response) { $location.path("/Litter/" + $scope.note.LitterId) });
    }

    $scope.back = function () {
        $location.path("/Litter/" + $scope.note.LitterId);
    }
}]);