function SetValCheckBySwitchBtn(id, temp) {
    ///	<summary>
    ///	为Switch按钮根据传入的temp设置value以及选中状态
    ///
    ///	</summary>
    ///	<param name="id" type="string">
    ///		id选择器要选择的id
    ///	</param>
    ///	<param name="temp" type="string">
    ///		由后台传过来的true（注意此时为'True'，而非Bool类型
    ///	</param>

    var isShow;
    var id_str = "#" + id;
    //1 判断传入的temp是否为True，若为true则为isShow赋true
    temp == 'True' ? isShow = true : isShow = false;


    //2.1 若展示标记为true则为switch按钮的checked赋为选中
    if (isShow == true) {
        $(id_str).switchbutton({
            checked: isShow
        });

    }
    //2.2 位switch按钮的value赋为选中状态（bool）
    $(id_str).switchbutton({
        value: isShow
    });
}

//为Switch按钮绑定切换为value属性赋值的事件
function SwitchButtonBindSetValue(id) {
    ///	<summary>
    ///	为Switch按钮绑定切换为value属性赋值的事件
    ///
    ///	</summary>
    ///	<param name="id" type="string">
    ///		id选择器要选择的id
    ///	</param>

    var str = "#" + id;
    $(str).switchbutton({
        onChange: function (checked) {
            $(str).switchbutton({
                value: checked
            });
        }
    });
}