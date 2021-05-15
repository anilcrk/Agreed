$(document).ready(function () {

    $('#agreedTable').dataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/Agreed/GetAgreedItems",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [
            { "data": "id", "name": "Id", "autowidth": true },
            { "data": "barcode", "name": "Barcode", "autowidth": true },
            { "data": "packageNumber", "name": "PackageNumber", "autowidth": true },
            { "data": "cargoCompany", "name": "CargoCompany", "autowidth": true },
            { "data": "orderDate", "name": "OrderDate", "autowidth": true },
            //{
            //    "render": function (data, type, row) { return '<span>' + row.dateOfBirth.split('T')[0] + '</span>' },
            //    "name": "OrderDate"
            //},
            {
                "render": function (data, type, row) { return '<a href="#" class="btn btn-danger" onclick=DeleteCustomer("' + row.id + '"); > Delete </a>' },
                "orderable": false
            },

        ]
    });
});