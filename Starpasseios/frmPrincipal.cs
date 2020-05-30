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
    public partial class frmPrincipal : Form
    {
        #region Rotinas para abrir e fechar forms.
        private void FecharTodos()
        {
            try
            {
                foreach (Form childForm in Application.OpenForms)
                {
                    if (childForm.Name != this.Name)
                    {
                        childForm.Close();
                    }

                }
            }
            catch (Exception )
            {

            }
        }



        private void AbrirForm(Form childForm)
        {

            childForm.StartPosition = FormStartPosition.CenterScreen;
            int x = (this.Width - childForm.Width) / 2;
            int y = (this.Height - childForm.Height) / 2;
            childForm.Location = new Point(x, y);
            childForm.Show();


        }



        #endregion
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void pctimg_Click(object sender, EventArgs e)
        {

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblexclusiva.Text = lblexclusiva.Text + " " + loginSistema.email;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Deseja mesmo sair? ", "Mensage do sistema ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {

                //Instaciar as classes do usuariosDTO
                UsuarioDTO dados = new UsuarioDTO();
                LogarUsuario validar = new LogarUsuario();


                //popular
                dados.emailusuario = loginSistema.email;
                dados.senhausuario = loginSistema.senhausuario;


                //Chamar o método para gravar os dados
                validar.DesconectarUsuario(dados);



                Close();
            }



        }

        private void btnclientes_Click(object sender, EventArgs e)
        {

            FecharTodos();
            Form childForm = new frmcadcliente();
            AbrirForm(childForm);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            FecharTodos();
            Form childForm = new frmcadpacote();
            AbrirForm(childForm);
        }

        private void btncadcliente_Click(object sender, EventArgs e)
        {
            
        }

        private void btnVendedor_Click(object sender, EventArgs e)
        {
            FecharTodos();
            Form childForm = new frmvendapacote();
            AbrirForm(childForm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
       
                this.Close();
            }
           
        }
    }
}
