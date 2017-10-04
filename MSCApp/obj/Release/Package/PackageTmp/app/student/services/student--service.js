wiziqApp.service('StudentService', ['$http', 'utilService', function ($http, utilService) {

    var StudentService = this;

    StudentService.getStudentById = function (id) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: id };
        return $http.post(domain + 'StudentService.asmx/Get', param, config);
    };   

    StudentService.updateStudent = function (_student) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { student: _student };
        return $http.post(domain + 'StudentService.asmx/Update', param, config);
    };

    StudentService.getUpcomingSessionByStudentId = function (studentId) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: studentId };
        return $http.post(domain + 'StudentService.asmx/GetUpcomingSessionByStudentId', param, config);
    };

    StudentService.getLiveSessionByStudentId = function (studentId) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: studentId };
        return $http.post(domain + 'StudentService.asmx/GetLiveSessionByStudentId', param, config);
    };

    StudentService.getRecordedSessionByStudentId = function (studentId) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: studentId };
        return $http.post(domain + 'StudentService.asmx/GetRecordedSessionByStudentId', param, config);
    };
}]);