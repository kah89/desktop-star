using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespaces utilizados na conexão com o banco de dados
using System.Data;
using System.Data.SqlClient;
using AcessoBanco;

namespace TransferenciaDados
{
    public class UsuariosDTO
    {
        int _CodUsuario;
        string _EmailUsuario;
        string _SenhaUsuario;
        string _Logado;
        string _msg;



        public int CodUsuario
        {
            get { return _CodUsuario; }
            set { _CodUsuario = value; }
        }

        public string EmailUsuario
        {
            get { return _EmailUsuario; }
            set { _EmailUsuario = value; }
        }

        public string SenhaUsuario
        {
            get { return _SenhaUsuario; }
            set { _SenhaUsuario = value; }
        }

        public string Logado
        {
            get { return _Logado; }
            set { _Logado = value; }
        }

        public string msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
    }

    public static class LoginSistema
    {
        private static string _EmailUsuario;
        private static string _senhausuario;

        public static string usuario
        {
            get { return _EmailUsuario; }
            set { _EmailUsuario = value; }
        }

        public static string senhausuario
        {
            get { return _senhausuario; }
            set { _senhausuario = value; }
        }
    }

    public class LogadoUsuarios
    {
        public void ValidarUsuario(UsuariosDTO dados)
        {

            //Definir parâmetros para o SQL Server
            //Tratamento de excessões
            try
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", Conexao.obterConexao());
                cmd.CommandType = CommandType.StoredProcedure;
                //popular os parâmentros da Store Procedure
                cmd.Parameters.AddWithValue("@emailusuario", dados.EmailUsuario);
                cmd.Parameters.AddWithValue("@senhausuario", dados.SenhaUsuario);


                //Executar os comandos SQL
                /* int retVal = cmd.ExecuteNonQuery();

                 if (retVal > 0)
                 {
                     dados.msg = "Dados incluídos com sucesso!";
                 }

                 else
                 {
                     dados.msg = "Não foi possível inserir os dados";
                 }*/

                //Utilizar uma tabela temporária
                SqlDataReader dr = cmd.ExecuteReader();

                //Verificar a existência de registros (*linhas)
                if (dr.HasRows)
                {
                    //Percorre os registros
                    while (dr.Read())
                    {
                        //Popular com os dados da de retorno da Stored procedure
                        dados.Logado = dr.GetValue(0).ToString();
                        LoginSistema.usuario = dados.EmailUsuario;
                        LoginSistema.senhausuario = dr.GetValue(1).ToString();

                    }

                    //dados.msg = "Dados incluídos com sucesso";
                }

            }
            catch (SqlException )
            {
                //dados.msg = "Erro - LogadoUsuarios - ValidarUsuario" + e.Message;
            }

        }



        public void DesconectarUsuario(UsuariosDTO dados)
        {

            //Definir parâmetros para o SQL Server
            //Tratamento de excessões
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DesconectarUsuario", Conexao.obterConexao());
                cmd.CommandType = CommandType.StoredProcedure;
                //popular os parâmentros da Store Procedure
                cmd.Parameters.AddWithValue("@emailusuario", dados.EmailUsuario);
                cmd.Parameters.AddWithValue("@senhausuario", dados.SenhaUsuario);


                //Executar os comandos SQL
                /* int retVal = cmd.ExecuteNonQuery();

                 if (retVal > 0)
                 {
                     dados.msg = "Dados incluídos com sucesso!";
                 }

                 else
                 {
                     dados.msg = "Não foi possível inserir os dados";
                 }*/

                //Utilizar uma tabela temporária
                SqlDataReader dr = cmd.ExecuteReader();

                //Verificar a existência de registros (*linhas)
                if (dr.HasRows)
                {
                    //Percorre os registros
                    while (dr.Read())
                    {
                        //Popular com os dados da de retorno da Stored procedure
                        //dados.Logado = dr.GetValue(0).ToString();
                        //LoginSistema.usuario = dados.NomeUsuario;

                    }

                    //dados.msg = "Dados incluídos com sucesso";
                }

            }
            catch (SqlException )
            {
                //dados.msg = "Erro - LogadoUsuarios - ValidarUsuario" + e.Message;
            }

        }
    }

}



