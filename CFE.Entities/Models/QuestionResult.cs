using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.Entities.Models
{
    public class QuestionResult
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int FormResultId { get; set; }
        public FormResult FormResult { get; set; }
     //   public List<AnswerResult> AnswerResults { get; set; }
        //public QuestionResult()
        //{
        //    AnswerResults = new List<AnswerResult>();
        //}
    }
}
