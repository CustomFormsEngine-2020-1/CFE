using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<Form> Forms { get; set; }
        public ICollection<FormResult> FormResults { get; set; }
        public User()
        {
            Forms = new List<Form>();
            FormResults = new List<FormResult>();
        }

    }
}
