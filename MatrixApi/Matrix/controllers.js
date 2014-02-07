

matrixApp.controller('ProjectListController', function ($scope, $http, Projects, $location) {
    $scope.projects = [];

    init();

    function init() {
        Projects.getProjects()
            .then(
                function (data) {
                    $scope.projects = data;
                }
            );
    }
    $scope.edit = function (projectId) {
        $location.path("/projects/edit/" + projectId);
    };

    $scope.delete = function (projectId) {
        Projects.deleteProject(projectId)
            .then(
                function (data) {
                    for (var i = 0; i < $scope.projects.length; i++) {
                        if ($scope.projects[i].Id == projectId) {
                            $scope.projects.splice(i, 1);
                        }
                    }
                }
            );
    };
});

matrixApp.controller('ProjectController', function ($scope, $http, Projects, Tickets, $routeParams, $location) {
    var projectId = $routeParams.projectId;
    $scope.project = [];

    init();

    function init() {
        Projects.getProject(projectId)
            .then(
                function (data) {
                    $scope.project = data;
                }
            );
    }
    $scope.edit = function (ticketId) {
        $location.path("/tickets/edit/" + ticketId);
    };

    $scope.delete = function (ticketId) {
        Tickets.deleteTicket(ticketId)
            .then(
                function (data) {
                    for (var i = 0; i < $scope.project.Tickets.length; i++) {
                        if ($scope.project.Tickets[i].Id == ticketId) {
                            $scope.project.Tickets.splice(i, 1);
                        }
                    }
                }
            );
    };
});

matrixApp.controller('ProjectCreateController', function ($scope, $http, Projects, $location) {

    init();

    function init() {

    }

    $scope.addProject = function () {
        Projects.createProject($scope.newProject)
            .then(
                function (data, status, headers, config) {
                    // return the created id?
                    $location.path("/projects/");
                }
            );
    };
});

matrixApp.controller('ProjectEditController', function ($scope, $http, Projects, $routeParams, $location) {
    var projectId = $routeParams.projectId;

    init();
    function init() {
        Projects.getProject(projectId)
            .then(
                function (data) {
                    $scope.project = data;
                }
            );
    }

    $scope.editProject = function () {
        Projects.editProject($scope.project)
            .then(
                function (data, status, headers, config) {
                    $location.path("/projects/" + projectId);
                }
            );
    };
});

matrixApp.controller('TicketController', function ($scope, $http, $routeParams, $location, Tickets, Comments) {

    var ticketId = $routeParams.ticketId;

    $scope.ticket = [];

    Tickets.getTicket(ticketId)
        .then(
            function (data, status, headers, config) {
                // you can do some processing here
                $scope.ticket = data;
            }
        );

    $scope.addComment = function () {
        $scope.newComment.TicketId = $routeParams.ticketId;
        Comments.createComment($scope.newComment)
            .then(
                function (data, status, headers, config) {
                    $location.path("/tickets/" + $routeParams.ticketId);
                }
            );
    };
    $scope.deleteComment = function (commentId) {
        Comments.deleteComment(commentId)
            .then(
                function (data) {
                    for (var i = 0; i < $scope.ticket.Comments.length; i++) {
                        if ($scope.ticket.Comments[i].Id == commentId) {
                            $scope.ticket.Comments.splice(i, 1);
                        }
                    }
                }
            );
    };
});


matrixApp.controller('TicketCreateController', function ($scope, $http, $routeParams, $location, Tickets) {

    $scope.projectId = $routeParams.projectId;

    // push to server, get returned id?
    $scope.addTicket = function () {
        $scope.newTicket.ProjectId = $routeParams.projectId;
        Tickets.createTicket($scope.newTicket)
            .then(
                function (data, status, headers, config) {
                    $location.path("/project/" + $routeParams.projectId);
                }
            );
    };
});

matrixApp.controller('TicketEditController', function ($scope, $http, Tickets, $routeParams, $location) {
    var ticketId = $routeParams.ticketId;

    init();
    function init() {
        Tickets.getTicket(ticketId)
            .then(
                function (data) {
                    $scope.ticket = data;
                }
            );
    }

    $scope.editTicket = function () {
        Tickets.editTicket($scope.ticket)
            .then(
                function (data, status, headers, config) {
                    $location.path("/tickets/" + ticketId);
                }
            );
    };
});

matrixApp.controller('LoginController', function ($scope, $http, $location, User) {
    $scope.login = function () {
        User.login($scope.user)
            .then(
                function (user) {
                    $location.path("/projects");
                }
            );
    };
});

matrixApp.controller('LogoutController', function ($scope, $http, $location, User) {
    $scope.user = [];

    init();
    
    function init()
    {
        $scope.user = User.getCurrentUser();
    }
    // push to server, get returned id?
    $scope.logout = function () {
        User.logout();
        $location.path("/login");
    };
});