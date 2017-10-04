wiziqApp.controller('AdminGradeController', ['$scope', '$state', 'AdminGradeService', 'notificationService', 'utilService', function ($scope, $state, AdminGradeService, notificationService, utilService) {

    $scope.grade = {
        id: 0,
        name: "",
        description: "",
        isDelete: false,
        createdDate: new Date()
    }

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
            case "admin/manage-grade":
                $scope.getAllGrade();
                break;
            case "admin/create-grade":
                break;
            case "admin/update-grade":
                var id = $state.params.gradeId || 1;
                $scope.getGradeById(id);
                break;
            default:
                $scope.getAllGrade();
        }
    }


    $scope.getAllGrade = function () {
        AdminGradeService.getAllGrade().then(
            function (response) {
                $scope.gradeList = response.data.d;
            }, function (error) {
                console.log(error);
            });
    };

    $scope.getGradeById = function (id) {
        AdminGradeService.getGradeById(id).then(
            function (response) {
                $scope.grade = response.data.d;
                notificationService.responseHandler(response);
            },
            function (error) {
                notificationService.responseHandler(error);
            });
    };

    $scope.createGrade = function () {
        if ($scope.validateGrade()) {
            var _grade = { "grade": $scope.grade };
            AdminGradeService.createGrade(_grade).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }

    };

    $scope.updateGrade = function () {
        if ($scope.validateGrade()) {
            var _grade = { "grade": $scope.grade };
            AdminGradeService.updateGrade(_grade).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }
    }

    $scope.viewGrade = function (grade) {
        $state.go('admin/view-grade', { gradeId: grade.id });
    };

    $scope.editGrade = function (grade) {
        $state.go('admin/update-grade', { gradeId: grade.id });
    };

    $scope.addGrade = function () {
        $state.go('admin/create-grade');
    };

    $scope.viewGrade = function (grade) {
        $state.go('admin/create-grade');
    };

    $scope.deleteGrade = function (grade) {
        var response = window.confirm("Are you sure you want to delete Grade : " + grade.name);
        if (response) {
            AdminGradeService.deleteGrade(grade.id).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }

    };

    $scope.validateGrade = function () {
        var grade = $scope.grade;
        var isValid = true;
        if (grade.name !== "" && grade.name !== null && grade.name !== undefined) {
            $scope.nameRequired = "";
        } else {
            $scope.nameRequired = "Please enter grade name.";
            isValid = false;
        }

        if (grade.description !== "" && grade.description !== null && grade.description !== undefined) {
            $scope.passwordRequired = "";
        } else {
            $scope.descriptionRequired = "Please enter grade description.";
            isValid = false;
        }

        return isValid;
    }

    $scope.renderPage();

}]);