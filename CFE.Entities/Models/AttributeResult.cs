using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.Entities.Models
{
    public class AttributeResult
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int AttributeId { get; set; }
        public Attribute Attribute { get; set; }

    }
}
