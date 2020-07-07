$(document).ready(function () {
    $("#BuyNow").click(function (e) {
        var _token = $('input[name="_token"]').val();
        $.ajaxSetup({
            headers: {
                'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')
            }
        });
        $.ajax({
            url: "/Checkout/ClearCart",
            method: 'POST',
            data: { _token: _token },
            dataType: 'json',
            success: function (data) {
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