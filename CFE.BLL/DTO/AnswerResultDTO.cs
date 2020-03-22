using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.BLL.DTO
{
    public class AnswerResultDTO
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int QuestionResultId { get; set; }
    }
}
