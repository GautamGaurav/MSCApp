wiziqApp.service('TutorService', ['$http', 'utilService', function ($http, utilService) {

    var TutorService = this;

    TutorService.getTutorById = function (id) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: id };
        return $http.post(domain + 'TutorService.asmx/Get', param, config);
    };   

    TutorService.updateTutor = function (_tutor) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { Tutor: _tutor };
        return $http.post(domain + 'TutorService.asmx/Update', param, config);
    };

    TutorService.getUpcomingSessionByTutorId = function (_tutorId) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: _tutorId };
        return $http.post(domain + 'TutorService.asmx/GetUpcomingSessionByTeacherId', param, config);
    };

    TutorService.getLiveSessionByTutorId = function (_tutorId) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: _tutorId };
        return $http.post(domain + 'TutorService.asmx/GetLiveSessionByTeacherId', param, config);
    };

    TutorService.getRecordedSessionByTutorId = function (_tutorId) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: _tutorId };
        return $http.post(domain + 'TutorService.asmx/GetRecordedSessionByTeacherId', param, config);
    };
}]);