using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Artigos
{
    public partial class ArtigosList : Form
    {
      
        public void btnV()
        {

        }

        int count;
        public void lartigos()
        {
            var conn = Login.ConnectOpen;
            //Buscar todos usuários cadastrados
            string sql = "Select * from Artigo where codAutor =" + Dashboard.id;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
        }

        public void lrevisados()
        {
            var conn = Login.ConnectOpen;
            //Buscar todos usuários cadastrados
            string sql = "Select * from Artigo where revisado = 1 and codAutor = " + Dashboard.id;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
        }

        public string ArtigoSelect;
        public ArtigosList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

                CadArtigo cadArtigo = new CadArtigo();
                cadArtigo.Show();
                this.Hide();
        }

        private void ArtigosList_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //Recuperar a linha selecionadas.
            ArtigoSelect = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //id = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            //Fechar a tela
            Hide();
            NovosArtigoscs n = new NovosArtigoscs();
            n.carregaDados(Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[0].Value), dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            n.somenteVisualizacao();
            n.cont++;
            n.Show();
        }
    }
}
