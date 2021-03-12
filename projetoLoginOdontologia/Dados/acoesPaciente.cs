using MySql.Data.MySqlClient;
using projetoLoginOdontologia.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace projetoLoginOdontologia.Dados
{
    public class acoesPaciente
    {
        conexao con = new conexao();

        public void inserirPaciente(modelPaciente cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbPaciente values(@codPac, @nomePac, @telPac)", con.MyConectarBD());

            cmd.Parameters.Add("@codPac", MySqlDbType.VarChar).Value = cm.CodPac;
            cmd.Parameters.Add("@nomePac", MySqlDbType.VarChar).Value = cm.NomePac;
            cmd.Parameters.Add("@telPac", MySqlDbType.VarChar).Value = cm.Telpac;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public DataTable consultaPaciente()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbPaciente", con.MyConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable agendaClin = new DataTable();
            da.Fill(agendaClin);
            con.MyDesconectarBD();
            return agendaClin;
        }

        public DataTable buscaPaciente(modelPaciente pac)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbPaciente where codPac=@cod", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@cod", pac.CodPac);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable agendaClin = new DataTable();
            da.Fill(agendaClin);
            con.MyDesconectarBD();
            return agendaClin;
        }



        MySqlDataReader dr;
        public void consultaBuscaPaciente(modelPaciente pac)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbPaciente where codPac=@codPac", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@codPac", pac.CodPac);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                pac.CodPac = dr[0].ToString();

                pac.NomePac = dr[1].ToString();

                pac.Telpac = dr[2].ToString();

            }
            con.MyDesconectarBD();
        }





        public void atualizarPaciente(modelPaciente pac)
        {

            MySqlCommand cmd = new MySqlCommand("update tbPaciente set nomePac=@nomePac, telPac=@telPac where codPac=@codPac", con.MyConectarBD());

            cmd.Parameters.Add("@codPac", MySqlDbType.VarChar).Value = pac.CodPac;
            cmd.Parameters.Add("@nomePac", MySqlDbType.VarChar).Value = pac.NomePac;
            cmd.Parameters.Add("@telPac", MySqlDbType.VarChar).Value = pac.Telpac;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }





        public void excluirPaciente(modelPaciente pac)
        {

            MySqlCommand cmd = new MySqlCommand("delete from tbPaciente where codPac=@codPac", con.MyConectarBD());

            cmd.Parameters.Add("@codPac", MySqlDbType.VarChar).Value = pac.CodPac;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

    }
}