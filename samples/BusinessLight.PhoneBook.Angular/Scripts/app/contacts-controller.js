var phoneBookApp = angular.module("PhoneBookApp", ["ngRoute", "ui.bootstrap"])
    .constant("dataUrl", "http://localhost:51121/api/contact/search")
    .config(function ($routeProvider) {
        $routeProvider.when("/list", {
            templateUrl: "/scripts/views/contacts/contactList.html"
        });

        $routeProvider.when("/edit", {
            templateUrl: "/scripts/views/contacts/contactEdit.html"
        });

        $routeProvider.otherwise({
            templateUrl: "/scripts/views/contacts/contactList.html"
        });
    })
    .controller("ContactsController", function ($scope, $http, dataUrl) {
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
            //var data = {
            //    FirstName: $scope.firstName,
            //    LastName: $scope.lastName,
            //    BirthDate: $scope.birthDate,
            //    PageNumber: $scope.pageNumber - 1,
            //    PageSize: $scope.pageSize,
            //    SortField: $scope.sortField,
            //    IsAscending: $scope.isAscending
            //}
            $http.post(dataUrl, $scope.filter)
                .success(function (result, status) {
                    $scope.contacts = result;
                })
                .error(function (error) {
                    $scope.error = error;
                });
        }
    });