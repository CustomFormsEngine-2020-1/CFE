using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.Entities.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FormId { get; set; }
        public Form Form { get; set; }
        public ICollection<QuestionResult> QuestionResults { get; set; }
        public Question()
        {
            QuestionResults = new List<QuestionResult>();
        }

    }
}
