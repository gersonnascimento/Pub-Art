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
using System.Data.SqlClient;

namespace Artigos
{
    public partial class CadArtigo : Form
    {
        private Conexao conn;
        private SqlConnection ConnectOpen;

        protected override void OnPaint(PaintEventArgs e)
        {

            GraphicsPath forma = new GraphicsPath();
            forma.AddEllipse(0, 0, btnCadArtigos.Width, btnCadArtigos.Height);
            btnCadArtigos.Region = new Region(forma);

            GraphicsPath forma2 = new GraphicsPath();
            forma2.AddEllipse(0, 0, button2.Width, button2.Height);
            button2.Region = new Region(forma2);

            GraphicsPath forma3 = new GraphicsPath();
            forma3.AddEllipse(0, 0, button3.Width, button3.Height);
            button3.Region = new Region(forma3);



        }
        public int id;

        public CadArtigo()
        {
            InitializeComponent();
            conn = new Conexao();
            ConnectOpen = conn.ConnectToDatabase();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnCadArtigos_Click(object sender, EventArgs e)
        {
            NovosArtigoscs novosArtigos = new NovosArtigoscs();
            novosArtigos.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var listarArt = new ArtigosList();
            listarArt.ShowDialog();

            //Verificar se foi selecionado algum item
            if (listarArt.ArtigoSelect == "")
                return;

            var conn = ConnectOpen;
            //Buscar usuário selecionado
            string sql = "Select * from Artigo where codAutor = '" + listarArt.ArtigoSelect + "'";


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);



        }

        private void button3_Click(object sender, EventArgs e)
        {
            Revisados r = new Revisados();
            r.Show();
            this.Hide();
        }
    }
}
