$(document).ready(function () {
    $('input[name=rating]').change(function () {
        $('#rate').val($(this).val());
    });

    $(document).on('click', '#submitComment', function (e) {
        e.preventDefault();
        var rate = $('#rate').val();
        var idProduct = $('#idProduct').val();
        var name = $('#name').val();
        var message = $('#message').val();
        var _token = $('input[name="_token"]').val();
        $.ajaxSetup({
            headers: {
                'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')
            }
        });
        $.ajax({
            url: "/Product/GetComment",
            method: 'POST',
            data: { idProduct: idProduct, _token: _token, rate: rate, name: name, message: message },
            dataType: 'json',
            success: function (data) {
                if (data != "")
                {
                    Swal.fire(
                        'Your comment is created success',
                        '',
                        'success',
                    );
                } else
                {
                    Swal.fire(
                        'Sorry! Your comment is invalid',
                        '',
                        'error',
                    );
                }
                $('.rating > input:checked ~ label').css("color", "#ddd");
                $('#name').val('');
                $('#message').val('');
                $('#revCon').prepend(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert('An error occurred... Look at the console (F12 or Ctrl+Shift+I, Console tab) for more information!');
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