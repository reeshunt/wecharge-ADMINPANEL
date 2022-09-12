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


    $(document)
        .off('click', '#btnCreate')
        .on('click', '#btnCreate', function (e) {
            $('#btnCreate').prop('disabled', true);
            $('#btnCreate').html('Wait <i class="fa fa-spinner fa-spin"></i>');
            e.preventDefault();
            var _this = $(this);
            var _form = _this.closest("form");
            var isvalid = _form.valid();
            if (isvalid) {
                var formData = new FormData();
                formData.append("UserId", $("#frmCreate #userID").val());
                formData.append("AddressId", $("#frmCreate #addressDD").val());
                formData.append("VendorId", $("#frmCreate #vendorDD").val());
                formData.append("FuelTypeId", $("#frmCreate #fuelDD").val());
                formData.append("Quantity", $("#frmCreate #quantitytxt").val());
                formData.append("Price", $("#frmCreate #priceDD").val());
                formData.append("TimeSlotId", $("#frmCreate #TimeSlotDD").val());
                formData.append("PaymentModeId", $("#frmCreate #PaymentModeDD").val());
                formData.append("AssetTypeId", $("#frmCreate #assetDD").val());
                $.ajax({
                    url: `${baseUri}/Orders/AddOrder`,
                    type: 'POST',
                    cache: false,
                    contentType: false,
                    processData: false,
                    data: formData,
                    success: function (response) {
                        if (response.isSuccess === true) {
                            document.querySelector('#frmCreate').reset();
                            $('#tblOrders').DataTable().ajax.reload(null, false);
                            swal("", "Orders Created Sucessfully!", "success")
                            $('#btnCreate').prop('disabled', false);
                            $('#btnCreate').html('Submit');
                        }
                        else {
                            $("#error-msg-create").text(response.message);
                            $('#btnCreate').prop('disabled', false);
                            $('#btnCreate').html('Submit');
                        }
                    },
                    error: function (response) {
                        swal("Error", "An error has occured!", "error");
                        $('#btnCreate').prop('disabled', false);
                        $('#btnCreate').html('Submit');
                    }
                });
            }
            else {
                $('#btnCreate').prop('disabled', false);
                $('#btnCreate').html('Submit');
            }

        });


 });