﻿wiziqApp.controller('mainController', ['$scope', '$rootScope', '$window', '$state', 'mainService', 'authService', 'utilService', 'notificationService', function ($scope, $rootScope, $window, $state, mainService, authService, utilService, notificationService) {

    utilService.checkForLogin();

    $scope.isLoginClicked = false;

    $scope.changeClass = function (id) {
        utilService.changeClass(id);
    };


    $scope.doLogin = function () {
        $scope.isLoginClicked = true;
        var param = { userName: $scope.email, password: $scope.password };
        authService.doLogin(param).then(
            function (response) {
                $scope.isLoginClicked = false;
                if (response.data.d.isError) {
                    notificationService.responseHandler(response);
                } else {
                    $scope.saveCurrentUser(response.data.d)
                }
            }, function (error) {
                $scope.isLoginClicked = false;
                notificationService.responseHandler(error);
            });



    };

    $scope.logout = function () {
        $window.localStorage.clear();
        $rootScope.isLoggedIn = false;
        $rootScope.user = null;
        window.location.href = "/login";
    };

    $scope.saveCurrentUser = function (_user) {
        $window.localStorage.user = angular.toJson(_user);
        $rootScope.isLoggedIn = true;
        if (_user.userRole == 1) {
            window.location.href = "/admin";
        }
        else if (_user.userRole == 2) {
            window.location.href = "/student";
        }
        else {
            window.location.href = "/totuor";
        }
    };

    $scope.getAppData = function () {
        utilService.getAppData().then(
            function (response) {
                $scope.appData = response.data.d;
            },
            function (error) {
                $scope.timeZoneList = [];
                notificationService.responseHandler(error);
            });
    };

}]);