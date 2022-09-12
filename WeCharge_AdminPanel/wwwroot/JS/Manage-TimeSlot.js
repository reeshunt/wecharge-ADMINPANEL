$(document).ready(function () {

    $("#Refresh").click(function (e) {
        $('#tblTimeSlot').DataTable().ajax.reload(null, false);
    });


    $(document)
        .off('click', '.btnDelete')
        .on('click', '.btnDelete', function () {
            const id = $(this).attr('data-key');
            swal({
                title: "Are you sure?",
                text: "Once deleted, you will not be able to recover this record!",
                type: "warning",
                showCancelButton: true,
                cancelButtonClass: "btn-primary",
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Delete!",
                closeOnConfirm: false
            },
                function () {
                    $.ajax({
                        url: `/TimeSlot/Delete/${id}`,
                        type: 'POST',
                        cache: false,
                        contentType: false,
                        processData: false,
                        success: function (response) {
                            if (response === true) {
                                $('#tblTimeSlot').DataTable().ajax.reload(null, false);
                                swal("", "Vendor Deleted successfully!", "success")
                            }
                            else {
                                swal("Error", "An error has occured!", "error");
                            }
                        },
                        error: function (response) {
                            swal("Error", "An error has occured!", "error")
                        }
                    });
                });
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
                                     <a href='/TimeSlot/Edit/${row.id}' class="btn btn-default btn-info customhref" data-key="${row.id}">Edit</a>
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