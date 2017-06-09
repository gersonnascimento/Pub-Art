using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Artigos
{
    public partial class Revisados : Form
    {
        public Revisados()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CadArtigo cadArtigo = new CadArtigo();
           // cadArtigo.id = this.id;
            cadArtigo.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja REALMENTE publicar?", "Delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja REALMENTE enviar para revisão novamente?", "Delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            this.Hide();
        }
    }
}
