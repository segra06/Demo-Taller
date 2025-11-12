// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function saveMessage() {
    const msg = {
        name: $('#name').val(),
        email: $('#email').val(),
        subject: $('#subject').val(),
        content: $('#message').val()
    };

    $.ajax({
        url: "/Message/Post",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(msg),
        dataType: "json",
        success: function (response) {
            alert("Your question has been sent correctly");
        }
    });
}