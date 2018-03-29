// Will perform some action when the mouse hovers over the div
//$("div").mouseover

// Will perform some action when the mouse hover over any IDs named "div_main"
// The '#' character is used to access the ID of an HTML element
// $("#div_main").mouseover()

// Will perform some action when the mouse hover over any html elements with the class "div_class"
// The '.' character is used to acces the class of an HTML element
// $(".div_class").mouseover();

$(function () {
    // clicking on hide button will hide paragraphs with the class "hide_content"
    $("#hide_btn").click(function () {
        $(".hide_content").hide();
    });

    $("#show_btn").click(function () {
        $(".hide_content").show();
    });

    $("#red_btn").click(function () {
        $("#mainJQ").children("p").toggleClass("red important")
        $("#mainJQ").find("a").css({ "color": "purple" });
    });
})




