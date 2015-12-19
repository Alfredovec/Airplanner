$(document).ready(function() {
    registerDropDownLists();
    registerResetButton();
    registerDropDownSteward();
    //$("button[name=submit]").submit();
});

$(document).on("click", ".cell-clickable", function() {
    var id = $(this).parents("tr").first().children("input[type=hidden]").first().prop("name");
    window.location = "/Flight/Details/" + id;
});

$(document).on("change", ".steward", registerDropDownSteward);

function registerDropDownLists() {
    $("ul[class=dropdown-menu]").children("li").click(function () {
        var text = $(this).children("a").first().text();
        $(this).parents("div[class=input-group]").children("input").first().val(text);
        $("button[name=submit]").submit();
    });
}

function registerResetButton() {
    $("button[name=reset]").click(function() {
        $("input[type=text]").val("");
        $("input[type=number]").val("");
        $("button[name=submit]").submit();
    });
}

function registerDropDownSteward() {
    var stewards = [];
    $(".steward").each(function () {
        if ($(this).val() !== "")
            stewards.push($(this).val());
    });
    $(".steward").children("option").each(function () {
        if ($.inArray($(this).val(), stewards) > -1)
            $(this).addClass("hidden");
        else
            $(this).removeClass("hidden");
    });
}

$(document).on("change paste keyup", "#numfield", function() {
    $("button[name=submit]").submit();
});


