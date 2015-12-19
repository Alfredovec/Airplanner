$(document).ready(function () {
    registerNavigation();
    registerDeleteCOnfirm();
});

function registerNavigation() {
    var controller = $("title").text();
    $("#navigation li a").each(function () {
        if (controller === $(this).text()) {
            $(this).addClass("active");
        } else {
            $(this).removeClass("active");
        }
    });
    $(".account a div").each(function () {
        if (controller === $(this).text()) {
            $(this).parents("a").first().addClass("active");
        } else {
            $(this).parents("a").first().removeClass("active");
        }
    });
}