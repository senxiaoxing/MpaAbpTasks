(function () {
    $(function () {

        var _movieService = abp.services.app.movieTicket;
        var _$modal = $('#MovieTicketCreateModal');
        var _$form = _$modal.find('form[name="movieCreateForm"]');

        _$form.validate({
            rules: {
                MovieName:
                {
                    required:true
                },
                StartTime: "required",
                EndtTime:
                {
                    required: true
                },
                MovieActor: "required"
                ,Money:"required"
            },
            messages: {
                MovieName: {
                    required:"电影名称不能为空"
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

        var dateOption = {
            locale: {

                format: 'YYYY-MM-DD HH:mm:ss',
                applyLabel: '确认',
                cancelLabel: '取消'

            },
            singleDatePicker: true,
            startDate: moment().format("YYYY-MM-DD HH:mm:ss"),
            timePicker24Hour: true,
            timePicker: true,
            autoApply: true,
            autoUpdateInput: true
        };
        $('input[name=StartTime]').daterangepicker(dateOption);
        $('input[name=EndTime]').daterangepicker(dateOption);
        $('#RefreshButton').click(function () {
            refreshMovieList();
        });
      
        $('.delete-movie').click(function () {
            var movieId = $(this).attr("data-movie-id");
            var movieName = $(this).attr("data-movie-name");
            abp.message.confirm(
                "删除电影 '" + movieName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _movieService.deleteMovie({
                            "id": movieId, "movieName": movieName,
                        }).done(function () {
                            refreshMovieList();
                        });
                    }
                }
            );
        });

        $('.edit-movie').click(function (e) {
            var movieId = $(this).attr("data-movie-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'MovieTicket/EditMovieTicketModal?movieId=' + movieId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#MovieTicketEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var movie = _$form.serializeFormToObject(); 
            abp.ui.setBusy(_$modal);
            _movieService.createMovie(movie).done(function (response) {
                if (response == "No") {
                    abp.message.error("创建失败");
                }
                else {
                    _$modal.modal('hide');
                    location.reload(true); 
                }
               
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshMovieList() {
            location.reload(true); //reload page to see new user!
        }

        function deleteUser(userId, userName) {
           
        }
        var CONSTANT = {
            DATA_TABLES: {
                DEFAULT_OPTION: { //DataTables初始化选项  
                    language: {
                        "sProcessing": "处理中...",
                        "sLengthMenu": "每页 _MENU_ 项",
                        "sZeroRecords": "没有匹配结果",
                        "sInfo": "当前显示第 _START_ 至 _END_ 项，共 _TOTAL_ 项。",
                        "sInfoEmpty": "当前显示第 0 至 0 项，共 0 项",
                        "sInfoFiltered": "(由 _MAX_ 项结果过滤)",
                        "sInfoPostFix": "",
                        "sSearch": "搜索:",
                        "sUrl": "",
                        "sEmptyTable": "表中数据为空",
                        "sLoadingRecords": "载入中...",
                        "sInfoThousands": ",",
                        "oPaginate": {
                            "sFirst": "首页",
                            "sPrevious": "上页",
                            "sNext": "下页",
                            "sLast": "末页",
                            "sJump": "跳转"
                        },
                        "oAria": {
                            "sSortAscending": ": 以升序排列此列",
                            "sSortDescending": ": 以降序排列此列"
                        }
                    },
                    autoWidth: false,   //禁用自动调整列宽  
                    stripeClasses: ["odd", "even"],//为奇偶行加上样式，兼容不支持CSS伪类的场合  
                    order: [],          //取消默认排序查询,否则复选框一列会出现小箭头  
                    processing: false,  //隐藏加载提示,自行处理  
                    serverSide: true,   //启用服务器端分页  
                    searching: false    //禁用原生搜索  
                },
                COLUMN: {
                    CHECKBOX: { //复选框单元格  
                        className: "td-checkbox",
                        orderable: false,
                        width: "30px",
                        data: null,
                        render: function (data, type, row, meta) {
                            return '<input type="checkbox" class="iCheck">';
                        }
                    }
                },
                RENDER: {   //常用render可以抽取出来，如日期时间、头像等  
                    ELLIPSIS: function (data, type, row, meta) {
                        data = data || "";
                        return '<span title="' + data + '">' + data + '</span>';
                    }
                }
            }
        };  
        var getQueryCondition=function(data) {  
            var param = {};  
            //组装排序参数  
            if (data.order && data.order.length && data.order[0]) {
                switch (data.order[0].column) {
                    case 1:
                        param.sorting = "MovieName";//数据库列名称
                        break;
                    case 2:
                        param.sorting = "MovieActor";//数据库列名称
                        break;
                    case 3:
                        param.sorting = "StartTime";//数据库列名称
                        break;
                    case 4:
                        param.sorting = "EndTime";//数据库列名称
                        break;
                    case 5:
                        param.sorting = "Money";//数据库列名称
                        break;
                    default:
                        param.sorting = "MovieName";//数据库列名称
                        break;
                }
                //排序方式asc或者desc
                param.orderDir = data.order[0].dir;
            }
            //组装分页参数  
            param.sorting = "StartTime";//数据库列名称
            param.start = data.start;
            param.length = data.length;
            param.draw = data.draw;
            return param;  
        }
        var page = {
            $table: $("#MovieTable"),
            $dataTable: null,
        
            initDataPicker: function () {
                var dataOption = {
                    startDate: moment().startOf("month"),
                    "maxDate": null,
                    singleDatePicker: true
                };
                var dataOption1 = {
                    startDate: moment().endOf("month"),
                    "maxDate": null,
                    singleDatePicker: true
                };
                $("input[name=StartTime]").WIMIDaterangepicker(dataOption);
                $("input[name=EndTime]").WIMIDaterangepicker(dataOption1);
            },
            initTable: function () {
                if (!$.fn.DataTable.isDataTable("#MovieTable")) {
                    page.$datatable = page.$table.DataTable($.extend(true, {}, CONSTANT.DATA_TABLES.DEFAULT_OPTION, {
                        ajax: function (data, callback, settings) {
                            //封装请求参数  
                            var param = getQueryCondition(data);

                            $.ajax({
                                type: "GET",
                                url: "/api/services/app/" + "movieTicket/getAllMovieTicketPage",
                                cache: false,  //禁用缓存  
                                data: param,    //传入已封装的参数  
                                dataType: "json",
                                success: function (response) {
                                    //封装返回数据  
                                    var returnData = {};
                                    returnData.draw = response.result.draw;//这里直接自行返回了draw计数器,应该由后台返回  
                                    returnData.recordsTotal = response.result.recordsFiltered;//总记录数  
                                    returnData.recordsFiltered = response.result.recordsFiltered;//后台不实现过滤功能，每次查询均视作全部结果  
                                    returnData.data = response.result.items;
                                    //调用DataTables提供的callback方法，代表数据已封装完成并传回DataTables进行渲染  
                                    //此时的数据需确保正确无误，异常判断应在执行此回调前自行处理完毕  
                                    callback(returnData);
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    alert("查询失败");
                                }
                            });
                        },
                        "paging": true,
                        //绑定数据  
                        "columns": [
                            {
                                "defaultContent": "",
                                "title": "操作",
                                "orderable": false,
                                "width": "150px",
                                "className": "text-center not-mobile",
                                "createdCell": function (td, cellData, rowData, row, col) {
                                    var $actionContent = $("<div class='action-content'>");
                                    $('<button class="btn  btn-xs" data-toggle="modal" data-target="#MovieTicketEditModal">修改</button>')
                                        .appendTo($actionContent)
                                        .click(function () {
                                            var movieId = rowData.id;
                                            $.ajax({
                                                url: abp.appPath + 'MovieTicket/EditMovieTicketModal?movieId=' + movieId,
                                                type: 'POST',
                                                contentType: 'application/html',
                                                success: function (content) {
                                                    $('#MovieTicketEditModal div.modal-content').html(content);
                                                },
                                                error: function (e) { }
                                            });
                                        });
                                    $('<button class="btn  btn-xs"> 删除 </button>')
                                        .appendTo($actionContent)
                                        .click(function () {
                                            var movieId = rowData.id;
                                            var movieName = rowData.movieName;
                                            abp.message.confirm(
                                                "删除电影 《" + movieName + "》？",
                                                function (isConfirmed) {
                                                    if (isConfirmed) {
                                                        _movieService.deleteMovie({
                                                            "id": movieId
                                                        }).done(function () {
                                                            refreshMovieList();
                                                        });
                                                    }
                                                }
                                            );
                                        });
                                    $(td).append($actionContent);
                               }
                            },
                            {
                                "data": "movieName",
                                "title": "电影名称"
                            },
                            {
                                "data": "movieActor",
                                "title": "演员名称",
                                "width": "120px",
                            },
                            {
                                "data": "startTime",
                                "title": "开始时间",
                                "render": function (data, type, full, meta) {
                                    return moment(data).format("YYYY-MM-DD HH:mm:ss");
                                }
                            },
                            {
                                "data": "endTime",
                                "title": "结束时间",
                                "render": function (data, type, full, meta) {
                                    return moment(data).format("YYYY-MM-DD HH:mm:ss");
                                }

                            },
                            {
                                "data": "money",
                                "title": "票价",
                            }
                        ],     
                    }));//此处需调用api()方法,否则返回的是JQuery对象而不是DataTables的API对象 
               
                } else {

                    page.$datatable.ajax.reload();
                }
            },
            init: function () {
                page.initTable();
            }
        }
        page.init();
       
    });
})();