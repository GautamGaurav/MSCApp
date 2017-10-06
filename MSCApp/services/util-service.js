wiziqApp.service('utilService', ['$http', '$rootScope', '$window', '$location', '$state', function ($http, $rootScope, $window, $location, $state) {

    var _this = this;

    _this.checkForLogin = function () {
        var _user = angular.fromJson($window.localStorage.getItem("user"));
        var isLoggedIn = _user !== null ? true : false;
        if (isLoggedIn) {
            $rootScope.user = _user;
            $rootScope.isLoggedIn = true;

            if (_user.userRole === 1) {
                $location.path("/admin");
            }
            else if (_user.userRole === 2) {
                $location.path("/student");
            }
            else if (_user.userRole === 3) {
                $location.path("/totuor");
            }
            else {
                $location.path("/login");
            }
        } else {
            $window.localStorage.clear();
            $rootScope.user = null;
            $rootScope.isLoggedIn = false;
            $location.path("/login");
        }
    };

    _this.checkForMatchingValues = function (value1, value2) {
        return value1 === value2 ? true : false;
    };

    _this.changeClass = function (id) {
        $("#sidebar-menu").find('li').removeClass("active");
        $('#li' + id).addClass('active');
    };

    _this.getDomain = function () {
        var domain = "";
        var host = $location.$$host;
        if (host == "localhost") {
            domain = "http://localhost:" + $location.$$port + "/api/";
        } else {
            domain = "/api/"
        }
        return domain;
    };

    _this.getConfig = function () {
        var config = {
            headers: {
                'Accept': 'application/json;odata=verbose',
                "X-Testing": "testing"
            }
        };
        return config;
    };

    _this.getCurrentState = function () {
        var state = $state.current.name;
        return state;
    };

    _this.isValidNumber = function (phoneNumber) {
        var phoneno = new RegExp(/^\+\d{1,3} \d{9,10}$/, "g");
        return phoneNumber.match(phoneno) ? true : false;
    };

    _this.getAllTimeZone = function () {
        var config = _this.getConfig();
        var domain = _this.getDomain();
        return $http.post(domain + 'UtilService.asmx/GetAllTimeZone', config);
    };

    _this.getAllLanguageCultures = function () {
        var config = _this.getConfig();
        var domain = _this.getDomain();
        return $http.post(domain + 'UtilService.asmx/GetAllLanguageCulture', config);
    };

    _this.isUndefinedOrNullOrBlank = function (val) {
        if (angular.isUndefined(val) && val === null && val === "") {
            return false;
        } else {
            return true;
        };
    };
}]);