using System;
using System.Collections.Generic;
using MySqlConnector;
using Microsoft.AspNetCore.Http;
namespace TENTATIVA2.Models
{
    public class Produtos
    {
      public int id_produtos { get; set; }
      public string nome { get; set; }
      public double valor { get; set; }
      public string descricao { get; set; }
    }
}