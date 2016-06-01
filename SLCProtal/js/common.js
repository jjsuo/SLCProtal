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
        }).error(logger.ajaxError.bind(this));
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
        }).error(logger.ajaxError.bind(this));
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
        }).error(logger.ajaxError.bind(this));;
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
    warning: toastr.warning,
    ajaxError: function (msg) {
        window.showInfoOnSubmit = !0;
        logger.error('status:' + msg.status + ",statusText:" + msg.statusText);
    }
}
var MenuControll = function () {
    //左导航和Top控制
    if (typeof indexs != 'undefined') {
        indexs.forEach(function (index) {
            $('.usrBd .usrSubMenu li a[index=' + index + ']').parent().show();
        });
    }
    if (typeof menuState == 'undefined') {
        return;
    }

    var stateBefore = menuState;

    var divStates = $('.progressbar_bg div[state]');
    if (menuState > divStates.length) {
        menuState = divStates.length;
    }
    var divState = $('.progressbar_bg div[state=' + menuState + ']');
    var stateStart = divState.prevAll().last();
    var stateEnd = divState.nextAll().last();
    divState.prevAll().addClass('middle_complete');
    divState.addClass('middle_start');
    divState.nextAll().addClass('middle_notstart');
    stateStart.attr('class', 'left_complete');
    stateEnd.attr('class', 'right_notstart');
    //特殊情况 第一 或者最后或者全都结束
    if (stateBefore > divStates.length) {
        divState.attr('class', 'right_complete');
    }
    else if (divStates.index(divState) == 0) {
        divState.attr('class', 'left_start');
    }
    else if (divStates.index(divState) + 1 == divStates.length) {
        divState.attr('class', 'right_start');
    }
}
common.getTemp(common.GetRequest());
logger.init();