$(document).ready(function () {
    registerDropDownLists();
    registerResetButton();
    registerClickableRows();
});

function registerDropDownLists() {
    $("ul[class=dropdown-menu]").children("li").click(function () {
        var text = $(this).children("a").first().text();
        $(this).parents("div[class=input-group]").children("input").first().val(text);
        $("button[name=submit]").submit();
    });
}

function registerResetButton() {
    $("button[name=reset]").click(function () {
        $("input[type=text]").val("");
        $("button[name=submit]").submit();
    });
}

function registerClickableRows() {
    $(".cell-clickable").on("click", function () {
        var id = $(this).parents("tr").first().children("input[type=hidden]").first().prop("name");
        window.location = "/Staff/Details/" + id;
    });
}