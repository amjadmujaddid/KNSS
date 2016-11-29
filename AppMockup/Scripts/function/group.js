$(function () {
    $("#grdGroup").jqGrid({
        url: "/Group/GetAllData",
        datatype: "json",
        mtype: 'Get',
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
        pager: "#grdGroupPager",
        loadonce: true,
        multiselect: true,
        caption: 'Group List',
        emptyrecords: 'No Product Records are available to display',
        viewrecords: true,
        width: 680,
        height: 200,
        rowNum: 10

    });
    $("#grdGroup").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
});

function AddAutomaticCalculation() {

    $('#modalAddAutomaticCalculation').load("/AutomaticCalculation/AddAutomaticCalculation").modal('show');
}
