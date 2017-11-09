$(function () {
    $("#generatePoem").click(function () {
        $.ajax({
            type: "POST",
            url: "/Poem/GetPoem",
            data: {
                'schemaId': $('#selectSchema').val(),
            },
            success: function (data) {
                $("#poemTextArea").html(data);
            },
            error:     function errorFunc(xhr, ajaxOptions, throwError) {
        switch (xhr.status) {
            case 400: alert("Client error." + throwError); break;
            case 403: alert("Log in, please. Unput your email."); location.reload(true); break;
            case 500: alert("Internal server error. Try again later."); break;
        }
    }

        })
    });
})