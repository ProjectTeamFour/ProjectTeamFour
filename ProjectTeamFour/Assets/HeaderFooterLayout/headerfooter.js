$(document).ready(function () {

    $('#dismiss, .overlay').on('click', function () {
        $('#sidebar').removeClass('active');
        $('.overlay').removeClass('active');
    });

    $('#sidebarCollapse').on('click', function () {
        $('#sidebar').addClass('active');
        $('.overlay').addClass('active');
        $('.collapse.in').toggleClass('in');
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
    });

    //$(".pc-fa-search").on("click",

    //    function () {
    //    $(".pc-input-search").blur();
    //    $(".pc-input-search").css("border-bottom", "");
    //},
    //    function () {
    //    $(".pc-input-search").focus();
    //    $(".pc-input-search").css("border-bottom", "3px solid var(--color)");
    //});
});




let faSearch = document.querySelector(".pc-fa-search");
let inputSearch = document.querySelector(".pc-input-search");

faSearch.addEventListener("click", function () {
    inputSearch.style.borderBottom = "3px solid var(--color)";
    inputSearch.focus();
});

