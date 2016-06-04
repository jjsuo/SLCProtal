$(function () {
    $('.usrBd>div').attr('class', $('.usrBd .usrSubMenu a.act').attr('bgclass') + " clearfix");
})
var formOptions = {
    isSubmit: !1,

    beforeSubmit: function () {
        if (formOptions.isSubmit) {

            logger.info("表单正在提交中...");
            return false;
        }

        formOptions.isSubmit = !0;
    },
    clearForm: false,
    success: function (data) {
        if (data.result == "S") {
            logger.success("提交成功");
            arguments[3].clearForm();
            if (typeof formOptions.submitsuccess === 'function') {
                formOptions.submitsuccess(data);
                formOptions.submitsuccess = undefined;
            }
        }
        else {
            logger.error(data.result);
            if (typeof formOptions.submiterror === 'function') {
                formOptions.submiterror(data);
                formOptions.submiterror = undefined;
            }
        }
    },
    error: logger.ajaxError.bind(this),
    complete: function () {
        formOptions.isSubmit = !1;
    }
};