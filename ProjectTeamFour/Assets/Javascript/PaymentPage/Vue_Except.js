var form = new Vue({
    el: "#app",
    data: {
        inputData: {
            Name: '',
            Address: '',
            Tel: '',
            Email: '',
        },
        inputDataCheck: {
            NameError: false,
            NameErrorMsg: '',
            AddressError: '',
            AddressErrorMsg: '',
            TelError: '',
            TelErrorMsg: '',
            EmailError: '',
            EmailErrorMsg: '',
        }
    },
    watch: {
        'inputData.Name': function () {
            let nameRegexp = /^[0-9]*$/; //只能數字
            if (nameRegexp.test(this.inputData.Name)) {
                this.inputDataCheck.NameError = true;
                this.inputDataCheck.NameErrorMsg = '名稱不得有數字';
            }
            else if (this.inputData.Name.length > 8) {
                this.inputDataCheck.NameError = true;
                this.inputDataCheck.NameErrorMsg = '名稱不得超過8個字';
            }
            else {
                this.inputDataCheck.NameError = false;
                this.inputDataCheck.NameErrorMsg = '';
            }
            this.checkAddVerify();
        },
        'inputData.Address': function () {
            let addressRegexp = /^[0-9]{3}/;  //開頭為數字

            if (!addressRegexp.test(this.inputData.Address)) {
                this.inputDataCheck.AddressError = true;
                this.inputDataCheck.AddressErrorMsg = '開頭必須為3碼郵遞區號';
            }
            else {
                this.inputDataCheck.AddressError = false;
                this.inputDataCheck.AddressErrorMsg = '';
            }
            this.checkAddVerify();
        },
        'inputData.Tel': function () {
            let telRegexp = /^09/; //開頭為09
            let telRegexpNum = /^[0-9]*$/;
            if (!telRegexp.test(this.inputData.Tel)) {

                this.inputDataCheck.TelError = true;
                this.inputDataCheck.TelErrorMsg = '開頭必須為09';
            }
            else if (this.inputData.Tel.length < 10) {
                this.inputDataCheck.TelError = true;
                this.inputDataCheck.TelErrorMsg = '號碼長度必須為10碼';
            }
            else if (!telRegexpNum.test(this.inputData.Tel)) {
                this.inputDataCheck.TelError = true;
                this.inputDataCheck.TelErrorMsg = '只能輸入數字';
            }
            else {
                this.inputDataCheck.TelError = false;
                this.inputDataCheck.TelErrorMsg = '';
            }
            this.checkAddVerify();
        },
        'inputData.Email': function () {
            let emailRegexp = /^(([.](?=[^.]|^))|[\w_%{|}#$~`+!?-])+@(?:[\w-]+\.)+[a-zA-Z.]{2,63}$/;
            if (!emailRegexp.test(this.inputData.Email)) {
                this.inputDataCheck.EmailError = true;
                this.inputDataCheck.EmailErrorMsg = '不符合email格式';
            }
            else {
                this.inputDataCheck.EmailError = false;
                this.inputDataCheck.EmailErrorMsg = '';
            }
            this.checkAddVerify();
        }

    },
    methods: {
        checkAddVerify() {
            for (let index in this.inputDataCheck) {
                if (this.inputDataCheck[index] == true) {
                    this.AddVerify = false;
                    return;
                }
            }
            this.AddVerify = true;
        }
    }
})