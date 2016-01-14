var phoneBookApp = angular.module("PhoneBookApp", ["ngRoute", "ui.bootstrap"])
    .constant("dataUrl", "http://localhost:51121/api/contact/search")
    .config(function ($routeProvider) {
        $routeProvider.when("/checkout", {
            templateUrl: "/views/checkoutSummary.html"
        });
        $routeProvider.when("/products", {
            templateUrl: "/views/productList.html"
        });
        $routeProvider.otherwise({
            templateUrl: "/scripts/views/contacts/contactList.html"
        });
    })
    .controller('ContactsController', function ($scope, $http, dataUrl) {
        //$scope.firstName = "";
        //$scope.lastName = "";
        //$scope.birthDate = "";
        $scope.pageNumber = 1;
        $scope.pageSize = "10";
        //$scope.sortField = "";
        //$scope.isAscending = true;
        
        $scope.pageChanged = function () {
            $scope.search();
        };

        $scope.search = function () {
            var data = {
                FirstName: $scope.firstName,
                LastName: $scope.lastName,
                BirthDate: $scope.birthDate,
                PageNumber: $scope.pageNumber - 1,
                PageSize: $scope.pageSize,
                SortField: $scope.sortField,
                IsAscending: $scope.isAscending
            }
            $http.post(dataUrl, data)
                .success(function (result, status) {
                    $scope.contacts = result;
                })
                .error(function (error) {
                    $scope.error = error;
                });
        }
    });