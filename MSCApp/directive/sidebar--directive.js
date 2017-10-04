wiziqApp.directive('sideBar', function () {
    return {
        restrict: 'AE',
        transclude: true,
        scope: false,
        templateUrl: 'partials/sidebar.html',
        link: function ($scope, element, attrs) { },
        controller: 'mainController'
    };
});