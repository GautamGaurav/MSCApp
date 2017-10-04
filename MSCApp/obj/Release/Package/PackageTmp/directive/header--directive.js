wiziqApp.directive('headerBar', function () {
    return {
        restrict: 'AE',
        transclude: true,
        scope: false,
        templateUrl: 'partials/header.html',
        link: function ($scope, element, attrs) { },
        controller: 'mainController'
    };
});