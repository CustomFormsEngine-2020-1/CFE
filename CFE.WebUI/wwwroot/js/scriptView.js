const answerTypeText = 'Text';
const answerTypeNumber = 'Number';
const answerTypeTextarea = 'Textarea';
const answerTypeDate = 'Date';
const answerTypeFile = 'File';
const answerTypeCheckbox = 'Checkbox';
const answerTypeRadiobutton = 'Radiobutton';
const answerTypeDropdown = 'Drop-down';
const answerTypeTime = 'Time';

const answerTypeChoices = [
    answerTypeText,
    answerTypeTextarea,
    answerTypeNumber,
    answerTypeCheckbox,
    answerTypeRadiobutton,
    answerTypeDropdown,
    answerTypeTime,
    answerTypeDate,
    answerTypeFile,

]

const answerTypesToClear = [
    answerTypeText,
    answerTypeNumber,
    answerTypeTextarea,
    answerTypeDate,
    answerTypeFile,
    answerTypeTime
]

const defaultAnswerTemplate = {
    value: 'Answer',
}

function createNewAnswer(Id) {
    const newAnswer = { ...defaultAnswerTemplate };
    newAnswer.value += ` ${Id}`
    return newAnswer
}

const defaultQuestionTemplate = {
    name: "Question",
    answerType: answerTypeCheckbox,
    isRequired: true,
    answers: [{
        value: "aaaa"
    }, {
        value: "bbbb"
    }],
    userAnswer: null
}

window.onload = () => {
    document.body.style.backgroundColor = "lightblue"
}

const changeColor = (color) => {
    document.body.style.backgroundColor = color
}

Vue.component('question', {
    template: `
    <div class="question">
    <form>

        <! –– QUESTION NAME ––>

            <div class="md-form headline-item">
                <p align=center>{{que.name}}</p>
            </div>

            <! –– CHOOSE TYPE OF QUESTION ––>

                <p v-if="que.isRequired" style="color:red">*This question is required</p>

                <! –– ANSWERS ––>


                            <li class="nav-item dropdown nav-my-item" style="list-style-type: none" v-if="que.answerType =='Drop-down'">
                                <div class="nav-link dropdown-toggle nav-my-item" id="navbarDropdown" role="button"
                                    data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    Choose answer
                                </div>
                            <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <button class="dropdown-item" type="button" v-for="(ans, index) in que.answers" v-on:click="que.userAnswer=ans.value">{{ans.value}}</button>
                            </div>
                             </li>
                        <div v-for="(ans, index) in que.answers"
                             style="display: flex;justify-content: space-between; align-items: flex-start;">
                        <div v-if="que.answerType =='Checkbox'" class="input-group mb-3"
                            style="display: flex;">
                            <div class="input-group-prepend">
                                <div class="input-group-text">
                                    <input type="checkbox" aria-label="Checkbox for following text input" v-on:click="updateUserAnswer(index, que)">
                                </div>
                            </div>
                            <p style="margin: 0px 5px 0px 5px; ">{{que.answers[index].value}}</p>
                        </div>

                        <div v-if="que.answerType =='Radiobutton'" class="input-group" style="margin-bottom: 16px;">
                            <div class="input-group-prepend">
                                <div class="input-group-text">
                                    <input type="radio" aria-label="Radio button for following text input"
                                        v-model="que.userAnswer" v-bind:value="que.answers[index].value">
                                </div>
                            </div>
                            <p style="margin: 0px 5px 0px 5px; ">{{que.answers[index].value}}</p>
                        </div>
                    </div>
                        <div class="form-group" v-if="que.answerType =='Text'">
                            <input type="text" id="form1" class="form-control" v-model="que.userAnswer">
                        </div>
                        <div class="form-group" v-if="que.answerType =='Textarea'">
                            <textarea class="form-control" id="exampleFormControlTextarea1" rows="3" v-model="que.userAnswer"></textarea>
                        </div>
                        <div class="form-group" v-if="que.answerType =='Number'">
                            <input type="text" id="form1" class="form-control" pattern="\d*" v-model="que.userAnswer">
                        </div>
                        <div class="form-group row" v-if="que.answerType =='Date'">
                            <div class="col-10">
                                <input class="form-control" type="date" value="2020-04-23" id="example-date-input"
                                    style="width:120%" v-model="que.userAnswer">
                            </div>
                        </div>
                        <div class="form-group row" v-if="que.answerType =='Time'">
                            <div class="col-10">
                                <input class="form-control" type="time" value="12:00:00" id="example-time-input"
                                    style="width:120%" v-model="que.userAnswer">
                            </div>
                        </div>
                        <div class="form-group" v-if="que.answerType =='File'"
                            style="margin-left: 10px; margin-bottom: 0px;">
                            <label style="margin-bottom: 0px;">File input</label>
                        </div>
    </form>
</div>`,
    props: {
        questions: Array,
        que: Object,
        queIndex: Number,
    },
    data() {
        return {
            answerTypeChoices: answerTypeChoices,
            Id: 0,
            check: ""
        }
    },
    methods: {
        updateRequired(event) {
            this.que.isRequired = event.target.value
        },
        addAnswer() {
            this.que.answers.push(createNewAnswer(this.Id++))
        },
        deleteQuestion(event) {
            const indexToDelete = this.questions.indexOf(this.que)
            this.questions.splice(this.queIndex, 1)
        },
        updateText(event) {
            this.que.name = event.target.value
        },
        updateAnswer(event, index) {
            this.que.answers[index].value = event.target.value
        },
        updateAnswerType(type) {
            this.que.answerType = type
            if (answerTypesToClear.indexOf(type) !== -1) {
                const newAnswer = createNewAnswer(this.Id++)
                this.que.answers = [newAnswer]
            }
        },
        duplicate(ans) {
            const ansCopy = { ...ans }
            const index = this.que.answers.indexOf(ans)
            this.que.answers.splice(index, 0, ansCopy)
        },
        deleteAnswer(index) {
            this.que.answers.splice(index, 1)
        },
        updateUserAnswer(index, que) {
            if (!Array.isArray(que.userAnswer)) {
                que.userAnswer = que.userAnswer ? [que.userAnswer] : []
            }
            if (que.userAnswer.includes(que.answers[index].value)) {
                que.userAnswer.splice(que.userAnswer.indexOf(que.answers[index].value), 1)
            }
            else que.userAnswer.push(que.answers[index].value)
        }
    }
})

function createNewQuestion() {
    const newQuestion = JSON.parse(JSON.stringify(defaultQuestionTemplate))
    return newQuestion
}

function transformQuestionsToSendingDataFormat(questions) {
    return questions.map(que => {
        return ({
            QuestionViewModel: {
                Name: que.name
            },
            ElementViewModel: {
                Name: que.answerType
            },
            AttributeViewModel: [{
                Name: "isRequired",
                DisplayName: "Required",
            }],
            AttributeResultViewModel: { Value: que.isRequired },
            AnswerViewModel: que.answers.map(ans => ({ Name: ans.value }))
        })
    })
}

const getData = () => {
    const params = urlParams.get('data');
    const decodedParams = atob(params);
    return JSON.parse(decodedParams);
}

var app = new Vue({
    el: '#app',
    data: {
        formData: {},
        questions: [],
        numberOfQuestions: 0,
    },
    created: function () {
        const urlParams = new URLSearchParams(window.location.search);
        const data = urlParams.get('data');
        const decodedData = atob(data);
        const parsedDecodedData = JSON.parse(decodedData);
        const { questions, ...rest } = parsedDecodedData;

        this.formData = rest;
        this.questions = questions;
        this.numberOfQuestions = questions.length;
        this.initialData = data;
    },
    methods: {
        redirectToEdit() {
            window.location.assign(`Create?data=${this.initialData}`)
        },
        addQuestion() {
            this.questions.push(createNewQuestion());
        },
        updateName(event) {
            this.formData.name = event.target.value
        },
        updateDescription(event) {
            this.formData.description = event.target.value
        },  
        sendData() {
            const localFormData = { ...this.formData };
            const dataToSend = {
                Name: localFormData.name,
                Description: localFormData.description,
                DTCreate: localFormData.dtCreate,
                DTStart: localFormData.dtStart,
                DTFinish: localFormData.dtStop,
                DTResult: localFormData.dtResult,
                IsPrivate: localFormData.isPrivate,
                IsAnonymity: localFormData.isAnonymity,
                IsEditingAfterSaving: localFormData.isEditingAfterSaving,
                QuestionCreateViewModel: transformQuestionsToSendingDataFormat(this.questions)
            }
            const jsonData = JSON.stringify(dataToSend);

            fetch('http://localhost:44378/Form/Create', {
                method: 'POST',
                body: jsonData,
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(response => {
                    alert("Successfully sent data.");
                })
                .catch(e => {
                    alert("Failed to send data. Something went wrong.")
                })

        }
    }
})
