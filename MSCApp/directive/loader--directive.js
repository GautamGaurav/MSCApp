wiziqApp.directive('loader', ['$http', function ($http) {
    return {
        restrict: 'AE',
        template: '<div class="loading-spiner-holder"><div class="loading-spiner"> <div class="loader">Loading...</div></div>',
        link: function (scope, elm, attrs) {
            scope.isLoading = function () {
                return $http.pendingRequests.length > 0;
            };

            scope.$watch(scope.isLoading, function (isLoading) {
                if (isLoading) {
                    elm.show();
                } else {
                    elm.hide();
                }
            });
        }
    }
}]);