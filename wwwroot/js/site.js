// Open table row/dropdown
$(' table tr td .showmore ').click(function () {
    $(this).closest('tr.showmore').next('tr.rowdetail').toggle('fast');
    
});
// Rotate arrow on table rows
$(".rotate").click(function () {
    $(this).toggleClass('rotate-down');


});



// Bootstrap Tooltip
$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
});


// Sidenav drop down - Experimentation

//var dropdown = document.getElementsByClassName("dropdown-btn");
//var i;

//for (i = 0; i < dropdown.length; i++) {
//    dropdown[i].addEventListener("click", function () {
//        this.classList.toggle("active");
//        var dropdownContent = this.nextElementSibling;
//        if (dropdownContent.style.display === "block") {
//            dropdownContent.style.display = "none";
//        } else {
//            dropdownContent.style.display = "block";
//        }
//    });
//}

//$("#leftside-navigation .sub-menu > a").click(function (e) {
//    $("#leftside-navigation ul ul").slideUp(), $(this).next().is(":visible") || $(this).next().slideDown(),
//        e.stopPropagation()
//})


// Sidebar open/close
function openNav() {
    document.getElementById("mySidebar").style.left = "0px";
    document.getElementById("mainContent").style.marginLeft = "21%";

}

function closeNav() {
    document.getElementById("mySidebar").style.left = "-16%";
    document.getElementById("mainContent").style.marginLeft = "5%";

}

function limitStopDate() {
    let startDate = document.querySelector('input.start-date');
    let stopDate = document.querySelector('input.stop-date');

    stopDate.setAttribute('min', startDate.value);
}

function convertStartDateTime() {
    let startDate = document.querySelector('input.start-date').value;
    let startTime = document.querySelector('input.start-time').value;
    let startDateAndTime = document.querySelector('input.start-date-and-time');

    startDateAndTime.value = startDate + "T" + startTime;
}

function sendDurationValue() {
    let x = document.querySelector('select.unit-select').selectedIndex;
    let selectedValue = parseInt(document.querySelectorAll('option.unit-selector')[x].value);
    // Get duration input and unit selector and turn them to int. 
    // Get duration output
    let durationInput = parseInt(document.querySelector('input.duration-input').value);
    let durationOutput = document.querySelector('input.duration-output');
    //let unitSelector = parseInt(document.querySelector('option.unit-selector').value);

    // Calculate the duration output in hours
    durationOutput.value = durationInput * selectedValue;
    console.log("Your input was multiplied by " + selectedValue)
}



