using System;
using System.Windows.Forms;
using BibliotecaApp.Negocio;

namespace BibliotecaApp.Presentacion
{
    public partial class FrmAutores : Form
    {
        private AutorNegocio autorNegocio = new AutorNegocio();

        public FrmAutores()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void FrmAutores_Load(object sender, EventArgs e)
        {
            CargarAutores();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Listado de Autores";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(600, 400);

            if (!this.Controls.ContainsKey("dgvAutores"))
            {
                DataGridView dgv = new DataGridView();
                dgv.Name = "dgvAutores";
                dgv.Dock = DockStyle.Fill;
                dgv.ReadOnly = true;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.Controls.Add(dgv);
            }
        }

        private void CargarAutores()
        {
            try
            {
                Control[] ctrls = this.Controls.Find("dgvAutores", true);
                if (ctrls.Length > 0 && ctrls[0] is DataGridView dgv)
                {
                    dgv.DataSource = autorNegocio.Listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de autores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

