$(document).ready(function () {

    $("#Refresh").click(function (e) {
        $('#tblWallet').DataTable().ajax.reload(null, false);
    });

    var table = $('#tblWallet')
        .DataTable({
            "sAjaxSource": `/User/GetUsersWallet/`,
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
                    /*"data": "balance",*/
                    "autoWidth": true,
                    "searchable": false,
                    render: function (data, type, row) {
                        console.log(data)
                        console.log(row)
                        return `<div>
                                    <input type="text" value="${row.balance}" readonly class="form-control" id="txtBal${row.id}" placeholder="Enter balance">
                                </div>`;
                    }
                },
                {
                    "orderable": false,
                    "autoWidth": true,
                    render: function (data, type, row) {
                        console.log(data)
                        console.log(row)
                        return `<div>
                                    <button type="button" id="btnUpdate${row.id}" class="btn btn-sm btn-info mr-2 btnUpdate" data-key="${row.id}">Edit Balance</button>
                                    <button type="submit" id="btnSubmit${row.id}" class="btn btn-sm btn-info mr-2 btnSubmit" style="display:none" data-key="${row.id}">Update</button>
                                    <button type="submit" id="btnCancel${row.id}" class="btn btn-sm btn-info mr-2 btnCancel" style="display:none" data-key="${row.id}">Cancel</button>
                                </div>`;
                    }
                },
            ],

            "columnDefs": [
                { "width": "50%", "targets": [1] }
            ],
        });

    $(document)
        .off('click', '.btnUpdate')
        .on('click', '.btnUpdate', function () {
            const id = $(this).attr('data-key');
            $('#btnSubmit' + id).css('display', 'block');
            $('#btnCancel' + id).css('display', 'block');
            $('#btnUpdate' + id).css('display', 'none');
            $('#txtBal' + id).removeAttr('readonly');
            
        });
    $(document)
        .off('click', '.btnCancel')
        .on('click', '.btnCancel', function () {
            const id = $(this).attr('data-key');
            $('#btnSubmit' + id).css('display', 'none');
            $('#btnCancel' + id).css('display', 'none');
            $('#btnUpdate' + id).css('display', 'block');
            $('#txtBal' + id).attr('readonly',true);
        });

    $(document)
        .off('click', '.btnSubmit')
        .on('click', '.btnSubmit', function () {
            debugger;
            const id = $(this).attr('data-key');
            $('#btnSubmit' + id).css('display', 'none');
            $('#btnCancel' + id).css('display', 'none');
            $('#btnUpdate' + id).css('display', 'block');
            $('#txtBal' + id).attr('readonly', true);
            $.ajax({
                url: `/User/UpdateWallet/${id}/${$('#txtBal' + id).val()}`,
                type: 'POST',
                cache: false,
                contentType: false,
                processData: false,
                success: function (response) {
                    /*swal("Success", "Updated successfully!", "success")*/
                },
                error: function (response) {
                    /*swal("Error", "An error has occured!", "error")*/
                }
            });
        });
});
