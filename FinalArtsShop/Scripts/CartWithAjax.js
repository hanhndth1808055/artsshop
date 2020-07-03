$(document).ready(function () {
    $(".addCart").click(function (e) {
        e.preventDefault();
        var _token = $('input[name="_token"]').val();
        var productId = $(this).attr("data-id");
        $.ajaxSetup({
            headers: {
                'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')
            }
        });
        $.ajax({
            url: "/ShoppingCart/AddToCartWithAjax",
            method: 'POST',
            data: { productId: productId, quantity: 1, _token: _token },
            dataType: 'json',
            success: function (data) {
                if (data != "") {
                    $('#showSummaryCart').html(data);
                    $('.aa-cart-notify').html($('#hiddenCartNum').val());
                    Swal.fire(
                        'Product is added to your cart!',
                        '',
                        'success',
                    );
                } else {
                    Swal.fire(
                        'Product is unavailable now. Please select another one!',
                        '',
                        'error',
                    );
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                $('#result').html('<p>status code: ' + jqXHR.status + '</p><p>errorThrown: ' + errorThrown + '</p><p>jqXHR.responseText:</p><div>' + jqXHR.responseText + '</div>');
                console.log('jqXHR:');
                console.log(jqXHR);
                console.log('textStatus:');
                console.log(textStatus);
                console.log('errorThrown:');
                console.log(errorThrown);
            },
        });
    });

    $(".removeItem").click(function (e) {
        e.preventDefault();
        Swal.fire({
            title: 'Are you sure to remove this?',
            text: "You won't be able to revert this!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, remove it!'
        }).then((result) => {
            if (result.value) {
                var _token = $('input[name="_token"]').val();
                var productId = $(this).attr("data-id");
                $.ajaxSetup({
                    headers: {
                        'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')
                    }
                });
                $.ajax({
                    url: "/ShoppingCart/RemoveItemWithAjax",
                    method: 'POST',
                    data: { productId: productId, token: _token },
                    dataType: 'json',
                    success: function (data) {
                        if (data != "") {
                            $('#bodyCon').html(data[0]);
                            $('#showSummaryCart').html(data[1]);
                            $('#TotalPrice').html(data[2]);
                            $('.aa-cart-notify').html(data[3]);
                            Swal.fire(
                                'Remove!',
                                'This product has been removed.',
                                'success'
                            )
                        } else {
                            Swal.fire(
                                'Please retry removing this product!',
                                '',
                                'error',
                            );
                        }
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        $('#result').html('<p>status code: ' + jqXHR.status + '</p><p>errorThrown: ' + errorThrown + '</p><p>jqXHR.responseText:</p><div>' + jqXHR.responseText + '</div>');
                        console.log('jqXHR:');
                        console.log(jqXHR);
                        console.log('textStatus:');
                        console.log(textStatus);
                        console.log('errorThrown:');
                        console.log(errorThrown);
                    }
                })
            }
        })
    });

    $(document).on('click', '.aa-cart-quantity', function (e) {
        e.preventDefault();
        var _token = $('input[name="_token"]').val();
        var productId = $(this).attr("data-id");
        var quantity = $(this).val();
        $.ajaxSetup({
            headers: {
                'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')
            }
        });
        $.ajax({
            url: "/ShoppingCart/UpdateNumOfProductWithAjax",
            method: 'POST',
            data: { productId: productId, quantity: quantity, _token: _token },
            dataType: 'json',
            success: function (data) {
                if (data != "") {
                    $('#showSummaryCart').html(data[0]);
                    $('#TotalPrice').html(data[1]);
                    $('.aa-cart-notify').html(data[2]);
                    $('#ItemPrice' + productId).html(data[3]);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                $('#result').html('<p>status code: ' + jqXHR.status + '</p><p>errorThrown: ' + errorThrown + '</p><p>jqXHR.responseText:</p><div>' + jqXHR.responseText + '</div>');
                console.log('jqXHR:');
                console.log(jqXHR);
                console.log('textStatus:');
                console.log(textStatus);
                console.log('errorThrown:');
                console.log(errorThrown);
            },
        });
    });
});
