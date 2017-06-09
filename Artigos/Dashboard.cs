using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Artigos
{
    public partial class Dashboard : Form
    {
        public static int id;
        protected override void OnPaint(PaintEventArgs e)
        {

            GraphicsPath forma = new GraphicsPath();
            forma.AddEllipse(0, 0, button2.Width, button2.Height);
            button2.Region = new Region(forma);

            GraphicsPath forma2 = new GraphicsPath();
            forma2.AddEllipse(0, 0, btnCadastrarArtigo.Width, btnCadastrarArtigo.Height);
            btnCadastrarArtigo.Region = new Region(forma2);

            GraphicsPath forma3 = new GraphicsPath();
            forma3.AddEllipse(0, 0, button1.Width, button1.Height);
            button1.Region = new Region(forma3);

            GraphicsPath forma4 = new GraphicsPath();
            forma4.AddEllipse(0, 0, button3.Width, button3.Height);
            button3.Region = new Region(forma4);



        }

        
        //1 - Autores
            //2 - Revisores
            //3 - Gerente
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            var frmLogin = new Login();
            frmLogin.ShowDialog();

            

            if (frmLogin.logado == false) {
                Close();

            }

            if(Login.perfilUsuario == 3)
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
            else if (Login.perfilUsuario == 2)
            {
                button2.Enabled = true;
            }
            else if (Login.perfilUsuario == 1)
            {
                btnCadastrarArtigo.Enabled = true;
            }


                    id = frmLogin.id;
            MessageBox.Show(Convert.ToString(id));
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cad = new Cadastrar();
            cad.ShowDialog();
        }

        private void btnCadastrarArtigo_Click(object sender, EventArgs e)
        {
            CadArtigo cadArtigo = new CadArtigo();
            cadArtigo.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Revisoes r = new Revisoes();
            r.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.button2.Enabled = false;
            this.btnCadastrarArtigo.Enabled = false;

            var frmLogin = new Login();
            frmLogin.ShowDialog();



            if (frmLogin.logado == false)
            {
                Close();

            }

            if (Login.perfilUsuario == 3)
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
            else if (Login.perfilUsuario == 2)
            {
                button2.Enabled = true;
            }
            else if (Login.perfilUsuario == 1)
            {
                btnCadastrarArtigo.Enabled = true;
            }


            id = frmLogin.id;

        }
    }
}
