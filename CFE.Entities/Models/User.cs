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
        // public List<Form> Forms { get; set; }
        // public List<FormResult> FormResults { get; set; }
        // public User()
        // {
        //     Forms = new List<Form>();
        //     FormResults = new List<FormResult>();
        // }

    }
}
