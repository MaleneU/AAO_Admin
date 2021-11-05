// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

 //Write your JavaScript code.
$(' table tr td .showmore ').click(function () {
    $(this).closest('tr.showmore').next('tr.rowdetail').toggle();
    
})

$(".rotate").click(function () {
    $(this).toggleClass("down");
})


$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
});