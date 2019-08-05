(function ($) {

    var _movieTicketService = abp.services.app.movieTicket;
    var _$modal = $('#MovieTicketEditModal');
    var _$form = $('form[name=MovieEditForm]');

    _$form.validate({
        rules: {
            MovieName:
            {
                required: true
            },
            StartTime: "required",
            EndtTime:
            {
                required: true
            },
            MovieActor: "required"
            , Money: "required"
        },
        messages: {
            MovieName: {
                required: "电影名称不能为空"
            },
            MovieActor: {
                required: "演员名称不能为空"
            },
            StartTime: {
                required: "开始时间不能为空"
            },
            EndTime: {
                required: "结束时间不能为空"
            },
            Money: {
                required: "票价不能为空"
            }
        }
    });
    
    var dateOption1 = {
        locale: {

            format: 'YYYY-MM-DD HH:mm:ss',
            applyLabel: '确认',
            cancelLabel: '取消'

        },
        singleDatePicker: true,
        startDate: moment($("input[name=StartTime]").eq(1).val(), "YYYY-MM-DD HH:mm:ss"),
        maxDate: moment($("input[name=EndTime]").eq(1).val(), "YYYY-MM-DD HH:mm:ss"),
        timePicker24Hour: true,
        timePicker: true,
        autoApply: true,
        autoUpdateInput: true
    };
    var dateOption2 = {
        locale: {

            format: 'YYYY-MM-DD HH:mm:ss',
            applyLabel: '确认',
            cancelLabel: '取消'

        },
        singleDatePicker: true,
        startDate: moment($("input[name=EndTime]").eq(1).val(), "YYYY-MM-DD HH:mm:ss"),
        minDate: moment($("input[name=StartTime]").eq(1).val(), "YYYY-MM-DD HH:mm:ss"),
        timePicker24Hour: true,
        timePicker: true,
        autoApply: true,
        autoUpdateInput: true
    };
    $('input[name=StartTime]').daterangepicker(dateOption1);
    $('input[name=EndTime]').daterangepicker(dateOption2);

    function save() {

        if (!_$form.valid()) {
            return;
        }

        var movie = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

        abp.ui.setBusy(_$form);
        _movieTicketService.updateMovie(movie).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page to see edited user!
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    }

    //Handle save button click
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    //Handle enter key
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    $.AdminBSB.input.activate(_$form);

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);