function DoSubmit(id, url) {
    ///	<summary>
    ///	执行提交操作
    ///
    ///	</summary>
    ///	<param name="id" type="string">
    ///		id选择器要选择的id
    ///	</param>
    ///	<param name="url" type="string">
    ///		要提交到的url地址
    ///	</param>
    var myform = $("#"+id);
    var options = {
        url: url,
        type: 'post',
        success: function (data) {
            afterEdit(data);
        }
    };

    myform.form('submit', options);
}

function afterEdit(data) {

    //$.messager.alert('提醒', '提交成功!');
    //——经测试提交表单成功后可以执行OnSucess的回调函数
    //提交表单成功后关闭本页面
    //无法关闭此窗口
    //window.close();
    if (data == "ok") {
        window.parent.afterEdit("修改成功");
    }
    else {
        window.parent.afterEdit("修改失败");
    }
    //此处也可以调用window.parent.xxx——当前页面的父级页面中的xxx方法
}