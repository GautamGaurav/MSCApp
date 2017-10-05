wiziqApp.controller('AdminController', ['$scope', 'utilService', 'notificationService', function ($scope, utilService, notificationService) {
    $scope.getAppData = function () {
        utilService.getAppData().then(
            function (response) {
                $scope.appData = response.data.d;
            },
            function (error) {
                $scope.timeZoneList = [];
                notificationService.responseHandler(error);
            });
    }

    $scope.changePassword = function () {
        utilService.getAppData().then(
            function (response) {
                $scope.appData = response.data.d;
            },
            function (error) {
                $scope.timeZoneList = [];
                notificationService.responseHandler(error);
            });
    }
    $scope.getAppData();
}]);