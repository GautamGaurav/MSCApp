wiziqApp.service('AdminSubjectService', ['$http', 'utilService', function ($http, utilService) {

    var AdminSubjectService = this;

    AdminSubjectService.getSubjectById = function (id) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: id };
        return $http.post(domain + 'SubjectService.asmx/Get', param, config);
    };

    AdminSubjectService.getAllSubject = function () {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'SubjectService.asmx/GetAll', config);
    };

    AdminSubjectService.syncSubjects = function () {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'SubjectService.asmx/SyncSubjects', config);
    };

    AdminSubjectService.createSubject = function (_subject) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'SubjectService.asmx/Create', _subject, config);
    };

    AdminSubjectService.updateSubject = function (_subject) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'SubjectService.asmx/Update', _subject, config);
    };

    AdminSubjectService.deleteSubject = function (id) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: id };
        return $http.post(domain + 'SubjectService.asmx/Delete', param, config);
    };

}]);