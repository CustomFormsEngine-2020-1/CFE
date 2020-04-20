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
        public int ElementId { get; set; }
        public Element Element { get; set; }
     //   public List<QuestionResult> QuestionResults { get; set; }
      //  public List<Answer> Answers { get; set; }
        //public Question()
        //{
        //    QuestionResults = new List<QuestionResult>();
        //    Answers = new List<Answer>();
        //}

    }
}
