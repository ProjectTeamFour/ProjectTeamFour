
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

let classurl = document.querySelectorAll(".url1");

let url1 = document.getElementsByClassName('url1');
let url2 = document.getElementById('url2');
let url3 = document.getElementById('url3');

let tech = $("#tech");
let music = $("#music");
let art = $("#art");
let life = $("#life");
let local = $("#local");
let game = $("#game");
var category = $("#category").text();
var status = $("#status").text();
var id = $("id").text();

let all = $(".category-group");//事件綁定父層
all.click(function () {
    
    if ($(".category-group").children("a#tech")) {
        url1.innerText = '';
        url1.innerText = classurl[0].textContent;
        var url = decodeURI(encodeURI(`/Projects/Index/?category=${url1.innerText}&projectStatus=${status}&id=${id}`));
        tech.attr("href", url);        
    }
    if ($(".category-group").children("a#music")) {
        url1.innerText = '';
        url1.innerText = classurl[1].textContent;
        var url = decodeURI(encodeURI(`/Projects/Index/?category=${url1.innerText}&projectStatus=${status}&id=${id}`));
        music.attr("href", url);
        
    }
    if ($(".category-group").children("a#art")) {
        url1.innerText = '';
        url1.innerText = classurl[2].textContent;
        var url = decodeURI(encodeURI(`/Projects/Index/?category=${url1.innerText}&projectStatus=${status}&id=${id}`));
        art.attr("href", url);
    }
    if ($(".category-group").children("a#life")) {
        url1.innerText = '';
        url1.innerText = classurl[3].textContent;
        var url = decodeURI(encodeURI(`/Projects/Index/?category=${url1.innerText}&projectStatus=${status}&id=${id}`));
        life.attr("href", url);
    }
    if ($(".category-group").children("a#local")) {
        url1.innerText = '';
        url1.innerText = classurl[4].textContent;
        var url = decodeURI(encodeURI(`/Projects/Index/?category=${url1.innerText}&projectStatus=${status}&id=${id}`));
        local.attr("href", url);
    }
    if ($(".category-group").children("a#game")) {
        url1.innerText = '';
        url1.innerText = classurl[5].textContent;
        var url = decodeURI(encodeURI(`/Projects/Index/?category=${url1.innerText}&projectStatus=${status}&id=${id}`));
        game.attr("href", url);
    }
    
})

    
let menu = $("#menu");//事件綁定父層
let ongoing = $("#ongoing");
let success = $("#success");

let StatusForNow = document.getElementsByName("StatusForNow")


menu.click(function () {
    if ($(menu).children("a#ongoing")) {
        //StatusForNow[1].innerText = "";
        StatusForNow[0].innerText = "集資中";
        url2.innerText = '';
        url2.innerText = '集資中';        
        var url = decodeURI(encodeURI(`/Projects/Index/?category=${category}&projectStatus=${url2.innerText}&id=${id}`));
        ongoing.attr("href", url);        
    }
    if ($(menu).children("a#success")) {
        url2.innerText = '';
        url2.innerText = '集資成功';
        var url = decodeURI(encodeURI(`/Projects/Index/?category=${category}&projectStatus=${url2.innerText}&id=${id}`));
        success.attr("href", url);
    }
})

let orderByItem = $("#orderByItem"); //綁定事件父層
let hot = $("#hot");
let time = $("#new");
let money = $("#money");

orderByItem.click(function () {
    if ($(orderByItem).children("a#hot")) {
        url3.innerText = "";
        url3.innerText = "Fundedpeople";
        var url = decodeURI(encodeURI(`/Projects/Index/?category=${category}&projectStatus=${status}&id=${url3.innerText}`));
        hot.attr("href", url);
    }
    if ($(orderByItem).children("a#time")) {
        url3.innerText = "";
        url3.innerText = "EndDate";
        var url = decodeURI(encodeURI(`/Projects/Index/?category=${category}&projectStatus=${status}&id=${url3.innerText}`));
        time.attr("href", url);
    }
    if ($(orderByItem).children("a#money")) {
        url3.innerText = "";
        url3.innerText = "FundingAmount";
        var url = decodeURI(encodeURI(`/Projects/Index/?category=${category}&projectStatus=${status}&id=${url3.innerText}`));
        money.attr("href", url);
    }
})





