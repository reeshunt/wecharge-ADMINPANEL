$(document).ready(function () {

    $("#Refresh").click(function (e) {
        $('#tblVendors').DataTable().ajax.reload(null, false);
    });

    var table = $('#tblVendors')
        .DataTable({
            "sAjaxSource": `/Vendors/GetAllVendors/`,
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
                    "data": "fulL_NAME",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "mobilE_NO",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "email",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "imagE_PATH",
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

    $(document)
        .off('click', '.btnEdit')
        .on('click', '.btnEdit', function () {
            const id = $(this).attr('data-key');
            $.ajax({
                url: `/Vendors/Edit/${id}`,
                type: 'GET',
                cache: false,
                contentType: false,
                processData: false,
                success: function (response) {
                },
                error: function (response) {
                    swal("Error", "An error has occured!", "error")
                }
            });
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
                        url: `${baseUri}/Vendors/Delete/${id}`,
                        type: 'POST',
                        cache: false,
                        contentType: false,
                        processData: false,
                        success: function (response) {
                            if (response === true) {
                                $('#tblVendors').DataTable().ajax.reload(null, false);
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


});





