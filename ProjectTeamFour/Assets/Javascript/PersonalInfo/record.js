
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

//var jsonObj = {
//    "items": { OrderId: $("#transJSON").val()},
//    "detail": { OrderDetailId: $('#odtransJSON').val()},
//    "modeldata": []
//};

var odData = jsonObj.modeldata
//var data = { OrderId: $("#transJSON").val(), OrderDetailId: $('#odtransJSON').val() };

function Binding() {
    new Vue({
        el: "#record",
        data: jsonObj,
        methods: {
            changeJsonOd(orderId) {
                this.modeldata = [];
                this.modeldata = objod.filter(x => x.OrderId == orderId);
            },
            //sendDataToRecord: function (e) {
            //    var self = this;                
            //    $.ajax({
            //        type: "Get",
            //        url: '~/api/BackingRecord/GetOrder',
            //        success: function (res) {
            //            console.log(res.data);
            //            alert("123");
            //        },
            //        error: function (error) {
            //            console.log(error);
            //        }
            //    })
            //}
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

    var table_clear = $(".dataTables_empty");
    table_clear.html('<p>目前無任何購買紀錄<p>');   
});


