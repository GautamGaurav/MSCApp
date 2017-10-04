wiziqApp.service('utilService', ['$http', '$rootScope', '$window', '$location', '$state', function ($http, $rootScope, $window, $location, $state) {

    var _this = this;

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
    }

    _this.getCurrentState = function () {
        var state = $state.current.name;
        var location = $location;
        return state;
    }

    _this.isValidNumber = function (phoneNumber) {
        var phoneno = new RegExp(/^\+\d{1,3} \d{9,10}$/, "g");
        return phoneNumber.match(phoneno) ? true : false;
    }

    _this.getAllTimeZone = function () {
        var config = _this.getConfig();
        var domain = _this.getDomain();
        return $http.post(domain + 'UtilService.asmx/GetAllTimeZone', config);
    }

    _this.getAllLanguageCultures = function () {
        var config = _this.getConfig();
        var domain = _this.getDomain();
        return $http.post(domain + 'UtilService.asmx/GetAllLanguageCulture', config);
    }

    _this.getAppData = function () {
        var config = _this.getConfig();
        var domain = _this.getDomain();
        return $http.post(domain + 'UtilService.asmx/GetAppData', config);
    }

    _this.isUndefinedOrNullOrBlank = function (val) {
        if (angular.isUndefined(val) && val === null && val === "") {
            return false;
        } else {
            return true;
        };
    }

    //_this.getEncryptedText = function (input) {
    //    var key = CryptoJS.enc.Utf8.parse('8080808080808080');
    //    var iv = CryptoJS.enc.Utf8.parse('8080808080808080');
    //    var encryptedOutput = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(input), key,
    //    {
    //        keySize: 128 / 8,
    //        iv: iv,
    //        mode: CryptoJS.mode.CBC,
    //        padding: CryptoJS.pad.Pkcs7
    //    });
    //    return encryptedOutput;
    //}
}]);