wiziqApp.service('AdminClassService', ['$http', 'utilService', function ($http, utilService) {

    var AdminClassService = this;

    AdminClassService.getClassById = function (id) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { wId: id };
        return $http.post(domain + 'SessionService.asmx/Get', param, config);
    };

    AdminClassService.getAllClass = function () {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'SessionService.asmx/GetAll', config);
    };

    AdminClassService.syncClasses = function () {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'SessionService.asmx/SyncClasses', config);
    };

    AdminClassService.createClass = function (_class) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'SessionService.asmx/Create', _class, config);
    };

    AdminClassService.updateClass = function (_class) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'SessionService.asmx/Update', _class, config);
    };

    AdminClassService.deleteClass = function (_class) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'SessionService.asmx/Delete', _class, config);
    };

    AdminClassService.cancelClass = function (Class) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { session: Class };
        return $http.post(domain + 'SessionService.asmx/Cancel', param, config);
    };

}]);