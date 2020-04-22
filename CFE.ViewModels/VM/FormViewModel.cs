using System;

namespace CFE.ViewModels.VM
{
    public class FormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DTCreate { get; set; }
        public DateTime? DTStart { get; set; }
        public DateTime? DTFinish { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsAnonymity { get; set; }
        public bool IsEditingAfterSaving { get; set; }
        public string UserId { get; set; } = "1";
    }
}
