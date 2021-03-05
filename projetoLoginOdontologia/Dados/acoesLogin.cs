using MySql.Data.MySqlClient;
using projetoLoginOdontologia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoLoginOdontologia.Dados
{
    public class acoesLogin
    {
        //chamando a conexão para testar se o usuario e senha estão no banco
        conexao con = new conexao();

        //inicio do métod testar usuário
        public void TestarUsuario(modelLogin user)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbLogin where usuario = @usuario and senha = @Senha", con.MyConectarBD());

            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = user.usuario;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = user.senha;

            //comando que divide os dados selecionados para pegar individualmente
            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.usuario = Convert.ToString(leitor["usuario"]);
                    user.senha = Convert.ToString(leitor["senha"]);
                    user.tipo = Convert.ToString(leitor["tipo"]);
                }
            }

            else
            {
                user.usuario = null;
                user.senha = null;
                user.tipo = null;
            }

            con.MyDesconectarBD();
        }
    }
}