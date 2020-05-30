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
    public class VendedorDTO
    {
        int _cod_vendedor;
        string _nomevendedor;
        string _emailvendedor;
        string _datanascimento;
        string _CPF;
        string _telefone;
        string _endereco;
        string _cidade;
        string _UF; 
        string _CEP;
        string _msg;

        public int cod_vendedor
        {
            get { return _cod_vendedor; }
            set { _cod_vendedor = value; }
        }
        public string nomevendedor
        {
            get { return _nomevendedor; }
            set { _nomevendedor = value; }
        }
        public string emailvendedor
        {
            get { return _emailvendedor; }
            set { _emailvendedor = value; }
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

        public string CEP
        {
            get { return _CEP; }
            set { _CEP = value; }
        }

        public string msg
        {
            get { return _msg; }
            set { _msg = value; }
        }


    }


    public class SalvarVendedor
    {
        public void IncluirVendedor(VendedorDTO dados)
        
        {
            //Definir parâmetros para o SQL Server
            //Tratamento de excessões
            try
            {
                SqlCommand cmd = new SqlCommand("sp_IncluirVendedor", Conexao.obterConexao());
                cmd.CommandType = CommandType.StoredProcedure;
                //popular os parâmentros da Store Procedure
                cmd.Parameters.AddWithValue("@nomevendedor", dados.nomevendedor);
                cmd.Parameters.AddWithValue("@emailvendedor", dados.emailvendedor);
                cmd.Parameters.AddWithValue("@datanascimento", dados.datanascimento);
                cmd.Parameters.AddWithValue("@CPF", dados.CPF);
                cmd.Parameters.AddWithValue("@telefone", dados.telefone);
                cmd.Parameters.AddWithValue("@endereco", dados.endereco);
                cmd.Parameters.AddWithValue("@cidade", dados.cidade);
                cmd.Parameters.AddWithValue("@UF", dados.UF);
                cmd.Parameters.AddWithValue("@CEP", dados.CEP);


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
                        dados.cod_vendedor = Convert.ToInt32(dr.GetValue(0).ToString());

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
                dados.msg = "Erro - SalvarVendedor - IncluirVendedor" + e.Message;
            }
        }

    }

}
