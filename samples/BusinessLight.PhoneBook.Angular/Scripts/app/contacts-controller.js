var phoneBookApp = angular.module("phoneBookApp", ["ngRoute", "ui.bootstrap", "ui.bootstrap.datepicker"])
    .constant("searchUrl", "http://localhost:51121/api/contact/search")
    .constant("getByIdUrl", "http://localhost:51121/api/contact/get")
    .constant("createUrl", "http://localhost:51121/api/contact/create")
    .constant("updateUrl", "http://localhost:51121/api/contact/update")
    .config(function ($routeProvider) {
        $routeProvider.when("/list", {
            templateUrl: "/scripts/views/contacts/contactList.html",
            controller: "contactsController"
        });

        $routeProvider.when("/create", {
            templateUrl: "/scripts/views/contacts/contactCreate.html",
            controller: "contactCreateController"
        });

        $routeProvider.when("/edit/:id", {
            templateUrl: "/scripts/views/contacts/contactEdit.html",
            controller: "contactEditController"
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
        
        $scope.getAge = function (birthday) {
            var ageDifMs = Date.now() - new Date(birthday).getTime();
            var ageDate = new Date(ageDifMs); // miliseconds from epoch
            return Math.abs(ageDate.getUTCFullYear() - 1970);
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
    .controller("contactCreateController", function ($scope, $http,$location, createUrl) {
         $scope.saveContact = function () {
             $http.post(createUrl, $scope.contact)
             .success(function (data) {
                 $scope.data.contactId = data.id;
                 $location.path("/list");
             })
             .error(function (error) {
                 $scope.error = error;
             }).finally(function () {
          
             });
         }
     })
    .controller("contactEditController", function ($scope, $http, $routeParams,$location, getByIdUrl, updateUrl) {
        var id = $routeParams.id;

        $http.get(getByIdUrl, {
            params: { id: id }
        }).success(function (result) {
            $scope.contact = result;
        });

        $scope.saveContact = function () {
            $http.put(updateUrl, $scope.contact)
            .success(function (data) {
                $scope.data.contactId = data.id;
                $location.path("/list");
            })
            .error(function (error) {
                $scope.error = error;
            }).finally(function () {
               
            });
        }
    });