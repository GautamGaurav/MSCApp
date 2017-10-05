wiziqApp.controller('AdminStudentController', ['$scope', '$state', 'notificationService', 'utilService', 'AdminStudentService', 'AdminCourseService', 'AdminBatchService', 'AdminGradeService', function ($scope, $state, notificationService, utilService, AdminStudentService, AdminCourseService, AdminBatchService, AdminGradeService) {

    $scope.student = {
        id: 0,        
        batchId: 1,
        batchName: "",
        name: "",
        email: "",
        phoneNumber: "",
        password: "",
        address: "",
        timeZone: "Asia/Kolkata",
        photoPath: "",
        courseId: 1,
        courseName: "",
        isDelete: false,
        createdDate: new Date()        
        //gradeId: 1,
        //gradeName: "",
    }

    $scope.isEdit = false;
    $scope.nameRequired = "";
    $scope.passwordRequired = "";
    $scope.emailRequired = "";
    $scope.phoneRequired = "";
    $scope.mobileRequired = "";
    $scope.timeZoneRequired = "";
    $scope.isValidPhoneNumber = true;
    $scope.isValidMobileNumber = true;

    $scope.renderPage = function () {
        var state = utilService.getCurrentState();
        switch (state) {
            case "admin/manage-student":
                $scope.student.batchId = '--Select Batch--';
                $scope.getAllBatch();
                $scope.isEdit = false;
                $scope.getAllStudent();
                break;
            case "admin/create-student":
                $scope.isEdit = false;
                $scope.getAllTimeZones();
                $scope.getAllBatch();
                $scope.getAllCourse();

                break;
            case "admin/update-student":
                $scope.isEdit = true;
                $scope.getAllTimeZones();
                $scope.student.timeZone = "Asia/Kolkata";
                $scope.getAllBatch();
                $scope.student.batchId = '--Select--';
                $scope.getAllCourse();
                $scope.student.courseId = '--Select--';
                var id = $state.params.studentId || 1;
                $scope.getStudentById(id);
                break;
            default:
                $scope.isEdit = false;
                $scope.getAllStudent();
        }
    };

    $scope.getAllStudent = function () {
        AdminStudentService.getAllStudent().then(
            function (response) {
                $scope.studentList = response.data.d;
            }, function (error) {
                console.log(error);
            });
    };

    $scope.getStudentById = function (id) {
        AdminStudentService.getStudentById(id).then(
            function (response) {
                $scope.student = response.data.d;
                $scope.student.timeZone = $scope.student.timeZone.toString();
                $scope.student.batchId = $scope.student.batchId.toString();
                $scope.student.courseId = $scope.student.courseId.toString();  
                $scope.student.createdDate = new Date(); 
                notificationService.responseHandler(response);
            },
            function (error) {
                notificationService.responseHandler(error);
            });
    };

    $scope.getStudentByBatchId = function (batchId) {
        if (batchId != '--Select Batch--') {
            AdminStudentService.getStudentByBatchId(batchId).then(
           function (response) {
               $scope.studentList = response.data.d;
               var message = $scope.studentList.length > 0 ? $scope.studentList.length + " Student(s) Found." : "No Student Found";
               var index = $scope.studentList.length > 0 ? 1 : 4;
               notificationService.show(message, index);
           },
           function (error) {
               notificationService.responseHandler(error);
           });
        } else {
            $scope.getAllStudent();
        }
       
    };

    $scope.createStudent = function () {
        if ($scope.validateStudent()) {
            var _student = { "student": $scope.student };
            AdminStudentService.createStudent(_student).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }

    };

    $scope.updateStudent = function () {
        if ($scope.validateStudent()) {
            var _student = { "student": $scope.student };
            AdminStudentService.updateStudent(_student).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }
    }

    $scope.viewStudent = function (student) {
        $state.go('admin/view-student', { studentId: student.id });
    };

    $scope.editStudent = function (student) {
        $state.go('admin/update-student', { studentId: student.id });
    };

    $scope.addStudent = function () {
        $state.go('admin/create-student');
    };

    $scope.viewStudent = function (Student) {
        $state.go('admin/create-Student');
    };

    $scope.deleteStudent = function (Student) {
        var response = window.confirm("Are you sure you want to delete Student : " + Student.name);
        if (response) {
            AdminStudentService.deleteStudent(Student.id).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }

    };

    $scope.validateStudent = function () {
        var student = $scope.student;
        var isValid = true;
        if (student.name !== "" && student.name !== null && student.name !== undefined) {
            $scope.nameRequired = "";
        } else {
            $scope.nameRequired = "Please enter name.";
            isValid = false;
        }

        if (student.password !== "" && student.password !== null && student.password !== undefined) {
            $scope.passwordRequired = "";
        } else {
            if (!$scope.isEdit) {
                $scope.passwordRequired = "Please enter password.";
                isValid = false;
            }            
        }

        if (student.email !== "" && student.email !== null && student.email !== undefined) {
            $scope.emailRequired = "";
        } else {
            $scope.emailRequired = "Please enter valid email.";
            isValid = false;
        }

        if (student.phoneNumber !== "" && student.phoneNumber !== null && student.phoneNumber !== undefined) {
            $scope.phoneRequired = "";
        } else {
            $scope.phoneRequired = "Please enter valid phone number.";
            isValid = false;
        }

        if (student.timeZone !== "" && student.timeZone !== null && student.timeZone !== undefined) {
            $scope.timeZoneRequired = "";
        } else {
            $scope.timeZoneRequired = "Please enter time zone.";
            isValid = false;
        }

        return isValid;
    };

    $scope.getAllBatch = function () {
        AdminBatchService.getAllBatch().then(
            function (response) {
                $scope.batchList = response.data.d;
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