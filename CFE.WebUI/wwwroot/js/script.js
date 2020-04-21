const answerTypeText = 'Text';
const answerTypeNumber = 'Number';
const answerTypeTextarea = 'Textarea';
const answerTypeDate = 'Date';
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

]

const answerTypesToClear = [
    answerTypeText,
    answerTypeNumber,
    answerTypeTextarea,
    answerTypeDate,
    answerTypeTime
]

const defaultAnswerTemplate = {
    value: 'Answer',
}

function createNewAnswer(Id) {
    const newAnswer = { ...defaultAnswerTemplate };
    newAnswer.value += ` ${Id}`;
    return newAnswer;
}

const defaultQuestionTemplate = {
    name: "Question",
    answerType: answerTypeCheckbox,
    isRequired: true,
    answers: []
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
                <input type="text" id="form1" class="form-control" v-on:input="updateText" v-bind:value="que.name">
            </div>

            <! –– CHOOSE TYPE OF QUESTION ––>

                <li class="nav-item dropdown nav-my-item" style="list-style-type: none; display: flex;
                align-items: flex-end; justify-content: flex-start;">
                    <div class="nav-link dropdown-toggle nav-my-item" id="navbarDropdown" data-toggle="dropdown"
                        aria-haspopup="true" aria-expanded="false">
                        {{que.answerType}}
                    </div>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                        <button v-for="type in answerTypeChoices" class="dropdown-item" v-on:click="updateAnswerType(type)"
                            type="button">{{type}}</button>
                    </div>
                    <div >
                    <input type="checkbox" value="" v-model="que.isRequired">
                    <label>
                      Required
                    </label>
                  </div>
                </li>

                <! –– ANSWERS ––>

                    <div v-for="(ans, index) in que.answers"
                        style="display: flex;justify-content: space-between; align-items: center;">
                        <input v-if="que.answerType =='Drop-down'" type="text" class="form-control"
style="display: flex; justify-content: space-between; margin-bottom: 0px; margin-right: 5px;"
                            aria-label="Text input with checkbox" v-on:input="updateAnswer($event, index)"
                            value='Input answer' v-bind:value="ans.value"
                            >

                        <div v-if="que.answerType =='Checkbox'" class="input-group"
                            style="display: flex; justify-content: space-between; margin-bottom: 0px;">
                            <div class="input-group-prepend" >
                                <div class="input-group-text" style="padding: .375rem .75rem; border: 1px solid #ced4da; border-right: none;">
                                    <input type="checkbox" aria-label="Checkbox for following text input">
                                </div>
                            </div>
                            <input type="text" class="form-control" aria-label="Text input with checkbox"
                                v-on:input="updateAnswer($event, index)" value='Input answer' v-bind:value="ans.value"
                                style="margin: 0px 5px 0px 0px;">
                        </div>

                        <div v-if="que.answerType =='Radiobutton'"  class="input-group"
                            style="display: flex; justify-content: space-between; margin-bottom: 0px;">
                            <div class="input-group-prepend">
                                <div class="input-group-text" style="padding: .375rem .75rem; border: 1px solid #ced4da; border-right: none;">
                                    <input type="radio" aria-label="Radio button for following text input"
                                        v-model="check" v-bind:value="index">
                                </div>
                            </div>
                            <input type="text" class="form-control" aria-label="Text input with radio button"
                                v-on:input="updateAnswer($event, index)" value='Input answer' v-bind:value="ans.value"
                                style="margin: 0px 5px 0px 0px;">
                        </div>
                        <button type="button" class="btn btn-primary" v-on:click="duplicate(ans)"
                            style="margin-right: 5px;"
                            v-if="que.answerType =='Radiobutton' || que.answerType =='Checkbox' || que.answerType =='Drop-down'">Duplicate</button>
                        <button type="button" class="btn btn-danger" v-on:click="deleteAnswer(index)"
                            v-if="que.answerType =='Radiobutton' || que.answerType =='Checkbox' || que.answerType =='Drop-down'">Delete</button>
                    </div>
                        <div class="form-group" v-if="que.answerType =='Text'">
                            <input type="text" id="form1" class="form-control">
                        </div>
                        <div class="form-group" v-if="que.answerType =='Textarea'">
                            <textarea class="form-control" id="exampleFormControlTextarea1" rows="3" ></textarea>
                        </div>
                        <div class="form-group" v-if="que.answerType =='Number'">
                            <input type="text" id="form1" class="form-control" >
                        </div>
                        <div class="form-group row" v-if="que.answerType =='Date'">
                            <div class="col-10">
                                <input class="form-control" type="date" value="2020-04-23" id="example-date-input"
                                    style="width:120%"  >
                            </div>
                        </div>
                        <div class="form-group row" v-if="que.answerType =='Time'">
                            <div class="col-10">
                                <input class="form-control" type="time" value="12:00:00" id="example-time-input"
                                    style="width:120%"  >
                            </div>
                        </div>
                        <div class="form-group" v-if="que.answerType =='File'"
                            style="margin-left: 10px; margin-bottom: 0px;">
                            <label style="margin-bottom: 0px;">File input</label>
                        </div>
                    <! –– ADD ––>
                        <div style="display: flex; justify-content: space-between">
                                    <div class="nav-link nav-my-item"
                                        v-if="que.answerType =='Radiobutton' || que.answerType =='Checkbox' || que.answerType =='Drop-down'">
                                        <button type="button" class="btn btn-primary"
                                            style="margin-left:-5px; display: flex; justify-content: flex-start;"
                                            v-on:click="addAnswer()">Add answer</button>
                                    </div>
                                    <button type="button" class="btn btn-danger" v-on:click="deleteQuestion()"
                                        style="height: 38; margin-right: 8px; margin-top: 8px;">Delete
                                        question</button>
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
    created: function () {
        this.Id = (this.que && this.que.answers && this.que.answers.length) || 0;
    },
    methods: {
        updateRequired(event) {
            this.que.isRequired = event.target.value
        },
        addAnswer() {
            this.que.answers.push(createNewAnswer(this.Id++))
        },
        deleteQuestion(event) {
            const indexToDelete = this.questions.indexOf(this.que);
            this.questions.splice(this.queIndex, 1);
        },
        updateText(event) {
            this.que.name = event.target.value;
        },
        updateAnswer(event, index) {
            this.que.answers[index].value = event.target.value;
        },
        updateAnswerType(type) {
            this.que.answerType = type
            if (answerTypesToClear.indexOf(type) !== -1) {
                const newAnswer = createNewAnswer(this.Id++);
                this.que.answers = [newAnswer]
            }
        },
        duplicate(ans) {
            const ansCopy = { ...ans };
            const index = this.que.answers.indexOf(ans)
            this.que.answers.splice(index, 0, ansCopy);
        },
        deleteAnswer(index) {
            this.que.answers.splice(index, 1);
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

var app = new Vue({
    el: '#app',
    data: {
        formData: {
            name: 'Form name',
            description: 'Description',
            dtCreate: new Date,
            dtStart: new Date,
            dtStop: new Date,
            dtResult: new Date,
            isPrivate: false,
            isAnonymity: false,
            isEditingAfterSaving: false
        },
        questions: [createNewQuestion()],
        numberOfQuestions: 1,
    },
    created: function () {
        const urlParams = new URLSearchParams(window.location.search);
        const data = urlParams.get('data');
        if (data) {
            const decodedData = atob(data);
            const parsedDecodedData = JSON.parse(decodedData);
            const { questions, ...rest } = parsedDecodedData;

            this.formData = rest;
            this.questions = questions;
            this.numberOfQuestions = questions.length;
        }
    },
    methods: {
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

        },
        redirectToView() {
            const encodedUrl = btoa(JSON.stringify({ ...this.formData, questions: this.questions }));
            window.location.assign(`FormView?data=${encodedUrl}`)
        }
    }
})
