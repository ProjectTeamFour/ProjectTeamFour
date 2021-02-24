$(document).ready(function () {

    $('.indemand-project-wrap').slick({
        slidesToShow: 5,
        slidesToScroll: 5,
        autoplay: false,
        infinite: true,
        arrows: true,
        accessibility: true,
        prevArrow: $(".prev"),
        nextArrow: $(".next"),
        responsive: [{
            breakpoint: 1024,
            settings: {
                slidesToShow: 4,
                slidesToScroll: 4
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
                slidesToShow: 2,
                slidesToScroll: 2
            }
        }
        ]
    });
});