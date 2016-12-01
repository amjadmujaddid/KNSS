$(function () {
    bindMenu();
});
function bindMenu() {
    var listMenu = [];
    $.ajax({
        url: "menu/getallmenu",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var menuHtml = '';
            $("#MainMenu").append(menuHtml);
            for (var i = 0; i < data.length; i++) {
                listMenu.push(data[i]);
                menuHtml = "<li><a  href='" + data[i].Url + "'><span>" + data[i].MenuName + "</span></li>";
                $("#MainMenu").append(menuHtml);
            }
            //  $.each(data, function (key, value{ <- this is wrong
            //$.each(data, function () {
            //    //$("#MainMenu").append("<li><a rel='external' href='" + data + "'><span>" + data + "</span></li>");
            //});
        }
    });

}