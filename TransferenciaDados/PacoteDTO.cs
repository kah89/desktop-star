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
   public class PacoteDTO
    {
        int _cod_pacote;
        string _destinopacote;
        string _datasaida;
        string _dataretorno;
        string _horariosaida;
        string _horarioretorno;
        string _descricapacote;
        string _msg;

        public int cod_pacote
        {
            get { return _cod_pacote; }
            set { _cod_pacote = value; }
        }
        public string destinopacote
        {
            get { return _destinopacote; }
            set { _destinopacote = value; }
        }
        public string datasaida
        {
            get { return _datasaida; }
            set { _datasaida = value; }
        }
        public string dataretorno
        {
            get { return _dataretorno; }
            set { _dataretorno = value; }
        }
        public string horariosaida
        {
            get { return _horariosaida; }
            set { _horariosaida = value; }
        }
        public string horarioretorno
        {
            get { return _horarioretorno; }
            set { _horarioretorno = value; }
        }

        public string descricapacote
        {
            get { return _descricapacote; }
            set { _descricapacote = value; }
        }

        public string msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
    }

    public class SalvarPacotes
    {
        public void IncluirPacotes (PacoteDTO dados)
        {
            //Definir parâmetros para o SQL Server
            //Tratamento de excessões
            try
            {
                SqlCommand cmd = new SqlCommand("sp_IncluirPacotes", Conexao.obterConexao());
                cmd.CommandType = CommandType.StoredProcedure;
                //popular os parâmentros da Store Procedure
                cmd.Parameters.AddWithValue("@destinopacote", dados.destinopacote);
                cmd.Parameters.AddWithValue("@datasaida", dados.datasaida);
                cmd.Parameters.AddWithValue("@dataretorno", dados.dataretorno);
                cmd.Parameters.AddWithValue("@horariosaida", dados.horariosaida);
                cmd.Parameters.AddWithValue("@horarioretorno", dados.horarioretorno);
                cmd.Parameters.AddWithValue("@descricapacote", dados.descricapacote);



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
                        dados.cod_pacote = Convert.ToInt32(dr.GetValue(0).ToString());

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
                dados.msg = "Erro - SalvarPacotes - IncluirPacotes " + e.Message;
            }
        }

    }
}
