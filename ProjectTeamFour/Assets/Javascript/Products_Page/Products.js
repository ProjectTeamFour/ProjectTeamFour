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

//document.getElementById("tech").addEventListener("click", function () {
//    console.log("123");
//});


$().ready(function () {
    $("#ajax").click(function () {
        $.ajax({
            url: 'https://localhost:44300/api/Projects/GetAll',
            type: "POST",
            data: { ProjectId: ProjectId, ProjectMainUrl: ProjectMainUrl, Category: Category, ProjectStatus: ProjectStatus, ProjectName: ProjectName, CreatorName: CreatorName, FundingAmount: FundingAmount, AmountThreshold: AmountThreshold, EndDate: EndDate, StartDate: StartDate, dateLine: dateLine, Fundedpeople: Fundedpeople},
            dataType: "json",
            success: function (response) {
                
                console.log(response);
            }
        })
    })
})