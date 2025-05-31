using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodGuardian.Domain.Models;


[Table("User_FloodGuardian")]
public class User
{
    public Guid Id { get; set; }

    public string Nome { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public void SetPassword(string password)
    {
        Password = BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool CheckPassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, Password);
    }
}
