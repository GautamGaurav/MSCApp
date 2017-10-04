wiziqApp.controller('AdminBatchController', ['$scope', '$state', '$filter', 'notificationService', 'utilService', 'AdminBatchService', 'AdminGradeService', function ($scope, $state, $filter, notificationService, utilService, AdminBatchService, AdminGradeService) {

    $scope.batch = {
        id: 0,
        name: "",
        gradeId: "--Select--",
        gradeName: "",
        description: "",
        createdDate: new Date()
    }

    $scope.nameRequired = false;
    $scope.gradeRequired = false;

    $scope.renderPage = function () {
        var state = utilService.getCurrentState();
        switch (state) {
            case "admin/manage-batch":
                $scope.getAllBatch();
                break;
            case "admin/create-batch":
                $scope.getAllGrade();
                break;
            case "admin/update-batch":
                var id = $state.params.batchId || 1;
                $scope.getBatchById(id);
                $scope.getAllGrade();
                break;
            default:
                $scope.getAllBatch();
        }
    }


    $scope.getAllBatch = function () {
        AdminBatchService.getAllBatch().then(
            function (response) {
                $scope.batchList = response.data.d;
            }, function (error) {
                console.log(error);
            });
    };

    $scope.getBatchById = function (id) {
        AdminBatchService.getBatchById(id).then(
            function (response) {
                $scope.batch = response.data.d;
                $scope.batch.gradeId = $scope.batch.gradeId.toString();
                notificationService.responseHandler(response);
            },
            function (error) {
                notificationService.responseHandler(error);
            });
    };

    $scope.createBatch = function () {
        if ($scope.validateBatch()) {
            var _batch = { "batch": $scope.batch };
            AdminBatchService.createBatch(_batch).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }

    };

    $scope.updateBatch = function () {
        if ($scope.validateBatch()) {
            var _batch = { "batch": $scope.batch };
            AdminBatchService.updateBatch(_batch).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }
    }

    $scope.viewBatch = function (batch) {
        $state.go('admin/view-batch', { batchId: batch.id });
    };

    $scope.editBatch = function (batch) {
        $state.go('admin/update-batch', { batchId: batch.id });
    };

    $scope.addBatch = function () {
        $state.go('admin/create-batch');
    };

    $scope.viewBatch = function (batch) {
        $state.go('admin/create-batch');
    };

    $scope.deleteBatch = function (batch) {
        var response = window.confirm("Are you sure you want to delete Batch : " + batch.name);
        if (response) {
            AdminBatchService.deleteBatch(batch.id).then(
                function (response) {
                    notificationService.responseHandler(response);
                },
                function (error) {
                    notificationService.responseHandler(error);
                });
        }

    };

    $scope.validateBatch = function () {
        var batch = $scope.batch;
        var isValid = true;
        if (batch.name !== "" && batch.name !== null && batch.name !== undefined) {
            $scope.nameRequired = false;
        } else {
            $scope.nameRequired = true;
            isValid = false;
        }

        if (batch.gradeId !== "" && $scope.batch.gradeId !== null && $scope.batch.gradeId !== undefined && $scope.batch.gradeId !== "--Select--") {
            $scope.gradeRequired = false;
        } else {
            $scope.gradeRequired = true;
            isValid = false;
        }
        return isValid;
    }

    $scope.getAllGrade = function () {
        AdminGradeService.getAllGrade().then(
            function (response) {
                $scope.gradeList = response.data.d;
            }, function (error) {
                console.log(error);
            });
    };

    $scope.setGrade = function () {
        if (utilService.isUndefinedOrNullOrBlank($scope.batch.gradeId)) {
            var grade = $filter('filter')($scope.gradeList, { 'id': $scope.batch.gradeId });
            if (grade.length > 0) {
                $scope.grade = grade[0];
                $scope.batch.gradeName = $scope.grade.name;
            }
        }
    }



    $scope.renderPage();

}]);