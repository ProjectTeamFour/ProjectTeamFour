var myApp = new Vue({
    el: "#resetpassword",
    data: {
        AddVerify: "",
        inputData: {
            Email: "",
            Password: "",
            ConfirmPassword: "",
        },
        Error: {
            EmailError: true,
            PasswordError: true,
            ConfirmPasswordError: true,
        },
        ErrorMsg: {
            EmailErrorMsg: "",
            PasswordErrorMsg: "",
            ConfirmPasswordErrorMsg: "",
        }
    },
    watch: {
        "inputData.Email": {
            handler: function () {
                let emailRegexp =
                    /(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])/;
                if (this.inputData.Email == "") {
                    this.Error.EmailError = true;
                    this.ErrorMsg.EmailErrorMsg = "Email 不得為空";
                } else if (!emailRegexp.test(this.inputData.Email)) {
                    this.Error.EmailError = true;
                    this.ErrorMsg.EmailErrorMsg = "請符合 Email 格式";
                } else {
                    this.Error.EmailError = false;
                    this.ErrorMsg.EmailErrorMsg = "";

                }
                this.checkAddVerify();
            }
        },
        "inputData.Password": {
            handler: function () {
                let passwordRegexp = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$/;
                if (this.inputData.Password == "") {
                    this.Error.PasswordError = true;
                    this.ErrorMsg.PasswordErrorMsg = "密碼不得為空";
                } else if (!passwordRegexp.test(this.inputData.Password)) {
                    this.Error.PasswordError = true;
                    this.ErrorMsg.PasswordErrorMsg = "密碼須至少一個英文字母，且6位數以上";
                } else {
                    this.Error.PasswordError = false;
                    this.ErrorMsg.PasswordErrorMsg = "";
                }
                this.checkAddVerify();
            }
        },
        "inputData.ConfirmPassword": {
            handler: function () {
                if (this.inputData.ConfirmPassword == "") {
                    this.Error.ConfirmPasswordError = true;
                    this.ErrorMsg.ConfirmPasswordErrorMsg = "確認密碼不得為空";
                } else if (this.inputData.ConfirmPassword !== this.inputData.Password) {
                    this.Error.ConfirmPasswordError = true;
                    this.ErrorMsg.ConfirmPasswordErrorMsg = "密碼需一致";
                } else {
                    this.Error.ConfirmPasswordError = false;
                    this.ErrorMsg.ConfirmPasswordErrorMsg = "";
                }
                this.checkAddVerify();
            }
        }
    },
    methods: {
        checkAddVerify() {
            for (let index in this.Error) {
                if (this.Error[index] == true) {
                    this.AddVerify = false;
                    return;
                }
            }
            this.AddVerify = true;
        },
        sendToApi() {

            var searchURL = window.location.search;
            console.log(searchURL);
            searchURL = searchURL.substring(1, searchURL.length);
            console.log(searchURL);
            var targetPageId = searchURL.split("&")[0].split("=")[1];
            console.log(targetPageId);

            if (this.AddVerify == true) {

                var uploadData = {
                    "TargetPageId": targetPageId,
                    "MemberRegEmail": this.inputData.MemberEmail,
                    "MemberPassword": this.inputData.MemberPassword,
                    "ConfirmPassword": this.inputData.ConfirmPassword,
                }

                $.ajax({
                    url: "/Mail/CheckMemberUrl/",
                    type: "post",
                    //contentType: "application/json; charset=utf-8",
                    data: uploadData,
                    success: function (response) {

                        Swal.fire({
                            position: 'top',
                            icon: 'success',
                            title: '寄送驗證信成功',
                            html: '如果您的填寫都無誤，已幫您修改完成<br>請用新密碼登入',
                            showConfirmButton: false,
                            timer: 3000
                        });

                        setTimeout(() => {
                            window.location.href = "/Home/Index/";
                        }, 3000);

                    },
                    error: function (response) {
                        Swal.fire({
                            position: 'top',
                            icon: 'error',
                            title: '修改失敗',
                            showConfirmButton: false,
                            timer: 1500
                        });
                    }
                });



                //操作寄信
            } else {
                Swal.fire({
                    position: 'top',
                    icon: 'warning',
                    title: '請將信箱、密碼填完整才能重設密碼',
                    showConfirmButton: false,
                    timer: 2500
                });
            }
        }
    }
});