app.controller('callController', function ($scope, $http, $compile, $window) {
    $scope.message = "Катя перезвонит вам";
    $scope.model = {};

    $scope.sendOrder = function (e) {
        e.preventDefault();
        $scope.status = null;
        if ($('#callForm').valid()) {
            $scope.message = "Отправка...";
            $http({
                method: 'POST',
                url: 'order-call',
                data: $scope.model,
                DataType: 'json'
            }).then(function(result) {
                $scope.loading = false;
                if (result.data) {
                    $scope.message = "Ваши данные отправлены!";
                    $scope.status = "success";
                } else {
                    $scope.message = "Ошибка при отправке!";
                    $scope.status = "error";
                }
            }).catch(function(response) {
                console.log(response);
                $scope.message = "Ошибка при отправке!";
                $scope.status = "error";
            });
        } else {
            $scope.message = "Проверьте введенные данные!";
            $scope.status = "error";
        }
    }
});