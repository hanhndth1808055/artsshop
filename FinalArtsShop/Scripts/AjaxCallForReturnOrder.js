$(".BackOrder").click(function (e) {
    e.preventDefault();
    var statusCol = this.closest("td").previousElementSibling.previousElementSibling;
    var thisTarget = $(this);
    Swal.fire({
        title: 'Are you sure for returning?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, I am sure!'
    }).then((result) => {
        if (result.value) {
            var _token = $('input[name="_token"]').val();
            var orderId = $(this).attr("data-id");
            $.ajaxSetup({
                headers: {
                    'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')
                }
            });
            $.ajax({
                url: "/Checkout/ReturnOrderForAjax",
                method: 'POST',
                data: { orderId: orderId, token: _token },
                dataType: 'json',
                success: function (data) {
                    if (data != "") {
                        Swal.fire(
                            'Your product is returning!',
                            '',
                            'success'
                        )
                        statusCol.innerHTML = data;
                        thisTarget.remove();
                    } else {
                        Swal.fire(
                            'Your product can not returning!',
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
