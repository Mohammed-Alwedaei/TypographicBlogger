$(document).ready(function () {
    var date;
    var dateTime;

    setInterval(function () {
        date = new Date;
        dateTime = date.toLocaleString();

        $("#dateTime").text("Current Time is " + dateTime);
    }, 1000);

    $("#toggle-vertical-nav").click(function() {
        $(".toggle-nav-item__visibility").toggle();
        $("#vertical-nav").toggleClass("collapsed-vertical-nav");
        $("#main-content").toggleClass("collapsed-nav__scale-comps");
        $("#horizontal-nav").toggleClass("collapsed-nav__scale-comps");
    });
});