$(document).ready(function() {
    SetTime("DepartureTime");
    SetTime("ArrivalTime");
});

function SetTime(element) {
    var datetime = $("#" + element).attr("timetext");
    var datetimearray = datetime.split(" ");
    var date = datetimearray[0];
    var time = datetimearray[1];
    var datearray = date.split("/");
    var timearray = time.split(":");
    var result = datearray[2] + "-" + datearray[0] + "-" + datearray[1] + "T" + timearray[0] + ":" + timearray[1] + ":00";
    $("#" + element).attr("value", result);
}