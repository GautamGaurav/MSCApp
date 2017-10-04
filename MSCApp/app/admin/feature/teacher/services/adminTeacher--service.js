wiziqApp.service('AdminTeacherService', ['$http', 'utilService', function ($http, utilService) {

    var AdminTeacherService = this;

    AdminTeacherService.getTeacherByWId = function (wId) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { wId: wId };
        return $http.post(domain + 'TutorService.asmx/GetByWId', param, config);
    };

    AdminTeacherService.getTeacherById = function (id) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: id };
        return $http.post(domain + 'TutorService.asmx/Get', param, config);
    };

    AdminTeacherService.getAllTeacher = function () {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'TutorService.asmx/GetAll', config);
    };

    AdminTeacherService.syncTeachers = function () {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'TutorService.asmx/SyncTeachers', config);
    };

    AdminTeacherService.createTeacher = function (_teacher) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'TutorService.asmx/Create', _teacher, config);
    };

    AdminTeacherService.updateTeacher = function (_teacher) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'TutorService.asmx/Update', _teacher, config);
    };

    AdminTeacherService.deleteTeacher = function (id) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: id };
        return $http.post(domain + 'TutorService.asmx/Delete', param, config);
    };

}]);