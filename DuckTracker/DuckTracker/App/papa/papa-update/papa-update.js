var app = angular.module('papaUpdateModule', []);

app.controller('papaUpdateController', ['$scope', '$http', '$location', function ($scope, $http, $location) {
    $http.get('http://localhost:64286/api/papa/get/' + $location.path().substring(13)).then(function (response) {
        $scope.papa = JSON.parse(response.data);
        $scope.Name = $scope.papa.Name;
        $scope.newInfo = $scope.papa;
        $scope.newInfo.BirthDate = new Date($scope.newInfo.BirthDate);
    });

    $scope.submit = function () {
        $http.post('http://localhost:64286/api/papa/update', $scope.newInfo).then(function (response) { $location.path("/Papa/" + $scope.papa.PapaDogId) });
    }

    $scope.back = function () {
        $location.path("/Papa/" + $scope.papa.PapaDogId);
    }

    $scope.delete = function () {
        if (confirm("WARNING! Are you sure you want to delete this papa? This will delete ALL notes and ALL litters associated with this papa.")) {
            $http.delete('http://localhost:64286/api/papa/delete/' + $scope.papa.PapaDogId).then(function (response) { $location.path("/Papa") });
        }
    }
}]);