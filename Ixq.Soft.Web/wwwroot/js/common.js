var ixq = {};

/*jqgrid*/
(function(ixq) {

    ixq.jqGrid = {};

    var format = {
        optionsFormat: function(cellvalue, options, rowObject) {
            return '<i onclick="editApplicationUser(\'' +
                rowObject.id +
                '\')" class="fa fa-fw fa-edit" title="编辑"></i>' +
                '<i onclick="removeApplicationUser(\'' +
                rowObject.id +
                '\')" class="fa fa-fw fa-remove" title="删除"></i>';
        },
        sexFormat: function(cellvalue, options, rowObject) {
            return cellvalue ? '男' : '女';
        },
        yesNoFormat: function(cellvalue, options, rowObject) {
            return cellvalue ? '是' : '否';
        }
    };
    ixq.jqGrid.format = format;
})(ixq)