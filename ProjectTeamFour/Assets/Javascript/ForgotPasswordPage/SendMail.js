var myApp = new Vue({
    el: "#forgetpassword",
    data: {
        AddVerify: "",
        inputData: {
            Email: "",
            EmailError: "",
            EmailErrorMsg: "",
        }
    },
    watch: {
        "inputData.Email": {
            handler: function () {
                let emailRegexp =
                    /(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])/;
                if (this.inputData.Email == "") {
                    this.inputData.EmailError = true;
                    this.inputData.EmailErrorMsg = "Email 不得為空";
                } else if (!emailRegexp.test(this.inputData.Email)) {
                    this.inputData.EmailError = true;
                    this.inputData.EmailErrorMsg = "請符合 Email 格式";
                } else {
                    this.inputData.EmailError = false;
                    this.inputData.EmailErrorMsg = "";

                }
                this.checkAddVerify();
            }
        }
    },
    methods: {
        checkAddVerify() {
            for (let index in this.inputData) {
                if (this.inputData[index] == true) {
                    this.AddVerify = false;
                    return;
                }
            }
            this.AddVerify = true;
        },
        sendToApi() {
            if (this.AddVerify == true) {
                Swal.fire({
                    position: 'top',
                    icon: 'success',
                    title: '寄送驗證信成功',
                    html: '如果您的 Email 無誤，已將驗證碼寄至您的信箱',
                    showConfirmButton: false,
                    timer: 2500
                });

                //操作寄信 
            } else {
                Swal.fire({
                    position: 'top',
                    icon: 'warning',
                    title: 'Email 格式請填妥',
                    showConfirmButton: false,
                    timer: 2500
                });
            }
        }
    }
});