$(document).ready(function () {

    $("#Refresh").click(function (e) {
        $('#tblOrders').DataTable().ajax.reload(null, false);
    });

    var table = $('#tblTimeSlot')
        .DataTable({
            "sAjaxSource": `/TimeSlot/GetAllTimeSlot/`,
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
                    "data": "timE_SLOT_FROM",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "timE_SLOT_TO",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "iS_ACTIVE",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "createD_BY",
                    "autoWidth": true,
                    "searchable": false
                },    
                {
                    "data": "createD_DATE",
                    "autoWidth": true,
                    "searchable": false
                }, 
                {
                    "orderable": false,
                    "autoWidth": true,
                    render: function (data, type, row) {
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