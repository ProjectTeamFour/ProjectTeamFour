$(document).ready(function () {
    $('.category-group').slick({
        centerMode: false,
        slidesToShow: 7,
        slidesToScroll: 7,
        autoplaySpeed: 2000,
        arrows: false,
        draggable: true,
        focusOnSelect: true,
        responsive: [{
            breakpoint: 768,
            settings: {
                slidesToShow: 3,
                slidesToScroll: 3
            }
        }]
    });
});


//$("#tech").click(function () {
//    $.ajax({
//        url: "~/api/Projects/GetAll",
//        type: "POST",        
//        dataType: "json",
//        success: function (response) {

//            console.log(response); 
//        }
//    })
//});
//alert("789");


//document.getElementById("tech").addEventListener("click", function () {
//    console.log("123");
//});