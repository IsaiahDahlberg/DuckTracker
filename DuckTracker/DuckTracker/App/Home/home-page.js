var app = angular.module("homePageModule", []);

app.controller("homePageController", ['$scope', '$http', '$location', function ($scope, $http, $location) {
    $http.get('http://localhost:64286/api/mama/upcomingheat').then(function (response) {
        $scope.heats = JSON.parse(response.data);
    });
    $http.get('http://localhost:64286/api/litter/getrecent').then(function (response) {
        $scope.litters = JSON.parse(response.data);
    });
    $http.get('http://localhost:64286/api/note/mama/getRecent').then(function (response) {
        $scope.mamaNotes = JSON.parse(response.data);
    });
    $http.get('http://localhost:64286/api/note/papa/getRecent').then(function (response) {
        $scope.papaNotes = JSON.parse(response.data);
    });
    $http.get('http://localhost:64286/api/note/litter/getRecent').then(function (response) {
        $scope.litterNotes = JSON.parse(response.data);
    });
}]);