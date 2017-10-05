wiziqApp.service('AdminStudentService', ['$http', 'utilService', function ($http, utilService) {

    var AdminStudentService = this;

    AdminStudentService.getStudentById = function (id) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: id };
        return $http.post(domain + 'StudentService.asmx/Get', param, config);
    };

    AdminStudentService.getStudentByBatchId = function (id) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { batchId: parseInt(id) };
        return $http.post(domain + 'StudentService.asmx/GetStudentByBatchId', param, config);
    };

    AdminStudentService.getAllStudent = function () {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'StudentService.asmx/GetAll', config);
    };

    AdminStudentService.syncStudents = function () {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'StudentService.asmx/SyncStudents', config);
    };

    AdminStudentService.createStudent = function (_student) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'StudentService.asmx/Create', _student, config);
    };

    AdminStudentService.updateStudent = function (_student) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'StudentService.asmx/Update', _student, config);
    };

    AdminStudentService.deleteStudent = function (id) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: id };
        return $http.post(domain + 'StudentService.asmx/Delete', param, config);
    };

}]);