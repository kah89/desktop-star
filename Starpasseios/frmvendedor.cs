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
using TransferenciaDados.br.com.correios.apps;
using System.Web.Services.Protocols;



namespace Starpasseios
{
    public partial class frmvendedor : Form
    {
        public frmvendedor()
        {
            InitializeComponent();
        }

        private void lbluf_Click(object sender, EventArgs e)
        {

        }

        private void frmvendedor_Load(object sender, EventArgs e)
        {

        }

        private void lblcadvend_Click(object sender, EventArgs e)
        {

        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btncadvend_Click(object sender, EventArgs e)
        {
            //Verificar se os campos foram preenchidos

            if (txtnomevendedor.Text == string.Empty)
            {
                MessageBox.Show("Favor preencher o campo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtnomevendedor.Focus();

            }




            //Instaciar as classes do clientesDTO
       VendedorDTO dados = new VendedorDTO();
            SalvarVendedor salvar = new SalvarVendedor();
            mskCEPvendedor.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            //popular
            //dados.codigocliente = Convert.ToInt32(txtCodigo.Text);
            dados.nomevendedor = txtnomevendedor.Text;
            dados.datanascimento = msknascimento.Text;
            dados.CPF = txtcpf.Text;
            dados.telefone = txttelefone.Text;
            dados.emailvendedor = txtemail.Text;
            dados.CEP = mskCEPvendedor.Text;
            dados.endereco = txtendereco.Text;
            dados.cidade = txtcidade.Text;
            dados.UF = txtuf.Text;



            //Chamar o método para gravar os dados
            salvar.IncluirVendedor(dados);


            //Mensagem de retorno da DTO
            MessageBox.Show(dados.msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtcodvendedor.Text = dados.cod_vendedor.ToString();



            //Limpar os campos
            txtnomevendedor.Clear();
            txtcodvendedor.Clear();
            txtcpf.Clear();
            msknascimento.Clear();
            txtemail.Clear();
            txttelefone.Clear();
            mskCEPvendedor.Clear();
            txtcidade.Clear();
            txtuf.Clear();
            txtendereco.Clear();
        }

        private void btncadcliente_Click(object sender, EventArgs e)
        {

            frmcadcliente formCliente = new frmcadcliente();
            formCliente.ShowDialog();

        }

        private void btncadpacote_Click(object sender, EventArgs e)
        {
            frmcadpacote formPacote= new frmcadpacote();
            formPacote.ShowDialog();
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
