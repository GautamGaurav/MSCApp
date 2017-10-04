wiziqApp.controller('StudentController', ['$rootScope', '$scope', '$state', 'notificationService', 'utilService', 'StudentService', 'AdminClassService', 'AdminCourseService', 'AdminBatchService', 'AdminGradeService', 'AdminStudentService', 'AdminSubjectService', 'AdminTeacherService', function ($rootScope, $scope, $state, notificationService, utilService, StudentService, AdminClassService, AdminCourseService, AdminBatchService, AdminGradeService, AdminStudentService, AdminSubjectService, AdminTeacherService) {

    $scope.student = {
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
            case "student/my-profile":
                var id = $rootScope.user.userId;
                $scope.getStudent(id);
                break;
            case "student/live-classes":
                var id = $rootScope.user.userId;
                $scope.getUpcomingSessionByStudentId(id);
                $scope.getLiveSessionByStudentId(id);
                break;
            case "student/recorded-classes":
                var id = $rootScope.user.userId;
                $scope.getRecordedSessionByStudentId(id);
                break;
            case "student/download-recordings":
                //$scope.getRecordedSessionForStudent();
                break;
            default:
                var id = $rootScope.user.id;
                $scope.getStudent(id);
        }
    }

    $scope.getStudent = function (id) {
        AdminStudentService.getStudentById(id).then(
            function (response) {
                $scope.student = response.data.d;
                // notificationService.responseHandler(response);
            },
            function (error) {
                notificationService.responseHandler(error);
            });
    };

    $scope.getUpcomingSessionByStudentId = function (studentId) {
        StudentService.getUpcomingSessionByStudentId(studentId).then(
            function (response) {
                $scope.upcomingStudentSessionList = response.data.d;
                //notificationService.responseHandler(response);
            },
            function (error) {
                notificationService.responseHandler(error);
            });
    };

    $scope.getLiveSessionByStudentId = function (studentId) {
        StudentService.getLiveSessionByStudentId(studentId).then(
            function (response) {
                $scope.liveStudentSessionList = response.data.d;
                //notificationService.responseHandler(response);
            },
            function (error) {
                notificationService.responseHandler(error);
            });
    };

    $scope.getRecordedSessionByStudentId = function (studentId) {
        StudentService.getRecordedSessionByStudentId(studentId).then(
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