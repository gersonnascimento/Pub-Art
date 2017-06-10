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
    public partial class NovosArtigoscs : Form
    {
        public static int idArtigo;
        private Conexao conn;
        private SqlConnection ConnectOpen;

        public int cont = 0;

        bool veioDaTela1()
        {
            if (cont == 0)
                return true;
            else return false;
        }

        public NovosArtigoscs()
        {
            InitializeComponent();
            conn = new Conexao();
            ConnectOpen = conn.ConnectToDatabase();
        }

        public void somenteVisualizacao()
        {
            this.button1.Visible = false;
            this.txtTexto.Enabled = false;
            this.txtTitulo.Enabled = false;
            this.comboBox1.Enabled = false;
        }

        public void carregaDados(int id, string titulo, string texto)
        {
            this.txtTexto.Text = texto;
            this.txtTitulo.Text = titulo;
            idArtigo = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja REALMENTE enviar?", "Delete",
              MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            int tipo;

            StringBuilder sql = new StringBuilder();
            sql.Append("Insert into Artigo(titulo, texto, codAutor, codTipo) ");
            sql.Append("Values (@titulo, @texto, @idUsuario, @codTipo)");
            SqlCommand command = null;

            try
            {
                switch (comboBox1.Text)
                {
                    case "Acadêmico":
                        tipo = 1;
                        break;
                    case "Apresentação":
                        tipo = 2;
                        break;
                    case "Científico":
                        tipo = 3;
                        break;
                    case "Divulgação":
                        tipo = 4;
                        break;
                        default:
                        tipo = 1;
                        break;
                }
                command = new SqlCommand(sql.ToString(), ConnectOpen);
                command.Parameters.Add(new SqlParameter("@titulo", txtTitulo.Text));
                command.Parameters.Add(new SqlParameter("@texto", txtTexto.Text));
                command.Parameters.Add(new SqlParameter("@idUsuario", Dashboard.id));
                command.Parameters.Add(new SqlParameter("@codTipo", tipo));// um por enquanto.
                command.ExecuteNonQuery();

                MessageBox.Show("Cadastrado com sucesso!");
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar" + ex);
                throw;
            }
        }//Fim else 

    private void button2_Click(object sender, EventArgs e)
        {
            if (veioDaTela1())
            {
                CadArtigo cadArtigo = new CadArtigo();
                //cadArtigo.id = this.id;
                cadArtigo.Show();
                this.Hide();
            }
            else
            {
                ArtigosList a = new ArtigosList();
                a.Show();
            }
        }
    }
}
