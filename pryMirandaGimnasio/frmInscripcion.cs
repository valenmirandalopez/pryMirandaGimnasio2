namespace pryMirandaGimnasio
{
    public partial class frmInscripcion : Form
    {

        public frmInscripcion()
        {
            InitializeComponent();
        }



        private void frmInscripcion_Load(object sender, EventArgs e)
        {
            EstadoInicial();


        }
        private void EstadoInicial()
        {
            txtnombre.Text = "";
            txtedad.Text = "";
            txtmeses.Text = "1";

            chkestudiante.Checked = false;
            chkcasillero.Checked = false;

            cboplan.SelectedIndex = 0;
            cboturno.SelectedIndex = 0;

            rbtefectivo.Checked = true;

            cbocuotas.SelectedIndex = -1;
            cbocuotas.Enabled = false;

            btncalcular.Enabled = false;

            txtnombre.Focus();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }
    }
}
