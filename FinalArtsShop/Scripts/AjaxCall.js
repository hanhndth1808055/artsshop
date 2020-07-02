$(document).ready(function () {
    var idArray = [];
    $("#deleteAll").click(function (e) {
        e.preventDefault();
        idArray = [];
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.value) {
                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )
                var myRows = document.querySelectorAll("tr.selected");
                myRows.forEach(myFunction);
                var targetType = document.getElementById('targetName').innerHTML;
                var _token = $('input[name="_token"]').val()
                $.ajaxSetup({
                    headers: {
                        'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')
                    }
                });
                $.ajax({
                    url: "/" + targetType + "/" + targetType + "DeleteWithAjax",
                    method: 'POST',
                    data: { idArray: idArray, token: _token },
                    dataType: 'json',
                    success: function (data) {
                        $(myRows).remove();
                        location.reload();
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

    function myFunction(v, i, a) {
        idArray.push(v.getAttribute("data-id"));
    };
});