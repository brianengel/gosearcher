var app = angular.module('app', []);

app.controller('SearchController', ['$http', 'utils', function ($http, utils) {
    var self = this;
    self.guns = [];
    self.isSearching = false;
    self.sort = 'name';
    self.reverse = false;

    this.submit = function () {
        self.isSearching = true;
        var query = self.query || ""
        $http({
            url: '/search?query=' + query,
            method: 'GET'
        }).success(function (data, status, headers, config) {
            self.guns = data;
            self.isSearching = false;
        }).error(function(data, status, headers, config) {
            self.isSearching = false;
        });
    };

    self.query = utils.getParameterByName('q');

    if (self.query != null) {
        this.submit();
    }

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

app.service('utils', function() {
    this.getParameterByName = function (name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    };
})