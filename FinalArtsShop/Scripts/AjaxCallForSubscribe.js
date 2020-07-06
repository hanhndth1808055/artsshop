$('#subscribe').click(function (e) {
    e.preventDefault();
    var email = $('#emailSubscribe').val();
    var _token = $('input[name="_token"]').val();
    var email_regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (email_regex.test(email) == true) {
        $.ajaxSetup({
            headers: {
                'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')
            }
        });
        $.ajax({
            url: "/Account/AddSubscriber",
            method: 'POST',
            data: { email: email, _token: _token },
            dataType: 'json',
            success: function (data) {
                if (data != "") {
                    Swal.fire(
                        'Thank for your subscribe!',
                        '',
                        'success',
                    );
                } else {
                    Swal.fire(
                        'Your email is still in list subscribers!',
                        '',
                        'success',
                    );
                }
                $('#emailSubscribe').val('');
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
    } else {
        $('#emailSubscribe').css('border', '1px solid #ff6666')
        $('#emailSubscribe').mouseleave(function () {
            $(this).css('border', '');
        })
    }
})