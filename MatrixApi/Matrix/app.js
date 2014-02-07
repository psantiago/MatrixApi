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
}]);

matrixApp.run(['$rootScope', '$location', 'User', function ($rootScope, $location, User) {
    $rootScope.$on("$routeChangeStart", function (event, next, current) {
        $rootScope.error = null;
        if (!User.isLoggedIn())
            $location.path('/login');
    });
}]);