$(function () {
    loadGrid({
        grid: "grdProduct",
        url: "/Home/GetAllData",
        colNames: ["", "Product Name", "Category", "Stock", "Quantity", "Price", "Ordered", "Supplier", "Supplier City", "Supplier Country"],
        colModel: [
            {
                label: 'ProductID',
                name: 'ProductID',
                width: 20,
                key: true,
                hidden: true
            },
            {
                label: 'ProductName',
                name: 'ProductName',
                width: 180,
                editable: true

            },
            {
                label: 'CategoryName',
                name: 'CategoryName',
                width: 180,
                editable: true
            },
            {
                label: 'UnitsInStock',
                name: 'UnitsInStock',
                width: 180,
                editable: true
            },
            {
                label: 'QuantityPerUnit',
                name: 'QuantityPerUnit',
                width: 180,
                editable: true
            },
            {
                label: 'UnitPrice',
                name: 'UnitPrice',
                width: 180,
                editable: true
            },
            {
                label: 'UnitsOnOrder',
                name: 'UnitsOnOrder',
                width: 180,
                editable: true
            },
            {
                label: 'CompanyName',
                name: 'CompanyName',
                width: 180,
                editable: true
            },
            {
                label: 'City',
                name: 'City',
                width: 180,
                editable: true
            },
            {
                label: 'Country',
                name: 'Country',
                width: 180,
                editable: true
            }
        ],
        toolbar: [true, "top"],
        width: 1050,
        height: "auto",
        buttonMode: "0",
        search: false
    });
    hideLoading();
});
$("#grdProduct_rn").html("No.");

function AddAutomaticCalculation() {

    $('#modalAddAutomaticCalculation').load("/AutomaticCalculation/AddAutomaticCalculation").modal('show');
}
