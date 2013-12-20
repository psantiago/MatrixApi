var jsonURL = "http://localhost:16185";
var matrixApp = angular.module('matrixApp', ['ngRoute']);

var user = [];

matrixApp.factory('projectFactory', function ($http) {

    var factory = {};
    var projects = [];

    factory.getProjects = function () {

        //return [{ "Id": 1, "Title": "The Blue Pill", "Description": "Further down the rabbit hole", "Priority": 1, "Status": 2, "Deadline": "2013-12-27T09:46:17.2012451-05:00", "Tickets": [{ "Id": 1, "Title": "Ticket the first", "Description": "Some ticket", "Priority": 0, "Status": 0, "Deadline": "2013-12-26T09:46:17.2012451-05:00", "User": { "Id": 7, "Name": "Neo", "Password": "Neo", "Email": "neo@thematrix.net" }, "Comments": [{ "Body": "Here's a comment body", "User": { "Id": 7, "Name": "Neo", "Password": "Neo", "Email": "neo@thematrix.net" }, "Ticket": null, "CreatedAt": "2013-12-20T09:46:17.2022449-05:00" }] }] }, { "Id": 2, "Title": "There is no spoon", "Description": "Noodle baking", "Priority": 2, "Status": 0, "Deadline": "2013-12-20T10:46:17.2022449-05:00", "Tickets": [{ "Id": 1, "Title": "This is a ticket title", "Description": "Another Ticket, for the spoons", "Priority": 0, "Status": 0, "Deadline": "2013-12-26T09:46:17.2022449-05:00", "User": { "Id": 7, "Name": "Morpheus", "Password": "Neo", "Email": "morpheus@thematrix.net" }, "Comments": [{ "Body": "Neo says this project is dumb", "User": { "Id": 7, "Name": "Neo", "Password": "Neo", "Email": "neo@thematrix.net" }, "Ticket": null, "CreatedAt": "2013-12-20T09:46:17.2022449-05:00" }] }] }];

    };

    return factory;
});

matrixApp.controller('ProjectListController', function ($scope, $http, projectFactory) {


    $scope.projects = [];

    $http.get('/API/PROJECTS?json=true').success(function (data, status, headers, config) {
        // you can do some processing here
        $scope.projects = data;
    });

    
});
matrixApp.controller('ProjectController', function ($scope, $http, projectFactory, $routeParams) {

    var projectId = $routeParams.projectId;

    $scope.projects = [];

    $http.get('/API/PROJECTS/' + projectId + '?json=true').success(function (data, status, headers, config) {
        // you can do some processing here
        $scope.project = data;
    });

});

matrixApp.controller('TicketController', function ($scope, $http, projectFactory, $routeParams) {

    var ticketId = $routeParams.ticketId;

    $scope.projects = [];

    $http.get('/API/TICKETS/' + ticketId + '?json=true').success(function (data, status, headers, config) {
        // you can do some processing here
        $scope.ticket = data;
    });

    $scope.addComment = function () {
        $http.post("/API/comments", $scope.newComment)
        .success(function (data, status, headers, config) {
            $location.path("/ticket/" + $routeParams.ticketId);
        }).error(function (data, status, headers, config) {
            alert("error");
        });
    };

});

matrixApp.controller('ProjectCreateController', function ($scope, $http, projectFactory, $location) {
    $scope.addProject = function () {
        // push to server, get returned id?
        $http.post("/API/projects", $scope.newProject)
        .success(function (data, status, headers, config) {
            $location.path("/projects/");
        }).error(function (data, status, headers, config) {
            alert("error");
        });
    };
});

matrixApp.controller('TicketCreateController', function ($scope, $http, projectFactory, $routeParams, $location) {

    $scope.projectId = $routeParams.projectId;

    // push to server, get returned id?
    $scope.addTicket = function () {
        // push to server, get returned id?
        $http.post("/API/tickets", $scope.newTicket)
        .success(function (data, status, headers, config) {
            $location.path("/project/" + $routeParams.projectId);
        }).error(function (data, status, headers, config) {
            alert("error");
        });
    };
});

matrixApp.controller('LoginController', function ($scope, $http, projectFactory, $location) {

    // push to server, get returned id?
    $scope.login = function () {
        user = $scope.user;
        // redirect to ticket
        $location.path("/projects");
    };
});

matrixApp.controller('LogoutController', function ($scope, $http, projectFactory, $location) {

    // push to server, get returned id?
    $scope.logout = function () {
        user = [];
        // redirect to ticket
        $location.path("/login");
    };
});

matrixApp.config(function ($routeProvider) {
    $routeProvider
        .when('/projects',
            {
                controller: 'ProjectListController',
                templateUrl: 'Partials/ProjectList.html'
            })
        .when('/project/create',
            {
                controller: 'ProjectCreateController',
                templateUrl: 'Partials/ProjectCreate.html'
            })
        .when('/projects/:projectId',
            {
                controller: 'ProjectController',
                templateUrl: 'Partials/Project.html'
            })
        .when('/projects/:projectId/create',
            {
                controller: 'TicketCreateController',
                templateUrl: 'Partials/TicketCreate.html'
            })
        .when('/tickets/:ticketId',
            {
                controller: 'TicketController',
                templateUrl: 'Partials/Ticket.html'
            })
        .when('/login',
            {
                controller: 'LoginController',
                templateUrl: 'Partials/Login.html'
            })
        .when('/logout',
            {
                controller: 'LogoutController',
                templateUrl: 'Partials/Logout.html'
            })
        .otherwise({ redirectTo: '/projects' });
});


/*
matrixApp.factory('allData', function ($http) {

    var obj = { content: null };

    $http({method: 'GET', url: jsonURL + '/API/PROJECTS?json=true'}).success(function(data) {
        // you can do some processing here
        obj.content = data;
    });

    return obj;
});
*/

/*
var projects =
    {}

var factory = {};
factory.getProjects = function () {
    return projects;
};
factory.getTickets = function () {
    return tickets;
};

*/