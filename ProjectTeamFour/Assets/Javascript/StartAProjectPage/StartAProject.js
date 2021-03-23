var myVue = new Vue({
    el: "#myapp",
    data: {
        AddVerify: "",
        inputData: {
            term: false,
        },
        inputDataError: {
            termError: 1,
        },
        inputDataErrorMsg: {
            termErrorMsg: "",
        },
    },
    watch: {
        "inputData.term": {
            // immediate:true,
            handler: function () {
                // this.watchStatus();
            }
        },
    },
    methods: {
        checkAddVerify: function () {
            for (let index in this.inputDataError) {
                if (this.inputDataError[index] == true) {
                    this.AddVerify = false;
                    return;
                }
            }
            this.AddVerify = true;
        },
        checkSubmit: function () {
            if (this.AddVerify == true) {
                window.location.href = "/StartAProject/SubmissionProcess";
            } else {
                Swal.fire({
                    position: 'top',
                    icon: 'warning',
                    title: '您必須勾選同意才能提案',
                    showConfirmButton: false,
                    timer: 3000
                });
            }
        },
        watchStatus: function () {
            if (this.inputData.term == false) {
                this.inputDataError.termError = true;
                this.inputDataErrorMsg.termErrorMsg = "您必須勾選同意才能撰寫提案";
                this.inputData.term = false;
            } else {
                this.inputDataError.termError = false;
                this.inputDataErrorMsg.termErrorMsg = "";
                this.inputData.term = true;
            }
            this.checkAddVerify();
        }
    }
})