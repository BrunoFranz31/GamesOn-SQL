using System;
using System.Collections.Generic;
using MySqlConnector;
using Microsoft.AspNetCore.Http;
namespace TENTATIVA2.Models
{
    public class Usuarios
    {
        public int id_usuarios { get; set; }
        public string nomeUsuario { get; set; }
        public string loginUsuario { get; set; }
        public string senhaUsuario { get; set; } 
    }
}