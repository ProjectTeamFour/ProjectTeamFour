
    //點選提問直接顯示出答案
    question1 = document.querySelectorAll(".question1");
    question2 = document.querySelectorAll(".question2");
    question3 = document.querySelectorAll(".question3");
    question4 = document.querySelectorAll(".question4");
    question5 = document.querySelectorAll(".question5");
    question6 = document.querySelectorAll(".question6");
    question7 = document.querySelectorAll(".question7");
    question8 = document.querySelectorAll(".question8");
    question9 = document.querySelectorAll(".question9");

        function onQuestionClick(questions) {
        questions[1].click();

        }
        question1[0].addEventListener("click", function () {
        onQuestionClick(question1)
    });
        question2[0].addEventListener("click", function () {
        onQuestionClick(question2)
    });
        question3[0].addEventListener("click", function () {
        onQuestionClick(question3)
    });
        question4[0].addEventListener("click", function () {
        onQuestionClick(question4)
    });
        question5[0].addEventListener("click", function () {
        onQuestionClick(question5)
    });
        question6[0].addEventListener("click", function () {
        onQuestionClick(question6)
    });
        question7[0].addEventListener("click", function () {
        onQuestionClick(question7)
    });
        question8[0].addEventListener("click", function () {
        onQuestionClick(question8)
    });
        question9[0].addEventListener("click", function () {
        onQuestionClick(question9)
    });
       
         //搜索功能(使用jqury)
//搜索功能(使用jqury)
let searchbar = document.querySelector(".form-control");
let cardNodeArray = document.querySelectorAll(".card");
let searchtitle = document.querySelector(".search-title");
let filter = document.querySelector(".filter");


searchbar.addEventListener("change", function () {

    if (searchbar.value != "") {
        filter.innerHTML = "";


        cardNodeArray.forEach(node => {

            if (node.innerText.includes(searchbar.value)) {
                //    console.dir(node);

                searchtitle.innerText = "搜尋結果";
                filter.append(node);

            }
            else {
                if (filter.innerHTML == "") {
                    searchtitle.innerText = "無符合的結果";
                }


            }

        });

    }
    else {
        searchtitle.innerText = "";
        filter.innerHTML = "";
    }


})

