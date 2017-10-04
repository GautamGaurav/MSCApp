wiziqApp.service('AdminBatchService', ['$http', 'utilService', function ($http, utilService) {

    var AdminBatchService = this;

    AdminBatchService.getBatchById = function (id) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: id };
        return $http.post(domain + 'BatchService.asmx/Get', param, config);
    };

    AdminBatchService.getAllBatch = function () {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'BatchService.asmx/GetAll', config);
    };

    AdminBatchService.syncBatchs = function () {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'BatchService.asmx/SyncBatchs', config);
    };

    AdminBatchService.createBatch = function (_batch) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'BatchService.asmx/Create', _batch, config);
    };

    AdminBatchService.updateBatch = function (_batch) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        return $http.post(domain + 'BatchService.asmx/Update', _batch, config);
    };

    AdminBatchService.deleteBatch = function (id) {
        var domain = utilService.getDomain();
        var config = utilService.getConfig();
        var param = { id: id };
        return $http.post(domain + 'BatchService.asmx/Delete', param, config);
    };

}]);