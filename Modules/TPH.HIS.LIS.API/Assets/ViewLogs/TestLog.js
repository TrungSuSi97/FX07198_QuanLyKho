var testLog = {
    actions: {
        insertLog: '../Logs/InsertHisTracking',
    },
    domeElements: {
        txtContent: '#txtContent',
        btnCancel: '#btnCancel',
        btnSave: '#btnSave'
    },

    init: function () {        
        testLog.bindEvent();
    },

    bindEvent: function () {

        $(testLog.domeElements.btnCancel).unbind('click').bind('click', function () {
            $('textarea#message').val('');
        });

        $(testLog.domeElements.btnSave).unbind('click').bind('click', function () {
            testLog.saveLog();
        });
    },

    saveLog: function () {
        
        var message = $.trim($('textarea#message').val());
        
        if (message === '') {
            return;
        }
                
        var params = {
            hisCode: '',
            lisCode: '',
            error: '',
            logTracking: message
        };

        ajaxRequest.sendRequest_Json(testLog.actions.insertLog,
           params, 'POST',
           function (data) {
               if (data.Code === 0) {
                   
                   alert('Thêm thành công');
               }
           },
           false);
    }
};

$(document).ready(function () {
    testLog.init();
});