
$(function () {
    HistoryInit();
    MainLoad();


});
var MainLoad = function () {
    //左导航和Top控制
    indexs.forEach(function (index) {
        $('.usrBd .usrSubMenu li a[index=' + index + ']').parent().show();
    });
    var divState = $('.progressbar_bg div[state=' + state + ']');
    divState.prevAll().addClass('left_complete');
    divState.addClass('middle_start');
    divState.nextAll().addClass('middle_notstart');

}
var HistoryInit = function () {
    History.Adapter.bind(window, 'statechange', function () {
        var State = History.getState();
        var index = State.data.state;

        var url = $('.usrBd .usrSubMenu li a[index=' + index + ']').attr('url')
        if (url) {
            $('.usrBd .usrMn').load('/' + url);
        }
        else {
            $('.usrBd .usrMn').html('');
        }
    });
    $('.usrBd .usrSubMenu li').hide();
    $('.usrBd .usrSubMenu li a[index]').click(function (event) {
        var curr = $(event.currentTarget);
        curr.parents('ul').find('.act').removeClass('act');
        curr.parent().addClass('act');
        var index = parseInt(curr.addClass('act').attr('index'));
        History.pushState({ state: index, rand: Math.random() }, $(curr).text(), "?state=" + index);
    });

}