var common = {
    tempObj: {},

    guid: function () {
        return 'xxxxxxxx-xxxx-xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    },
    momentFormat: function (date, format) {
        return moment(date).format(format || 'YYYY-MM-DD H:mm:ss');
    },
    getTemp: function (obj) {
        if (obj) {
            common.tempObj = $.extend(common.tempObj, obj);
        }
        return common.tempObj;
    },
    getWinTop: function () {
        var win = window;
        while (win.parent != win) {
            win = win.parent;
        }
        return win;
    },
    GetRequest: function (param) {
        var url = location.search; //获取url中"?"符后的字串
        if (param) {
            url = "?" + param;
        }
        var theRequest = new Object();
        if (url.indexOf('?') != -1) {
            var str = url.substr(1);
            var strs = str.split('&');
            for (var i = 0; i < strs.length; i++) {
                theRequest[strs[i].split('=')[0]] = unescape(strs[i].split('=')[1]);
            }
        }
        return theRequest;
    },
    toGuid: function (guid) {
        if (!guid)
            return '';
        return guid.replace(/({|})/g, '').toLowerCase();
    },
    msg: function (msg) {
        alert(msg);
    },
    extend: $.extend
}
var request = {
    get: function (url, data) {
        if (data) {
            url += "?" + $.parent(data);
        }
        return $.ajax({
            type: "get",
            url: url,
            beforeSend: function (XMLHttpRequest) {

            }
        });
    },
    post: function (url, data) {

        data = JSON.stringify(data || []);
        return $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            url: url,
            beforeSend: function (XMLHttpRequest) {
                XMLHttpRequest.setRequestHeader("Accept", "application/json");
            },
            data: data
        });
    },
    form: function (url, data) {

        //data = JSON.stringify(data || []);
        return $.ajax({
            type: "POST",
            contentType: "application/x-www-form-urlencoded",
            datatype: "json",
            url: url,
            beforeSend: function (XMLHttpRequest) {
                XMLHttpRequest.setRequestHeader("Accept", "application/x-www-form-urlencoded");
            },
            data: data
        });
    }
};
var logger = {
    init: function () {
        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }



    },
    info: toastr.info,
    error: toastr.error,
    success: toastr.success,
    warning: toastr.warning
}

common.getTemp(common.GetRequest());
logger.init();