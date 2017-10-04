wiziqApp.service('authService', ['$http', '$rootScope', '$window', 'utilService', function ($http, $rootScope, $window, utilService) {

    var authService = this;

    authService.doLogin = function (param) {
        var domain = utilService.getDomain();
        return $http.post(domain + 'AuthService.asmx/Login', param);       
    };

}]);