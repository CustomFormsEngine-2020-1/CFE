window.onload = () => {
    document.body.style.backgroundColor = "lightblue"
}

const changeColor = (color) => {
    document.body.style.backgroundColor = color
}

var question = new Vue({
    el: '#question',
    data: {
        text: 'Question',
        answers: [],
        answerType: 'Checkbox',
        isRequired: true,
        Id: 0
    },
    methods: {
        updateText(event) {
            this.text = event.target.value
        },
        updateAnswer(event, index) {
            this.answers.splice(index, 1, event.target.value)
        },
        updateAnswerType(type) {
            this.answerType = type
        },
        duplicate(ans) {
            const index = this.answers.indexOf(ans)
            this.answers.push("Input answer")
            for (let i = this.answers.length; i > index; i--)
                this.answers[i] = this.answers[i - 1]
            this.answers.pop()
        },
        deleteAnswer(index) {
            for (let i = index; i < this.answers.length; i++)
                this.answers[i] = this.answers[i + 1]
            this.answers.pop()
        }
    }
})

var headline = new Vue({
    el: '#headline',
    data: {
        name: 'New form',
        description: 'Description',
        dtCreate: new Date,
        dtStart: new Date,
        dtStop: new Date,
        dtResult: new Date,
        isPrivate: false,
        isAnonymity: false,
        isEditingAfterSaving: false
    },
    methods: {
        updateName(event) {
            this.name = event.target.value
        },
        updateDescription(event) {
            this.description = event.target.value
        }
    }
})
