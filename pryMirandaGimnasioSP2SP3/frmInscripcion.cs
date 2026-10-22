using System.Globalization;

namespace pryMirandaGimnasioSP2SP3;

public class frmInscripcion : Form
{
    private const decimal PRECIO_MUSCULACION = 15000m;
    private const decimal PRECIO_FUNCIONAL = 18000m;
    private const decimal PRECIO_NATACION = 22000m;
    private const decimal PRECIO_CASILLERO = 3000m;
    private const int EDAD_MINIMA = 14;
    private const decimal DESCUENTO_MENOR = 0.25m;
    private const decimal DESCUENTO_MAYOR = 0.30m;
    private const decimal DESCUENTO_ESTUDIANTE = 0.15m;
    private const decimal DESCUENTO_EFECTIVO = 0.10m;
    private const decimal RECARGO_3_CUOTAS = 0.10m;
    private const decimal RECARGO_6_CUOTAS = 0.20m;

    private readonly TextBox txtNombre = new() { MaxLength = 30 };
    private readonly TextBox txtEdad = new() { MaxLength = 3 };
    private readonly TextBox txtMeses = new() { MaxLength = 2 };
    private readonly ComboBox cboPlan = new() { DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly ComboBox cboTurno = new() { DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly ComboBox cboCuotas = new() { DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly CheckBox chkEstudiante = new() { Text = "Estudiante" };
    private readonly CheckBox chkCasillero = new() { Text = "Casillero ($3.000/mes)" };
    private readonly RadioButton rdoEfectivo = new() { Text = "Efectivo", Checked = true };
    private readonly RadioButton rdoTarjeta = new() { Text = "Tarjeta" };
    private readonly Button btnCalcular = new() { Text = "Calcular", Enabled = false };
    private readonly Button btnLimpiar = new() { Text = "Limpiar" };

    private struct SOCIO
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

    public frmInscripcion()
    {
        Text = "Gimnasio Siglo - Inscripción";
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(590, 390);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Font = new Font("Segoe UI", 9F);
        CrearInterfaz();
        AsociarEventos();
        EstadoInicial();
    }

    private void CrearInterfaz()
    {
        var datos = new GroupBox { Text = "DATOS PERSONALES", Location = new Point(12, 12), Size = new Size(566, 78) };
        datos.Controls.AddRange([
            Etiqueta("Nombre:", 12, 25), txtNombre,
            Etiqueta("Edad:", 300, 25), txtEdad, chkEstudiante
        ]);
        txtNombre.Location = new Point(70, 22); txtNombre.Size = new Size(205, 23);
        txtEdad.Location = new Point(340, 22); txtEdad.Size = new Size(55, 23);
        chkEstudiante.Location = new Point(420, 24);

        var plan = new GroupBox { Text = "PLAN Y TURNOS", Location = new Point(12, 100), Size = new Size(566, 112) };
        cboPlan.Items.AddRange(["Musculación", "Funcional", "Natación"]);
        cboTurno.Items.AddRange(["Mañana (7 a 12 h)", "Tarde (14 a 18 h)", "Noche (18 a 23 h)"]);
        plan.Controls.AddRange([
            Etiqueta("Plan:", 12, 25), cboPlan,
            Etiqueta("Turno:", 200, 25), cboTurno,
            Etiqueta("Meses:", 390, 25), txtMeses, chkCasillero
        ]);
        cboPlan.Location = new Point(52, 22); cboPlan.Size = new Size(135, 23);
        cboTurno.Location = new Point(250, 22); cboTurno.Size = new Size(130, 23);
        txtMeses.Location = new Point(440, 22); txtMeses.Size = new Size(55, 23);
        chkCasillero.Location = new Point(12, 65);

        var pago = new GroupBox { Text = "FORMA DE PAGO", Location = new Point(12, 222), Size = new Size(566, 72) };
        pago.Controls.AddRange([rdoEfectivo, rdoTarjeta, Etiqueta("Cuotas:", 260, 27), cboCuotas]);
        rdoEfectivo.Location = new Point(12, 27); rdoTarjeta.Location = new Point(100, 27);
        cboCuotas.Items.AddRange(["1 cuota", "3 cuotas", "6 cuotas"]);
        cboCuotas.Location = new Point(320, 24); cboCuotas.Size = new Size(110, 23);

        btnCalcular.Location = new Point(150, 320); btnCalcular.Size = new Size(120, 32);
        btnLimpiar.Location = new Point(310, 320); btnLimpiar.Size = new Size(120, 32);
        Controls.AddRange([datos, plan, pago, btnCalcular, btnLimpiar]);
    }

    private static Label Etiqueta(string texto, int x, int y) => new() { Text = texto, AutoSize = true, Location = new Point(x, y + 3) };

    private void AsociarEventos()
    {
        txtNombre.KeyPress += txtNombre_KeyPress;
        txtEdad.KeyPress += SoloDigitos_KeyPress;
        txtMeses.KeyPress += SoloDigitos_KeyPress;
        txtNombre.TextChanged += Datos_TextChanged;
        txtEdad.TextChanged += Datos_TextChanged;
        txtMeses.TextChanged += Datos_TextChanged;
        rdoEfectivo.CheckedChanged += FormaPago_CheckedChanged;
        rdoTarjeta.CheckedChanged += FormaPago_CheckedChanged;
        btnCalcular.Click += btnCalcular_Click;
        btnLimpiar.Click += (_, _) => EstadoInicial();
    }

    private void EstadoInicial()
    {
        txtNombre.Clear(); txtEdad.Clear(); txtMeses.Text = "1";
        chkEstudiante.Checked = false; chkCasillero.Checked = false;
        cboPlan.SelectedIndex = 0; cboTurno.SelectedIndex = 0;
        rdoEfectivo.Checked = true; cboCuotas.SelectedIndex = -1; cboCuotas.Enabled = false;
        btnCalcular.Enabled = false; txtNombre.Focus();
    }

    private void txtNombre_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back) e.Handled = true;
        e.KeyChar = char.ToUpper(e.KeyChar);
    }

    private static void SoloDigitos_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
    }

    private void Datos_TextChanged(object? sender, EventArgs e)
    {
        btnCalcular.Enabled = txtNombre.Text.Trim() != "" && txtEdad.Text != "" && txtMeses.Text != "";
    }

    private void FormaPago_CheckedChanged(object? sender, EventArgs e)
    {
        cboCuotas.Enabled = rdoTarjeta.Checked;
        if (rdoTarjeta.Checked) cboCuotas.SelectedIndex = 0;
        else cboCuotas.SelectedIndex = -1;
    }

    private void btnCalcular_Click(object? sender, EventArgs e)
    {
        if (!int.TryParse(txtEdad.Text, out int edad) || !int.TryParse(txtMeses.Text, out int meses)) return;
        if (edad < EDAD_MINIMA)
        {
            MessageBox.Show("La edad mínima para inscribirse es de 14 años.", "Edad no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (meses < 1 || meses > 12)
        {
            MessageBox.Show("La cantidad de meses debe estar entre 1 y 12.", "Meses fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string plan = cboPlan.Text;
        decimal precioMensual = plan switch
        {
            "Musculación" => PRECIO_MUSCULACION,
            "Funcional" => PRECIO_FUNCIONAL,
            "Natación" => PRECIO_NATACION,
            _ => 0m
        };
        if (chkCasillero.Checked) precioMensual += PRECIO_CASILLERO;

        decimal subtotal = precioMensual * meses;
        decimal porcentajeDescuento;
        if (edad < 18) porcentajeDescuento = DESCUENTO_MENOR;
        else if (edad >= 65) porcentajeDescuento = DESCUENTO_MAYOR;
        else porcentajeDescuento = chkEstudiante.Checked ? DESCUENTO_ESTUDIANTE : 0m;
        decimal total = subtotal * (1m - porcentajeDescuento);

        string formaPago;
        decimal ajustePago;
        int cantidadCuotas;
        if (rdoEfectivo.Checked)
        {
            formaPago = "Efectivo"; ajustePago = -DESCUENTO_EFECTIVO; cantidadCuotas = 1;
        }
        else
        {
            cantidadCuotas = cboCuotas.SelectedIndex switch { 1 => 3, 2 => 6, _ => 1 };
            formaPago = $"Tarjeta {cantidadCuotas} cuotas";
            ajustePago = cantidadCuotas switch { 3 => RECARGO_3_CUOTAS, 6 => RECARGO_6_CUOTAS, _ => 0m };
        }
        total *= 1m + ajustePago;
        decimal valorCuota = total / cantidadCuotas;
        string categoria = edad < 18 ? "Menor" : edad >= 65 ? "Mayor" : "Adulto";
        string horario = cboTurno.Text;
        SOCIO socio = new()
        {
            nombre = txtNombre.Text.Trim(),
            edad = edad,
            categoria = categoria,
            plan = plan,
            horario = horario,
            meses = meses,
            formaPago = formaPago,
            total = total,
            valorCuota = valorCuota
        };

        string detalle = $"Socio: {socio.nombre}\nEdad: {socio.edad} ({socio.categoria})\nPlan: {socio.plan}\nHorario: {socio.horario}\nMeses: {socio.meses}\nForma de pago: {socio.formaPago}\nSubtotal: {subtotal.ToString("C", CultureInfo.CurrentCulture)}\nDescuento: {porcentajeDescuento:P0}\nTotal: {socio.total.ToString("C", CultureInfo.CurrentCulture)}\nValor de cuota: {socio.valorCuota.ToString("C", CultureInfo.CurrentCulture)}";
        MessageBox.Show(detalle, "Inscripción calculada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        EstadoInicial();
    }
}
