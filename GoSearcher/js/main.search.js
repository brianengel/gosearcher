var app = angular.module('app', []);

app.controller('SearchController', function ($http) {
    var self = this;
    self.guns = [];
    self.isSearching = false;
    self.sort = 'name';
    self.reverse = false;

    this.submit = function () {
        self.isSearching = true;
        var query = self.query || ""
        $http({
            url: "/home/search?query=" + query,
            method: "POST",
            data: { "foo": "bar" }
        }).success(function (data, status, headers, config) {
            self.guns = data;
            self.isSearching = false;
        }).error(function(data, status, headers, config) {
            self.isSearching = false;
        });
    };
});

app.directive('gunPreview', function () {
    return {
        restrict: 'A',
        scope: {
            previewUrl: "&"
        },
        link: function (scope, element) {
            var url = scope.previewUrl();
            var previewImage = url.substring(0, url.length - 7) + "360fx360f";
            $(element).popover({
                html: true,
                content: "<div><img height='500' width='500' src='" + previewImage + "' /></div>",
                trigger: 'hover'
            });
        }
    }
});