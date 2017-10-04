wiziqApp.controller('AdminTeacherController', ['$scope', '$state', 'AdminTeacherService', 'notificationService', 'utilService', function ($scope, $state, AdminTeacherService, notificationService, utilService) {

    $scope.teacher = {
        name: "",
        email: "",
        password: "",
        timeZone: "Asia/Kolkata",
        phoneNumber: "",
        mobileNumber: "",
        canScheduleClass: true,
        isActive: true,
        aboutTheTeacher: "",
        address: "",
        photoPath: ""
    }

    $scope.nameRequired = "";
    $scope.passwordRequired = "";
    $scope.emailRequired = "";
    $scope.phoneRequired = "";
    $scope.mobileRequired = "";
    $scope.timeZoneRequired = "";
    $scope.isValidPhoneNumber = true;
    $scope.isValidMobileNumber = true;
    $scope.timeZoneList = [];

    $scope.renderPage = function () {
        var state = utilService.getCurrentState();
        switch (state) {
            case "admin/manage-teacher":
                $scope.getAllTeacher();
                break;
            case "admin/create-teacher":
                $scope.getAllTimeZones();
                $scope.teacher.timeZone = "Asia/Kolkata";
                break;
            case "admin/update-teacher":
                var wId = $state.params.teacherId || 1;
                $scope.getTeacherByWId(wId);
                $scope.getAllTimeZones();
                break;
            default:
                $scope.getAllTeacher();
        }
    }

    $scope.isValidPhoneNumberFun = function (phoneNumber) {
        $scope.isValidPhoneNumber = utilService.isValidNumber(phoneNumber);
        return $scope.isValidPhoneNumber;
    }

    $scope.isValidMobileNumberFun = function (phoneNumber) {
        $scope.isValidMobileNumber = utilService.isValidNumber(phoneNumber);
        return $scope.isValidMobileNumber;
    }

    $scope.getAllTeacher = function () {
        AdminTeacherService.getAllTeacher().then(
            function (response) {
                $scope.teacherList = response.data.d;
            }, function (error) {
                console.log(error);
            });
    };

    $scope.syncTeachers = function () {
        AdminTeacherService.syncTeachers().then(
            function (response) {
                $scope.teacherList = response.data.d;
            }, function (error) {
                notificationService.responseHandler(error);
            });
    };

    $scope.getTeacherByWId = function (id) {
        AdminTeacherService.getTeacherByWId(id).then(
            function (response) {
                $scope.teacher = response.data.d;
                notificationService.responseHandler(response);
            },
            function (error) {
                notificationService.responseHandler(error);
            });
    };

    $scope.createTeacher = function () {
        if ($scope.validateTeacher()) {
            $scope.teacher.canScheduleClass = $scope.teacher.canScheduleClass == "1" ? true : false;
            $scope.teacher.isActive = $scope.teacher.isActive == "1" ? true : false;
            var _teacher = { "teacher": $scope.teacher };
            AdminTeacherService.createTeacher(_teacher).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }

    };

    $scope.updateTeacher = function () {
        if ($scope.validateTeacher()) {
            $scope.teacher.canScheduleClass = $scope.teacher.canScheduleClass == "1" ? true : false;
            $scope.teacher.isActive = $scope.teacher.isActive == "1" ? true : false;
            var _teacher = { "teacher": $scope.teacher };
            AdminTeacherService.updateTeacher(_teacher).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }
    }

    $scope.viewTeacher = function (teacher) {
        $state.go('admin/view-teacher', { teacherId: teacher.id });
    };

    $scope.editTeacher = function (teacher) {
        $state.go('admin/update-teacher', { teacherId: teacher.wId });
    };

    $scope.addTeacher = function (teacher) {
        $state.go('admin/create-teacher');
    };

    $scope.viewTeacher = function (teacher) {
        $state.go('admin/create-teacher');
    };

    $scope.deleteTeacher = function (teacher) {
        var response = window.confirm("Are you sure you want to delete teahcer : " + teacher.name);
        if (response) {
            AdminTeacherService.deleteTeacher(teacher.id).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }

    };

    $scope.validateTeacher = function () {
        var teacher = $scope.teacher;
        var isValid = true;
        if (teacher.name !== "" && teacher.name !== null && teacher.name !== undefined) {
            $scope.nameRequired = "";
        } else {
            $scope.nameRequired = "Please enter name.";
            isValid = false;
        }

        if (teacher.password !== "" && teacher.password !== null && teacher.password !== undefined) {
            $scope.passwordRequired = "";
        } else {
            $scope.passwordRequired = "Please enter password.";
            isValid = false;
        }

        if (teacher.email !== "" && teacher.email !== null && teacher.email !== undefined) {
            $scope.emailRequired = "";
        } else {
            $scope.emailRequired = "Please enter valid email.";
            isValid = false;
        }

        if (teacher.phoneNumber !== "" && teacher.phoneNumber !== null && teacher.phoneNumber !== undefined) {
            $scope.phoneRequired = "";
        } else {
            $scope.phoneRequired = "Please enter valid phone number.";
            isValid = false;
        }

        if (teacher.mobileNumber !== "" && teacher.mobileNumber !== null && teacher.mobileNumber !== undefined) {
            $scope.mobileRequired = "";
        } else {
            $scope.mobileRequired = "Please enter mobile number.";
            isValid = false;
        }

        if (teacher.timeZone !== "" && teacher.timeZone !== null && teacher.timeZone !== undefined) {
            $scope.timeZoneRequired = "";
        } else {
            $scope.timeZoneRequired = "Please enter time zone.";
            isValid = false;
        }

        if (!$scope.isValidPhoneNumberFun(teacher.phoneNumber)) {
            isValid = false;
        }

        if (!$scope.isValidMobileNumberFun(teacher.mobileNumber)) {
            isValid = false;
        }

        return isValid;
    }

    $scope.getAllTimeZones = function () {
        utilService.getAllTimeZone().then(
            function (response) {
                $scope.timeZoneList = response.data.d;
            },
            function (error) {
                $scope.timeZoneList = [];
                notificationService.responseHandler(error);
            });
    }

    $scope.renderPage();

}]);