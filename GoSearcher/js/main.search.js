var app = angular.module('app', []);

app.controller('SearchController', function ($http) {
    var self = this;
    self.guns = [];
    self.isSearching = false;
    self.sort = 'name';
    self.reverse = false;

    this.submit = function () {
        self.isSearching = true;
        $http({
            url: "/home/search?query=" + self.query,
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
