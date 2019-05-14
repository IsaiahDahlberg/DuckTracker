var app = angular.module('mamaUpdateModule', []);

app.controller('mamaUpdateController', ['$scope', '$http', '$location', function ($scope, $http, $location) {
    $http.get('http://localhost:64286/api/mama/get/' + $location.path().substring(13)).then(function (response) {
        $scope.mama = JSON.parse(response.data);
        $scope.Name = $scope.mama.Name;
        $scope.newInfo = $scope.mama;
        $scope.newInfo.BirthDate = new Date($scope.newInfo.BirthDate);
    });

    $scope.submit = function () {
        $http.post('http://localhost:64286/api/mama/update', $scope.newInfo).then(function (response) { $location.path("/Mama/" + $scope.mama.MamaDogId) });
    }

    $scope.back = function () {
        $location.path("/Mama/" + $scope.mama.MamaDogId);
    }

    $scope.delete = function() {
        if (confirm("WARNING! Are you sure you want to delete this mama? This will delete ALL notes and ALL litters associated with this mama.")) {
            $http.delete('http://localhost:64286/api/mama/delete/' + $scope.mama.MamaDogId).then(function (response) { $location.path("/Mama")});
        }
    }
}]);