using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.Entities.Models
{
    public class Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int ElementId { get; set; }
        // public Element Element { get; set; }

    }
}
