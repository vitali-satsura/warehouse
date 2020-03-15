var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_storage').DataTable({
        "ajax": {
            "url": "/storages/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "productId", "width": "2%" },
            { "data": "receiptDate", "width": "15%" },
            { "data": "supplierId", "width": "2%" },
            { "data": "orderDate", "width": "15%" },
            { "data": "customerId", "width": "2%" },
            { "data": "departureDate", "width": "15%" },
            { "data": "deliveryMethod", "width": "2%" },
            { "data": "volume", "width": "2%" },
            { "data": "price", "width": "2%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/storages/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                            Edit
                        </a>
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                            onclick=Delete('/storages/Delete?id='+${data})>
                            Delete
                        </a>
                        </div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}