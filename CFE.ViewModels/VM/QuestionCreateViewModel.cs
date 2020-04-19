using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.ViewModels.VM
{
    public class QuestionCreateViewModel
    {
        public QuestionViewModel QuestionViewModel { get; set; }
        public ElementViewModel ElementViewModel { get; set; }
        public List<AnswerViewModel> AnswerViewModel { get; set; }
        public List<AttributeViewModel> AttributeViewModel { get; set; }
        public List<AttributeResultViewModel> AttributeResultViewModel { get; set; }
    }
}
