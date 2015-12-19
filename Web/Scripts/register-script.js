$(document).ready(registerCorpass);

$(document).on("change", registerCorpass);

function registerCorpass() {
    if ($("select[name=role]").val() === "Admin" || $("select[name=role]").val() === "Dispecher") {
            $(".corpass").removeClass("hidden");
        } else {
            $(".corpass").addClass("hidden");
        }
}