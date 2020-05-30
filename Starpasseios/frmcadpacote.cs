using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferenciaDados;

namespace Starpasseios
{
    public partial class frmcadpacote : Form
    {
        public frmcadpacote()
        {
            InitializeComponent();
        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void frmcadpacote_Load(object sender, EventArgs e)
        {

        }

        private void btnok_Click(object sender, EventArgs e)
        {
            //Verificar se os campos foram preenchidos

            if (txtnomepacote.Text == string.Empty)
            {
                MessageBox.Show("Favor preencher o campo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtnomepacote.Focus();
            }


            //Instaciar as classes do clientesDTO
           PacoteDTO dados = new PacoteDTO();
           SalvarPacotes salvar = new SalvarPacotes();

            //popular
            //dados.codigocliente = Convert.ToInt32(txtCodigo.Text);
            dados.destinopacote = txtnomepacote.Text;
            dados.datasaida = mskdatasaida.Text;
            dados.dataretorno = mskdataretorno.Text;
            dados.horariosaida = txths.Text;
            dados.horarioretorno = txthr.Text;
            dados.descricapacote = txtdescricao.Text;
           
       

            //Chamar o método para gravar os dados
            salvar.IncluirPacotes(dados);



            //Mensagem de retorno da DTO
            MessageBox.Show(dados.msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtcodpacote.Text = dados.cod_pacote.ToString();



            //Limpar os campos
            txtcodpacote.Clear();
            txtnomepacote.Clear();
            mskdatasaida.Clear();
            mskdataretorno.Clear();
            txths.Clear();
            txthr.Clear();
            txtdescricao.Clear();
          
        }

        private void txtnomevendedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btncadcliente_Click(object sender, EventArgs e)
        {
            frmcadcliente formCliente = new frmcadcliente();
            formCliente.ShowDialog();
        }

        private void btncadvendedor_Click(object sender, EventArgs e)
        {
            frmvendedor formVendedor = new frmvendedor();
            formVendedor.ShowDialog();

        }
    }
}
