var ixq = {};

/*jqgrid*/
(function(ixq) {

    ixq.jqGrid = {};

    var format = {
        optionsFormat: function(cellvalue, options, rowObject) {
            return '<i onclick="alert(' +
                rowObject.id +
                ')" class="fa fa-fw fa-edit" title="编辑"></i>' +
                '<i class="fa fa-fw fa-remove" title="删除"></i>';
        },
        sexFormat: function(cellvalue, options, rowObject) {
            return "";
        },
        yesNoFormat: function(cellvalue, options, rowObject) {
            return "";
        } 
    };
    ixq.jqGrid.format = format;

})(ixq)