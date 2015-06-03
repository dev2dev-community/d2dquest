var registerWordAjaxHandler = (function ($) {
    return function (data) {
        $(".information").html(data.Message);
        $("#UserUid").val(data.UserUid);
        $("#Word").val(data.Word);
    };
})($);