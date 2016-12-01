$(function () {
    $('#grdGroup').jqGrid({
        url: "grouplist",
        datatype: "json",
        contentType: "application/json; charset-utf-8",
        mtype: 'GET',
        colNames: ["Group Id", "Group Name"],
        colModel: [
            {
                label: 'GroupId',
                name: 'GroupId',
                width: 20,
                key: true
            },
            {
                label: 'GroupName',
                name: 'GroupName',
                width: 50
            }
        ],
        loadonce: true,
        rowNum: 10,
        multiselect: true,
        width: 1080,
        pager: "#ctrlGrdGroup",
        sortname: 'id',
        sortorder: 'asc',
        recreateFilter: true

    });

    // textboxt on change
    $("#txtSearchGroup").on('change keyup paste', function () {
        filterTextBox();
        showProgress();
    });
    // combobox on change
    $("#cboGroup").on('change keyup paste', function () {
        filterCombobox();
    });


    hideLoading();
    bindComboBox();

});
function filterCombobox() {
    //  value filternya
    var searchString = $("#cboGroup").val();

    //  Prepare to pass a new search filter to our jqGrid
    var f = { groupOp: "AND", rules: [] };

    //  searching groupname
    f.rules.push({
        field: "GroupId", op: "cn", data: searchString
    });
    var grid = $('#grdGroup');
    grid[0].p.search = f.rules.length > 0;
    $.extend(grid[0].p.postData, { filters: JSON.stringify(f) });
    grid.trigger("reloadGrid", [{ page: 1 }]);
}
function filterTextBox() {
    //  value filternya
    var searchString = $("#txtSearchGroup").val();

    //  Prepare to pass a new search filter to our jqGrid
    var f = { groupOp: "AND", rules: [] };

    //  searching groupname
    f.rules.push({
        field: "GroupId", op: "cn", data: searchString
    });
    var grid = $('#grdGroup');
    grid[0].p.search = f.rules.length > 0;
    $.extend(grid[0].p.postData, { filters: JSON.stringify(f) });
    grid.trigger("reloadGrid", [{ page: 1 }]);
}
function bindComboBox()
{
    var listStatus = [];
    $.ajax({
        url: "cbogroup",
        dataType: "json",
        type: "GET",
        success: function (res) {
            var optHTML = '<option value="' +
                0 + '">' + "-- Pilih Group --" + '</option>';
            $("#cboGroup").append(optHTML);
            for (var i = 0; i < res.length; i++) {
                listStatus.push(res[i]);
                optHTML = '<option value="' + res[i].GroupId + '">' + res[i].GroupName + '</option>';
                $("#cboGroup").append(optHTML);
            }
        }
    });
}

function showProgress() {
    var elem = document.getElementById("divBar");
    var width = 0;
    var id = setInterval(frame, 10);
    function frame() {
        if (width >= 100) {
            clearInterval(id);
        } else {
            width++;
            elem.style.width = width + '%';
            document.getElementById("label").innerHTML = width * 1 + '%';
        }
    }
}
