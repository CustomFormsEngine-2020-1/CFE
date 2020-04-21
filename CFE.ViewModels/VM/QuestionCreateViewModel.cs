using System.Collections.Generic;

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
