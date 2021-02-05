
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
        let searchbar = document.querySelector(".form-control");
        let answerTitle = document.querySelectorAll(".btn-block");
        let filter=document.querySelector(".filter");

        let answer = document.querySelector("#answer");
        let answerrClone=answer.cloneNode(true);
        let answerTitleArray = [];

       searchbar.addEventListener("change",function(){

        answerTitle.forEach(node => {
            if (node.innerText.includes(searchbar.value) && searchbar.value != "") {
                var clonenode = node.cloneNode(true);
                answer.innerHTML = "";
                console.dir(clonenode);
                debugger;
                //   clonenode.forEach(node=>{
                //     answer.appendChild(clonenode);
                //   })



            }
            else if (searchbar.value == "") {
                answer.innerHTML = "";
                answer.appendChild(answerrClone);
            }
        })
    })

