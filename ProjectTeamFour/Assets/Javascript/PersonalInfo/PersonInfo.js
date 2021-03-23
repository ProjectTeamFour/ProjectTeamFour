$(document.getElementById('user-profile')).ready(function () {
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

    //document.getElementById('user-profile').addEventListener('',)

    //document.getElementById('user-profile').addEventListener('click', function () {

    var btn_submit = document.querySelector('#btnSub');
    var imgUrl = document.getElementById('imgshow');
    btn_submit.addEventListener('click', function () {

        $.ajax({
            url: '/api/memberapi/update',
            type: 'post',
            data: {
                MemberId: $('#memberid').text(),
                MemberConEmail: $('#contactEmail').val(),
                Gender: document.getElementById('gender1').value,
                MemberBirth: document.getElementById('birthday1').value,
                AboutMe: $('#about').val(),
                MemberName: $('#name1').val(),
                MemberWebsite: $('#personal-site').val(),
                ProfileImgUrl: document.getElementById('imgshow').getAttribute('src')
            },
            success: function (response) {
                if (response == "成功") {
                    //debugger;
                    let imgurl = document.getElementById('imgshow').getAttribute('src');
                    console.log(imgurl);
                    imgUrl.setAttribute('src', imgurl);
                    //document.getElementsByName('memberimg').forEach(item => {
                    //    console.log(imgurl);
                    //    item.setAttribute('src', imgurl);
                    //})

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
};

function getGender() {
    let mygender = document.getElementById('gender1').value;
    //e.options[e.selectedIndex].text;
    //let genderselect = document.getElementById('gender1');
    switch (myselect) {
        case "女性":
            //setgender.selectedOptions[1].setAttribute("selected")
            genderselect.selectedIndex = "1";
            break;
        case "男性":
            //setgender.selectedOptions[2].setAttribute("selected")
            genderselect.selectedIndex = "2";
            break;
        case "其他":
            //setgender.selectedOptions[3].setAttribute("selected")
            genderselect.selectedIndex = "3";
            break;
        default:
            //setgender.selectedOptions[0].setAttribute("selected")
            genderselect.selectedIndex = "0";
            break;
    }
}


