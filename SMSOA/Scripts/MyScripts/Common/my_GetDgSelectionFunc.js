//选择唯一的行并执行相应的操作
function CheckOnlySelectionAndDo(id_dg,title_confirm,content_succeed,attr_str,url,param_url) {
   // var div_str=
    var rows = $("#"+id_dg).datagrid('getSelections');
    //若选中的行不为一行
    if (rows.length != 1) {
        //提示
        $.messager.show({
            title: '提示',
            msg: '请选择唯一一行',
            showType: 'show'
        });
        return;
    }
    //post请求至软删除方法
    if ($.messager.confirm("提示", title_confirm, function (r) {
        if (r) {
            var strId = "";
        for (var i = 0; i < rows.length; i++) {
                strId = strId + rows[i][attr_str] + ",";
    }
        //去掉最后一个逗号
        strId = strId.substr(0, strId.length - 1);
        $.post(url + "?" + param_url + "=" + strId, function (data) {
        //请求成功后的回调函数
        if (data == "ok") {
        //重新加载datagrid
           $("#" + id_dg).datagrid('reload');
        //清楚所选中的行
        $("#" + id_dg).datagrid('clearSelections');
        $.messager.alert("提示", content_succeed);
    }
    });
    }
    }));

}