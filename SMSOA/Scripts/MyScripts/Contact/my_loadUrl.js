//根据pid加载对应的群组并添加至combobox中
function my_loadCombobox_Group(id, url,groupColumns, func_loadSuccess, func_onUnSelect) {
    var div_id = "#" + id;
    $(div_id).combogrid({
        url: url,
        method: 'get',
        idField: 'GID',
        textField: 'GroupName',
        panelWidth: 350,
        panelHeight: 400,
        multiple: true,
        //singleSelect:false,
        //nowrap: true,
        columns: groupColumns,
        //获取数据成功后启动事件
        onLoadSuccess: func_loadSuccess,
        //6月13日
        onUnselect: func_onUnSelect
    })
}