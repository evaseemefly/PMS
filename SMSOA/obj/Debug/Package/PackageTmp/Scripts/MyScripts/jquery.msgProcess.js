(function ($) {
	$.extend($, {
		procAjaxData: function (data, funcSuc, funcErr) {
            //判断传入的数据是否存在状态
			if (!data.Statu)
			{
				return;
			}
			switch(data.Statu)
			{
				case "ok":
					alert("OK;" + data.Msg);
					//若ok 则执行成功的回调函数
					if (funcSuc) funcSuc(data);
					break;
				case "err":
					alert("ERR;" + data.Msg);
					if (funcErr) funcErr(data);
					break;
			    case "nologin":
			        alert(data.Msg);
			        window.location = data.BackUrl;
			        break;
			}
			//alert("我是扩展方法" + data);
		}

	})
}(jQuery));