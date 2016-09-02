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
    var date_str = value.replace("T", " ");

    var date = new Date(date_str);
    //var str = date.getYear() + "/" + (date.getMonth() + 1) + +"/" + date.getDate() +" " + date.getHours + ":" + date.getMinutes;
    var str = date.toLocaleDateString("yyyy-MM-dd") + " " + date.getHours() + ":" + date.getMinutes();

    return str;
}