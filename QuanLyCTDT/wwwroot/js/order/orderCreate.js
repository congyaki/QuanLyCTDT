var orderUpdateCtr = {
    Init: function () {
        this.RegisterEvent();
    },
    RegisterEvent: function () {
        var currentIndex = $('#order-details-table tbody tr').length;

        $(document).on('click', '#add-order-detail', function () {
            var row = '<tr>' +
                '<td><input class="form-control" name="OrderDetails[' + currentIndex + '].PId" type="text" /></td>' +
                '<td><input class="form-control" name="OrderDetails[' + currentIndex + '].ODQuantity" type="text" /></td>' +
                '<td><input class="form-control" name="OrderDetails[' + currentIndex + '].ODPrice" type="text" /></td>' +
                '<td><button type="button" class="btn btn-danger">Remove</button></td>' +
                '</tr>';
            $('#order-details-table tbody').append(row);
            currentIndex++;
        });

        $(document).on('click', '#order-details-table tbody tr button', function () {
            $(this).closest('tr').remove();
            currentIndex--;
        });
    }
};

