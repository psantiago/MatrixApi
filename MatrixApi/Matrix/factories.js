'use strict';



matrixApp.factory('User', function ($http, $q, Base64) {
    function changeUser(user) {
        localStorage.user = angular.toJson(user);
    }
    function getCurrentUserFromLocalStorage() {
        return angular.fromJson(localStorage.user);
    }
    return {
        login: function (user) {
            var deferred = $q.defer();
            console.log(user);
            $http.defaults.headers.common['Authorization'] = 'Basic ' + Base64.encode(user.username + ':' + user.password);
            $http.get('/API/Users')
                .success(
                    function (data, status, headers, config) {
                        changeUser(data);          
                        deferred.resolve(data);
                    }
                )
                .error(
                    function (data, status, headers, config) {
                        alert("Invalid Login");
                    }
                );

            return deferred.promise;
        },
        logout: function () {
            changeUser(null);
            return true;
        },
        getCurrentUser: function () {
            return getCurrentUserFromLocalStorage();
        },
        isLoggedIn: function () {
            var user = getCurrentUserFromLocalStorage();
            return user != null;
        }
    }
});

matrixApp.factory('Projects', function ($http, $q) {
    return {
        getProjects: function () {
            var deferred = $q.defer();
            $http.get('/API/PROJECTS' + '?json=true')
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                });
            return deferred.promise;
        },
        getProject : function(projectId) {
            var deferred = $q.defer();
            $http.get('/API/PROJECTS/' + projectId + '?json=true')
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                });
            return deferred.promise;
        },
        createProject: function (project)
        {
            var deferred = $q.defer();
            $http.post("/API/projects", project)
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                });
            return deferred.promise;
        },
        editProject: function (project)
        {
            var deferred = $q.defer();
            $http.put("/API/projects/" + project.Id, project)
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                });
            return deferred.promise;
        },
        deleteProject: function (projectId) {
            var deferred = $q.defer();
            $http.delete("/API/projects/" + projectId)
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                });
            return deferred.promise;
        }
    }
});

matrixApp.factory('Tickets', function ($http, $q) {
    return {
        getTicket: function (ticketId) {
            var deferred = $q.defer();
            $http.get('/API/TICKETS/' + ticketId + '?json=true')
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                });
            return deferred.promise;
        },
        createTicket: function (ticket) {
            var deferred = $q.defer();
            $http.post("/API/tickets", ticket)
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                });
            return deferred.promise;
        }
    }
});

matrixApp.factory('Base64', function () {
    var keyStr = 'ABCDEFGHIJKLMNOP' +
        'QRSTUVWXYZabcdef' +
        'ghijklmnopqrstuv' +
        'wxyz0123456789+/' +
        '=';
    return {
        encode: function (input) {
            var output = "";
            var chr1, chr2, chr3 = "";
            var enc1, enc2, enc3, enc4 = "";
            var i = 0;

            do {
                chr1 = input.charCodeAt(i++);
                chr2 = input.charCodeAt(i++);
                chr3 = input.charCodeAt(i++);

                enc1 = chr1 >> 2;
                enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
                enc3 = ((chr2 & 15) << 2) | (chr3 >> 6);
                enc4 = chr3 & 63;

                if (isNaN(chr2)) {
                    enc3 = enc4 = 64;
                } else if (isNaN(chr3)) {
                    enc4 = 64;
                }

                output = output +
                    keyStr.charAt(enc1) +
                    keyStr.charAt(enc2) +
                    keyStr.charAt(enc3) +
                    keyStr.charAt(enc4);
                chr1 = chr2 = chr3 = "";
                enc1 = enc2 = enc3 = enc4 = "";
            } while (i < input.length);

            return output;
        },

        decode: function (input) {
            var output = "";
            var chr1, chr2, chr3 = "";
            var enc1, enc2, enc3, enc4 = "";
            var i = 0;

            // remove all characters that are not A-Z, a-z, 0-9, +, /, or =
            var base64test = /[^A-Za-z0-9\+\/\=]/g;
            if (base64test.exec(input)) {
                alert("There were invalid base64 characters in the input text.\n" +
                    "Valid base64 characters are A-Z, a-z, 0-9, '+', '/',and '='\n" +
                    "Expect errors in decoding.");
            }
            input = input.replace(/[^A-Za-z0-9\+\/\=]/g, "");

            do {
                enc1 = keyStr.indexOf(input.charAt(i++));
                enc2 = keyStr.indexOf(input.charAt(i++));
                enc3 = keyStr.indexOf(input.charAt(i++));
                enc4 = keyStr.indexOf(input.charAt(i++));

                chr1 = (enc1 << 2) | (enc2 >> 4);
                chr2 = ((enc2 & 15) << 4) | (enc3 >> 2);
                chr3 = ((enc3 & 3) << 6) | enc4;

                output = output + String.fromCharCode(chr1);

                if (enc3 != 64) {
                    output = output + String.fromCharCode(chr2);
                }
                if (enc4 != 64) {
                    output = output + String.fromCharCode(chr3);
                }

                chr1 = chr2 = chr3 = "";
                enc1 = enc2 = enc3 = enc4 = "";

            } while (i < input.length);

            return output;
        }
    };
});