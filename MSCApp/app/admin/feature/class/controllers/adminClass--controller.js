wiziqApp.controller('AdminClassController', ['$scope', '$state', '$filter', 'notificationService', 'utilService', 'AdminClassService', 'AdminCourseService', 'AdminBatchService', 'AdminGradeService', 'AdminStudentService', 'AdminSubjectService', 'AdminTeacherService', function ($scope, $state, $filter, notificationService, utilService, AdminClassService, AdminCourseService, AdminBatchService, AdminGradeService, AdminStudentService, AdminSubjectService, AdminTeacherService) {

    $scope.isEdit = false;
    $scope.startDate = new Date();
    $scope.startDateTime = new Date();
    $scope.attendeeDefaultControls = {
        audio: true,
        writing: true
    }
    $scope.presenterDefaultControls = {
        audio: true,
        video: true
    }

    $scope.class = {
        title: "",
        presenterEmail: "",
        startTime: moment(new Date()).add(+1, 'days').format("MM/DD/YYYY HH:mm"),
        languageCultureName: "en-US",
        timeZone: "Asia/Kolkata",
        duration: 5,
        extendDuration: 0,
        presenterDefaultControls: "",
        attendeeDefaultControls: "",
        attendeeLimit: 1,
        createRecording: true,
        recordingLink: "",
        returnUrl: "",
        coPresenterUrl: "",

        wId: 0,
        id: 0,
        batchId: "--Select--",
        batchName: "",
        tutorId: "--Select--",
        tutorName: "",
        tutorEmail: "",
        attendeeLink: "",
        tutorLink: "",
        isDelete: false,
        sessionDate: new Date(),
        createdDate: new Date(),
        deletedDate: new Date()
    }

    $scope.batchList = [];
    $scope.gradeList = [];
    $scope.subjectList = [];
    $scope.teacherList = [];

    $scope.renderPage = function () {
        var state = utilService.getCurrentState();
        switch (state) {
            case "admin/manage-class":
                $scope.isEdit = false;
                $scope.getAllClass();
                break;
            case "admin/create-class":
                $scope.isEdit = false;
                $scope.getAllBatch();
                $scope.getAllLanguageCultures();
                $scope.getAllTimeZones();
                $scope.getAllTeacher();

                break;
            case "admin/update-class":
                $scope.isEdit = true;
                var id = $state.params.classId || 1;
                $scope.getAllBatch();
                $scope.getAllLanguageCultures();
                $scope.getAllTimeZones();
                $scope.getAllTeacher();
                $scope.getClassById(id);
                break;
            default:
                $scope.getAllClass();
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

    $scope.getAllClass = function () {
        AdminClassService.getAllClass().then(
            function (response) {
                $scope.classList = response.data.d;
            }, function (error) {
                console.log(error);
            });
    };

    $scope.syncClasses = function () {
        AdminClassService.syncClasses().then(
            function (response) {
                $scope.ClassList = response.data.d;
            }, function (error) {
                notificationService.responseHandler(error);
            });
    };

    $scope.getClassById = function (id) {
        AdminClassService.getClassById(id).then(
            function (response) {
                $scope.class = response.data.d;
                $scope.class.duration = parseInt($scope.class.duration);
                $scope.class.extendDuration = parseInt($scope.class.extendDuration);
                $scope.attendeeDefaultControls.audio = $scope.class.attendeeDefaultControls.indexOf("audio") !== -1 ? true : false;
                $scope.attendeeDefaultControls.writing = $scope.class.attendeeDefaultControls.indexOf("writing") !== -1 ? true : false;
                $scope.presenterDefaultControls.audio = $scope.class.presenterDefaultControls.indexOf("audio") !== -1 ? true : false;
                $scope.presenterDefaultControls.video = $scope.class.presenterDefaultControls.indexOf("video") !== -1 ? true : false;
                $scope.class.languageCultureName = $scope.isEdit ? $scope.class.languageCultureName : "--Select--";
                $scope.class.timeZone = $scope.isEdit ? $scope.class.timeZone : "Asia/Kolkata";
                $scope.class.tutorId = $scope.isEdit ? $scope.class.tutorId.toString() : "--Select--";
                $scope.class.batchId = $scope.isEdit ? $scope.class.batchId.toString() : "--Select--";
                $scope.class.sessionDate = new Date();
                $scope.class.createdDate = new Date();
                $scope.class.deletedDate = new Date();
                notificationService.responseHandler(response);
            },
            function (error) {
                notificationService.responseHandler(error);
            });
    };

    $scope.createClass = function () {
        if ($scope.validateClass()) {
            $scope.class.attendeeDefaultControls = $scope.getAttendeeDefaultControls();
            $scope.class.presenterDefaultControls = $scope.getPresenterDefaultControls();
            $scope.class.tutorId = $scope.teacher.id;
            $scope.class.tutorName = $scope.teacher.name;
            $scope.class.tutorEmail = $scope.teacher.email;
            var _class = { "session": $scope.class };
            AdminClassService.createClass(_class).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }

    }

    $scope.updateClass = function () {
        if ($scope.validateClass()) {
            $scope.class.attendeeDefaultControls = $scope.getAttendeeDefaultControls();
            $scope.class.presenterDefaultControls = $scope.getPresenterDefaultControls();
            var _class = { "session": $scope.class };
            AdminClassService.updateClass(_class).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }
    }

    $scope.getAttendeeDefaultControls = function () {
        var attendeeControls = "";
        if ($scope.attendeeDefaultControls.audio) {
            attendeeControls += "audio"
        }
        if ($scope.attendeeDefaultControls.writing) {
            attendeeControls += attendeeControls == "" ? "writing" : ", writing";
        }
        return attendeeControls;
    }

    $scope.getPresenterDefaultControls = function () {
        var presenterControls = "";
        if ($scope.presenterDefaultControls.audio) {
            presenterControls += "audio"
        }
        if ($scope.presenterDefaultControls.video) {
            presenterControls += presenterControls == "" ? "video" : ", video";
        }
        return presenterControls;
    }

    $scope.deleteClass = function (Class) {
        var response = window.confirm("Are you sure you want to delete class : " + Class.title);
        if (response) {
            Class.createdDate = new Date();
            Class.deletedDate = new Date();
            Class.sessionDate = new Date();
            var _class = { "session": Class };
            AdminClassService.deleteClass(_class).then(
                function (response) {
                    notificationService.responseHandler(response);                    
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }

    };

    $scope.cancelClass = function (Class) {
        var response = window.confirm("Are you sure you want to cancel the class : " + Class.title);
        if (response) {
            Class.createdDate = new Date();
            Class.deletedDate = new Date();
            Class.sessionDate = new Date();
            AdminClassService.cancelClass(Class).then(
                function (response) {
                    $scope.getAllClass();
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }

    };

    $scope.viewClass = function (Class) {
        $state.go('admin/view-class', { classId: Class.id });
    };

    $scope.editClass = function (Class) {
        $state.go('admin/update-class', { classId: Class.wId });
    };

    $scope.addClass = function () {
        $state.go('admin/create-class');
    };
    
    $scope.classTitleRequired = false;
    $scope.classPresenterEmailRequired = false;
    $scope.classBatchRequired = false;
    $scope.classTeacherRequired = false;
    $scope.classLanguageCultureName = false;
    $scope.classTimeZoneRequired = false;

    $scope.validateClass = function () {
        var Class = $scope.class;
        var isValid = true;
        if (Class.title !== "" && Class.title !== null && Class.title !== undefined) {
            $scope.classTitleRequired = false;
        } else {
            $scope.classTitleRequired = true;
            isValid = false;
        }

        if (Class.presenterEmail !== "" && Class.presenterEmail !== null && Class.presenterEmail !== undefined) {
            $scope.classPresenterEmailRequired = false;
        } else {
            $scope.classPresenterEmailRequired = true;
            isValid = false;
        }

        if (Class.batchId == "--Select--") {
            $scope.classBatchRequired = true;
            isValid = false;
        } else {
            $scope.classBatchRequired = false;
        }

        if (Class.tutorId == "--Select--") {
            $scope.classTeacherRequired = true;
            isValid = false;
        } else {
            $scope.classTeacherRequired = false;
        }

        if ($scope.class.languageCultureName == '--Select--') {
            $scope.classLanguageCultureName = true;
            isValid = false;
        } else {
            $scope.classLanguageCultureName = false;
        }

        if ($scope.class.timeZone == '--Select--') {
            $scope.classTimeZoneRequired = true;
            isValid = false;
        } else {
            $scope.classTimeZoneRequired = false;
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

    $scope.getAllLanguageCultures = function () {
        utilService.getAllLanguageCultures().then(
            function (response) {
                $scope.languageCultureList = response.data.d;
            },
            function (error) {
                $scope.languageCultureList = [];
                notificationService.responseHandler(error);
            });
    }

    $scope.getAllBatch = function () {
        AdminBatchService.getAllBatch().then(
            function (response) {
                $scope.batchList = response.data.d;
            }, function (error) {
                console.log(error);
            });
    };

    $scope.getAllTeacher = function () {
        AdminTeacherService.getAllTeacher().then(
            function (response) {
                $scope.teacherList = response.data.d;
            }, function (error) {
                console.log(error);
            });
    };

    $scope.getAllCourse = function () {
        AdminCourseService.getAllCourse().then(
            function (response) {
                $scope.courseList = response.data.d;
            }, function (error) {
                console.log(error);
            });
    };

    $scope.getAllGrade = function () {
        AdminGradeService.getAllGrade().then(
            function (response) {
                $scope.gradeList = response.data.d;
            }, function (error) {
                console.log(error);
            });
    };

    $scope.getAllStudent = function () {
        AdminStudentService.getAllStudent().then(
            function (response) {
                $scope.studentList = response.data.d;
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

    $scope.addStudent = function (element, student) {
        if (element.target.checked) {
            $scope.class.stundetIds.push(student.id);
        } else {
            for (var i = 0; i < $scope.class.stundetIds.length; i++) {
                if (student.id == $scope.class.stundetIds[i].id) {
                    $scope.class.stundetIds.splice(i, 1);;
                }
            }
        }
    }

    $scope.setTeacher = function () {
        if (utilService.isUndefinedOrNullOrBlank($scope.class.tutorId)) {
            var teacher = $filter('filter')($scope.teacherList, { 'id': $scope.class.tutorId });
            if (teacher.length > 0) {
                $scope.teacher = teacher[0];
                $scope.class.tutorName = $scope.teacher.name;
                if ($scope.class.presenterEmail === "") {
                    $scope.class.presenterEmail = $scope.teacher.email;
                }
            }

        }
    }

    $scope.setBatch = function () {
        if (utilService.isUndefinedOrNullOrBlank($scope.class.batchId)) {
            var batch = $filter('filter')($scope.batchList, { 'id': $scope.class.batchId });
            if (batch.length > 0) {
                $scope.batch = batch[0];
                $scope.class.batchName = $scope.batch.name;
            }
        }
    }

    $scope.renderPage();

}]);
