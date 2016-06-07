var down = {
    suggDown: {
        '投诉': 1,
        '建议': 2
    }

}

$(function () {
    $('select[down]').each(function (index, item) {
        var dn = $(item).attr('down');
        if (typeof down[dn] == "object") {
            for (var key in down[dn]) {
                $(item).append($('<option value=' + down[dn][key] + '>' + key + '</option>'));
            }
          
        }

    })

})