using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

using AcessoBanco.Properties;

namespace AcessoBanco
{
    public class Conexao
    {
        //Definir variável de conexão
        private static string strConn = Settings.Default.strconexao;

        // Representação de conexão com o banco de dados
        private static SqlConnection conn = null;

        //Método responsável pela conexão (Acesso ao SQL Server e abrir o banco de dados)

        public static SqlConnection obterConexao()
        {
            //Instanciar 
            conn = new SqlConnection(strConn);

            //Tratamento de Excessões
            try
            {
                // abre a conexão e a devolve ao chamador do método
                conn.Open();
            }
            catch (SqlException e)
            {
                // retorna a variável como nulo
                conn = null;
                // apresentar a mensagem de excessão
                throw e;
            }

            return conn;
        }

        //Método responsável por fechar conexão com o banco de dados
        public static SqlConnection fecharConexao()
        {

            //Tratamento de Excessões
            try
            {
                // fecha a conexão e a devolve ao chamador do método
                conn.Close();
            }
            catch (SqlException e)
            {
                // retorna a variável como nulo
                conn = null;
                // apresentar a mensagem de excessão
                throw e;
            }

            return conn;
        }


    }
}

