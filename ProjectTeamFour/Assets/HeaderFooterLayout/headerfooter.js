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

//購物車功能
function AddToMyCart(PlanId, PlanTitle, PlanImgUrl, PlanPrice) {
    $.ajax({
        type: "POST",
        url: "/ShoppingCart/AddtoCart",
        data: { PlanId: PlanId, PlanTitle: PlanTitle, PlanPrice: PlanPrice, PlanImgUrl: PlanImgUrl, Quantity: 1 },
        dataType: "text",
        success: function (response) {

            $(".MyCart").text(`${response}`);
        }
    }).then(function TriggerAlert() {

        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: '已成功加入購物車',
            showConfirmButton: false,
            timer: 1500
        });

    })
}



function search(SearchValue) {

    //var pcSearchString = document.getElementsByClassName("pc-input-search").value();

    //$.ajax({
    //    type: "POST",
    //    url: "/Home/Search",
    //    data: { SearchValue: SearchValue },
    //    dataType: "text",
    //    success: function (response) {
    //        $(".pc-input-search").text(`${response}`);
    //    }

    //});
}


document.querySelector("#searchString").addEventListener("keypress", function (e) {
    if (e.key === "Enter") {

        var url = "/Home/Search/";
        var searchString = document.querySelector("#searchString").value;
        console.log(searchString);

        window.location.href = url + searchString;

        //$.ajax({
        //    type: "GET",
        //    url: url,
        //    data: { searchString: searchString },
        //    success: function (data) {

        //    }
        //});
    }
});

//$("#searchString").on("keyup", function (e) {
//    console.log("11");

//    if (e.which == 13) {
//        e.preventDefault();
//        var form = $(this);
//        var url = "/Home/Search/";
//        var searchString = $("#searchString").val();
//        console.log(searchString);
        
//        window.location.replace(url + searchString);

//        $.ajax({
//            type: "GET",
//            url: url,
//            data: { searchString: searchString },
//            success: function (data) {

//            }
//        });

//        console.log(searchString);
//    }
//});

