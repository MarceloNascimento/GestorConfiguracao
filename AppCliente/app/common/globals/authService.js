﻿
app.factory('authService', ['$http', '$q', 'locationhostService', 'storageService', 'md5', '$location',
    function ($http, $q, locationhostService, storageService, $md5, $location) {

        var serviceBase = locationhostService.apiBase;

        var authServiceFactory = {};

        var _authentication = {
            isAuth: false,
            userName: ""
        };

        var _saveRegistration = function (registration) {

            _logOut();
            registration.Senha = $md5.createHash(registration.Senha);

            return $http.post(serviceBase + 'api/account/register', registration).then(function (response) {
                return response;
            });

        };

        var _login = function (loginData) {

                var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

                var deferred = $q.defer();

                $http.post(serviceBase + 'api/security/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).then(function (response) {

                    storageService.set('authorizationData', { token: response.data.access_token, userName: loginData.userName });
                    _authentication.isAuth = true;
                    _authentication.userName = loginData.userName;

                    deferred.resolve(response);

                }).catch(function (err, status) {

                    _logOut();
                    deferred.reject(err);
                });

                return deferred.promise;
        };

        var _logOut = function () {

            storageService.delete('authorizationData');

            _authentication.isAuth = false;
            _authentication.userName = "";

        };

        var _fillAuthData = function () {

            var authData = storageService.get('authorizationData');
            if (authData) {
                _authentication.isAuth = true;
                _authentication.userName = authData.userName;
            }

        }

        authServiceFactory.saveRegistration = _saveRegistration;
        authServiceFactory.login = _login;
        authServiceFactory.logOut = _logOut;
        authServiceFactory.fillAuthData = _fillAuthData;
        authServiceFactory.authentication = _authentication;

        return authServiceFactory;
    }]);