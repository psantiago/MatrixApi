var jsonURL = "http://localhost:16185";
var matrixApp = angular.module('matrixApp', []);

matrixApp.factory('projectFactory', function ($http) {

    var factory = {};
    var projects = [];

    factory.getProjects = function () {

        //return [{ "Id": 1, "Title": "The Blue Pill", "Description": "Further down the rabbit hole", "Priority": 1, "Status": 2, "Deadline": "2013-12-27T09:46:17.2012451-05:00", "Tickets": [{ "Id": 1, "Title": "Ticket the first", "Description": "Some ticket", "Priority": 0, "Status": 0, "Deadline": "2013-12-26T09:46:17.2012451-05:00", "User": { "Id": 7, "Name": "Neo", "Password": "Neo", "Email": "neo@thematrix.net" }, "Comments": [{ "Body": "Here's a comment body", "User": { "Id": 7, "Name": "Neo", "Password": "Neo", "Email": "neo@thematrix.net" }, "Ticket": null, "CreatedAt": "2013-12-20T09:46:17.2022449-05:00" }] }] }, { "Id": 2, "Title": "There is no spoon", "Description": "Noodle baking", "Priority": 2, "Status": 0, "Deadline": "2013-12-20T10:46:17.2022449-05:00", "Tickets": [{ "Id": 1, "Title": "This is a ticket title", "Description": "Another Ticket, for the spoons", "Priority": 0, "Status": 0, "Deadline": "2013-12-26T09:46:17.2022449-05:00", "User": { "Id": 7, "Name": "Morpheus", "Password": "Neo", "Email": "morpheus@thematrix.net" }, "Comments": [{ "Body": "Neo says this project is dumb", "User": { "Id": 7, "Name": "Neo", "Password": "Neo", "Email": "neo@thematrix.net" }, "Ticket": null, "CreatedAt": "2013-12-20T09:46:17.2022449-05:00" }] }] }];

    };

    return factory;
});

matrixApp.controller('ProjectController', function ($scope, $http, projectFactory) {

    var projects = [];

    $http.get('/API/PROJECTS?json=true').success(function (data, status, headers, config) {
        alert(data);
        // you can do some processing here
        $scope.projects = data;
    }).error(function (data, staus, headers, config) { });

    
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