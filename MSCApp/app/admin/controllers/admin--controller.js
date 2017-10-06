wiziqApp.controller('AdminController', ['$rootScope', '$scope', 'AdminService', 'utilService', 'notificationService', 'authService', function ($rootScope, $scope, AdminService, utilService, notificationService, authService) {

    $scope.password = {
        oldPassword: "",
        newPassword: "",
        confirmPassword: ""
    }
    $scope.outputEncryptedText = "";
    $scope.outputDecryptedText = "";

    $scope.getAppData = function () {
        AdminService.getAppData().then(
            function (response) {
                $scope.appData = response.data.d;
            },
            function (error) {
                $scope.timeZoneList = [];
                notificationService.responseHandler(error);
            });
    };

    $scope.changePassword = function () {
        var param = {
            oldPassword: $scope.password.oldPassword,
            newPassword: $scope.password.newPassword,
            confirmPassword: $scope.password.confirmPassword,
            userId: $rootScope.user.id,
            userEmail: $rootScope.user.email
        };

        AdminService.changePassword(param).then(
            function (response) {
                $scope.responseData = response.data.d;
                notificationService.responseHandler(response);
            },
            function (error) {
                notificationService.responseHandler(error);
            });
    };

    $scope.encryptText = function () {
        var param = { inputText: $scope.inputEncryptText }
        authService.encryptText(param).then(
            function (response) {
                $scope.outputEncryptedText = response.data.d;
            },
            function (error) {
                notificationService.responseHandler(error);
            });
    };

    $scope.decryptText = function () {
        var param = { inputText: $scope.inputDecryptText }
        authService.decryptText(param).then(
            function (response) {
                $scope.outputDecryptedText = response.data.d;
            },
            function (error) {
                notificationService.responseHandler(error);
            });
    };

   

    $scope.getAppData();
}]);