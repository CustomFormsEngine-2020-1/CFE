﻿using Microsoft.AspNetCore.Identity;

namespace CFE.Entities.Models
{
    public class User : IdentityUser
    {
        public string Id { get; set; }
        // public string Login { get; set; }
        public string Password { get; set; }
        //  public string Email { get; set; }
        // public List<Form> Forms { get; set; }
        // public List<FormResult> FormResults { get; set; }
        // public User()
        // {
        //     Forms = new List<Form>();
        //     FormResults = new List<FormResult>();
        // }

    }
}
