var phoneBookApp = angular.module('PhoneBookApp', ['ui.bootstrap'])
    .controller('ContactsController', function ($scope, $http) {
        $scope.firstName = "";
        $scope.lastName = "";
        $scope.birthDate = "";
        $scope.pageNumber = 1;
        //$scope.pageSize = "1";

        $scope.pageChanged = function () {
            $scope.search();
        };

        $scope.search = function () {
            var data = {
                "FirstName": $scope.firstName,
                "LastName": $scope.lastName,
                "BirthDate": $scope.birthDate,
                "PageNumber": $scope.pageNumber - 1,
                "PageSize": $scope.pageSize
            }
            $http.post("http://localhost:51121/api/contact/search", data).success(function (result, status) {
                $scope.contacts = result;
            });
        }
    });