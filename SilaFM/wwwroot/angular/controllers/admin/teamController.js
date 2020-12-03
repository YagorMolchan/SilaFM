var map;
var myLatLng = { lat: 53.903529, lng: 27.557316 };
var myZoom = 5;
var marker;

app.controller('teamController', function ($scope, $http, $compile, $window) {
    $scope.model = model;

    $scope.addSocial = function (e) {
        e.preventDefault();
        if (!$scope.model.SocialsList)
            $scope.model.SocialsList = [];
        $scope.model.SocialsList.push({ Type: 'Facebook' });
    };

    $scope.removeSocials = function (e, item) {
        e.preventDefault();
        var index = $scope.model.SocialsList.indexOf(item);
        if (index >= 0) {
            $scope.model.SocialsList.splice(index, 1);
        }
    };

    $scope.getMask = function (contact) {
        switch (contact.Type) {
        case "Facebook": contact.Link = "https://facebook.com/"; break;
        case "Instagram": contact.Link = "https://instagram.com/"; break;
        case "LinkedIn": contact.Link = "https://linkedin.com/"; break;
        case "Skype": contact.Link = "skype:username"; break;
        case "Telegram": contact.Link = "https://telegram.me/username"; break;
        case "Viber": contact.Link = "viber://chat?number=+71234567890"; break;
        case "Vk": contact.Link = "https://vk.com/"; break;
        case "WhatsApp": contact.Link = "https://wa.me/71234567890"; break;
        default: contact.Link = ""; break;
        }
    };
    
});