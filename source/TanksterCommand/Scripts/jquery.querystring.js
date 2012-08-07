$.extend({
    getQueryStringParameters: function () {
        // get all the queryString, remove the ? and separate it in a 'key = value' array
        var queryStringParameters = window.location.search.substring(1).split('&');
        var toReturn = [];
        for (var i = 0; i < queryStringParameters.length; i++) {
            var pair = queryStringParameters[i].split('=');
            toReturn.push(pair[0]);
            toReturn[pair[0]] = pair[1];
        }
        return toReturn;
    },
    getQueryStringParameter: function (parameter) {
        return $.getQueryStringParameters()[parameter];
    }
});
