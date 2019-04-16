using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AluraMVC5.Models
{
    public class Usuario
    {
        public Usuario() { }

        public Usuario(string login, string senha, string email)
        {
            Login = login;
            Senha = senha;
            Email = email;
        }

        public int Id { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }
    }
}