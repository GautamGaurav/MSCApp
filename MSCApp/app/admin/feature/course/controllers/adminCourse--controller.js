wiziqApp.controller('AdminCourseController', ['$scope', '$state', 'AdminCourseService', 'AdminSubjectService', 'notificationService', 'utilService', function ($scope, $state, AdminCourseService, AdminSubjectService, notificationService, utilService) {

    $scope.course = {
        id: 0,
        name: "",
        targetExam: "",
        targetYear: "--Select--",
        subjectIds: "",
        isDelete: false,
        createdDate: new Date(),
    }

    $scope.subject = "--Select--";
    $scope.nameRequired = "";
    $scope.targetExamRequired = "";
    $scope.targetYearRequired = "";
    $scope.subjectRequired = "";
    $scope.subjectList = [];

    $scope.renderPage = function () {
        var state = utilService.getCurrentState();
        switch (state) {
            case "admin/manage-course":
                $scope.getAllCourse();
                break;
            case "admin/create-course":
                $scope.getAllSubject();
                $scope.subject = "--Select--";
                $scope.course.targetYear = "--Select--";
                break;
            case "admin/update-course":
                $scope.getAllSubject();
                var id = $state.params.courseId;
                $scope.getCourseById(id);
                break;
            default:
                $scope.getAllCourse();
        }
    }

    $scope.getAllCourse = function () {
        AdminCourseService.getAllCourse().then(
            function (response) {
                $scope.courseList = response.data.d;
            }, function (error) {
                console.log(error);
            });
    };

    $scope.getAllSubject = function () {
        AdminSubjectService.getAllSubject().then(
            function (response) {
                $scope.subjectList = response.data.d;
            }, function (error) {
                console.log(error);
            });
    };

    $scope.getCourseById = function (id) {
        AdminCourseService.getCourseById(id).then(
            function (response) {
                $scope.course = response.data.d;
                notificationService.responseHandler(response);
            },
            function (error) {
                notificationService.responseHandler(error);
            });
    };

    $scope.createCourse = function () {
        if ($scope.validatecourse()) {
            $scope.course.subjectIds = $scope.subject;
            var _course = { "course": $scope.course };
            AdminCourseService.createCourse(_course).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }
    };

    $scope.updateCourse = function () {
        if ($scope.validatecourse()) {
            var _course = { "course": $scope.course };
            AdminCourseService.updateCourse(_course).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }
    }

    $scope.viewCourse = function (course) {
        $state.go('admin/view-course', { courseId: course.id });
    };

    $scope.editCourse = function (course) {
        $state.go('admin/update-course', { courseId: course.id });
    };

    $scope.addCourse = function (course) {
        $state.go('admin/create-course');
    };

    $scope.viewcourse = function (course) {
        $state.go('admin/create-course');
    };

    $scope.deletecourse = function (course) {
        var response = window.confirm("Are you sure you want to delete course : " + course.name);
        if (response) {
            AdminCourseService.deletecourse(course.id).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }

    };

    $scope.validatecourse = function () {
        var course = $scope.course;
        var isValid = true;
        if (course.name !== "" && course.name !== null && course.name !== undefined) {
            $scope.nameRequired = "";
        } else {
            $scope.nameRequired = "Please enter name.";
            isValid = false;
        }

        if (course.targetExam !== "--Select--" && course.targetExam !== null && course.targetExam !== undefined) {
            $scope.targetExamRequired = "";
        } else {
            $scope.targetExamRequired = "Please enter target exam.";
            isValid = false;
        }

        if (course.targetYear !== "--Select--" && course.targetYear !== null && course.targetYear !== undefined) {
            $scope.targetYearRequired = "";
        } else {
            $scope.targetYearRequired = "Please enter target year.";
            isValid = false;
        }

        if ($scope.subject !== "--Select--" && $scope.subject !== null && $scope.subject !== undefined) {
            $scope.subjectRequired = "";
        } else {
            $scope.subjectRequired = "Please enter subject.";
            isValid = false;
        }

        return isValid;
    }

    $scope.renderPage();

}]);