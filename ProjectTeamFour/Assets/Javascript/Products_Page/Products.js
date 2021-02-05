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