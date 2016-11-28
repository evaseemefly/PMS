Date.getStrOfDate= function(value) {
    ///	<summary>
    ///	将时间转成yyyy/MM/dd HH:mm
    ///
    ///	</summary>
    ///	<param name="value" type="string">
    ///		传入的date string
    ///	</param>
        //var re = /-?\d+/;
        //var m = re.exec(value);
        //var d = new Date(parseInt(m[0]));
        //// 按【2012-02-13 09:09:09】的格式返回日期
    //var date_format= d.format("yyyy-MM-dd hh:mm:ss");

    //注意此时的value为2016-06-05T16:10:04.13需要去掉T
    //使用正则表达式的预定义类匹配所有非数字字符
    var reg = /\D/;
    //var date_array = value.replace("T", " ").replace(/-/g," ").replace(/:/," ").split(" ");
    //从第几个元素开始就不要了，最后一个下标就是多少
    var date_str_array = value.split(reg).slice(0, 6);
    //转换为数字
    var date_int_array = date_str_array.map(function (data) {
        return parseInt(data);
    })
    //特别注意：这里的数组要为Int类型,否则就会变成Invalid date
    var date = new Date(date_int_array[0],date_int_array[1]-1,date_int_array[2],date_int_array[3],date_int_array[4],date_int_array[5]);

    var str = date.toLocaleString();
    //var str = date.getYear() + "/" + (date.getMonth() + 1) + +"/" + date.getDate() +" " + date.getHours + ":" + date.getMinutes;
    //var str = date.toLocaleDateString("yyyy-MM-dd") + "  " + date.getHours() + ":" + date.getMinutes()+":"+ date.getSeconds();

    return str;
}