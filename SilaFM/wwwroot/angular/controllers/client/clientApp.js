var app = angular.module('clientApp', []);

app.config(['$httpProvider', function ($httpProvider) {
    var antiForgeryToken = document.getElementsByName("__RequestVerificationToken")[0].value;
    $httpProvider.defaults.headers.post['__RequestVerificationToken'] = antiForgeryToken;
    $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest'; 
}]);

function createGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

function capitalizeFirstLetter(string) {
    if (string && string.length)
        return string[0].toUpperCase() + string.slice(1);
    return string;
}