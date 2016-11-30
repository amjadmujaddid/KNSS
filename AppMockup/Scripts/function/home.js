$(function () {
    //loadGrid({
    //    grid: "grdProduct",
    //    url: "/Home/GetAllData/",
    //    colNames: ["ID", "Group Name"],
    //    colModel: [
    //        {
    //            label: 'GroupId',
    //            name: 'GroupId',
    //            width: 20,
    //            key: true,
    //            hidden: false
    //        },
    //        {
    //            label: 'GroupName',
    //            name: 'GroupName',
    //            width: 20,
    //            key: true,
    //            key: false
    //        }
    //    ],
    //    toolbar: [true, "top"],
    //    width: 1100,
    //    height: "auto",
    //    search: true,
    //    sortName: 'GroupId',
    //    sortOrder: 'desc'
    //});
    //hideLoading();

    //$("#btnSearch").click(function () {

    //    //if ($("#" + obj + "dtpMonth").val() != "") {
    //    //    joinDate = setMonthYear($("#" + obj + "dtpMonth").val());
    //    //}
    //    //var text = $("#txtSearchGroup").val();
    //    //refreshGrid({
    //    //    grid: "grdProduct",
    //    //    url: "/Home/GetFilteredData/",
    //    //    param: "text" + ($("#txtSearchGroup").$()),
    //    //    //postData: {
    //    //    //    text: $("#txtSearchGroup").val()
    //    //});

    //    });
    //$.ajax({
    //    type: "POST",
    //    url: "/Home/GetFilteredData",
    //    data: JSON.stringify({ text: $("#txtSearchGroup").val() }),
    //    dataType: "json",
    //    contentType: "application/json; charset=utf-8",
    //    success: function (data) {
    //        alert(data);
    //    },
    //    error: function (xhr, ajaxOptions, thrownError) { alert(xhr.responseText); }
    //});
});



$("#grdProduct_rn").html("No.");

//function AddAutomaticCalculation() {

//    $('#modalAddAutomaticCalculation').load("/AutomaticCalculation/AddAutomaticCalculation").modal('show');
//}







//$(function () {
//    loadGrid({
//        grid: "grdProduct",
//        url: "/Home/GetAllData",
//        colNames: ["", "Product Name", "Category", "Stock", "Quantity", "Price", "Ordered", "Supplier", "Supplier City", "Supplier Country"],
//        colModel: [
//            {
//                label: 'ProductID',
//                name: 'ProductID',
//                width: 20,
//                key: true,
//                hidden: true
//            },
//            {
//                label: 'ProductName',
//                name: 'ProductName',
//                width: 180,
//                editable: true

//            },
//            {
//                label: 'CategoryName',
//                name: 'CategoryName',
//                width: 180,
//                editable: true
//            },
//            {
//                label: 'UnitsInStock',
//                name: 'UnitsInStock',
//                width: 180,
//                editable: true
//            },
//            {
//                label: 'QuantityPerUnit',
//                name: 'QuantityPerUnit',
//                width: 180,
//                editable: true
//            },
//            {
//                label: 'UnitPrice',
//                name: 'UnitPrice',
//                width: 180,
//                editable: true
//            },
//            {
//                label: 'UnitsOnOrder',
//                name: 'UnitsOnOrder',
//                width: 180,
//                editable: true
//            },
//            {
//                label: 'CompanyName',
//                name: 'CompanyName',
//                width: 180,
//                editable: true
//            },
//            {
//                label: 'City',
//                name: 'City',
//                width: 180,
//                editable: true
//            },
//            {
//                label: 'Country',
//                name: 'Country',
//                width: 180,
//                editable: true
//            }
//        ],
//        toolbar: [true, "top"],
//        width: 1050,
//        height: "auto",
//        buttonMode: "0",
//        search: false
//    });
//    hideLoading();
//});
//$("#grdProduct_rn").html("No.");

//function AddAutomaticCalculation() {

//    $('#modalAddAutomaticCalculation').load("/AutomaticCalculation/AddAutomaticCalculation").modal('show');
//}
