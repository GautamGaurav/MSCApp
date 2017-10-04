wiziqApp.controller('TutorController', ['$rootScope', '$scope', '$state', 'notificationService', 'utilService', 'TutorService', function ($rootScope, $scope, $state, notificationService, utilService, TutorService) {

    $scope.tutor = {
        id: 0,
        batchId: 1,
        batchName: "",
        name: "",
        email: "",
        phoneNumber: "",
        password: "",
        address: "",
        timeZone: "",
        photoPath: "",
        courseId: 1,
        courseName: "",
        isDelete: false,
        createdDate: new Date()
        //gradeId: 1,
        //gradeName: "",
    }

    $scope.renderPage = function () {
        var state = utilService.getCurrentState();
        switch (state) {
            case "tutor/my-profile":
                var id = $rootScope.user.userId;
                $scope.getTutorById(id);
                break;
            case "tutor/live-classes":
                var id = $rootScope.user.userId;
                $scope.getUpcomingSessionByTutorId(id);
                $scope.getLiveSessionByTutorId(id);
                break;
            case "tutor/recorded-classes":
                var id = $rootScope.user.userId;
                $scope.getRecordedSessionByTutorId(id);
                break;
            case "tutor/download-recordings":
                //$scope.getRecordedSessionFortutor();
                break;
            default:
                var id = $rootScope.user.id;
                $scope.getTutorById(id);
        }
    }

    $scope.getTutorById= function (id) {
        TutorService.getTutorById(id).then(
            function (response) {
                $scope.tutor = response.data.d;
                // notificationService.responseHandler(response);
            },
            function (error) {
                notificationService.responseHandler(error);
            });
    };

    $scope.getUpcomingSessionByTutorId = function (tutorId) {
        TutorService.getUpcomingSessionByTutorId(tutorId).then(
            function (response) {
                $scope.upcomingSessionList = response.data.d;
                //notificationService.responseHandler(response);
            },
            function (error) {
                notificationService.responseHandler(error);
            });
    };

    $scope.getLiveSessionByTutorId = function (tutorId) {
        TutorService.getLiveSessionByTutorId(tutorId).then(
            function (response) {
                $scope.liveSessionList = response.data.d;
                //notificationService.responseHandler(response);
            },
            function (error) {
                notificationService.responseHandler(error);
            });
    };

    $scope.getRecordedSessionByTutorId = function (tutorId) {
        TutorService.getRecordedSessionByTutorId(tutorId).then(
            function (response) {
                $scope.recordedSessionList = response.data.d;
                //notificationService.responseHandler(response);
            },
            function (error) {
                //notificationService.responseHandler(error);
            });
    };

    $scope.renderPage();


}]);