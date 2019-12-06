$(document).ready(function () {

    $('a[id*=btnDeleteItem]').click(function () {
        var id = 0;
        var url;
        try {
            id = $(this).parent()[0].id;
            url = document.getElementById("btnDeleteItem").getAttribute("name");
            swal({
                title: 'Delete Item',
                text: 'Do you want to delete the record?',
                type: 'error',
                showCancelButton: true,
                confirmButtonText: 'Delete',
                cancelButtonText: 'Cancel',
                confirmButtonClass: 'btn btn-warning',
                cancelButtonClass: 'btn btn-danger',
                buttonsStyling: false,
                reverseButtons: true
            }).then((result) => {
                if (result.value) {

                    window.location.href = url + id;
                   

                } else if (result.dismiss === 'cancel') {
                   
                    return false;
                }
            });
        }
        catch (err) {

            alert(err.message);
        }

        return false;
    });
});


