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

//購物車功能(加入購物車):使用ajax呼叫以POST的方法呼叫ShoppingCart控制器的AddtoCart Action。
function AddToMyCart(PlanId, PlanTitle, PlanImgUrl, PlanPrice, QuantityLimit,ProjectId) {
    $.ajax({
        type: "POST",
        url: "/ShoppingCart/AddtoCart",
        data: { PlanId: PlanId, PlanTitle: PlanTitle, PlanPrice: PlanPrice, PlanImgUrl: PlanImgUrl, Quantity: 1, QuantityLimit: QuantityLimit, ProjectId: ProjectId },
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



//全域搜尋
document.querySelector("#searchString").addEventListener("keypress", function (e) {
    if (e.key === "Enter") {

        var url = "/Home/Search/";
        var searchString = document.querySelector("#searchString").value;
        console.log(searchString);

        window.location.href = url + searchString;
    }
});

//全域搜尋
document.querySelector("#phone-searchString").addEventListener("keypress", function (e) {
    if (e.key === "Enter") {

        var url = "/Home/Search/";
        var searchString = document.querySelector("#phone-searchString").value;
        console.log(searchString);

        window.location.href = url + searchString;
    }
});


//讓fb登出 也讓session 清空
function Logout(isThirdParty) {
    if (isThirdParty == "Facebook") {
        FB.getLoginStatus(function (response) {
            FB.logout(function (response) {
                //console.log("Logged Out!");
                window.location.href = "/Member/Logout"; //讓session 清空
            });
        });
    } else {
        window.location.href = "/Member/Logout"; //讓session 清空
    }
}








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

