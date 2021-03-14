﻿let credit_one = document.getElementById("credit-card");
let credit_split = document.getElementById("credit-card-split");
let atm = document.getElementById("credit-atm");
let market = document.getElementById("credit-market");

let sp_one = document.getElementById("one");
let sp_split = document.getElementById("split");
let sp_atm = document.getElementById("atm");
let sp_market = document.getElementById("market");




credit_one.onclick = function () {
    sp_one.classList.add("widthOfblock");
    sp_split.classList.remove("widthOfblock");
    sp_atm.classList.remove("widthOfblock");
    sp_market.classList.remove("widthOfblock");
}

credit_split.onclick = function () {
    sp_split.classList.add("widthOfblock");
    sp_one.classList.remove("widthOfblock");
    sp_atm.classList.remove("widthOfblock");
    sp_market.classList.remove("widthOfblock");
}

atm.onclick = function () {
    sp_split.classList.remove("widthOfblock");
    sp_one.classList.remove("widthOfblock");
    sp_atm.classList.add("widthOfblock");
    sp_market.classList.remove("widthOfblock");
}

market.onclick = function () {
    sp_split.classList.remove("widthOfblock");
    sp_one.classList.remove("widthOfblock");
    sp_atm.classList.remove("widthOfblock");
    sp_market.classList.add("widthOfblock");
}

//document.querySelector(".btn-pay").addEventListener("click", function (e) {
//    e.preventDefault();
//});

function ConnectToECPay(orderName, orderAddress, orderPhone, orderEmail) {
    $.ajax({
        type: "post",
        url: "/pay/connectecpay",
        data: { OrderName: orderName, OrderAddress: orderAddress, OrderPhone: orderPhone, OrderConEmail: orderEmail },
        //dataType: "text",
        success: function (response) {

            //$(".btn-pay").text(`${response}`);
        }
    }).then(function TriggerAlert() {

        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: '',
            showConfirmButton: false,
            timer: 1500
        });

    })
}