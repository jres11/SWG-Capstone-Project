var myApp = angular.module('BlogApp', ['ngRoute', 'ui.tinymce', 'ui.bootstrap']);


// ----------------FACTORY----------------
myApp.factory('dataService', function ($http) {
    var WebApiProvider = {};

    var url = '/api/BlogStuff/';
    var surl = '/api/StaticPage/';

    WebApiProvider.getBlogs = function () {
        return $http.get(url);
    };

    WebApiProvider.deleteBlogEntry = function (id) {
        return $http.delete(url + id);
    };

    WebApiProvider.createBlogEntry = function (blogEntry) {
        return $http.post(url, blogEntry);
    };

    WebApiProvider.editBlogEntry = function (blogEntry) {
        return $http.put(url, blogEntry);
    };

    WebApiProvider.createStaticEntry = function(staticEntry) {
        return $http.post(surl, staticEntry);
    }

    return WebApiProvider;
});


// ----------------CONFIG----------------
myApp.config([
    '$routeProvider', function($routeProvider) {
        $routeProvider
            .when('/blogs', {
                controller: 'DefaultBlogController',
                templateUrl: '/Home/blogs'
            })
            .when('/SarahsBlog', {
                    controller: 'DefaultBlogController',
                    templateUrl: '/AngularViews/SarahsBlog.html'
            })
            .when('/AddBlogEntry', {
                controller: 'CreateBlogController',
                templateUrl: '/AngularViews/CreateBlogEntry.html'
            })
            .when('/EditBlogEntry', {
                controller: 'EditBlogController',
                templateUrl: '/AngularViews/EditBlogEntry.html'
            })
            .when('/DeleteBlogEntry', {
                controller: 'DeleteBlogEntry',
                templateUrl: '/AngularViews/DeleteBlogEntry.html'
            })
            .when('/AddStaticEntry', {
                controller: 'CreateStaticController',
                templateUrl: '/AngularViews/CreateStaticPage.html'
            })
                .otherwise({ redirectTo: '/blogs' });
    }
]);

// ----------------CONTROLLERS----------------
    myApp.controller('RootController', function ($scope, $route, $routeParams, $location, dataService) {
    $scope.$on('$routeChangeSuccess', function (e, current, previous) {
        $scope.activeViewPath = $location.path();
    });
});

    myApp.controller('DefaultBlogController', function ($scope, dataService, $location) {
    $scope.$on('$routeChangeSuccess', function(e, current, previous) {
        $scope.activeViewPath = $location.path();
    });
    $scope.blogList = [];
    loadblogs();

    function loadblogs() {
        dataService.getBlogs()
            .success(function (data) {
                $scope.blogList = data;
            });
    }

    $scope.deleteblog = function (id) {
        dataService.deleteBlogEntry(id)
            .success(function () {
                loadblogs();
            });
    }
    
});

myApp.controller('CreateBlogController', function($scope, $location, dataService) {
    $scope.blogEntry = {};

    $scope.createBlogEntry = function() {
        dataService.createBlogEntry($scope.blogEntry)
            .success(function() {
                $location.path('/Routes');
            })
            .ERROR(function(data, status) {
                alert('ERROR - ' + status);
            });
    }
});

/*
myApp.controller('DeleteBlogController', function($scope, $location, dataService) {
    dataService.deleteBlogEntry(id)
        .success(function(data) {
            $scope.blogList = data;
        });
});
*/

myApp.controller('EditBlogController', function($scope, $location, dataService) {

    $scope.blog = {};
    loadblog();

    function loadblog(id) {
        dataService.getBlog(id)
            .success(function (data) {
                $scope.blogList = data;
            });
    }

    $scope.edit = function()
    {
        dataService.editBlogEntry(blogEntry)
            .success(function (data) {

    });
    }

    
});

myApp.controller('CreateStaticController', function($scope, $location, dataService) {
    $scope.staticEntry = {};

    $scope.createStaticEntry = function() {
        dataService.createStaticEntry($scope.staticEntry)
            .success(function() {
                $location.path('/Routes');
            })
            .ERROR(function(data, status) {
                alert('ERROR - ' + status);
            });
    }
});
