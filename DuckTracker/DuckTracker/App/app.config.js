'use strict';

angular.
    module('ducktrackerApp').config(function ($routeProvider) {
        $routeProvider
            .when('/Mama', {
                templateUrl: 'mama-list/mama-list.html'
            })
            .when('/Mama/:id', {
                templateUrl: function (params) {
                    if (Number.isSafeInteger(parseInt(params.id))) {
                        return 'mama-details/mama-details.html';
                    } else {
                        return 'mama-list/mama-list.html';
                    }                    
                }
            })
            .when('/mama/update/:id', {
                templateUrl: function (params) {
                    if (Number.isSafeInteger(parseInt(params.id))) {
                        return 'mama-update/mama-update.html';
                    } else {
                        return 'mama-list/mama-list.html';
                    }
                }
            })
            .when('/mama/note/add/:id', {
                templateUrl: function (params) {
                    if (Number.isSafeInteger(parseInt(params.id))) {
                        return 'notes/mama-notes/mama-add-note/mama-add-note.html';
                    } else {
                        return 'mama-list/mama-list.html';
                    }
                }
            })
            .when('/mama/note/update/:id', {
                templateUrl: function (params) {
                    if (Number.isSafeInteger(parseInt(params.id))) {
                        return 'notes/mama-notes/mama-update-note/mama-update-note.html';
                    } else {
                        return 'mama-list/mama-list.html';
                    }
                }
            })
            .when('/Papa', {
                templateUrl: 'papa-list/papa-list.html'
            })
            .when('/Litter', {
                templateUrl: 'litter-list/litter-list.html'
            });
    });