using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.ViewModels.VM
{
    public class FormViewModel
    {
        // public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DTCreate { get; set; }
        public string DTStart { get; set; }
        public string DTFinish { get; set; }
        public string IsPrivate { get; set; }
        public string IsAnonymity { get; set; }
        public string IsEditingAfterSaving { get; set; }
        // public int UserId { get; set; }
    }
}
