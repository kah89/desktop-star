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
    public class ClientesDTO
    {
        int _codcliente;
        string _nomedocliente;
        string _datanascimento;
        string _CPF;
        string _telefone;
        string _emailusuario;
        string _CEP;
        string _endereco;
        string _cidade;
        string _UF;
        string _como_nos_achou;
        string _msg;

        public int codcliente
        {
            get { return _codcliente; }
            set { _codcliente = value; }
        }
        public string nomedocliente
        {
            get { return _nomedocliente; }
            set { _nomedocliente = value; }
        }
        public string datanascimento
        {
            get { return _datanascimento; }
            set { _datanascimento = value; }
        }
        public string CPF
        {
            get { return _CPF; }
            set { _CPF = value; }
        }
        public string telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }
        public string emailusuario
        {
            get { return _emailusuario; }
            set { _emailusuario = value; }
        }

        public string CEP
        {
            get { return _CEP; }
            set { _CEP = value; }
        }

        public string endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }

        public string cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }

        public string UF
        {
            get { return _UF; }
            set { _UF = value; }
        }

        public string como_nos_achou
        {
            get { return _como_nos_achou; }
            set { _como_nos_achou = value; }
        }

        public string msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
    }

    public class SalvarCliente
    {
        public void IncluirClientes(ClientesDTO dados)
        {
            //Definir parâmetros para o SQL Server
            //Tratamento de excessões
            try
            {
                SqlCommand cmd = new SqlCommand("sp_IncluirClientes",Conexao.obterConexao());
                cmd.CommandType = CommandType.StoredProcedure;
                //popular os parâmentros da Store Procedure
                cmd.Parameters.AddWithValue("@nomedocliente", dados.nomedocliente);
                cmd.Parameters.AddWithValue("@datanascimento", dados.datanascimento);
                cmd.Parameters.AddWithValue("@CPF", dados.CPF);
                cmd.Parameters.AddWithValue("@telefone", dados.telefone);
                cmd.Parameters.AddWithValue("@email", dados.emailusuario);
                cmd.Parameters.AddWithValue("@CEP", dados.CEP);
                cmd.Parameters.AddWithValue("@endereco", dados.endereco);
                cmd.Parameters.AddWithValue("@cidade", dados.cidade);
                cmd.Parameters.AddWithValue("@UF", dados.UF);
                cmd.Parameters.AddWithValue("@como_nos_achou", dados.como_nos_achou);


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
                        dados.codcliente = Convert.ToInt32(dr.GetValue(0).ToString());

                    }

                    dados.msg = "Dados incluídos com sucesso!";
                }
                else
                {
                    dados.msg = "Não foi possível inserir os dados";
                }



            }
            catch (SqlException e)
            {
                dados.msg = "Erro - SalvarCliente - IncluirCliente" + e.Message;
            }
        }

    }
}

