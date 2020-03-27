var map;
var myLatLng = { lat: 53.903529, lng: 27.557316 };
var myZoom = 5;
var marker;

app.controller('settingsController', function ($scope, $http, $compile, $window) {
    $scope.model = model;

    $scope.addGroup = function (e) {
        e.preventDefault();
        if (!$scope.model.FullContactsGroups)
            $scope.model.FullContactsGroups = [];
        $scope.model.FullContactsGroups.push({ Items: [] });
    }

    $scope.deleteGroup = function (e, group) {
        e.preventDefault();
        if (group)
            $scope.model.FullContactsGroups.splice($scope.model.FullContactsGroups.indexOf(group), 1);
    }

    $scope.addContact = function (e, group) {
        e.preventDefault();
        if (!group.Items)
            group.Items = [];
        group.Items.push({});
    }

    $scope.deleteContact = function (e, group, item) {
        e.preventDefault();
        if (group && item)
            group.Items.splice(group.Items.indexOf(item), 1);
    }

    $scope.addProject = function (e) {
        e.preventDefault();
        if (!$scope.model.ProjectsList)
            $scope.model.ProjectsList = [];
        $scope.model.ProjectsList.push({});
    }

    $scope.deleteProject = function (e, project) {
        e.preventDefault();
        if (project)
            $scope.model.ProjectsList.splice($scope.model.ProjectsList.indexOf(project), 1);
    }

    $scope.addPartner = function (e) {
        e.preventDefault();
        if (!$scope.model.PartnersList)
            $scope.model.PartnersList = [];
        $scope.model.PartnersList.push({});
    }

    $scope.deletePartner = function (e, partner) {
        e.preventDefault();
        if (partner)
            $scope.model.PartnersList.splice($scope.model.PartnersList.indexOf(partner), 1);
    }

    $scope.saveSettings = function (e, model) {
        e.preventDefault();
        $scope.loading = true;
        if ($('#EditSettings').valid()) {
            $http({
                method: 'POST',
                url: 'admin/settings',
                data: model,
                DataType: 'json'
            }).then(function (result) {
                $scope.loading = false;
                if (result.data) {
                    $scope.model = result.data;
                    $scope.showMessage(true, "Сохранение");
                } else {
                    $scope.showMessage(result.data, "Сохранение");
                }
            }).catch(function (response) {
                console.log(response);
                $scope.showMessage(false, "Сохранение");
            });
        } else
            $scope.loading = false;
        $window.scrollTo(0, 0);
    }

    $scope.showMessage = function (result, action) {
        if (result) {
            $scope.message = {
                Class: "alert-success",
                Title: "Выполнено!",
                Text: action + " произведено успешно.",
                Icon: "fa-check"
            };
        } else if (result === "") {
            $scope.message = {
                Class: "alert-warning",
                Title: "Внимание!",
                Text: action + " не было произведено. Проверьте введенные данные.",
                Icon: "fa-warning"
            };
        } else if (result === false) {
            $scope.message = {
                Class: "alert-danger",
                Title: "Ошибка",
                Text: action + " привело к ошибке.",
                Icon: "fa-ban"
            };
        }
        setTimeout(function () {
            $scope.message = null;
            $scope.$apply();
        }, 5000);
    }
}).directive('ckEditor', [
    '$timeout', function ($timeout) {
        return {
            require: '?ngModel',
            link: function ($scope, elm, attr, ngModel) {
                return $timeout(function () {
                    var ck = CKEDITOR.replace(elm[0], {
                        toolbar: 'Basic',
                        height: $(elm[0]).data('height') || 150
                    });

                    ck.on('pasteState', function () {
                        $scope.$apply(function () {
                            ngModel.$setViewValue(ck.getData());
                            $(elm).html(ngModel.$viewValue || '');
                        });
                    });

                    ck.on('insertElement', function () {
                        $scope.$apply(function () {
                            ngModel.$setViewValue(ck.getData());
                            $(elm).html(ngModel.$viewValue || '');
                        });
                    });

                    ck.on('insertHtml', function () {
                        $scope.$apply(function () {
                            ngModel.$setViewValue(ck.getData());
                            $(elm).html(ngModel.$viewValue || '');
                        });
                    });

                    ngModel.$render = function (value) {
                        ck.setData(ngModel.$modelValue);
                    };
                });
            }
        };
    }
]);