using System;
using System.Windows.Forms;
using BibliotecaApp.Negocio;

namespace BibliotecaApp.Presentacion
{
    public partial class FrmUsuarios : Form
    {
        private UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

        public FrmUsuarios()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Listado de Usuarios";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(600, 400);

            if (!this.Controls.ContainsKey("dgvUsuarios"))
            {
                DataGridView dgv = new DataGridView();
                dgv.Name = "dgvUsuarios";
                dgv.Dock = DockStyle.Fill;
                dgv.ReadOnly = true;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.Controls.Add(dgv);
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                Control[] ctrls = this.Controls.Find("dgvUsuarios", true);
                if (ctrls.Length > 0 && ctrls[0] is DataGridView dgv)
                {
                    dgv.DataSource = usuarioNegocio.Listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}