using MySql.Data.MySqlClient;
using projetoLoginOdontologia.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace projetoLoginOdontologia.Dados
{
    public class acoesDentista
    {
        conexao con = new conexao();

        public void inserirDentista(modelDentista cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbDentista values(@codDentista, @nomeDentista, @telDentista, @emailDentista)", con.MyConectarBD());

            cmd.Parameters.Add("@codDentista", MySqlDbType.VarChar).Value = cm.CodDentista;
            cmd.Parameters.Add("@nomeDentista", MySqlDbType.VarChar).Value = cm.NomeDentista;
            cmd.Parameters.Add("@telDentista", MySqlDbType.VarChar).Value = cm.TelDentista;
            cmd.Parameters.Add("@EmailDentista", MySqlDbType.VarChar).Value = cm.EmailDentista;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public DataTable consultaDentista()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbDentista", con.MyConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable agendaClin = new DataTable();
            da.Fill(agendaClin);
            con.MyDesconectarBD();
            return agendaClin;
        }

        public DataTable buscaDentista(modelDentista dent)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbDentista where codDentista=@codDentista", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@codDentista", dent.CodDentista);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable agendaClin = new DataTable();
            da.Fill(agendaClin);
            con.MyDesconectarBD();
            return agendaClin;
        }


        
        MySqlDataReader dr;
        public void consultaBuscaDentista(modelDentista dent)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbDentista where codDentista=@codDentista", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@codDentista", dent.CodDentista);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                dent.CodDentista = dr[0].ToString();

                dent.NomeDentista = dr[1].ToString();

                dent.TelDentista = dr[2].ToString();

                dent.EmailDentista = dr[3].ToString();

            }
            con.MyDesconectarBD();
        }





        public void atualizarDentista(modelDentista dent)
        {

            MySqlCommand cmd = new MySqlCommand("update tbDentista set nomeDentista=@nomeDentista, telDentista=@telDentista, emailDentista=@emailDentista where codDentista=@codDentista", con.MyConectarBD());

            cmd.Parameters.Add("@codDentista", MySqlDbType.VarChar).Value = dent.CodDentista;
            cmd.Parameters.Add("@nomeDentista", MySqlDbType.VarChar).Value = dent.NomeDentista;
            cmd.Parameters.Add("@telDentista", MySqlDbType.VarChar).Value = dent.TelDentista;
            cmd.Parameters.Add("@emailDentista", MySqlDbType.VarChar).Value = dent.EmailDentista;
          
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }



        public void excluirDentista(modelDentista dent)
        {

            MySqlCommand cmd = new MySqlCommand("delete from tbDentista where codDentista=@codDentista", con.MyConectarBD());

            cmd.Parameters.Add("@codDentista", MySqlDbType.VarChar).Value = dent.CodDentista;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

    }
}