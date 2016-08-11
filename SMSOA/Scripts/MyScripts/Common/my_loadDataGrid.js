function load_datagrid(id, url, myColumns, myToolbar_id, isSingle, pagination, pageSize, pageList) {
    //2 根据GroupID查询该群组所拥有的人员列表
    $("#" + id).datagrid({
        fitColumns: true,
        striped: true,
        singleSelect: isSingle,     //单选
        fit: true,
        url: url,
        showHeader: true,
        autoRowHeight: true,
        nowrap: false,//自动换行
        loadMsg: '加载中……',
        pagination: pagination,//启用分页，默认每页10行
        rownumbers: true,//显示页码，默认 提供 10 - 50 的页容量选择下拉框
        pageSize: pageSize,   //设置 页容量为 5
        pageList: pageList,//设置 页容量下拉框
        columns: myColumns,
        toolbar: '#' + myToolbar_id,
        //toolbar: myPersonToolbar,
    });
}