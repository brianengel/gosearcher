var app = angular.module('app', []);

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

app.directive('gunPreview', function () {
    return {
        restrict: 'A',
        scope: {
            previewUrl: "&"
        },
        link: function (scope, element) {
            var url = scope.previewUrl();
            var previewImage = url.substring(0, url.length - 7) + "500fx500f";
            $(element).popover({
                html: true,
                content: "<img height='500' width='500' src='" + previewImage + "' />",
                trigger: 'hover'
            });
        }
    }
});