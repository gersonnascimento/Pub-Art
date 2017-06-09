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
    public partial class Revisoes : Form
    {
        protected override void OnPaint(PaintEventArgs e)
        {

            GraphicsPath forma = new GraphicsPath();
            forma.AddEllipse(0, 0, btnCadArtigos.Width, btnCadArtigos.Height);
            btnCadArtigos.Region = new Region(forma);

            GraphicsPath forma2 = new GraphicsPath();
            forma2.AddEllipse(0, 0, button1.Width, button1.Height);
            button1.Region = new Region(forma2);

   
        }
        public Revisoes()
        {
            InitializeComponent();
        }

        private void btnCadArtigos_Click(object sender, EventArgs e)
        {
            Revisar r = new Revisar();
            r.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Demais d = new Demais();
            d.Show();
            this.Hide();
        }
    }
}
