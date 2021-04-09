
function LanchCommentAjax(ProjectId, AskedMemberId) {
    let clientComment = document.querySelector(".form-control");
    if (clientComment.value == null) {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: '請留言!',

        });
    }
    else {
        $.ajax({
            url: "/api/Comment/UpdateComment",
            type: "POST",
            /*dataType: "json",*/
            data: { ProjectId: ProjectId, Comment_Question: clientComment.value, AskedMemberId: AskedMemberId },
            success: function (data, textStatus, jqXHR) {

                if (data == "login") {
                    Swal.fire(
                        '尚未登入?',
                        '請先登入！',
                        'question'
                    ).then(result => {
                        reloading();
                    })

                }
                else if (data == "try") {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: '請留言!',

                    })
                }
                else if (data == "fail") {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: '發生錯誤，請再試一次!',

                    })
                }
                else {
                    Swal.fire({
                        position: 'top-center',
                        icon: 'success',
                        title: '已成功留言！',
                        showConfirmButton: false,
                        timer: 1500
                    })
                }

            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(jqXHR);
                console.log(textStatus);

            }
        })
    }


}

function reloading() {
    window.location.href = "/Member/Login";

}

/*判斷募資進度的狀態(已成功/募資中/募資失敗)*/
var project_status = document.getElementById("goal-wrap");


//    $('#share').popover(
//        {
//            trigger: 'focus', //触发方式
//            placement: 'bottom',
//            //html: true,
//            content: '分享分享',
//            template: `<div class="popover" role="tooltip">
//                        < div class = "arrow" ></div>
//                  <h3 class ="popover-title">SELECT A DATE</h3>
//                  <div class ="popover-content">
//                    <p>asdadqweqrqq</p>
//                  </div>
//                </div >
//                    <div id="share-content">
//                    <div class="fab fa-facebook-square" data-href="https://www.google.com" data-layout="button"></div>-->
//                                                @*<div id="share-line-btn"><script type="text/javascript">LineIt.loadButton();</script></div>*@
//                                                <a href='javascript: void(window.open(&apos;https://lineit.line.me/share/ui?url=&apos; .concat(encodeURIComponent(location.href)) ));' title='分享給 LINE 好友'><i class="fab fa-line"></i></a>
//                </div>
//                    `,
//        });




/*聯絡提案人按鈕*/
var message_btn = document.getElementById("ask-btn");
message_btn.addEventListener('click', function SendMessage() {
    document.createElement("div");
})

$('#ask-btn').on('shown.bs.modal', function () {
    $('#ask-modal').trigger('focus')
})

$('#exampleModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var recipient = button.data('#Message') // Extract info from data-* attributes
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    var modal = $(this)
    modal.find('.modal-title').text('傳送訊息 ' + recipient)
    modal.find('.modal-body input').val(recipient)
})



//取得目前網址
//var currentUri = document.querySelector('[rel="canonical"]').href;
//Facebook分享的Api
//window.fbAsyncInit = function () {
//    FB.init({
//        appId: 'share-fb-btn',
//        xfbml: true,
//        version: 'v2.4'
//    });
//};

//(function (d, s, id) {
//    var js, fjs = d.getElementsByTagName(s)[0];
//    if (d.getElementById(id)) { return; }
//    js = d.createElement(s); js.id = id;
//    js.src = "//connect.facebook.net/en_US/sdk.js";
//    fjs.parentNode.insertBefore(js, fjs);
//}(document, 'script', 'facebook-jssdk'));




//官網傳送訊息程式碼:
$(document).on('click', '#send_msg', function () {
    var content = $('#msg_content').val();


    //plan card投影片slide動畫
    $(document).ready(function () {
        $('#select-plans').carousel({
            interval: 2000
        })
    });
});