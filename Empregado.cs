using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace local
{
    class Empregado
    {
        private const string stringConexao = "SERVER=localhost; PORT=3308; DATABASE=db_empregado; UID=root; PWD=admin";
        public int Matricula { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }

        public DataTable Pesquisar()
        {
            try
            {
                StringBuilder stringSql = new StringBuilder();
                stringSql.Append("select Matricula, CPF, Nome, Endereco ");
                stringSql.Append("from empregado ");
                stringSql.Append("where 1");

                if (Matricula != 0)
                    stringSql.Append(" and matricula=@matricula");
                if (!Cpf.Equals(""))
                    stringSql.Append(" and cpf=@cpf");
                if (!Nome.Equals(""))
                    stringSql.Append(" and nome like @nome");

                MySqlConnection conexao = new MySqlConnection(stringConexao);
                MySqlCommand comando = new MySqlCommand(stringSql.ToString(), conexao);

                comando.Parameters.AddWithValue("@matricula", Matricula);
                comando.Parameters.AddWithValue("@cpf", Cpf);
                comando.Parameters.AddWithValue("@nome", "%"+Nome+"%");

                MySqlDataAdapter adaptador = new MySqlDataAdapter();
                adaptador.SelectCommand = comando;

                DataTable dados = new DataTable();
                adaptador.Fill(dados);
                return dados;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void Incluir() 
        {
            try
            {
                MySqlConnection conexao = new MySqlConnection(stringConexao);
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexao;
                comando.CommandText = "insert into empregado (cpf, nome, endereco) " +
                                                    "values (@cpf,@nome,@endereco)";
                conexao.Open();
                comando.Prepare();                
                comando.Parameters.AddWithValue("@cpf", Cpf);
                comando.Parameters.AddWithValue("@nome", Nome);
                comando.Parameters.AddWithValue("@endereco", Endereco);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public void Alterar()
        {
            try
            {
                MySqlConnection conexao = new MySqlConnection(stringConexao);
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexao;
                comando.CommandText = "update empregado SET " +
                                             "cpf=@cpf, " +
                                             "nome=@nome, " +
                                             "endereco=@endereco " +
                                       "where matricula=@matricula";
                conexao.Open();
                comando.Prepare();
                comando.Parameters.AddWithValue("@matricula", Matricula);
                comando.Parameters.AddWithValue("@cpf", Cpf);
                comando.Parameters.AddWithValue("@nome", Nome);
                comando.Parameters.AddWithValue("@endereco", Endereco);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Excluir()
        {
            try
            {
                MySqlConnection conexao = new MySqlConnection(stringConexao);
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexao;
                comando.CommandText = "delete from empregado " +
                                            "where matricula=@matricula";
                conexao.Open();
                comando.Prepare();
                comando.Parameters.AddWithValue("@matricula", Matricula);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}