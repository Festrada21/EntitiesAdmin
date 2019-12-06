$(document).ready(function () {
    $("body").on("click", "a.dialog-window", null, function (e) {

        e.preventDefault();
        var $link = $(this);
        var title = $link.attr("name");
        var id = 1;
        $('#modalwindows .modal-title').html(title);
        var url = $(this).attr('href');
        if (url.indexOf('#') === 0) {
            $('#modalwindows').modal('show');
        }
        else {
            $.get(url, function (data) {
                $('#modalwindows .te').html(data);
                $('#modalwindows').modal();
            }).success(function () { $('input:text:visible:first').focus(); });
        }

    });
});