var lisAdmin = {
    actions: {
        getOrder: '../Lis/GetOrder',
        getOrderByPatient: '../Lis/GetOrdersByPatient',
        updateResult: '../Lis/UpdateOrderResults',
        uploadResultFile: '../Lis/UploadResultFile',
    },
    domeElements: {
        txtBarcode: '#txtBarcode',
        btnGetOrder: '#btnGetOrder',
        txtGetOrderResponse: '#txtGetOrderResponse',
        txtResultFile: '#txtResultFile',
        btnUploadFile: '#btnUploadFile',
        btnUpdateResults: '#btnUpdateResults',
        txtResultResponse: '#txtResultResponse'
    },
    init: function () {
        lisAdmin.bindEvent();
    },

    bindEvent: function () {

        $(lisAdmin.domeElements.btnGetOrder).unbind('click').bind('click', function () {
            lisAdmin.getOrder();
        });

        $(lisAdmin.domeElements.btnUploadFile).unbind('click').bind('click', function () {
            lisAdmin.uploadResultFile();
        });

        $(lisAdmin.domeElements.btnUpdateResults).unbind('click').bind('click', function () {
            lisAdmin.updateResult();
        });

        //$(lisAdmin.domeElements.txtResultFile).ace_file_input({
        //    no_file: 'No File ...',
        //    btn_choose: 'Choose',
        //    btn_change: 'Change',
        //    droppable: false,
        //    onchange: null,
        //    thumbnail: false,
        //    //| true | large
        //    //whitelist: 'gif|png|jpg|jpeg'
        //    whitelist:'pdf|word'
        //    //blacklist:'exe|php'
        //    //onchange:''
        //    //
        //});
    },

    getOrder: function () {
        $(lisAdmin.domeElements.txtGetOrderResponse).val('');
        var barcode = $.trim($(lisAdmin.domeElements.txtBarcode).val());
        if (barcode === '') {
            alert('Plz input barcode or patientcode');
            return false;
        }

        var url = lisAdmin.actions.getOrder;
        var params = { orderCode: barcode };
        if (barcode.length === 10) {
            url = lisAdmin.actions.getOrderByPatient;
            params = { patient: barcode };
        }

        ajaxRequest.sendRequest_Json(url,
           params, 'POST',
           function (data) {
               $(lisAdmin.domeElements.txtGetOrderResponse).val(data.Message);
           },
           false);
    },

    uploadResultFile: function () {
        //console.log($(lisAdmin.domeElements.txtResultFile).val());
        $(lisAdmin.domeElements.txtResultResponse).val('');
        var filePath = $.trim($(lisAdmin.domeElements.txtResultFile).val());

        if (filePath === '') {
            alert('Plz input your result file path!');
            return false;
        }
        var params = {
            filePath: filePath
        };
        ajaxRequest.sendRequest_Json(lisAdmin.actions.uploadResultFile,
          params, 'POST',
          function (data) {
              $(lisAdmin.domeElements.txtResultResponse).val(data.Message);
          },
          false);
   
    },

    updateResult: function () {
        $(lisAdmin.domeElements.txtResultResponse).val('');
        ajaxRequest.sendRequest_Json(lisAdmin.actions.updateResult,
         null, 'POST',
         function (data) {
             $(lisAdmin.domeElements.txtResultResponse).val(data.Message);
         },
         false);
    }
};


$(document).ready(function () {
    lisAdmin.init();
});