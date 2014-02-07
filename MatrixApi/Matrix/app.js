var jsonURL = "http://localhost:16185";
var matrixApp = angular.module('matrixApp', ['ngRoute']);





matrixApp.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.interceptors.push(function ($q, $location) {
        return {
            'responseError': function (response) {
                if (response.status === 401 || response.status === 403) {
                    $location.path('/login');
                    return $q.reject(response);
                }
                else {
                    return $q.reject(response);
                }
            }
        }
    });
    $httpProvider.interceptors.push(function () {
        return {
            request: function (config) {
                console.log(config.method);
                console.log(config.url);
                if (config.method == 'GET') {
                    var separator = config.url.indexOf('?') === -1 ? '?' : '&';
                    config.url = config.url + separator + 'noCache=' + new Date().getTime();
                }
                console.log(config.method);
                console.log(config.url);
                return config;
            }
        };
    });
}]);

matrixApp.run(['$rootScope', '$location', 'User', '$http', 'Base64', function ($rootScope, $location, User, $http, Base64) {
    var user = angular.fromJson(localStorage.user);
    if (user != null) {
        $http.defaults.headers.common['Authorization'] = 'Basic ' + Base64.encode(user.Email + ':' + user.Password);
    }
    $rootScope.$on("$routeChangeStart", function (event, next, current) {
        $rootScope.error = null;
        if (!User.isLoggedIn())
            $location.path('/login');
    });
}]);

function doThing() {
   
}