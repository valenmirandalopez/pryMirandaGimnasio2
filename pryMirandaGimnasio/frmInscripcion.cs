using System.Numerics;

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


        struct SOCIO
        {
            public string nombre;
            public int edad;
            public string categoria;
            public string plan;
            public string horario;
            public int meses;
            public string formaPago;
            public decimal total;
            public decimal valorCuota;
        }
        //Declara array de 1 dimension
        string[] vecSocio = new string[3];

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
            if (txtnombre.Text != "" && txtedad.Text != "" && txtmeses.Text != "")
            {
                btncalcular.Enabled = true;
            }
            else
            {
                btncalcular.Enabled = false;
            }
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

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            if (txtnombre.Text != "" && txtedad.Text != "" && txtmeses.Text != "")
            {
                btncalcular.Enabled = true;
            }
            else
            {
                btncalcular.Enabled = false;
            }
        }

        private void txtmeses_TextChanged(object sender, EventArgs e)
        {
            if (txtnombre.Text != "" && txtedad.Text != "" && txtmeses.Text != "")
            {
                btncalcular.Enabled = true;
            }
            else
            {
                btncalcular.Enabled = false;
            }
        }

        private void btncalcular_Click_1(object sender, EventArgs e)
        {

            string nombre = txtnombre.Text;
            int edad = int.Parse(txtedad.Text);
            int meses = int.Parse(txtmeses.Text);


            if (edad < EDAD_MINIMA)
            {
                MessageBox.Show("La edad mínima es de 14 años.",
                                "Edad no válida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (meses < 1 || meses > 12)
            {
                MessageBox.Show("La cantidad de meses debe estar entre 1 y 12.",
                                "Meses fuera de rango",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            decimal precioMensual = 0;
            decimal subtotal = 0;
            decimal porcentajeDescuento = 0;
            decimal porcentajeAjustePago = 0;
            decimal total = 0;
            decimal valorCuota = 0;



            //plan segun lo seleccionado
            
            switch (cboplan.Text)
            {
                case "Musculación":
                    precioMensual = PRECIO_MUSCULACION;
                    break;
                case "Funcional":
                    precioMensual = PRECIO_FUNCIONAL;
                    break;
                case "Natación":
                    precioMensual = PRECIO_NATACION;
                    break;
                default:
                    precioMensual = 0;
                    break;

                             
                        
            }

            string descripcionTurno = "";
             
            //turno segun lo seleccionado
            switch (cboturno.SelectedIndex)
            {
                case 0:
                    descripcionTurno = "Mañana (07:00 a 12:00 hs)";
                    break;
                case 1:
                    descripcionTurno = "Tarde (12:00 a 18:00 hs)";
                    break;
                case 2:
                    descripcionTurno = "Noche (18:00 a 22:00 hs)";
                    break;
                default:
                    descripcionTurno = "Sin turno";
                    break;
            }


            decimal precioCasilleroTotal = 0;
            if (chkcasillero.Checked)
            {
                precioCasilleroTotal = PRECIO_CASILLERO;
            }

            
            subtotal = (precioMensual + precioCasilleroTotal) * meses;

           
            if (chkestudiante.Checked || edad >= 60)
            {
                porcentajeDescuento = 0.20m; // 20% de descuento
            }

            decimal montoDescuento = subtotal * porcentajeDescuento;
            decimal subtotalConDescuento = subtotal - montoDescuento;

            
            if (rbtefectivo.Checked)
            {
                porcentajeAjustePago = -0.10m; // 10% de descuento en efectivo
            }
            else if (rbttarjeta.Checked) // O rbtcredito / el radiobutton de tarjeta que tengas
            {
                if (cbocuotas.SelectedIndex == 0)      // 1 cuota
                {
                    porcentajeAjustePago = 0.00m;      // Sin recargo
                }
                else if (cbocuotas.SelectedIndex == 1) // 3 cuotas
                {
                    porcentajeAjustePago = RECARGO_3_CUOTAS; // 10% de recargo
                }
                else if (cbocuotas.SelectedIndex == 2) // 6 cuotas
                {
                    porcentajeAjustePago = RECARGO_6_CUOTAS; // 20% de recargo
                }
            }

            decimal montoAjustePago = subtotalConDescuento * porcentajeAjustePago;

       
            total = subtotalConDescuento + montoAjustePago;

           
            int cantidadCuotas = 1;
            if (!rbtefectivo.Checked && cbocuotas.SelectedIndex != -1)
            {
            
                cantidadCuotas = int.Parse(cbocuotas.SelectedItem.ToString());
            }

            valorCuota = total / cantidadCuotas;

            //mostrar resultado final
            // 1. Declarar la variable basada en la estructura
            SOCIO socio;

            // 2. Cargar los datos simples
            socio.nombre = nombre;
            socio.edad = edad;
            socio.plan = cboplan.Text;
            socio.horario = descripcionTurno; // Usamos la variable del switch de turnos
            socio.meses = meses;
            socio.total = total;
            socio.valorCuota = valorCuota;

            // 3. Determinar Categoría (Estudiante, Jubilado o Estándar)
            if (chkestudiante.Checked)
            {
                socio.categoria = "Estudiante";
            }
            else if (edad >= 60)
            {
                socio.categoria = "Jubilado / Mayor de 60";
            }
            else
            {
                socio.categoria = "Estándar";
            }

            // 4. Determinar Forma de Pago
            if (rbtefectivo.Checked)
            {
                socio.formaPago = "Efectivo";
            }
            else
            {
                socio.formaPago = "Tarjeta (" + cbocuotas.SelectedItem.ToString() + " cuotas)";
            }

            // 5. Armar el mensaje con los datos del socio
            string mensaje = "DATOS DEL SOCIO\n\n" +
                             "Nombre: " + socio.nombre + "\n" +
                             "Edad: " + socio.edad + " años\n" +
                             "Categoría: " + socio.categoria + "\n" +
                             "Plan: " + socio.plan + "\n" +
                             "Horario: " + socio.horario + "\n" +
                             "Meses: " + socio.meses + "\n" +
                             "Forma de Pago: " + socio.formaPago + "\n\n" +
                             "TOTAL A PAGAR: $" + socio.total.ToString("N2") + "\n" +
                             "Valor de Cuota: $" + socio.valorCuota.ToString("N2");

            // 6. Mostrar el resultado
            MessageBox.Show(mensaje, "Inscripción Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }
}

