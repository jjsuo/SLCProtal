
$(function () {
    HistoryInit();
    MenuControll();
});

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
        if (!curr.attr('url')) {
            return;
        }
        curr.parents('ul').find('.act').removeClass('act');
        curr.parent().addClass('act');
        var index = parseInt(curr.addClass('act').attr('index'));

        History.pushState({ state: index, rand: Math.random() }, $(curr).text(), "?state=" + index);
    });
    var state = common.GetRequest().state;
    if (state) {
        $(".usrBd .usrSidMenu a[index=" + state + "]").trigger('click');
    }


}