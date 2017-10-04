wiziqApp.service('AdminCourseService', ['$http', 'utilService', function ($http, utilService) {

    var AdminCourseService = this;

    AdminCourseService.getCourseById = function (id) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: id };
        return $http.post(domain + 'CourseService.asmx/Get', param, config);
    };

    AdminCourseService.getAllCourse = function () {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'CourseService.asmx/GetAll', config);
    };

    AdminCourseService.syncCourses = function () {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'CourseService.asmx/SyncCourses', config);
    };

    AdminCourseService.createCourse = function (_course) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'CourseService.asmx/Create', _course, config);
    };

    AdminCourseService.updateCourse = function (_course) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'CourseService.asmx/Update', _course, config);
    };

    AdminCourseService.deleteCourse = function (id) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: id };
        return $http.post(domain + 'CourseService.asmx/Delete', param, config);
    };

}]);