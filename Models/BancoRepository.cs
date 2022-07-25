using System;
using System.Collections.Generic;
using MySqlConnector;
using Microsoft.AspNetCore.Http;
namespace TENTATIVA2.Models
{
    public class BancoRepository
    {   
      // LINKANDO MINHA BASE DE DADOS
      private string enderecoConexao = "Server=localhost;Database=lojaonline;Uid=root;Pwd=root;";

    // **----------------*MODELS PARA USUÁRIOS***

    public void Insert(Usuarios usuarios)
    {
      // CRIANDO A CONEXÃO
      MySqlConnection conexao = new MySqlConnection(enderecoConexao);
      // ABRINDO A CONEXÃO
      conexao.Open();
      // CRIANDO O COMANDO
      MySqlCommand comando = new MySqlCommand();
      // SETANDO A CONEXÃO
      comando.Connection = conexao;
      // SETANDO O COMANDO
      comando.CommandText = "INSERT INTO usuarios (nomeUsuario, loginUsuario, senhaUsuario) VALUES (@nomeUsuario, @loginUsuario, @senhaUsuario)";
      // SETANDO OS PARAMETROS
      comando.Parameters.AddWithValue("@nomeUsuario", usuarios.nomeUsuario);
      comando.Parameters.AddWithValue("@loginUsuario", usuarios.loginUsuario);
      comando.Parameters.AddWithValue("@senhaUsuario", usuarios.senhaUsuario);
      // EXECUTANDO O COMANDO
      comando.ExecuteNonQuery();
      // FECHANDO A CONEXÃO
      conexao.Close();
    }

    // ***LISTANDO USUÁRIOS***
    public List<Usuarios> ListarUsuarios()
    {
      // CRIANDO A CONEXÃO
      MySqlConnection conexao = new MySqlConnection(enderecoConexao);
      // ABRINDO A CONEXÃO
      conexao.Open();
      // CRIANDO O COMANDO
      MySqlCommand comando = new MySqlCommand();
      // SETANDO A CONEXÃO
      comando.Connection = conexao;
      // SETANDO O COMANDO
      comando.CommandText = "SELECT * FROM usuarios";
      // CRIANDO UM LETROER
      MySqlDataReader leitor = comando.ExecuteReader();
      // CRIANDO UMA LISTA DE USUÁRIOS
      List<Usuarios> listaUsuarios = new List<Usuarios>();
      // LAPARO PARA LER OS DADOS
      while (leitor.Read())
      {
        // CRIANDO UM USUÁRIO
        Usuarios usuarios = new Usuarios();
        // SETANDO OS DADOS
        usuarios.id_usuarios = Convert.ToInt32(leitor["id_usuarios"]);
        usuarios.nomeUsuario = leitor["nomeUsuario"].ToString();
        usuarios.loginUsuario = leitor["loginUsuario"].ToString();
        usuarios.senhaUsuario = leitor["senhaUsuario"].ToString();
        // ADICIONANDO O USUÁRIO NA LISTA
        listaUsuarios.Add(usuarios);
       }
      // FECHANDO A CONEXÃO
      conexao.Close();
      // RETORNANDO A LISTA DE USUÁRIOS
      return listaUsuarios;
      
      }

    // *ALTERAR USUÁRIOS*
    public void Alterar (Usuarios usuarios ){
      // CRIANDO A CONEXÃO
      MySqlConnection conexao = new MySqlConnection(enderecoConexao);
      // ABRINDO A CONEXÃO
      conexao.Open();
      // CRIANDO O COMANDO
      MySqlCommand comando = new MySqlCommand();
      // SETANDO A CONEXÃO
      comando.Connection = conexao;
      // SETANDO O COMANDO
      comando.CommandText = "UPDATE usuarios SET nomeUsuario = @nomeUsuario, loginUsuario = @loginUsuario, senhaUsuario = @senhaUsuario WHERE id_usuarios = @id_usuarios";
      // SETANDO OS PARAMETROS
      comando.Parameters.AddWithValue("@id_usuarios", usuarios.id_usuarios);
      comando.Parameters.AddWithValue("@nomeUsuario", usuarios.nomeUsuario);
      comando.Parameters.AddWithValue("@loginUsuario", usuarios.loginUsuario);
      comando.Parameters.AddWithValue("@senhaUsuario", usuarios.senhaUsuario);
      // EXECUTANDO O COMANDO
      comando.ExecuteNonQuery();
      // FECHANDO A CONEXÃO
      conexao.Close();
    }

    /*EXCLUIR USUÁRIOS*/
     public void Excluir(int id_usuarios){
    
    MySqlConnection conexao = new MySqlConnection(enderecoConexao);
    
    conexao.Open();

    string sqlDelete = "DELETE FROM usuarios WHERE id_usuarios = @id_usuarios";

    MySqlCommand comando = new MySqlCommand(sqlDelete, conexao);

    comando.Parameters.AddWithValue("@id_usuarios", id_usuarios);

    comando.ExecuteNonQuery();

    conexao.Close();  
    }

    // *RETORNO DE USUÁRIOS*
    public Usuarios RetornoUsuario (int id_usuarios){
      // CRIANDO A CONEXÃO
      MySqlConnection conexao = new MySqlConnection(enderecoConexao);
      // ABRINDO A CONEXÃO
      conexao.Open();
      // CRIANDO O COMANDO
      MySqlCommand comando = new MySqlCommand();
      // SETANDO A CONEXÃO
      comando.Connection = conexao;
      // SETANDO O COMANDO
      comando.CommandText = "SELECT * FROM usuarios WHERE id_usuarios = @id_usuarios";
      // SETANDO OS PARAMETROS
      comando.Parameters.AddWithValue("@id_usuarios", id_usuarios);
      // CRIANDO UM LETROER
      MySqlDataReader leitor = comando.ExecuteReader();
      // CRIANDO UM USUÁRIO
      Usuarios usuarios = new Usuarios();
      // LAPARO PARA LER OS DADOS
      while (leitor.Read())
      {
        // SETANDO OS DADOS
        usuarios.id_usuarios = Convert.ToInt32(leitor["id_usuarios"]);
        usuarios.nomeUsuario = leitor["nomeUsuario"].ToString();
        usuarios.loginUsuario = leitor["loginUsuario"].ToString();
        usuarios.senhaUsuario = leitor["senhaUsuario"].ToString();
      }
      // FECHANDO A CONEXÃO
      conexao.Close();
      // RETORNANDO O USUÁRIO
      return usuarios;
    }

    }
}