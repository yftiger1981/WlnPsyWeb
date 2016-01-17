$.ajaxjson = function (url, dataMap, fnSuccess) {
    $.ajax({
        type: "POST",
        url: url,
        data: dataMap,
        dataType: "json",
        cache: false,
        beforeSend: function () { top.$.hLoading.show(); },
        complete: function () {
            try {
                closeDialog();
            } catch (e) { }
            top.$.hLoading.hide();
        },
        success: fnSuccess
    });
}
$.ajaxtext = function (url, dataMap, fnSuccess) {
    $.ajax({
        type: "POST",
        url: url,
        data: dataMap,
        cache: false,
        beforeSend: function () { top.$.hLoading.show(); },
        complete: function () { top.$.hLoading.hide(); },
        success: fnSuccess
    });
}

function MessageOrRedirect(d) {
    if (d) {
        if (d.Data == "-99")
            top.$.hLoading.show({
                type: 'hits',
                msg: d.Message,
                onAfterHide: function () {
                    top.login();
                },
                timeout: 1000
            });

        else {
            alert(d.Message);
        }
    }
}