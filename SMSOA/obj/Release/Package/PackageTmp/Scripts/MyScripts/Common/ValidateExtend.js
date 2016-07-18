//扩展easyui表单的验证
$.extend($.fn.validatebox.defaults.rules, {
    //验证是否是汉字
    CHS: {
        validator: function (value) {
            return /^[\u0391-\uFFE5]+$/.test(value);
        },
        message: '请输入中文'
    },
    //验证是否是合法的移动手机号码
    Mobile: {
        validator: function (value) {
            var reg = /^1[3|4|5|8|9]\d{9}$/;
            return reg.test(value);
        },
        message: '请输入合法的手机号码'
    },

    //验证是否是合法字符
    String: {
        validator: function (value) {
            return /^[a-zA-Z0-9-\u0391-\uFFE5]+$/.test(value);
        },
        message:'不允许包含特殊符号'
    },
    //验证两次密码是否输入一致
    Equals: {
        validator: function (value, param) {
            return value == $(param[0]).val();
        },
        message: '两次密码输入不一致'
    }

})