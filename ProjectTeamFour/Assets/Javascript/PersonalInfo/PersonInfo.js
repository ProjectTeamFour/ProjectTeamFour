document.getElementById('personinfo').addEventListener('click', function () {

    var uploadimg = document.querySelector('#uploadimg');
    uploadimg.addEventListener('change', function (e) {
        //debugger;
        let files = $(this).get(0).files;
        let formData = new FormData();
        formData.append(files[0].name, files[0]);
        uploadFile(formData);
        console.log(files);
        console.log(formData);
    })

    var btn_submit = document.querySelector('#btnSub');
    btn_submit.addEventListener('click', function () {

        // console.log(document.getElementById('imgshow').getAttribute('src'));

        $.ajax({
            url: '/api/memberapi/update',
            type: 'post',
            data: {
                MemberId: $('#memberid').text(),
                MemberConEmail: $('#contactEmail').val(),
                Gender: document.getElementById('gender1').selectedOptions[0].text,
                MemberBirth: document.getElementById('birthday1').value,
                AboutMe: $('#about').val(),
                MemberName: $('#name1').val(),
                MemberWebsite: $('#personal-site').val(),
                ProfileImgUrl: document.getElementById('imgshow').getAttribute('src')
            },
            success: function (response) {
                if (response == "成功") {
                    debugger;
                    let imgurl = document.getElementById('imgshow').getAttribute('src');
                    document.getElementsByName('memberimg').forEach(item => {
                        console.log(imgurl);
                        item.setAttribute('src', imgurl);
                    })
                    Swal.fire({
                        position: 'top-center',
                        icon: 'success',
                        title: '修改成功',
                        showConfirmButton: false,
                        timer: 1500
                    })
                }
                else {
                    Swal.fire({
                        position: 'top-center',
                        icon: 'error',
                        title: '修改失敗',
                        showConfirmButton: false,
                        timer: 1500
                    })
                }
            }
        })
    })
})

function uploadFile(formData) {
    //debugger;
    console.log(formData);
    $.ajax({
        url: '/api/memberapi/UploadFiles',
        method: 'post',
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            document.getElementById('imgshow').setAttribute('src', response);
        }
    })
}

function getGender() {
    var gender = document.getElementById('gender1').innerText();
    switch (gender) {
        case "女":
            selectedOptions[1].setAttribute("selected")
            break;
        case "男":
             selectedOptions[2].setAttribute("selected")
            break;
        default:
            selectedOptions[0].setAttribute("selected")
            break;
    }
}