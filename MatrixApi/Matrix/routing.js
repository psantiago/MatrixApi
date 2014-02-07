
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
        .when('/projects/edit/:projectId',
            {
                controller: 'ProjectEditController',
                templateUrl: 'Partials/ProjectEdit.html'
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
        .when('/tickets/edit/:ticketId',
            {
                controller: 'TicketEditController',
                templateUrl: 'Partials/TicketEdit.html'
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