$(document).ready(function () {
    $("#PaymentStatus").change(function (e) {
        e.preventDefault();
        var _token = $('input[name="_token"]').val();
        var paymentStatusVal = $(this).children("option:selected").val();
        var idOrder = $(this).attr("data-id");
        $.ajaxSetup({
            headers: {
                'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')
            }
        });
        $.ajax({
            url: "/Orders/UpdatePaymentStatus",
            method: 'POST',
            data: { paymentStatusVal: paymentStatusVal, idOrder: idOrder, _token: _token },
            dataType: 'json',
            success: function (data) {
                if (data != "") {
                    //this.html(data);
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

    $("#FulfillmentStatus").change(function (e) {
        e.preventDefault();
        var _token = $('input[name="_token"]').val();
        var fullfillmentStatusVal = $(this).children("option:selected").val();
        var idOrder = $(this).attr("data-id");
        $.ajaxSetup({
            headers: {
                'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')
            }
        });
        $.ajax({
            url: "/Orders/UpdateFullfillmentStatus",
            method: 'POST',
            data: { fullfillmentStatusVal: fullfillmentStatusVal, idOrder: idOrder, _token: _token },
            dataType: 'json',
            success: function (data) {
                if (data != "") {
                    //this.html(data);
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