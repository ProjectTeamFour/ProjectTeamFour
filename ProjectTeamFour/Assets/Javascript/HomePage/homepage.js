$(document).ready(function () {

    $('.autoplay').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 3000,
        infinite: true,
        arrows: true,
        accessibility: true,
        prevArrow: $(".prev"),
        nextArrow: $(".next"),
    });

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