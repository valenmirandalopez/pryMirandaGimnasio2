namespace pryMirandaGimnasio
{
    public partial class frmInscripcion : Form
    {
        const decimal PRECIO_MUSCULACION = 15000m;
        const decimal PRECIO_FUNCIONAL = 18000m;
        const decimal PRECIO_NATACION = 22000m;
        const decimal PRECIO_CASILLERO = 3000m;

        const int EDAD_MINIMA = 14;

        const decimal DESCUENTO_MENOR = 0.25m;
        const decimal DESCUENTO_MAYOR = 0.30m;
        const decimal DESCUENTO_ESTUDIANTE = 0.15m;

        const decimal DESCUENTO_EFECTIVO = 0.10m;
        const decimal RECARGO_3_CUOTAS = 0.10m;
        const decimal RECARGO_6_CUOTAS = 0.20m;



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

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }

            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtedad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btncalcular_Click(object sender, EventArgs e)
        {

            string nombre = txtnombre.Text;
            int edad = int.Parse(txtedad.Text);
            int meses = int.Parse(txtmeses.Text);

            decimal precioMensual = 0;
            decimal subtotal = 0;
            decimal porcentajeDescuento = 0;
            decimal porcentajeAjustePago = 0;
            decimal total = 0;
            decimal valorCuota = 0;
        }

        private void txtedad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtmeses_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}

