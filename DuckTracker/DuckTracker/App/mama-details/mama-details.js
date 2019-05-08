var app = angular.module('mamaDetailsModule', []);

app.controller('mamaDetailsController', ['$scope', '$http', '$location', function ($scope, $http, $location) {
    $http.get('http://localhost:64286/api/mama/get/' + $location.path().substring(6)).then(function (response) {
        $scope.mama = JSON.parse(response.data);
        $scope.mama.BirthDate = $scope.mama.BirthDate.substring(0, 10);
    });
    $http.get('http://localhost:64286/api/litter/getbymamaid/' + $location.path().substring(6)).then(function (response) {
        $scope.litters = JSON.parse(response.data);
    }); 
    $http.get('http://localhost:64286/api/note/mama/getbymamaid/' + $location.path().substring(6)).then(function (response) {
        $scope.notes = JSON.parse(response.data);        
    });
    $scope.delete = function (id) {
        $http.delete('http://localhost:64286/api/note/mama/delete/' + id).then(() => {
            $http.get('http://localhost:64286/api/note/mama/getbymamaid/' + $location.path().substring(6)).then(function (response) {
                $scope.notes = JSON.parse(response.data);
            })
        });
    }
}]);