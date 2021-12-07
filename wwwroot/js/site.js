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


var dropdown = document.getElementsByClassName("dropdown-btn");
var i;

for (i = 0; i < dropdown.length; i++) {
    dropdown[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var dropdownContent = this.nextElementSibling;
        if (dropdownContent.style.display === "block") {
            dropdownContent.style.display = "none";
        } else {
            dropdownContent.style.display = "block";
        }
    });
}

$("#leftside-navigation .sub-menu > a").click(function (e) {
    $("#leftside-navigation ul ul").slideUp(), $(this).next().is(":visible") || $(this).next().slideDown(),
        e.stopPropagation()
})


function openNav() {
    document.getElementById("mySidebar").style.left = "0px";
    document.getElementById("mainContent").style.marginLeft = "260px";

}

function closeNav() {
    document.getElementById("mySidebar").style.left = "-240px";
    document.getElementById("mainContent").style.marginLeft = "60px";

}