var app = angular.module('mamaDetailsModule', []);

app.controller('mamaDetailsController', ['$scope', '$route', '$http', '$location', function ($scope, $route, $http, $location) {
    $scope.newHeat;

    $http.get('http://localhost:64286/api/mama/get/' + $location.path().substring(6)).then(function (response) {
        $scope.mama = JSON.parse(response.data);        
    });
    $http.get('http://localhost:64286/api/mama/getheat/' + $location.path().substring(6)).then(function (response) {
        $scope.heat = JSON.parse(response.data);
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
            }).then($route.reload());
        });
    }

    

    $scope.setHeat = function () {
        $scope.newHeat.MamaDogId = $scope.mama.MamaDogId;

        $http.post('http://localhost:64286/api/mama/createheat', $scope.newHeat).then(() => { $route.reload()});
    }
}]);