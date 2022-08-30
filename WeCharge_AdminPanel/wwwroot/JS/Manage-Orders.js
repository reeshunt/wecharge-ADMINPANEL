$(document).ready(function () {

    $("#Refresh").click(function (e) {
        $('#tblOrders').DataTable().ajax.reload(null, false);
    });

    var table = $('#tblOrders')
        .DataTable({
            "sAjaxSource": `/Orders/GetAllOrders/`,
            "bServerSide": true,
            "bProcessing": true,
            "responsive": true,
            "bSearchable": true,
            "ordering": false,
            "searching": true,
            "lengthChange": true,
            "order": [[0, 'asc']],
            "language": {
                "emptyTable": "No record found.",
                "processing":
                    '<i class="fa fa-spinner fa-spin fa-3x fa-fw" style="color:#2a2b2b;"></i><span class="sr-only">Loading...</span> '
            },
            "columns": [
                {
                    "data": "ordeR_ID",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "ordeR_DATETIME",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "fulL_NAME",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "email",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "fueL_TYPE_NAME",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "price",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "ordeR_STATUS",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "vendoR_ID",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "quantity",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "createD_DATE",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "modofieD_DATE",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "orderable": false,
                    "autoWidth": true,
                    render: function (data, type, row) {
                        console.log(data)
                        console.log(row)
                        return `<div>
                                    <button type="button" class="btn btn-sm btn-info mr-2 btnEdit" data-key="${row.id}">Edit</button>
                                    <button type="button" class="btn btn-sm btn-danger btnDelete" data-key="${row.id}">Delete</button>
                                </div>`;
                    }
                },
            ],

            "columnDefs": [
                { "width": "50%", "targets": [1] }
            ],
        });
 });