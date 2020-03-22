using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.BLL.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FormId { get; set; }
        public int ElementId { get; set; }
    }
}
