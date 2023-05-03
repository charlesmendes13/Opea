// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getCompanySize(callback) {    

    $.ajax({
        type: "GET",
        url: '/Client/GetCompanySize',
        data: {},
        success: function (data) {
            callback(data);
        }
    });
}