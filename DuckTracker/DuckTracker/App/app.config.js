'use strict';

angular.
    module('ducktrackerApp').config(function ($routeProvider) {
        $routeProvider
            .when('/Mama', {
                templateUrl: 'mama/mama-list/mama-list.html'
            })
            .when('/Mama/:id', {
                templateUrl: function (params) {
                    if (Number.isSafeInteger(parseInt(params.id))) {
                        return 'mama/mama-details/mama-details.html';
                    } else {
                        return 'mama/mama-list/mama-list.html';
                    }
                }
            })
            .when('/mama/update/:id', {
                templateUrl: function (params) {
                    if (Number.isSafeInteger(parseInt(params.id))) {
                        return 'mama/mama-update/mama-update.html';
                    } else {
                        return 'mama/mama-list/mama-list.html';
                    }
                }
            })
            .when('/mama/add', {
                templateUrl: 'mama/mama-add/mama-add.html'
            })
            .when('/mama/note/add/:id', {
                templateUrl: function (params) {
                    if (Number.isSafeInteger(parseInt(params.id))) {
                        return 'notes/mama-notes/mama-add-note/mama-add-note.html';
                    } else {
                        return 'mama/mama-list/mama-list.html';
                    }
                }
            })
            .when('/mama/note/update/:id', {
                templateUrl: function (params) {
                    if (Number.isSafeInteger(parseInt(params.id))) {
                        return 'notes/mama-notes/mama-update-note/mama-update-note.html';
                    } else {
                        return 'mama/mama-list/mama-list.html';
                    }
                }
            })
            .when('/Papa', {
                templateUrl: 'papa/papa-list/papa-list.html'
            })
            .when('/Papa/:id', {
                templateUrl: function (params) {
                    if (Number.isSafeInteger(parseInt(params.id))) {
                        return 'papa/papa-details/papa-details.html';
                    } else {
                        return 'papa/papa-list/papa-list.html';
                    }
                }
            })
            .when('/papa/update/:id', {
                templateUrl: function (params) {
                    if (Number.isSafeInteger(parseInt(params.id))) {
                        return 'papa/papa-update/papa-update.html';
                    } else {
                        return 'papa/papa-list/papa-list.html';
                    }
                }
            })
            .when('/papa/add', {
                templateUrl: 'papa/papa-add/papa-add.html'
            })
            .when('/papa/note/add/:id', {
                templateUrl: function (params) {
                    if (Number.isSafeInteger(parseInt(params.id))) {
                        return 'notes/papa-notes/papa-add-note/papa-add-note.html';
                    } else {
                        return 'papa/papa-list/papa-list.html';
                    }
                }
            })
            .when('/papa/note/update/:id', {
                templateUrl: function (params) {
                    if (Number.isSafeInteger(parseInt(params.id))) {
                        return 'notes/papa-notes/papa-update-note/papa-update-note.html';
                    } else {
                        return 'papa/papa-list/papa-list.html';
                    }
                }
            })
            .when('/Litter', {
                templateUrl: 'litter/litter-list/litter-list.html'
            })
            .when('/Litter/:id', {
                templateUrl: function (params) {
                    if (Number.isSafeInteger(parseInt(params.id))) {
                        return 'litter/litter-details/litter-details.html';
                    } else {
                        return 'litter/litter-list/litter-list.html';
                    }
                }
            })
            .when('/litter/update/:id', {
                templateUrl: function (params) {
                    if (Number.isSafeInteger(parseInt(params.id))) {
                        return 'litter/litter-update/litter-update.html';
                    } else {
                        return 'litter/litter-list/litter-list.html';
                    }
                }
            })
            .when('/litter/add', {
                templateUrl: 'litter/litter-add/litter-add.html'
            })
            .when('/litter/note/add/:id', {
                templateUrl: function (params) {
                    if (Number.isSafeInteger(parseInt(params.id))) {
                        return 'notes/litter-notes/litter-add-note/litter-add-note.html';
                    } else {
                        return 'litter/litter-list/litter-list.html';
                    }
                }
            })
            .when('/litter/note/update/:id', {
                templateUrl: function (params) {
                    if (Number.isSafeInteger(parseInt(params.id))) {
                        return 'notes/litter-notes/litter-update-note/litter-update-note.html';
                    } else {
                        return 'litter/litter-list/litter-list.html';
                    }
                }
            })
            .when('/', {
                    templateUrl: 'home/home-page.html'
                }
            );
    });