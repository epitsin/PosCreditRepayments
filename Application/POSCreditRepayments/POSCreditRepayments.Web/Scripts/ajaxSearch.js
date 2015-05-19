$(document).ready(function () {
    var APPLICATION_NAME = 'POSCreditsRepaymentCalculator';

    $('#product-search').devbridgeAutocomplete({
        serviceUrl: getServiceUrl('/Products/SearchForProduct'),
        transformResult: function (response) {
            response = JSON.parse(response);
            return {
                suggestions: $.map(response, function (dataItem) {
                    return { value: dataItem.Name, data: dataItem.Id };
                })
            };
        },
        onSelect: function (suggestion) {
            window.location.href = getEditUserPath(suggestion.data);
        },
    });

    function getBaseUrl() {
        var hostName = $(location).attr('host');
        hostName = 'http://' + hostName;

        var appName = $(location).attr('pathname').split('/')[1];
        if (appName !== APPLICATION_NAME) {
            appName = '';
        } else {
            appName = '/' + appName;
        }

        var baseUrl = hostName + appName;

        return baseUrl;
    }

    function getServiceUrl(serviceName) {
        var appName = getBaseUrl();
        var finalUrl = appName + serviceName;

        return finalUrl;
    }

    function getEditUserPath(id) {
        var baseUrl = getBaseUrl();
        var whatsLeft = '/Products/ProductDetails/' + id;
        var final = baseUrl + whatsLeft;

        return final;
    }
});