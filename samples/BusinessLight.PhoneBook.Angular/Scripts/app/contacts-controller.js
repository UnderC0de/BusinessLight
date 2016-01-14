var phoneBookApp = angular.module("phoneBookApp", ["ngRoute", "ui.bootstrap"])
    .constant("searchUrl", "http://localhost:51121/api/contact/search")
    .constant("getByIdUrl", "http://localhost:51121/api/contact/get")
    .config(function ($routeProvider) {
        $routeProvider.when("/list", {
            templateUrl: "/scripts/views/contacts/contactList.html",
            controller: "contactsController"
        });

        $routeProvider.when("/edit/:id", {
            templateUrl: "/scripts/views/contacts/contactEdit.html",
            controller: "contactController"
        });

        $routeProvider.otherwise({
            templateUrl: "/scripts/views/contacts/contactList.html",
            controller: "contactsController"
        });
    })
    .controller("contactsController", function ($scope, $http, searchUrl) {
        $scope.filter = {
            firstName: "",
            lastName: "",
            birthDate: "",
            pageNumber: 0,
            pageSize: "10",
            sortField: "",
            isAscending: true
        }
        
        
        $scope.pageChanged = function () {
            $scope.search();
        };

        $scope.search = function () {
            $http.post(searchUrl, $scope.filter)
                .success(function (result) {
                    $scope.contacts = result;
                })
                .error(function (error) {
                    $scope.error = error;
                });
        }
    })
    .controller("contactController", function ($scope, $http, $routeParams, getByIdUrl) {
        var id = $routeParams.id;

        $http.get(getByIdUrl, {
            params: { id: id }
        }).success(function (result) {
            $scope.contact = result;
        });
    });