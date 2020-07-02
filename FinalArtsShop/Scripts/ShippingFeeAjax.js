$(document).ready(function () {
    $('#district').change(function (e) {
        e.preventDefault();
        var x = parseFloat($('#deliveryType').find(':selected').data('num')) * parseFloat($('#district').find(':selected').data('num'));
        counting(x);
    });

    $('#deliveryType').change(function (e) {
        e.preventDefault();
        var x = parseFloat($('#deliveryType').find(':selected').data('num')) * parseFloat($('#district').find(':selected').data('num'));
        counting(x);
    });

    $('#city').change(function (e) {
        e.preventDefault();
        var idCity = $(this).val();
        if (idCity == 0) {
            $('#district').val(0);
            $('#district').html('<option selected value="0">Select Your District</option>');
            $('#shippingfee').val(0);
            $('#shippingfee').html('$ ' + 0);
        };
        var _token = $('input[name="_token"]').val();
        $.ajax({
            url: "/Checkout/getDistrictWithAjax",
            method: 'POST',
            data: { idCity: idCity, _token: _token },
            dataType: 'json',
            success: function (data) {
                if (data != "") {
                    $('#district').html(data);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                $('#result').html('<p>status code: ' + jqXHR.status + '</p><p>errorThrown: ' + errorThrown + '</p><p>jqXHR.responseText:</p><div>' + jqXHR.responseText + '</div>');
            },
        });
    });
});

function counting(x) {
    x = x.toFixed(2);
    x = parseFloat(x);
    var y = parseFloat($('#inputSubTotal').val());
    y = y.toFixed(2);
    y = parseFloat(y);
    if (isNaN(x) == false) {
        var z = x + y;
        $('#shippingfee').val(x);
        $('#shippingfee').html('$ ' + x);
        $('#total').val(z);
        $('#total').html('$ ' + z );
    }
}