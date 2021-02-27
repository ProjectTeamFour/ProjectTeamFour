$(document).ready(function () {


    $('.project-categories-wrap').slick({
        slidesToShow: 6,
        slidesToScroll: 6,
        autoplay: false,
        infinite: true,
        arrows: true,
        accessibility: true,
        prevArrow: $(".prev"),
        nextArrow: $(".next"),
        responsive: [{
            breakpoint: 1024,
            settings: {
                slidesToShow: 6,
                slidesToScroll: 6
            }
        },
        {
            breakpoint: 992,
            settings: {
                slidesToShow: 3,
                slidesToScroll: 3
            }
        },
        {
            breakpoint: 768,
            settings: {
                slidesToShow: 3,
                slidesToScroll: 3
            }
        }
        ]
    });


});


//車車搜尋
document.querySelector("#button-input").addEventListener("click", function (e) {
    //if (e.key === "Enter") {

        var url = "/CarCarPlan/Search/";
        var searchString = document.querySelector("#text-input").value;
        //console.log(searchString);

        window.location.href = url + searchString;
    //}
});