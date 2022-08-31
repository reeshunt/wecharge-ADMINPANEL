$(document).ready(function () {
    window.onload = function () {
        bindDatatable("1");
    };

    $("#Refresh").click(function (e) {
        $('#tblVendors').DataTable().ajax.reload(null, false);
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
                        url: `/Vendors/Delete/${id}`,
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


    function bindDatatable(val) {
        $("#tblVendors").DataTable().destroy();
        datatable = $('#tblVendors')
            .DataTable({
                "sAjaxSource": `/Vendors/GetAllVendors/`,
                "bServerSide": true,
                "bProcessing": true,
                "responsive": true,
                "bSearchable": true,
                "fnServerData": function (sSource, aoData, fnCallback) {
                    aoData.push({ "name": "UserType", "value": val });
                    $.getJSON(sSource, aoData, function (json) {
                        fnCallback(json)
                    });
                },
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
                        render: function (data, type, row) {
                            return `<img src="${row.imagE_PATH}" style="height:40px; width:40px;"/>`;
                        }
                    },

                    {
                        "orderable": false,
                        "autoWidth": true,
                        render: function (data, type, row) {
                            return `<div>
                                    <a href='/Vendors/Edit/${row.id}' class="btn btn-default btn-info customhref" data-key="${row.id}">Edit</a>
                                    <button type="button" class="btn btn-sm btn-danger btnDelete" data-key="${row.id}">Delete</button>
                                </div>`;
                        }
                    },
                ],

                "columnDefs": [
                    { "width": "50%", "targets": [1] }
                ],
            });
    }

});





