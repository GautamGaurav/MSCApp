wiziqApp.service('AdminGradeService', ['$http', 'utilService', function ($http, utilService) {

    var AdminGradeService = this;

    AdminGradeService.getGradeById = function (id) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: id };
        return $http.post(domain + 'GradeService.asmx/Get', param, config);
    };

    AdminGradeService.getAllGrade = function () {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'GradeService.asmx/GetAll', config);
    };

    AdminGradeService.syncGrades = function () {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'GradeService.asmx/SyncGrades', config);
    };

    AdminGradeService.createGrade = function (_grade) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'GradeService.asmx/Create', _grade, config);
    };

    AdminGradeService.updateGrade = function (_grade) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'GradeService.asmx/Update', _grade, config);
    };

    AdminGradeService.deleteGrade = function (id) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: id };
        return $http.post(domain + 'GradeService.asmx/Delete', param, config);
    };

}]);