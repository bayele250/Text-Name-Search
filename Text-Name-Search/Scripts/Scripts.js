function jQueryAjaxPost(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        var ajaxConfig = {
            type: "POST",
            url: form.action,
            data: new FormData(form),
            success: function (response) {
                $("#nameTab").html(response);
                refreshAddNewTab($(form).attr('data-resetUrl',true))
            }
        }
        if ($(form).attr("enctype") == "multiport/form-data") {
            ajaxConfig["contentType"] = false;
            ajaxConfig["processData"] = false;
        }
        $.ajax(ajaxConfig);
    }
    return false;
}

function refreshAddNewTab(resetUrl, showViewTab) {
    ajax({
        type: 'GET',
        url: resetUrl,
        success: function (response) {
            $("#nameTab").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html("Add Name");
            if (showViewTab)
                $('ul.nav.nav-tabs a:eq(0)');
        }
    });
}