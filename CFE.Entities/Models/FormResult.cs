﻿using System;

namespace CFE.Entities.Models
{
    public class FormResult
    {
        public int Id { get; set; }
        public DateTime DTResult { get; set; }
        public int FormId { get; set; }
        // public Form Form { get; set; }
        public string UserId { get; set; }
        // public User User { get; set; }
        // public List<QuestionResult> QuestionResults { get; set; }
        // public FormResult()
        // {
        //     QuestionResults = new List<QuestionResult>();
        // }
    }
}
