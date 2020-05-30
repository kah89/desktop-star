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
   
    public partial class frmcadcliente : Form
    {
        public frmcadcliente()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

        }

        private void btnok_Click(object sender, EventArgs e)
        {
            //Verificar se os campos foram preenchidos

            if (txtNomeCliente.Text == string.Empty)
            {
                MessageBox.Show("Favor preencher o campo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNomeCliente.Focus();
            }


            //Instaciar as classes do clientesDTO
            ClientesDTO dados = new ClientesDTO();
            SalvarCliente salvar = new SalvarCliente();
            mskCep.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            //popular
            //dados.codigocliente = Convert.ToInt32(txtCodigo.Text);
            dados.nomedocliente = txtNomeCliente.Text;
            dados.datanascimento = msknascimento.Text;
            dados.CPF = txtcpf.Text;
            dados.telefone = txttelcliente.Text;
            dados.email = txtemail.Text;
            dados.CEP = mskCep.Text;
            dados.endereco = txtendereco.Text;
            dados.cidade = txtcidade.Text;
            dados.UF = txtuf.Text;
            dados.como_nos_achou = txtachou.Text;


            //Chamar o método para gravar os dados
            salvar.IncluirClientes(dados);



            //Mensagem de retorno da DTO
            MessageBox.Show(dados.msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtcodcliente.Text = dados.codcliente.ToString();



            //Limpar os campos
            txtNomeCliente.Clear();
            txtcodcliente.Clear();
            txtcpf.Clear();
            msknascimento.Clear();
            txtemail.Clear();
            txttelcliente.Clear();
            mskCep.Clear();
            txtcidade.Clear();
            txtuf.Clear();
            txtendereco.Clear();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            //Limpar os campos
            txtNomeCliente.Clear();
            txtcodcliente.Clear();
            msknascimento.Clear();
            txtcpf.Clear();
            txttelcliente.Clear();
            txtemail.Clear();
            mskCep.Clear();
            txtendereco.Clear();
            txtcidade.Clear();
            txtuf.Clear();
            txtachou.Clear();
        }


        private void btnTesteCep_Click_Click(object sender, EventArgs e)
        {

            //remover a máscara
            // não devemos enviar para o banco de dados campos com máscaras
            //mskCep.Mask = "";
            mskCep.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            //verificar se o campo foi preenchido
            if (mskCep.Text == string.Empty)
            {
                MessageBox.Show(mskCep.Text);
            }

            //retornar a máscara
            mskCep.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            //mskCep.Mask = "#####-###";

        }

        private void mskCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                //  MessageBox.Show("tecla - " + e.KeyChar.ToString());
                LocalizarCEP();
            }

        }

        private void LocalizarCEP()
        {

            //Instanciar a classe AtendeClienteService
   
            AtendeClienteService correios = new AtendeClienteService();

            try
            {
                //Remover a máscara do campo CEP        
                mskCep.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                var resultadocep = correios.consultaCEP(mskCep.Text);
               txtendereco.Text = resultadocep.end;
                txtcidade.Text = resultadocep.cidade;
                txtuf.Text = resultadocep.uf;



            }
            catch (SoapException e)
            {
                MessageBox.Show(e.Message);
            }



        }

        private void frmClientes_Load(object sender, EventArgs e)
        {

        }

        private void mskCep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void mskCep_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btncadcliente_Click(object sender, EventArgs e)
        {
            
        }

        private void btncadvendedor_Click(object sender, EventArgs e)
        {
            frmvendedor formVendedor= new frmvendedor();
            formVendedor.ShowDialog();

        }

        private void btncadpacote_Click(object sender, EventArgs e)
        {
            frmcadpacote formPacote = new frmcadpacote();
            formPacote.ShowDialog();
        }

        private void txtcodcliente_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
