using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.Entities.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuestionId { get; set; }
        // public Question Question { get; set; }

    }
}
