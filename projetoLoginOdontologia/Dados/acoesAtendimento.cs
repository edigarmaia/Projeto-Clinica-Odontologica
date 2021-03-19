using MySql.Data.MySqlClient;
using projetoLoginOdontologia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoLoginOdontologia.Dados
{
    public class acoesAtendimento
    {
        conexao con = new conexao();
       
        public void TestarAgenda(modelAtendimento agenda) //verificar se a agenda está reservada
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbAtendimento where dataAtend = @data and horaAtend = @hora", con.MyConectarBD());

            cmd.Parameters.Add("@data", MySqlDbType.VarChar).Value = agenda.dataAtend;
            cmd.Parameters.Add("@hora", MySqlDbType.VarChar).Value = agenda.horaAtend;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    agenda.confAgendamento = "0";
                }

            }

            else
            {
                agenda.confAgendamento = "1";
            }

            con.MyDesconectarBD();
        }

        public void inserirAtendimento(modelAtendimento cm)// Cadastrar o atendimento no BD
        {

            MySqlCommand cmd = new MySqlCommand("insert into tbAtendimento(codAtendimento, dataAtend, horaAtend, codDentista, codPac) values (default, @data, @hora, @codDent, @codPac)", con.MyConectarBD());
            cmd.Parameters.Add("@data", MySqlDbType.VarChar).Value = cm.dataAtend;
            cmd.Parameters.Add("@hora", MySqlDbType.VarChar).Value = cm.horaAtend;
            cmd.Parameters.Add("@codDent", MySqlDbType.VarChar).Value = cm.codDentista;
            cmd.Parameters.Add("@codPac", MySqlDbType.VarChar).Value = cm.codPac;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }




    }
}