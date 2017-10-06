wiziqApp.service('AdminService', ['$http', 'utilService', function ($http, utilService) {

    var AdminService = this;

    AdminService.changePassword = function (param) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'AuthService.asmx/changePassword', param, config);
    };

    AdminService.getAppData = function () {
        var config = utilService.getConfig();
        var domain = utilService.getDomain();
        return $http.post(domain + 'UtilService.asmx/GetAppData', config);
    }
}]);