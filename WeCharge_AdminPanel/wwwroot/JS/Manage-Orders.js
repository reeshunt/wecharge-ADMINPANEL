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
                    "data": "vendoR_NAME",
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
        .on('click', '#btnCreate', function () {
            debugger;
            var formData = new FormData();
            formData.append("USER_ID", $("#frmCreate #userID").val());
            formData.append("ADDRESS_ID", $("#frmCreate #addressDD").val());
            formData.append("VENDOR_ID", $("#frmCreate #vendorDD").val());
            formData.append("FUEL_TYPE_ID", $("#frmCreate #fuelDD").val());
            formData.append("QUANTITY", $("#frmCreate #quantitytxt").val());
            formData.append("PRICE", $("#frmCreate #priceDD").val());
            formData.append("TIME_SLOT_ID", $("#frmCreate #TimeSlotDD").val());
            formData.append("PAYMENT_MODE_ID", $("#frmCreate #PaymentModeDD").val());
            formData.append("ASSET_TYPE_ID", $("#frmCreate #assetDD").val());
            formData.append("DATE_OF_DELIVERY", $("#frmCreate #dateofDelivery").val());
            formData.append("BILLING_ADDRESS", $("#frmCreate #billingAddressTxtArea").val());
            formData.append("ORDER_STATUS", $("#frmCreate #orderStatus").val());
            $.ajax({
                url: `/Orders/AddOrder`,
                type: 'POST',
                cache: false,
                contentType: false,
                processData: false,
                data: formData,
                success: function (response) {
                    if (response === true) {
                        document.querySelector('#frmCreate').reset();
                        $('#tblOrders').DataTable().ajax.reload(null, false);
                        swal("", "Orders Created Sucessfully!", "success")
                    }
                    else {
                        $("#error-msg-create").text(response.message);
                    }
                },
                error: function (response) {
                    swal("Error", "An error has occured!", "error");
                }
            });
        });


 });