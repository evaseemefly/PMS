
function addRow(urlAdd) {
    //从指定页面中预读取数据
    $("#setActionRoleFrame").attr("src", urlAdd);
    //$("#editWindow").panel({ title: "创建任务模板" });
    //打开编辑窗体
    $("#editWindow").window('open');    

}

function editRow(urlEdit) {
    var rows = $("#datagrid").datagrid('getSelections');
    //若选中的行不为一行
    if (rows.length != 1) {
        //提示
        $.messager.show({
            title: '提示',
            msg: '请选择一行数据',
            showType: 'show'
        });
        return;
    }
    $("#editWindow").panel({ title: "编辑权限" });
    //若选中了一行数据则执行修改操作
    //获取选中列的某一行的值，由于选中的行是一个数组，需要取出第一个
    $("#setActionRoleFrame").attr("src", urlEdit + "?id=" + rows[0].ID);//会出现重定向的错误
    $("#editWindow").window('open');
    
}


function removeRow(urlDel) {
    var rows = $("#datagrid").datagrid('getSelections');
    //若选中的行不为一行
    if (rows.length < 1) {
        //提示
        $.messager.show({
            title: '提示',
            msg: '请至少选中一行数据',
            showType: 'show'
        });
        return;
    }
    //post请求至软删除方法
    if ($.messager.confirm("提示", "确定要删除吗？", function (r) {
        if (r) {
            var strId = "";
        for (var i = 0; i < rows.length; i++) {
                strId = strId + rows[i].ID + ",";
    }
        //去掉最后一个逗号
        strId = strId.substr(0, strId.length - 1);
        $.post(urlDel + "?ids=" + strId, function (data) {
        //请求成功后的回调函数
        if (data == "ok") {
        //重新加载datagrid
           $("#datagrid").datagrid('reload');
        //清楚所选中的行
        $("#datagrid").datagrid('clearSelections');
        $.messager.alert("提示", "删除成功");
    }
    });
    }
    }));

}


//从远程一次性获取下拉菜单中的json格式对象
function GetDropDowData(urlGetOption) {
    $.ajax({
        type: "get",
        url: urlGetOption,      // 这里是提交到什么地方的url

        //dataType: "json",
        success: function (res) {
            // 调用回调函数——将下拉列表data 赋值给data_Options
            data_Options = res;
            //若数组长度不为0，则将
            if (data_Options.length != 0) {
                $("#ParentActionOptions").combobox({
                    valueField: 'id',
                    textField: 'text',
                    data: data_Options
                });
            }
        }
    });
}

//编辑或创建某个权限后执行的操作
function afterEdit(msg) {
    //editWindow
    //1 关闭加载的iframe页面
    $.messager.alert('提示', msg);

    $("#editWindow").window('close');
    //2 刷新当前页面
    $("#datagrid").datagrid('reload');
}