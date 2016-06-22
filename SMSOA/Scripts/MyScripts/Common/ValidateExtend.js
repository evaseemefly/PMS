//扩展easyui表单的验证
$.extend($.fn.validatebox.defaults.rules, {
    //验证汉字
    CHS: {
        validator: function (value) {
            return /^[\u0391-\uFFE5]+$/.test(value);
        },
        message: 'The input Chinese characters only.'
    },
    //移动手机号码验证
    Mobile: {//value值为文本框中的值
        validator: function (value) {
            var reg = /^1[3|4|5|8|9]\d{9}$/;
            return reg.test(value);
        },
        message: 'Please enter your mobile phone number correct.'
    },
    //国内邮编验证
    ZipCode: {
        validator: function (value) {
            var reg = /^[0-9]\d{5}$/;
            return reg.test(value);
        },
        message: 'The zip code must be 6 digits and 0 began.'
    },
    //数字
    Number: {
        validator: function (value) {
            var reg = /^[0-9]*$/;
            return reg.test(value);
        },
        message: 'Please input number.'
    },
})