let getodjson = document.getElementById("odtransJSON");
let getjson = document.getElementById("transJSON");
var obj = JSON.parse(getjson.value);//order 陣列
var objod = JSON.parse(getodjson.value); //orderdetail 陣列
console.log(obj);
console.log(objod);



var jsonObj = {
    "items": obj,
    "detail": objod,
    "modeldata": []
};

var odData = jsonObj.modeldata;

function sendDataToRecord() {
    $.ajax({
        type: "Get",
        url: '~/api/BackingRecord/GetOrderData',
        data: {},
        success: function (response) {
            window.setTimeout(reloading, 1000);
        }
    })
}

function Binding() {
    new Vue({
        el: "#record",
        data: jsonObj,
        methods: {
            changeJsonOd(orderId) {
                this.modeldata = [];
                this.modeldata = objod.filter(x => x.OrderId == orderId);
            }
        }
    });
};

$(document).ready(function () {
    Binding();
    $("#mytable").DataTable({
        "info": false,
        "bLengthChange": false,
        "pageLength": 5
    })

    $("#mytable-2").DataTable({
        "info": false,
        "bLengthChange": false,
        "pageLength": 5
    })
    var table_clear = $(".dataTables_empty");
    table_clear.html('<p>目前無任何購買紀錄<p>');   
});


