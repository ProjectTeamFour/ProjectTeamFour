
var splitJoin;
var pmu;
var pcu;
var piu;
var priu;
var imgSwitch;
var editorImgId = 0;
var imgurArray = [];
const id = 'ae6d69a08006f9d'; // 填入 App 的 Client ID
const token = 'da270109cacdb90f4dd7f0539f983217e184c45a'; // 填入 token
const album = 'J1vm7F3'; // 若要指定傳到某個相簿，就填入相簿的 ID
var url;



Vue.component("multi-text", {
    template: "#multi-text-template",
    // props: ['value'],
    data: function () {
        return {
            ProjectQuestionAnswer: [{
                Question: "",
                Answer: "",
                Count: 0,
                QAError: "",
                QAErrorMsg: "",
            }],
        };
    },
    methods: {
        updateValue: function () {
            console.debug(JSON.stringify(this.ProjectQuestionAnswer));
            this.$emit("input", this.ProjectQuestionAnswer);
            this.ProjectQuestionAnswer.forEach(function (item) {
                if (item.Question == "" || item.Answer == "") {
                    item.QAError = true;
                    item.QAErrorMsg = "常見問答請填完善";
                } else {
                    item.QAError = false;
                    item.QAErrorMsg = "";
                }
            });
            this.checkAddVerifyQA();
        },
        deleteValue: function (index) {
            this.ProjectQuestionAnswer.splice(index, 1);
            console.debug(JSON.stringify(this.ProjectQuestionAnswer));
            this.$emit("input", this.ProjectQuestionAnswer);
        },
        addInput: function () {
            this.ProjectQuestionAnswer
            this.ProjectQuestionAnswer.push({
                Question: this.ProjectQuestionAnswer.Question,
                Answer: this.ProjectQuestionAnswer.Answer,
                Count: this.ProjectQuestionAnswer[this.ProjectQuestionAnswer.length - 1]
                    .Count + 1,
            });
            this.$emit("input", this.ProjectQuestionAnswer);
            //console.log(this.ProjectQuestionAnswer);
        },
        checkAddVerifyQA: function () {
            for (let index in this.ProjectQuestionAnswer) {
                if (this.ProjectQuestionAnswer[index] == true) {
                    this.AddVerify = false;
                    return;
                }
            }
            this.AddVerify = true;
        },
    },
    watch: {
        "ProjectQuestionAnswer": {
            immediate: false,
            deep: true,
            handler: function () {
                this.ProjectQuestionAnswer.forEach((el, index) => {
                    el.Count = index;
                });
            }
        }
    }
})



var form = new Vue({
    el: "#myApp",
    data: {
        AddVerify: true,
        // isShow: true,
        inputData: {
            ProjectName: "取個好標題",
            AmountThreshold: "",
            Category: "",
            StartDate: "",
            EndDate: "",
            ProjectVideoUrl: "",
            ProjectMainUrl: "",
            ProjectCoverUrl: "",
            ProjectPrincipal: "",
            MemberConEmail: "",
            MemberPhone: "",
            IdentityNumber: "",
            TeamPicture: "",
            MemberName: "提案團隊姓名",
            AboutMe: "",
            MemberWebsite: "",
            QuillHtml: "",
        },
        inputDataCheck: {
            ProjectNameError: "",
            ProjectNameErrorMsg: "",
            AmountThresholdError: "",
            AmountThresholdErrorMsg: "",
            CategoryError: "",
            CategoryErrorMsg: "",
            StartDateAndEndDateError: "",
            StartDateAndEndDateErrorMsg: "",
            ProjectVideoUrlError: "",
            ProjectVideoUrlErrorMsg: "",
            ProjectMainUrlError: "",
            ProjectMainUrlErrorMsg: "",
            ProjectCoverUrlError: "",
            ProjectCoverUrlErrorMSg: "",
            ProjectPrincipalError: "",
            ProjectPrincipalErrorMsg: "",
            MemberConEmailError: "",
            MemberConEmailErrorMsg: "",
            MemberPhoneError: "",
            MemberPhoneErrorMsg: "",
            IdentityNumberError: "",
            IdentityNumberErrorMsg: "",
            TeamPictureError: "",
            TeamPictureErrorMsg: "",
            MemberNameError: "",
            MemberNameErrorMsg: "",
            AboutMeError: "",
            AboutMeErrorMsg: "",
            MemberWebsiteError: "",
            MemberWebsiteErrorMsg: "",
        },

        modalData: {
            PlanPrice: "",
            PlanTitle: "",
            QuantityLimit: "",
            AddCarCarPlanSwitch: "",
            PlanDescription: "",
            PlanImgUrl: "",
            PlanShipDateYear: "year",
            PlanShipDateMonth: "month",
            tempYear: "",
            tempMonth: "",
            makePlanCount: 0,
        },
        modalDataCheck: {
            PlanPriceError: "",
            PlanPriceErrorMsg: "",
            PlanTitleError: "",
            PlanTitleErrorMsg: "",
            QuantityLimitError: "",
            QuantityLimitErrorMsg: "",
            AddCarCarPlanSwitchError: "",
            AddCarCarPlanSwitchErrorMsg: "",
            PlanDescriptionError: "",
            PlanDescriptionErrorMsg: "",
            PlanImgUrlError: "",
            PlanImgUrlErrorMsg: "",
            PlanShipDateError: "",
            PlanShipDateErrorMsg: "",
        },
        modalList: [{
            ProjectPlanId: "",
            ViewId: "",
            makePlanCount: "",
            PlanPrice: "",
            PlanTitle: "",
            QuantityLimit: "",
            AddCarCarPlanSwitch: "",
            AddCarCarPlan: "",
            PlanDescription: "",
            PlanImgUrl: "",
            PlanShipDateYear: "",
            PlanShipDateMonth: "",
            PlanShipDate: "",
        }],
        ProjectQuestionAnswer: [{
        }],
    },
    watch: {
        "inputData.ProjectName": {
            immediate: false,
            handler: function () {
                if (this.inputData.ProjectName == "") {
                    this.inputDataCheck.ProjectNameError = true;
                    this.inputDataCheck.ProjectNameErrorMsg = "專案標題不得為空";
                } else if (this.inputData.ProjectName.length > 40) {
                    this.inputDataCheck.ProjectNameError = true;
                    this.inputDataCheck.ProjectNameErrorMsg = "專案標題不得超過40字";
                } else {
                    this.inputDataCheck.ProjectNameError = false;
                    this.inputDataCheck.ProjectNameErrorMsg = "";
                }
                this.checkAddVerify();
            }
        },
        "inputData.AmountThreshold": {
            handler: function () {
                if (this.inputData.AmountThreshold == "") {
                    this.inputDataCheck.AmountThresholdError = true;
                    this.inputDataCheck.AmountThresholdErrorMsg = "募資目標不得為空";
                } else if (this.inputData.AmountThreshold > 1000000000) {
                    this.inputDataCheck.AmountThresholdError = true;
                    this.inputDataCheck.AmountThresholdErrorMsg = "上限為10億, 特殊情況請聯絡我們!";
                } else {
                    this.inputDataCheck.AmountThresholdError = false;
                    this.inputDataCheck.AmountThresholdErrorMsg = "";
                }
                this.checkAddVerify();
            }
        },
        // "inputData.StartDate": { //待處理
        //     handler: function () {
        //         if (this.inputData.StartDate == "") {
        //             this.inputDataCheck.StartDateError = true;
        //             this.inputDataCheck.StartDateAndEndDateErrorMsg = "募資時間不得為空";
        //         } else if (this.inputData.StartDate > 1000000000) {
        //             this.inputDataCheck.StartDateError = true;
        //             this.inputDataCheck.StartDateAndEndDateErrorMsg = "";
        //         } else {
        //             this.inputDataCheck.StartDateError = false;
        //             this.inputDataCheck.StartDateAndEndDateErrorMsg = "";
        //         }
        //         this.checkAddVerify();
        //     }
        // },
        // "inputData.EndDate": { //待處理
        //     handler: function () {
        //         if (this.inputData.EndDate == "") {
        //             this.inputDataCheck.EndDateError = true;
        //             this.inputDataCheck.StartDateAndEndDateErrorMsg = "募資時間不得為空";
        //         } else if (this.inputData.EndDate > 1000000000) {
        //             this.inputDataCheck.EndDateError = true;
        //             this.inputDataCheck.StartDateAndEndDateErrorMsg = "";
        //         } else {
        //             this.inputDataCheck.EndDateError = false;
        //             this.inputDataCheck.StartDateAndEndDateErrorMsg = "";
        //         }
        //         this.checkAddVerify();
        //     }
        // },
        "inputData.ProjectVideoUrl": { //缺一個正則
            handler: function () {
                if (this.inputData.ProjectVideoUrl == "") {
                    this.inputDataCheck.ProjectVideoUrlError = true;
                    this.inputDataCheck.ProjectVideoUrlErrorMsg = "專案影片不得為空";
                } else {
                    this.inputDataCheck.ProjectVideoUrlError = false;
                    this.inputDataCheck.ProjectVideoUrlErrorMsg = "";
                }
                this.checkAddVerify();
            }
        },
        "inputData.ProjectPrincipal": {
            handler: function () {
                if (this.inputData.ProjectPrincipal == "") {
                    this.inputDataCheck.ProjectPrincipalError = true;
                    this.inputDataCheck.ProjectPrincipalErrorMsg = "負責人姓名不能為空";
                } else {
                    this.inputDataCheck.ProjectPrincipalError = false;
                    this.inputDataCheck.ProjectPrincipalErrorMsg = "";
                }
                this.checkAddVerify();
            }
        },
        "inputData.MemberConEmail": {
            handler: function () {
                if (this.inputData.MemberConEmail == "") {
                    this.inputDataCheck.MemberConEmailError = true;
                    this.inputDataCheck.MemberConEmailErrorMsg = "電子郵件不能為空";
                } else {
                    this.inputDataCheck.MemberConEmailError = false;
                    this.inputDataCheck.MemberConEmailErrorMsg = "";
                }
                this.checkAddVerify();
            }
        },
        "inputData.MemberPhone": {
            handler: function () {
                let phoneRegexp = /09\d{2}(\d{6}|-\d{3}-\d{3})/;
                if (!phoneRegexp.test(this.inputData.MemberPhone)) {
                    this.inputDataCheck.MemberPhoneError = true;
                    this.inputDataCheck.MemberPhoneErrorMsg = "行動電話格式不對";
                } else if (this.inputData.MemberPhone == "") {
                    this.inputDataCheck.MemberPhoneError = true;
                    this.inputDataCheck.MemberPhoneErrorMsg = "行動電話不能為空";
                } else {
                    this.inputDataCheck.MemberPhoneError = false;
                    this.inputDataCheck.MemberPhoneErrorMsg = "";
                }
                this.checkAddVerify();
            }
        },
        "inputData.IdentityNumber": {
            handler: function () {
                let phoneRegexp = /^09[0-9]{8}$/;
                if (!phoneRegexp.test(this.inputData.IdentityNumber)) {
                    this.inputDataCheck.IdentityNumberError = true;
                    this.inputDataCheck.IdentityNumberErrorMsg = "身分證字號格式不對";
                } else if (this.inputData.IdentityNumber == "") {
                    this.inputDataCheck.IdentityNumberError = true;
                    this.inputDataCheck.IdentityNumberErrorMsg = "身分證字號不能為空";
                } else {
                    this.inputDataCheck.IdentityNumberError = false;
                    this.inputDataCheck.IdentityNumberErrorMsg = "";
                }
                this.checkAddVerify();
            }
        },
        "inputData.MemberName": {
            handler: function () {
                if (this.inputData.MemberName == "") {
                    this.inputDataCheck.MemberNameError = true;
                    this.inputDataCheck.MemberNameErrorMsg = "執行團隊名稱不能為空";
                } else {
                    this.inputDataCheck.MemberNameError = false;
                    this.inputDataCheck.MemberNameErrorMsg = "";
                }
                this.checkAddVerify();
            }
        },
        "inputData.AboutMe": {
            handler: function () {
                if (this.inputData.AboutMe == "") {
                    this.inputDataCheck.AboutMeError = true;
                    this.inputDataCheck.AboutMeErrorMsg = "自我介紹不能為空";
                } else {
                    this.inputDataCheck.AboutMeError = false;
                    this.inputDataCheck.AboutMeErrorMsg = "";
                }
                this.checkAddVerify();
            }
        },
        "inputData.MemberWebsite": {
            handler: function () {
                if (this.inputData.MemberWebsite == "") {
                    this.inputDataCheck.MemberWebsiteError = true;
                    this.inputDataCheck.MemberWebsiteErrorMsg = "專案網站不能為空";
                } else {
                    this.inputDataCheck.MemberWebsiteError = false;
                    this.inputDataCheck.MemberWebsiteErrorMsg = "";
                }
                this.checkAddVerify();
            }
        },
        // "ProjectQuestionAnswer.Question": {
        //     handler: function () {
        //         if (this.ProjectQuestionAnswer.Question == "") {
        //             this.QuestionError = true;
        //             this.QuestionErrorMsg = "專案網站不能為空";
        //         } else {
        //             this.QuestionError = false;
        //             this.QuestionErrorMsg = "";
        //         }
        //         this.checkAddVerify();
        //     }
        // },
        // "ProjectQuestionAnswer.Answer": {
        //     handler: function () {
        //         if (this.ProjectQuestionAnswer.Answer == "") {
        //             this.AnswerError = true;
        //             this.AnswerErrorMsg = "專案網站不能為空";
        //         } else {
        //             this.AnswerError = false;
        //             this.AnswerErrorMsg = "";
        //         }
        //         this.checkAddVerify();
        //     }
        // },
        "modalData.PlanPrice": {
            immediate: false,
            handler: function () {
                if (this.modalData.PlanPrice == "") {
                    this.modalDataCheck.PlanPriceError = true;
                    this.modalDataCheck.PlanPriceErrorMsg = "回饋金額不得為空";
                } else if (this.modalData.PlanPrice > 500000) {
                    this.modalDataCheck.PlanPriceError = true;
                    this.modalDataCheck.PlanPriceErrorMsg = "上限為50萬, 特殊情況請聯絡我們!";
                } else {
                    this.modalDataCheck.PlanPriceError = false;
                    this.modalDataCheck.PlanPriceErrorMsg = "";
                }
                this.checkAddVerifyModal();
            }
        },
        "modalData.PlanTitle": {
            immediate: false,
            handler: function () {
                if (this.modalData.PlanTitle == "") {
                    this.modalDataCheck.PlanTitleError = true;
                    this.modalDataCheck.PlanTitleErrorMsg = "回饋標題不得為空";
                } else {
                    this.modalDataCheck.PlanTitleError = false;
                    this.modalDataCheck.PlanTitleErrorMsg = "";
                }
                this.checkAddVerifyModal();
            }
        },
        "modalData.QuantityLimit": {
            immediate: false,
            handler: function () {
                if (this.modalData.QuantityLimit == "") {
                    this.modalDataCheck.QuantityLimitError = true;
                    this.modalDataCheck.QuantityLimitErrorMsg = "回饋數量限制不得為空";
                } else {
                    this.modalDataCheck.QuantityLimitError = false;
                    this.modalDataCheck.QuantityLimitErrorMsg = "";
                }
                this.checkAddVerifyModal();
            }
        },
        "modalData.PlanShipDateYear": {
            handler: function () {
                if (this.modalData.PlanShipDateYear == "") {
                    this.modalDataCheck.PlanShipDateYearError = true;
                    this.modalDataCheck.PlanShipDateYearErrorMsg = "年份不得為空";
                } else {
                    this.modalDataCheck.PlanShipDateYearError = false;
                    this.modalDataCheck.PlanShipDateYearErrorMsg = "";
                }
                this.checkAddVerifyModal();
            }
        },
        "modalData.PlanDescription": {
            immediate: false,
            handler: function () {
                if (this.modalData.PlanDescription == "") {
                    this.modalDataCheck.PlanDescriptionError = true;
                    this.modalDataCheck.PlanDescriptionErrorMsg = "請填寫回饋方案內容";
                } else {
                    this.modalDataCheck.PlanDescriptionError = false;
                    this.modalDataCheck.PlanDescriptionErrorMsg = "";
                }
                this.checkAddVerifyModal();
            }
        },

    },
    methods: {
        getStartDateAndEndDate(e) {
            if (this.inputData.StartDate == "" || this.inputData.EndDate == "") {
                this.inputDataCheck.StartDateAndEndDateError = true;
                this.inputDataCheck.StartDateAndEndDateErrorMsg = "募資時間必須填妥";
            } else {
                console.log(this.inputData.StartDate);
                console.log(this.inputData.EndDate);
                this.inputDataCheck.StartDateAndEndDateError = false;
                this.inputDataCheck.StartDateAndEndDateErrorMsg = "";
            }
            this.checkAddVerify();
        },
        getTeamPicture(e) {
            //console.log(e.target.files[0]);
            if (e.target.files[0] == undefined) {
                this.inputDataCheck.TeamPictureError = true;
                this.inputDataCheck.TeamPictureErrorMsg = "團隊圖片不能為空";
            } else {
                const reader = new FileReader();
                reader.readAsDataURL(e.target.files[0]);
                reader.onload = () => {
                    this.inputData.TeamPicture = reader.result;
                }

                let formData = new FormData();
                formData.append('image', e.target.files[0]); //required
                imgSwitch = "ProfileImgUrl";
                this.uploadImg(formData, imgSwitch);


                console.log(pmu);
                console.log(pcu);
                console.log(piu);
                console.log(priu);

                


                this.inputDataCheck.TeamPictureError = false;
                this.inputDataCheck.TeamPictureErrorMsg = "";
            }
            this.checkAddVerify();
        },
        getProjectMainUrl(e) {
            //console.log(e.target.files[0]);
            if (e.target.files[0] == undefined) {
                this.inputData.ProjectMainUrl = "";
                this.inputDataCheck.ProjectMainUrlError = true;
                this.inputDataCheck.ProjectMainUrlErrorMsg = "專案封面不能為空";
            } else {
                const reader = new FileReader();
                reader.readAsDataURL(e.target.files[0]);
                reader.onload = () => {
                    this.inputData.ProjectMainUrl = reader.result;
                }

                let formData = new FormData();
                formData.append('image', e.target.files[0]); //required
                imgSwitch = "ProjectMainUrl";
                this.uploadImg(formData, imgSwitch);

                console.log(pmu);
                console.log(pcu);
                console.log(piu);
                console.log(priu);

                


                this.inputDataCheck.ProjectMainUrlError = false;
                this.inputDataCheck.ProjectMainUrlErrorMsg = "";
            }
            this.checkAddVerify();
        },
        getProjectCoverUrl(e) {
            //console.log(e.target.files[0]);
            if (e.target.files[0] == undefined) {
                this.inputData.ProjectCoverUrl = "";
                this.inputDataCheck.ProjectCoverUrlError = true;
                this.inputDataCheck.ProjectCoverUrlErrorMsg = "影片封面預覽不能為空";
            } else {
                const reader = new FileReader();
                reader.readAsDataURL(e.target.files[0]);
                reader.onload = () => {
                    //console.log(reader.result);
                    this.inputData.ProjectCoverUrl = reader.result;
                }

                let formData = new FormData();
                formData.append('image', e.target.files[0]); //required
                imgSwitch = "ProjectCoverUrl";
                this.uploadImg(formData, imgSwitch);


                console.log(pmu);
                console.log(pcu);
                console.log(piu);
                console.log(priu);

                


                this.inputDataCheck.ProjectCoverUrlError = false;
                this.inputDataCheck.ProjectCoverUrlErrorMsg = "";
            }
            this.checkAddVerify();
        },

        getPlanImgUrl(e) {
            if (e.target.files[0] == undefined) {
                this.modalData.PlanImgUrl = "";
                this.modalDataCheck.PlanImgUrlError = true;
                this.modalDataCheck.PlanImgUrlErrorMsg = "回饋封面不能為空";
            } else {
                const reader = new FileReader();
                reader.readAsDataURL(e.target.files[0]);
                reader.onload = () => {
                    //console.log(reader.result);
                    this.modalData.PlanImgUrl = reader.result;
                }

                let formData = new FormData();
                formData.append('image', e.target.files[0]); //required
                imgSwitch = "PlanImgUrl";
                this.uploadImg(formData, imgSwitch);


                console.log(pmu);
                console.log(pcu);
                console.log(piu);
                console.log(priu);

                


                this.modalDataCheck.PlanImgUrlError = false;
                this.modalDataCheck.PlanImgUrlErrorMsg = "";
            }
            this.checkAddVerifyModal();
        },
        checkAddVerify() {
            for (let index in this.inputDataCheck) {
                if (this.inputDataCheck[index] == true) {
                    this.AddVerify = false;
                    return;
                }
            }
            this.AddVerify = true;
        },
        checkAddVerifyModal() {
            for (let index in this.modalDataCheck) {
                if (this.modalDataCheck[index] == true) {
                    this.AddVerify = false;
                    return;
                }
            }
            this.AddVerify = true;
        },
        onChangeYear: function (event) {
            //console.log(this.modalData.PlanShipDateYear);
            //console.log(typeof this.modalData.PlanShipDateYear);
            this.modalData.tempYear = this.modalData.PlanShipDateYear;
        },
        onChangeMonth: function (event) {
            //console.log(this.modalData.PlanShipDateMonth);
            this.modalData.tempMonth = this.modalData.PlanShipDateMonth;
        },
        getCategory() {
            //console.log(this.inputData.Category);
        },
        addItem() {
            let AddCarCarPlan;
            let AddCarCarPlanSwitch;
            let SetPlanId = "set-plan";
            this.modalData.makePlanCount += 1;
            //console.log(this.modalData.AddCarCarPlanSwitch);
            if (this.modalData.AddCarCarPlanSwitch === true) {
                AddCarCarPlanSwitch = "是";
                AddCarCarPlan = true;
            } else {
                AddCarCarPlanSwitch = "否";
                AddCarCarPlan = false;
            }
            SetPlanId += this.modalData.makePlanCount;

            if (this.modalData.PlanShipDateMonth < 10) {
                var newMonth = "0" + this.modalData.PlanShipDateMonth;
            }
            else {
                newMonth = this.modalData.PlanShipDateMonth;
            }

            this.modalList.push({
                ProjectPlanId: this.modalData.makePlanCount,
                ViewId: SetPlanId,
                makePlanCount: this.modalData.makePlanCount,
                PlanPrice: this.modalData.PlanPrice,
                PlanTitle: this.modalData.PlanTitle,
                QuantityLimit: this.modalData.QuantityLimit,
                AddCarCarPlanSwitch: AddCarCarPlanSwitch,
                AddCarCarPlan: AddCarCarPlan,
                PlanDescription: this.modalData.PlanDescription,
                PlanImgUrl: piu,
                PlanShipDateYear: this.modalData.tempYear,
                PlanShipDateMonth: this.modalData.tempMonth,
                PlanShipDate: this.modalData.tempYear + newMonth + "15",
            });
            // console.log(this.modalList);
            this.modalData.PlanPrice = "";
            this.modalData.PlanTitle = "";
            this.modalData.QuantityLimit = "";
            this.modalData.PlanDescription = "";
            // console.log(this.$refs.planpicfileupload.value);
            this.modalData.PlanImgUrl = "";
            this.$refs.planpicfileupload.value = null;
            // document.querySelector(".gray-block").innerHTML = `<img :src="modalData.PlanImgUrl" alt="planImgUrl" width="250px" height="187.5px" class="planPreviewPic">`;
            this.modalData.AddCarCarPlanSwitch = false;
            this.modalData.PlanShipDateYear = "year";
            this.modalData.PlanShipDateMonth = "month";
            this.modalData.tempYear = "";
            this.modalData.tempMonth = "";
            SetPlanId = "set-plan";



            console.log(this.modalList[0].PlanShipDate);
            console.log(this.modalList[1].PlanShipDate);
            //console.log(this.modalList[2].PlanShipDate);
        },
        cancelCleanModal() {
            this.modalData.PlanPrice = "";
            this.modalData.PlanTitle = "";
            this.modalData.QuantityLimit = "";
            this.modalData.PlanDescription = "";
            this.modalData.PlanImgUrl = "";
            this.$refs.planpicfileupload.value = null;
            // document.querySelector(".gray-block").innerHTML = `<img :src="modalData.PlanImgUrl" alt="planImgUrl" width="250px" height="187.5px" class="planPreviewPic">`;
            this.modalData.AddCarCarPlanSwitch = false;
            this.modalData.PlanShipDateYear = "year";
            this.modalData.PlanShipDateMonth = "month";
        },
        submitProposal() {


            for (i = 1; i <= editorImgId; i++) {
                document.querySelector(`#editorImgId${i}`).src = imgurArray[i - 1];
            }


            this.inputData.QuillHtml = splitJoin;
            console.log(this.inputData.QuillHtml);

            this.modalList.shift(); //移掉陣列第一個空的
            this.ProjectQuestionAnswer.shift(); //也是

            console.log(this.modalList[0].PlanShipDate);
            console.log(this.inputData.StartDate.split("-").join(""));
            console.log(this.inputData.EndDate.split("-").join(""));
            //console.log(this.modalList[1].PlanShipDate);
            //console.log(this.modalList[2].PlanShipDate);

            var totalQuestion = "";
            var totalAnswer = "";

            this.ProjectQuestionAnswer.forEach(x => {
                totalQuestion = totalQuestion + "," + x.Question;
                totalAnswer = totalAnswer + "," + x.Answer;
            });
            totalQuestion = totalQuestion.substr(1);
            totalAnswer = totalAnswer.substr(1);


            console.log(pmu);
            console.log(pcu);
            console.log(piu);
            console.log(priu);


            var date = new Date();
            
          


            var UpLoadData = {
                "ProjectName": this.inputData.ProjectName,
                "AmountThreshold": this.inputData.AmountThreshold,
                "Category": this.inputData.Category,
                "StartDate": this.inputData.StartDate.split("-").join(""),
                "EndDate": this.inputData.EndDate.split("-").join(""),
                "ProjectVideoUrl": this.inputData.ProjectVideoUrl,
                "ProjectMainUrl": pmu,
                "ProjectCoverUrl": pcu,
                "ProjectPrincipal": this.inputData.ProjectPrincipal,
                "MemberConEmail": this.inputData.MemberConEmail,
                "MemberPhone": this.inputData.MemberPhone,
                "IdentityNumber": this.inputData.IdentityNumber,
                "ProfileImgUrl": priu,
                "CreatorName": this.inputData.MemberName,
                "AboutMe": this.inputData.AboutMe,
                "MemberWebsite": this.inputData.MemberWebsite,
                "ProjectImgUrl": this.inputData.QuillHtml, //富文本
                "PlanObject": this.modalList,  //陣列包物件
                "ProjectQA": this.ProjectQuestionAnswer,  //陣列包物件
                "Project_Question": totalQuestion,
                "Project_Answer": totalAnswer,
                "CreatedDate": date.toJSON(),
                "SubmittedDate": date.toJSON(),
                "LastEditTime": date.toJSON(),
                "ApprovingStatus": 1,
            }
            // console.log(this.ProjectQuestionAnswer);

            $.ajax({
                url: "/api/projectsubmission/receivedata",
                type: "post",
                //contentType: "application/json; charset=utf-8",
                data: UpLoadData,
                success: function (response) {
                    alert(response);
                }
            });
        },

        uploadImg(formData, imgSwitch) {   //479-481行

            $.ajax({
                url: "/api/projectsubmission/uploadfiles",
                type: "post",
                //contentType: "application/json; charset=utf-8",
                data: formData,
                method: 'post',
                processData: false,
                contentType: false,
                success: function (response) {

                    console.log(response);

                    if (imgSwitch == "ProjectMainUrl") {
                        pmu = response;
                    }
                    else if (imgSwitch == "ProjectCoverUrl") {
                        pcu = response;
                    }
                    else if (imgSwitch == "PlanImgUrl") {
                        piu = response;
                    }
                    else {
                        priu = response;
                    }                    

                }
            });
        },
    }
    });







//quill 編輯器設定
var options = {
    modules: {
        toolbar: [
            [{
                header: [1, 2, 3, false]
            }],
            ['bold', 'italic', 'underline'],
            ['image', 'video'],
            [{
                list: 'ordered'
            }, {
                list: 'bullet'
            }],
            [{
                'color': []
            }, {
                'background': []
            }],
        ]
    },
    theme: 'snow',
};

// 編輯器 new 出來
var quill = new Quill('#editor', options);
quill.formatLine(4, 4, 'align', 'center');
quill.format(
    'color', 'black');

quill.on('text-change', function () {
    splitJoin = quill.root.innerHTML.split("  ").join(" &nbsp;");
    //console.log(splitjoin);
});


quill.getModule("toolbar").addHandler("image", () => {
    this.selectLocalImage();
});

function selectLocalImage() {
    editorImgId++;
    var input = document.createElement("input");
    input.setAttribute("type", "file");
    input.click();
    // Listen upload local image and save to server
    input.onchange = () => {
        const file = input.files[0];

        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => {

            var base64 = reader.result;
            var img = document.createElement("img");
            var qlEditor = document.querySelector(".ql-editor");
            img.src = base64;
            img.id = `editorImgId${editorImgId}`;
            qlEditor.appendChild(img);

        }

        // file type is only image.
        if (/^image\//.test(file.type)) {

            this.saveToServer(file, "image");

            // 胖羽
            // let formData = new FormData();
            // formData.append('image', file); 
            // imgSwitch = "editor";
            // this.uploadImg(formData, imgSwitch);

        } else {
            console.warn("Only images can be uploaded here.");
        }
    };
}


function saveToServer(file) {
    // this.file = e.target.files[0]; // input type="file" 的值
    var name = file.name; // input的圖檔名稱
    var size = Math.floor(file.size * 0.001) + 'KB'; // input的圖片大小
    var thumbnail = window.URL.createObjectURL(file); // input的圖片縮圖
    var title = name; // 預設 input 的圖檔名稱為圖片上傳時的圖片標題

    //let settings = {
    //    async: true,
    //    crossDomain: true,
    //    processData: false,
    //    contentType: false,
    //    type: 'POST',
    //    url: 'https://api.imgur.com/3/image',
    //    headers: {
    //        Authorization: 'Bearer ' + token
    //    },
    //    mimeType: 'multipart/form-data'
    //};

    let form = new FormData();
    form.append('image', file);
    form.append('title', title);
    // form.append('description', des);
    form.append('album', album); // 有要指定的相簿就加這行

    //settings.data = form;

    $.ajax({
        async: true,
        crossDomain: true,
        processData: false,
        contentType: false,
        type: 'post',
        url: 'https://api.imgur.com/3/image',
        headers: {
            Authorization: 'Bearer ' + token
        },
        mimeType: 'multipart/form-data',
        data: form,
        success: function (res) {

            setTimeout(() => {


                console.log(res); // 可以看見上傳成功後回的值
                console.log(JSON.parse(res));
                var jsonObj = JSON.parse(res);  //轉json物件
                console.log(jsonObj.data.link);
                // console.log(JSON.stringify(res));
                alert('上傳完成，稍待一會兒就可以在底部的列表上看見了。');
                url = jsonObj.data.link;  //拿imgur link
                imgurArray.push(url);
                console.log(imgurArray);


            }, 3000);

            
        },
        error: function () {
            alert("失敗");
        }       
    });


    //$.ajax(settings).done(function (res) {
    //    console.log(res); // 可以看見上傳成功後回的值
    //    console.log(JSON.parse(res));
    //    var jsonObj = JSON.parse(res);  //轉json物件
    //    console.log(jsonObj.data.link);
    //    // console.log(JSON.stringify(res));
    //    alert('上傳完成，稍待一會兒就可以在底部的列表上看見了。');
    //    url = jsonObj.data.link;  //拿imgur link
    //    imgurArray.push(url);
    //    console.log(imgurArray);


    //}).fail(function (data) {
    //    alert("Try again champ!");
    //});

    
}

//---------------------------------------------//



//-------彈出 modal 製作-------//

//點下新增一個回饋
var addPlanButton = document.querySelector("#add-plan-button");
addPlanButton.addEventListener("click",
    function (e) {
        e.preventDefault(); //取消預設跳轉
    });

var submitButton = document.querySelector("#submit-button");
submitButton.addEventListener("click",
    function (e) {
        e.preventDefault();
    })


//每次只要 modal消失都讓它為空表單
// var originalModal = $('.modal-body').clone(); //先clone一個空的
// $(".modal").on("hidden.bs.modal", function () {
//     $(".modal-body").html("");
//     var myClone = originalModal.clone();
//     $('.modal-body').append(myClone); //把空的蓋上去
// });

//製作plan卡片
var storePlanCard = document.querySelector("#store-plan-card");
storePlanCard.addEventListener("click",
    function (e) {

        // makePlan();
        hideModal();
    });


//點儲存讓 modal 消失
function hideModal() {
    $(".modal").modal("hide");
}