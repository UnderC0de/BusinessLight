var phoneBookApp = angular.module('PhoneBookApp', [])
    .controller('ContactsController', function ($scope, $http) {
        //$scope.contacts = [];
        //$scope.contact = null;
        //$http.get('http://localhost:51121/api/contact/get/0dce141c-adf6-4ead-b37a-e98153642f97').success(function (data) {
        //    $scope.contact = data;
        //});

        $scope.search = function () {
           var data =  {
                "PageNumber": 0,
                "PageSize": 10
            }
            $http.post("http://localhost:51121/api/contact/search", data).success(function (data, status) {
                $scope.contacts = data;
            });
        }


    });