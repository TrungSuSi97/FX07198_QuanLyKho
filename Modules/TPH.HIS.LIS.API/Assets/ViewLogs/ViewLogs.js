var viewLogs = {
    actions: {
        searchLogs: '../Logs/Search',
        deleteLog: '../Logs/Delete'
    },
    domeElements: {
        grid: '#grid',
        btnSearch: '#btnSearch',
        txtFilter: '#txtFilter',
        dialogDetail: '#dialog-message-detail',
        dptLogDate: '#dptLogDate'
    },
    pager: GridPagerOptions,
    dataField: [
        { name: 'MessageId', type: 'string' },
        { name: 'Action', type: 'string' },
        { name: 'InputMessage', type: 'string' },
        { name: 'OutputMessage', type: 'string' },
        { name: 'Ip', type: 'string' },
        { name: 'ErrorMessage', type: 'string' },
        { name: 'Username', type: 'string' },
        { name: 'LogDate', type: 'string' }
    ],
    firstRender: true,
    init: function () {
        $(viewLogs.domeElements.dptLogDate).datepicker({
            dateFormat: 'dd/mm/yy'
        });
        $(viewLogs.domeElements.dptLogDate).datepicker('setDate', new Date());
        viewLogs.bindEvent();
    },
    bindEvent: function () {
        //dptLogDate
        $(viewLogs.domeElements.dptLogDate + ',' + viewLogs.domeElements.txtFilter).unbind('keydown').bind('keydown', function (eve) {
            if (eve.keyCode == 13) {
                viewLogs.loadData();
            }            
        });

        $(viewLogs.domeElements.btnSearch).unbind('click').bind('click', function () {
            viewLogs.loadData();
        });
    },

    loadData: function () {
        var logDate = $.trim($(viewLogs.domeElements.dptLogDate).val());
        var filter = $.trim($(viewLogs.domeElements.txtFilter).val());
        if (logDate === '' && filter === '') {
            return;
        }

        var params = {
            filter: {
                LogDate: logDate,
                Filter: filter,
                pageIndex: viewLogs.pager.pageIndex,
                RowsPerPage: viewLogs.pager.rowsPerPage,
            }
        };
        
        ajaxRequest.sendRequest_Json(viewLogs.actions.searchLogs,
           params, 'POST',
           function (data) {
               viewLogs.renderData(viewLogs.domeElements.grid, data);
           },
           false);

    },
    renderData: function (grid, data) {
        //console.log(viewLogs.pager);

        var customSort = new GridCustomSort(grid, data.Logs);
        var source =
            {
                datatype: "array",
                localdata: data.Logs,
                root: "entry",
                sort: customSort.sort,
                updaterow: function (rowid, rowdata) {
                },
                beforeprocessing: function (obj) {                    
                    //source.totalrecords = data.TotalRows;
                },
                datafields: viewLogs.dataField
            };
        var dataAdapter = new $.jqx.dataAdapter(source);
        $(grid).jqxGrid('clearselection');
        $(grid).jqxGrid('clear');

        if (!viewLogs.firstRender) {
            $(grid).jqxGrid({ source: dataAdapter });
            $(grid).jqxGrid('updatebounddata');

            return;
        }

        viewLogs.firstRender = false;

        $(grid).jqxGrid({
            width: '99%',
            height: '700',
            source: dataAdapter,
            columnsresize: true,

            rowsheight: 50,
            sortable: true,
            enablebrowserselection: true,

            //pageable: true,
            //virtualmode: true,
            //pagesize: viewLogs.pager.rowsPerPage,
            rendergridrows: function (obj) {
                return obj.data;
            },
            //pagesizeoptions: viewLogs.pager.pageSizeArr,

            handlekeyboardnavigation: function (event) {
                return GridCustomHandleKeyBoardNavigation(this, grid, event);
            },
            columns: [
                {
                text: '#',
                sortable: false,
                filterable: false,
                editable: false,
                groupable: false,
                draggable: false,
                resizable: false,
                datafield: '',
                columntype: 'number',
                width: 30,
                cellsrenderer: function (row, column, value) {
                    return "<div style='margin:4px;'>" + (value + 1) + "</div>";
                }
            },
                {
                    text: 'Thời gian',
                    datafield: 'LogDate',
                    width: 140,
                    cellsalign: 'left',
                    align: 'center',
                    sortable: true,
                    editable: false
                },
                {
                    text: 'Nội dung Truyền vào',
                    datafield: 'InputMessage',
                    width: '30%',
                    cellsalign: 'left',
                    align: 'center',
                    sortable: true,
                    editable: false
                },
                {
                    text: 'Nội dung Trả ra',
                    datafield: 'OutputMessage',
                    width: '30%',
                    cellsalign: 'left',
                    align: 'center',
                    sortable: true,
                    editable: false
                },
                {
                    text: 'Nội dung Lỗi',
                    datafield: 'ErrorMessage',
                    width: '200',
                    cellsalign: 'left',
                    align: 'center',
                    sortable: true,
                   
                },
                {
                    text: 'IP',
                    datafield: 'Ip',
                    width: 100,
                    cellsalign: 'left',
                    align: 'center',
                    sortable: true,
                    editable: false
                },
                {
                    text: 'Người dùng',
                    datafield: 'Username',
                    width: 100,
                    cellsalign: 'left',
                    align: 'center',
                    sortable: true,
                    editable: false
                },
            ]
        });

        viewLogs.bindGridEvent(grid);
    },

    bindGridEvent: function (grid) {
        $(grid).unbind('pagechanged').bind("pagechanged", function (event) {
            var args = event.args;
            viewLogs.pager.rowsPerPage = args.pagesize;
            viewLogs.pager.pageIndex = args.pagenum;

            viewLogs.loadData();
        });

        $(grid).unbind('pagesizechanged').bind("pagesizechanged", function (event) {
            var args = event.args;

            viewLogs.pager.rowsPerPage = args.pagesize;
            viewLogs.pager.pageIndex = args.pagenum;

            viewLogs.loadData();
        });

        $(grid).unbind('rowdoubleclick').bind('rowdoubleclick', function (event) {
            // event arguments.
            var args = event.args;
            viewLogs.openLogDetailPopup(grid, args.rowindex);
        });
    },
    openLogDetailPopup: function (grid, rowIndex) {
        $('textarea#message').val('');
        var dataInfo = $(grid).jqxGrid('getrowdata', rowIndex);

        var message = 'Input Msg<br/>' + dataInfo.InputMessage + '<br/>Output Msg<br/>' + dataInfo.OutputMessage + '<br/>Error Msg<br/>' + dataInfo.ErrorMessage;

        $('textarea#message').val(message);

        var dialog = $(viewLogs.domeElements.dialogDetail).removeClass('hide').dialog({
            modal: true,
            width: '90%',
            height: '720',
            title: "Log Detail",
            
            buttons: [
                {
                    text: "[ OK ]",
                    "class": "btn btn-primary btn-minier",
                    click: function () {
                        $(this).dialog("close");
                    }
                }
            ]
        });
    },

    deleteLog: function (id) {
        var params = {
            key: id
        };

        ajaxRequest.sendRequest_Json(viewLogs.actions.deleteLog,
           params, 'POST',
           function (data) {
               viewLogs.loadData();
           },
           false);
    }
};

$(document).ready(function () {
    viewLogs.init();
});