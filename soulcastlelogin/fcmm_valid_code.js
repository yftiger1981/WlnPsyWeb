function getFcmmValidCode(imgId, codeId, url, appId) {
	$.ajax( {
		url : url,
		type : "get",
		asysc : false,
		dataType : 'jsonp',
		jsonp : 'callback',
		data :{appId : appId},
		success : function(data) {
			$("#" + imgId).attr("src", data.img);
			$("#" + codeId).attr("name", "validCodeId");
			$("#" + codeId).attr("value", data.id);
		}
	});
}

function checkValidCode(validCode, codeId, url) {
	$.ajax( {
		url : url,
		type : "get",
		asysc : false,
		data : {validCode :validCode, codeId : codeId},
		dataType : 'jsonp',
		jsonp : 'callback',
		success : function(data) {
			alert(data.status)
		}
	});
}
