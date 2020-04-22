using System;

namespace CFE.Entities.Models
{
    public class Form
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
        public string UserId { get; set; }
        // public User User { get; set; }
        // public List<FormResult> FormResults { get; set; }
        // public List<Question> Questions { get; set; }
        // public Form()
        // {
        //     FormResults = new List<FormResult>();
        //     Questions = new List<Question>();
        // }

    }
}
