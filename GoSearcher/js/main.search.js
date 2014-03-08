﻿var app = angular.module('app', []);

app.controller('SearchController', ['$http', function ($http) {
    var self = this;
    self.guns = [];
    self.isSearching = false;
    self.sort = 'name';
    self.reverse = false;

    this.submit = function () {
        self.isSearching = true;
        var query = self.query || ""
        $http({
            url: "/search?query=" + query,
            method: "GET"
        }).success(function (data, status, headers, config) {
            self.guns = data;
            self.isSearching = false;
        }).error(function(data, status, headers, config) {
            self.isSearching = false;
        });
    };
}]);

app.directive('previewPopover', function () {
    return {
        restrict: 'A',
        scope: {
            previewPopover: "&"
        },
        link: function (scope, element) {
            var previewImage = scope.previewPopover();
            $(element).popover({
                html: true,
                content: "<img height='500' width='500' src='" + previewImage + "' />",
                trigger: 'hover'
            });
        }
    }
});