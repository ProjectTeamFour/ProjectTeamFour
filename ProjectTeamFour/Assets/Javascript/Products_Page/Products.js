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

let tech = document.getElementById("tech");
tech.addEventListener(click, function () {

})

$().ready(function () {
    $("#ajax").click(function () {
        $.ajax({
            url: https://localhost:44300/api/Projects/GetAll,
            type: "POST",
            dataType: "json",
            success: function (response) {
                console.log(response);
            }
        })
    })
})