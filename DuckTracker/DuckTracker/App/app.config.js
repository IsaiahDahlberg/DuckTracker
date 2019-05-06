﻿'use strict';

angular.
    module('ducktrackerApp').config(function ($routeProvider) {
        $routeProvider
            .when('/Mama', {
                templateUrl: 'mama-list/mama-list.html'
            })
            .when('/Papa', {
                templateUrl: 'papa-list/papa-list.html'
            })
            .when('/Litter', {
                templateUrl: 'litter-list/litter-list.html'
            });
    });