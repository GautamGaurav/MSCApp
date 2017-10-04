wiziqApp.controller('AdminSubjectController', ['$scope', '$state', 'AdminSubjectService', 'notificationService', 'utilService', function ($scope, $state, AdminSubjectService, notificationService, utilService) {

    $scope.subject = {
        id: 0,
        name: "",
        description: "",
        isDelete: false,
        createdDate: new Date()
    }

    $scope.nameRequired = "";
    $scope.descriptionRequired = "";   
    $scope.subjectList = [];

    $scope.renderPage = function () {
        var state = utilService.getCurrentState();
        switch (state) {
            case "admin/manage-subject":
                $scope.getAllSubject();
                break;
            case "admin/create-subject":
                break;
            case "admin/update-subject":
                var id = $state.params.subjectId || 1;
                $scope.getSubjectById(id);
                break;
            default:
                $scope.getAllSubject();
        }
    }

    $scope.getAllSubject = function () {
        AdminSubjectService.getAllSubject().then(
            function (response) {
                $scope.subjectList = response.data.d;
            }, function (error) {
                console.log(error);
            });
    };

    $scope.getSubjectById = function (id) {
        AdminSubjectService.getSubjectById(id).then(
            function (response) {
                $scope.subject = response.data.d;
                notificationService.responseHandler(response);
            },
            function (error) {
                notificationService.responseHandler(error);
            });
    };

    $scope.createSubject = function () {
        if ($scope.validateSubject()) {
            var _subject = { "subject": $scope.subject };
            AdminSubjectService.createSubject(_subject).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }

    };

    $scope.updateSubject = function () {
        if ($scope.validateSubject()) {
            var _subject = { "Subject": $scope.subject };
            AdminSubjectService.updateSubject(_subject).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }
    }

    $scope.viewSubject = function (subject) {
        $state.go('admin/view-subject', { subjectId: subject.id });
    };

    $scope.editSubject = function (subject) {
        $state.go('admin/update-subject', { subjectId: subject.id });
    };

    $scope.addSubject = function (subject) {
        $state.go('admin/create-subject');
    };

    $scope.viewSubject = function (subject) {
        $state.go('admin/create-Subject');
    };

    $scope.deleteSubject = function (subject) {
        var response = window.confirm("Are you sure you want to delete Subject : " + subject.name);
        if (response) {
            AdminSubjectService.deleteSubject(subject.id).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }

    };

    $scope.validateSubject = function () {
        var subject = $scope.subject;
        var isValid = true;
        if (subject.name !== "" && subject.name !== null && subject.name !== undefined) {
            $scope.nameRequired = "";
        } else {
            $scope.nameRequired = "Please enter subject name.";
            isValid = false;
        }    
        if (subject.description !== "" && subject.description !== null && subject.description !== undefined) {
            $scope.descriptionRequired = "";
        } else {
            $scope.descriptionRequired = "Please enter description.";
            isValid = false;
        }    

        return isValid;
    }

    $scope.renderPage();

}]);