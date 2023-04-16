
var ajaxRequest = {
    sendRequest_Query: function (url, param, type, callback, global, callbackError) {

        $.ajax({
            type: type,
            //dataType: "json",
            async: false,
            contentType: "application/json, charset=utf-8",
            data: JSON.stringify(param),
            url: url,
            global: global != undefined ? global : true,
            success: function (data) {
                if ($.isFunction(callback)) {
                    callback(data);
                }
            },
            error: function (request, status, error) {
                console.log(error);
                if ($.isFunction(callbackError)) {
                    callback(callbackError(error));
                }
            }
        });
    },

    sendRequest_Json: function (url, param, type, callback, global, callbackError) {
        $.ajax({
            type: type,
            dataType: "json",
            async: false,
            contentType: "application/json, charset=utf-8",
            data: JSON.stringify(param),
            url: url,
            global: global != undefined ? global : true,
            success: function (data) {
                if ($.isFunction(callback)) {
                    callback(data);
                }
            },
            error: function (request, status, error) {
                console.log(error);
                if ($.isFunction(callbackError)) {
                    callback(callbackError(error));
                }
            }
        });
    },

    sendRequest_Html: function (url, param, type, callback, global, callbackError) {
        $.ajax({
            type: type,
            dataType: "HTML",
            crossDomain: true, // set this to ensure our $.ajaxPrefilter hook fires
            processData: false, // We want this to remain an object for  $.ajaxPrefilter
            contentType: "application/json, charset=utf-8",
            data: JSON.stringify(param),
            async: false,
            url: url,
            global: global != undefined ? global : true,
            cache: false,
            success: function (data) {
                if ($.isFunction(callback)) {
                    callback(data);
                }
            },
            error: function (request, status, error) {
                console.log(error);
                if ($.isFunction(callbackError)) {
                    callback(callbackError(error));
                }
            }
        });
    }
};