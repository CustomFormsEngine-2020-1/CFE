﻿using System.Collections.Generic;

namespace CFE.ViewModels.VM
{
    public class FormCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DTCreate { get; set; }
        public string DTStart { get; set; }
        public string DTFinish { get; set; }
        public string IsPrivate { get; set; }
        public string IsAnonymity { get; set; }
        public string IsEditingAfterSaving { get; set; }
        public string UserId { get; set; } = "1";
        public List<QuestionCreateViewModel> QuestionCreateViewModel { get; set; }

    }
}
