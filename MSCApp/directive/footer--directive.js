wiziqApp.directive('footerBar', function () {
    return {
        restrict: 'AE',
        transclude: true,
        scope: false,
        templateUrl: 'partials/footer.html',
        link: function ($scope, element, attrs) { },
        controller: 'mainController'
    };
});