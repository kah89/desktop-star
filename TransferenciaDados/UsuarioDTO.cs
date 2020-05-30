using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AcessoBanco;

namespace TransferenciaDados
{
    public class UsuarioDTO
    {
        string _emailusuario;
        string _senhausuario;
        string _logado;
        string _msg;

        public string emailusuario
        {
            get { return _emailusuario; }
            set { _emailusuario = value; }
        }
        public string senhausuario
        {
            get { return _senhausuario; }
            set { _senhausuario = value; }
        }
        public string logado
        {
            get { return _logado; }
            set { _logado = value; }
        }

        public string msg
        {
            get { return _msg; }
            set { _msg = value; }
        }

    }

    public static class loginSistema
    {
        private static string  _email;
        private static string _senhausuario;

        public static string email
        {
            get { return _email; }
            set { _email = value; }
        }

        public static string senhausuario
        {
            get { return _senhausuario; }
            set { _senhausuario = value; }
        }

    }

    public class LogarUsuario
    {
        public void ValidarUsuario(UsuarioDTO dados)
        {
            //Definir parâmetros para o SQL Server
            //Tratamento de excessões
            try
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuariostar", Conexao.obterConexao());
                cmd.CommandType = CommandType.StoredProcedure;
                //popular os parâmentros da Store Procedure
                cmd.Parameters.AddWithValue("@emailusuario", dados.emailusuario);
                cmd.Parameters.AddWithValue("@SenhaUsuario", dados.senhausuario);






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
                        dados.logado = dr.GetValue(0).ToString();
                        loginSistema.email = dados.emailusuario;
                        loginSistema.senhausuario = dr.GetValue(1).ToString();



                    }

                    // dados.msg = "Dados incluídos com sucesso!";
                }
                // else
                {
                    //dados.msg = "Não foi possível inserir os dados";
                }



            }
            catch (SqlException e)
            {
                dados.msg = "Erro - LogarUsuario - ValidarUsuario" + e.Message;
            }
        }


        public void DesconectarUsuario(UsuarioDTO dados)
        {
            //Definir parâmetros para o SQL Server
            //Tratamento de excessões
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DesconectarUsuario ", Conexao.obterConexao());
                cmd.CommandType = CommandType.StoredProcedure;
                //popular os parâmentros da Store Procedure
                cmd.Parameters.AddWithValue("@emailusuario", dados.emailusuario);
                cmd.Parameters.AddWithValue("@senhausuario", dados.senhausuario);








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
                        // dados.logado = dr.GetValue(0).ToString();
                        // loginSistema.usuario = dados.nomeusuario;



                    }

                    // dados.msg = "Dados incluídos com sucesso!";
                }
                // else
                {
                    //dados.msg = "Não foi possível inserir os dados";
                }



            }
            catch (SqlException e)
            {
                dados.msg = "Erro - LogarUsuario - ValidarUsuario" + e.Message;
            }
        }

    }
}