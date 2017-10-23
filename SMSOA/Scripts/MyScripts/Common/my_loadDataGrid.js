﻿/// <reference path="D:\02编程\2016年\01协同开发\PMS\newPMS\PMS\SMSOA\Areas/News/Views/Home/_Partial_News_SystemMessages.cshtml" />
function load_datagrid(id, url, myColumns, myToolbar_id, isSingle, pagination, pageSize, pageList) {
    //2 根据GroupID查询该群组所拥有的人员列表
    $("#" + id).datagrid({
        width: 'auto',
        height: 'auto',
        fitColumns: true,
        striped: true,
        singleSelect: isSingle,     //单选
        //fit: true,
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

//手动清除指定datagird中的全部行数据
function clearDataGrid(id) {
    $("#" + id).datagrid('loadData', { total: 0, rows: [] });
}