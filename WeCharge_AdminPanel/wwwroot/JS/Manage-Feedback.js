$(document).ready(function () {

    $("#Refresh").click(function (e) {
        $('#tblFeedback').DataTable().ajax.reload(null, false);
    });

    var table = $('#tblFeedback')
        .DataTable({
            "sAjaxSource": `/Feedback/GetAllVendors/`,
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
                    "data": "feedbacK_ID",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "feedbacK_VALUE",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "createD_DATE",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "feedbacK_NAME",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "issuE_NAME",
                    "autoWidth": true,
                    "searchable": false
                },
                {
                    "data": "issuE_ID",
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
