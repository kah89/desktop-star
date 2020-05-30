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
    public partial class frmlogin : Form
    {
        public bool LoginSucesso = false;
        public frmlogin()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            //Instaciar as classes do usuariosDTO
            UsuarioDTO dados = new UsuarioDTO();
            LogarUsuario validar = new LogarUsuario();


            //popular
            dados.emailusuario = txtusuario.Text;
            dados.senhausuario = txtsenha.Text;


            //Chamar o método para gravar os dados
            validar.ValidarUsuario(dados);

            //Verificar se o usuario esta logado ou não

            if (dados.logado == "2")
            {
                MessageBox.Show("USUARIO OU SENHA INCORRETOS ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            else if (dados.logado == "3")
            {
                MessageBox.Show("USUARIO JÁ ESTÁ CONECTADO", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            else if (dados.logado == "4")
            {
                MessageBox.Show("BEM VINDO AO SISTEMA", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (dados.logado == "4")
                {
                    //Instanciar o formulário
                    //frmPrincipal formPrincipal = new frmPrincipal();
                     // formPrincipal.ShowDialog();

                    this.LoginSucesso = true;



                    if (this.LoginSucesso)
                    {
                        this.Close();
                    }


                 


                }


            }

       

        }



        private void lblusuarios_Click(object sender, EventArgs e)
        {

        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnesquceu_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }
    }
}
