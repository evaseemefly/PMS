//根据pid加载对应的群组并添加至combobox中
function my_loadCombobox_Group(id, url,groupColumns, func_loadSuccess, func_onUnSelect) {
    var div_id = "#" + id;
    $(div_id).combogrid({
        url: url,
        method: 'get',
        idField: 'GID',
        textField: 'GroupName',
        panelWidth: 350,
        width: 210,
        panelHeight: 200,
        multiple: true,
        checkOnSelect: true,
        selectOncheck:true,
        //singleSelect:false,
        //nowrap: true,
        columns: groupColumns,
        //获取数据成功后启动事件
        onLoadSuccess: func_loadSuccess,
        //6月13日
        onUnselect: function (rowIndex, rowData) {
            //点击每一行时判断该行是否有禁止删除的标记
            if (rowData.forbidDel) {
                //若点击的这一行有禁止删除的标记
                //则点击后仍为该行设置为选中，并提示
                $(div_id).combogrid("grid").datagrid("selectRow", rowIndex);
                //7月6日 修改存在bug 若点击的是前面的checkbox，则会出现全部联系人 扔为选中，但checkbox为未选中状态，此时需要手动再为其checkbox设置为选中状态
                $(div_id).combogrid("grid").datagrid('checkRow', rowIndex);
                //$(div_id).combogrid('checkRow', rowIndex);
                //rowData.Checked = true;
                //rowData.Selected = true;
                //rowData.selected = true;
                //收起下拉框
                $(div_id).combogrid('hidePanel');
                messagerShowOnCenter("提示", "全部联系人必须选中");
            }
        }
    })
}

//1.1 加载全部部门下拉框
function my_loadComboTree_Department(id, url, func_loadSuccess) {//2 加载上级部门下拉框
    var div_id = "#" + id;
    $(div_id).combotree({
        //在ContactPerson控制器中的ShowAddPerson方法中添加
        url: url,
        valueField: 'id',   //注意此处只能设置为id以及text，否则不识别
        textField: 'text',
        //valueField: "DID",
        //textField: "DepartmentName",
        editable: false,
        onlyLeafCheck: true,
        cascaseCheck: true,
        method: 'get',
        panelHeight: 150,
        panelWidth: 250,
        width: 210,
        onLoadSuccess: func_loadSuccess
        });
}


function my_loadSuccess_Group(id,isChecked,gid) {
    ///	<summary>
    ///	ComboDataGrid加载成功后执行（Group）
    ///	</summary>
    ///	<param name="id" type="string">
    ///		id选择器要选择的id
    ///	</param>
    ///	<param name="isChecked" type="bool">
    ///		是否要检查checked标记
    ///	</param>
    ///	<param name="gid" type="Array">
    ///		选中的群组id数组
    ///	</param>
    var div_id = "#" + id;
    var data = $(div_id).combogrid("grid").datagrid("getData");
    var rowData = data.rows;
    $.each(rowData, function (rowIndex, rowData) {
        if (isChecked) {
            if (rowData.checked) {
                $(div_id).combogrid("grid").datagrid("selectRow", rowIndex);
            }
        }
        else if (!isChecked) {
            if (gid != null) {
                if (gid.length > 1) {
                    if (gid.indexOf(rowData.GID.toString()) > -1) {
                        $(div_id).combogrid("grid").datagrid("selectRow", rowIndex);
                    }
                }
                else {
                    if (rowData.GID == gid) {
                        $(div_id).combogrid("grid").datagrid("selectRow", rowIndex);
                    }
                }

            }
        }

        //6月13日
        //找到禁止删除标记的对象
        if (rowData.forbidDel) {
            //将该行设置为选中
            if (!rowData.checked) {
                $(div_id).combogrid("grid").datagrid("selectRow", rowIndex);
            }
        }
    });
}