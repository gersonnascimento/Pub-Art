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
    public partial class Demais : Form
    {
        public Demais()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Justificativa j = new Justificativa();
            j.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Revisoes r = new Revisoes();
            r.Show();
            this.Hide();
        }
    }
}
