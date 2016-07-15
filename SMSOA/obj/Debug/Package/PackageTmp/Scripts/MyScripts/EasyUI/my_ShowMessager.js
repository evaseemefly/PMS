function messagerAlertByAlert(title,msg) {
    $.messager.alert(title, msg);
}

//弹出确认按钮
function messagerConfirm(title,msg,func) {
    $.messager.confirm(title, msg, function (r) {
        if (r) {
            func();
            //return true;
        }
        else {
            return false;
        }

    });
}

//使用此种方式消息框还未显示页面就已经刷新了
function messagerShowOnCenter(title, msg) {
    ///	<summary>
    ///	在右下角弹出消息框
    ///
    ///	</summary>
    ///	<returns type="" />
    ///	<param name="title" type="string">
    ///		标题
    ///	</param>
    ///	<param name="msg" type="string">
    ///		消息内容
    ///	</param>
    $.messager.show({
        title: title,
        msg: msg,
        showType: 'show',
        style: {
            right: '',
            bottom: ''
        }

    });
}

function messagerShowOnCorner(title, msg) {
    ///	<summary>
    ///	在右下角弹出消息框
    ///
    ///	</summary>
    ///	<returns type="" />
    ///	<param name="title" type="string">
    ///		标题
    ///	</param>
    ///	<param name="msg" type="string">
    ///		消息内容
    ///	</param>
    $.messager.show({
        title: title,
        msg: msg,
        showType: 'show'
    })
}