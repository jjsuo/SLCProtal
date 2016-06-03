$(function () {
    $('.usrBd>div').attr('class', $('.usrBd .usrSubMenu a.act').attr('bgclass') + " clearfix");
})
var formOptions = {
    clearForm: true,
    success: function (data) {
        if (data.result == "S") {
            logger.success("提交成功");
        }
        else {
            logger.error(data.result);
        }
    },
    error: logger.ajaxError.bind(this)
};