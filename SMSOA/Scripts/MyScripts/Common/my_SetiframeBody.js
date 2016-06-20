//页面加载时根据iframe的尺寸设置本Body的尺寸
function SetiframeHeight(id) {
    

    var div_str = "#" + id;
    //1 获取iframe的高度
    var my_iframes = window.parent.document.getElementsByTagName("iframe");
    if (my_iframes.length > 0) {
        var index = my_iframes.length - 1;
        var iframeHeight = my_iframes[index].clientHeight-5;
        var iframeWidth = my_iframes[index].clientWidth - 5;
        //2 设置当前body的高度为iframe的高度
        //$("#body").height = iframeHeight;
        //$("#body").width = iframeWidth;
        $(div_str).layout({
            height: iframeHeight,
            width: iframeWidth
        });
        //设置部门列表的高度
        //$("#p").height = iframeHeight;
    }
    else if (my_iframes.length == 0) {
        $("#body_layout").layout({
            height: 400,
            //width: iframeWidth
        });
    }

    
}