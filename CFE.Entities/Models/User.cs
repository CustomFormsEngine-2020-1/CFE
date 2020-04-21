using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFE.Entities.Models
{
    public class User : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Password { get; set; }
        // public List<Form> Forms { get; set; }
        // public List<FormResult> FormResults { get; set; }
        // public User()
        // {
        //     Forms = new List<Form>();
        //     FormResults = new List<FormResult>();
        // }

    }
}
