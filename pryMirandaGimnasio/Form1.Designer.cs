namespace pryMirandaGimnasio
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblnombre = new Label();
            lbledad = new Label();
            gpbdatos = new GroupBox();
            chkestudiante = new CheckBox();
            txtedad = new TextBox();
            txtnombre = new TextBox();
            gpoplanturno = new GroupBox();
            txtmeses = new TextBox();
            chkcasillero = new CheckBox();
            lblmeses = new Label();
            cboturno = new ComboBox();
            cboplan = new ComboBox();
            lblturno = new Label();
            lblplan = new Label();
            gpopago = new GroupBox();
            cbocuotas = new ComboBox();
            label6 = new Label();
            rbotarjeta = new RadioButton();
            rbtefectivo = new RadioButton();
            gpbdatos.SuspendLayout();
            gpoplanturno.SuspendLayout();
            gpopago.SuspendLayout();
            SuspendLayout();
            // 
            // lblnombre
            // 
            lblnombre.AutoSize = true;
            lblnombre.Location = new Point(6, 25);
            lblnombre.Name = "lblnombre";
            lblnombre.Size = new Size(54, 15);
            lblnombre.TabIndex = 0;
            lblnombre.Text = "Nombre:";
            // 
            // lbledad
            // 
            lbledad.AutoSize = true;
            lbledad.Location = new Point(6, 57);
            lbledad.Name = "lbledad";
            lbledad.Size = new Size(36, 15);
            lbledad.TabIndex = 1;
            lbledad.Text = "Edad:";
            // 
            // gpbdatos
            // 
            gpbdatos.Controls.Add(chkestudiante);
            gpbdatos.Controls.Add(txtedad);
            gpbdatos.Controls.Add(txtnombre);
            gpbdatos.Controls.Add(lblnombre);
            gpbdatos.Controls.Add(lbledad);
            gpbdatos.Location = new Point(12, 12);
            gpbdatos.Name = "gpbdatos";
            gpbdatos.Size = new Size(526, 100);
            gpbdatos.TabIndex = 2;
            gpbdatos.TabStop = false;
            gpbdatos.Text = "DATOS PERSONALES";
            // 
            // chkestudiante
            // 
            chkestudiante.AutoSize = true;
            chkestudiante.Location = new Point(178, 57);
            chkestudiante.Name = "chkestudiante";
            chkestudiante.Size = new Size(81, 19);
            chkestudiante.TabIndex = 5;
            chkestudiante.Text = "Estudiante";
            chkestudiante.UseVisualStyleBackColor = true;
            // 
            // txtedad
            // 
            txtedad.Location = new Point(66, 54);
            txtedad.Name = "txtedad";
            txtedad.Size = new Size(100, 23);
            txtedad.TabIndex = 4;
            // 
            // txtnombre
            // 
            txtnombre.Location = new Point(66, 22);
            txtnombre.Name = "txtnombre";
            txtnombre.Size = new Size(229, 23);
            txtnombre.TabIndex = 3;
            // 
            // gpoplanturno
            // 
            gpoplanturno.Controls.Add(txtmeses);
            gpoplanturno.Controls.Add(chkcasillero);
            gpoplanturno.Controls.Add(lblmeses);
            gpoplanturno.Controls.Add(cboturno);
            gpoplanturno.Controls.Add(cboplan);
            gpoplanturno.Controls.Add(lblturno);
            gpoplanturno.Controls.Add(lblplan);
            gpoplanturno.Location = new Point(12, 134);
            gpoplanturno.Name = "gpoplanturno";
            gpoplanturno.Size = new Size(526, 100);
            gpoplanturno.TabIndex = 3;
            gpoplanturno.TabStop = false;
            gpoplanturno.Text = "PLAN Y TURNOS";
            // 
            // txtmeses
            // 
            txtmeses.Location = new Point(395, 25);
            txtmeses.Name = "txtmeses";
            txtmeses.Size = new Size(100, 23);
            txtmeses.TabIndex = 10;
            // 
            // chkcasillero
            // 
            chkcasillero.AutoSize = true;
            chkcasillero.Location = new Point(10, 63);
            chkcasillero.Name = "chkcasillero";
            chkcasillero.Size = new Size(142, 19);
            chkcasillero.TabIndex = 9;
            chkcasillero.Text = "Casillero ($3.000/mes)";
            chkcasillero.UseVisualStyleBackColor = true;
            // 
            // lblmeses
            // 
            lblmeses.AutoSize = true;
            lblmeses.Location = new Point(346, 28);
            lblmeses.Name = "lblmeses";
            lblmeses.Size = new Size(43, 15);
            lblmeses.TabIndex = 8;
            lblmeses.Text = "Meses:";
            // 
            // cboturno
            // 
            cboturno.DropDownStyle = ComboBoxStyle.DropDownList;
            cboturno.FormattingEnabled = true;
            cboturno.Items.AddRange(new object[] { "Mañana", "Tarde", "Noche" });
            cboturno.Location = new Point(219, 25);
            cboturno.Name = "cboturno";
            cboturno.Size = new Size(121, 23);
            cboturno.TabIndex = 7;
            // 
            // cboplan
            // 
            cboplan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboplan.FormattingEnabled = true;
            cboplan.Items.AddRange(new object[] { "Musculación", "Funcional", "Natación" });
            cboplan.Location = new Point(45, 25);
            cboplan.Name = "cboplan";
            cboplan.Size = new Size(121, 23);
            cboplan.TabIndex = 6;
            // 
            // lblturno
            // 
            lblturno.AutoSize = true;
            lblturno.Location = new Point(172, 28);
            lblturno.Name = "lblturno";
            lblturno.Size = new Size(41, 15);
            lblturno.TabIndex = 5;
            lblturno.Text = "Turno:";
            lblturno.Click += label4_Click;
            // 
            // lblplan
            // 
            lblplan.AutoSize = true;
            lblplan.Location = new Point(6, 28);
            lblplan.Name = "lblplan";
            lblplan.Size = new Size(33, 15);
            lblplan.TabIndex = 4;
            lblplan.Text = "Plan:";
            lblplan.Click += label3_Click;
            // 
            // gpopago
            // 
            gpopago.Controls.Add(cbocuotas);
            gpopago.Controls.Add(label6);
            gpopago.Controls.Add(rbotarjeta);
            gpopago.Controls.Add(rbtefectivo);
            gpopago.Location = new Point(12, 253);
            gpopago.Name = "gpopago";
            gpopago.Size = new Size(526, 100);
            gpopago.TabIndex = 4;
            gpopago.TabStop = false;
            gpopago.Text = "FORMA DE PAGO";
            // 
            // cbocuotas
            // 
            cbocuotas.DropDownStyle = ComboBoxStyle.DropDownList;
            cbocuotas.FormattingEnabled = true;
            cbocuotas.Items.AddRange(new object[] { "1 cuota/s", "3 cuota/s", "6 cuota/s" });
            cbocuotas.Location = new Point(181, 21);
            cbocuotas.Name = "cbocuotas";
            cbocuotas.Size = new Size(121, 23);
            cbocuotas.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(128, 24);
            label6.Name = "label6";
            label6.Size = new Size(47, 15);
            label6.TabIndex = 2;
            label6.Text = "Cuotas:";
            // 
            // rbotarjeta
            // 
            rbotarjeta.AutoSize = true;
            rbotarjeta.Location = new Point(10, 47);
            rbotarjeta.Name = "rbotarjeta";
            rbotarjeta.Size = new Size(59, 19);
            rbotarjeta.TabIndex = 1;
            rbotarjeta.TabStop = true;
            rbotarjeta.Text = "Tarjeta";
            rbotarjeta.UseVisualStyleBackColor = true;
            // 
            // rbtefectivo
            // 
            rbtefectivo.AutoSize = true;
            rbtefectivo.Location = new Point(10, 22);
            rbtefectivo.Name = "rbtefectivo";
            rbtefectivo.Size = new Size(67, 19);
            rbtefectivo.TabIndex = 0;
            rbtefectivo.TabStop = true;
            rbtefectivo.Text = "Efectivo";
            rbtefectivo.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 365);
            Controls.Add(gpopago);
            Controls.Add(gpoplanturno);
            Controls.Add(gpbdatos);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gimnasio Siglo — Inscripción";
            gpbdatos.ResumeLayout(false);
            gpbdatos.PerformLayout();
            gpoplanturno.ResumeLayout(false);
            gpoplanturno.PerformLayout();
            gpopago.ResumeLayout(false);
            gpopago.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblnombre;
        private Label lbledad;
        private GroupBox gpbdatos;
        private CheckBox chkestudiante;
        private TextBox txtedad;
        private TextBox txtnombre;
        private GroupBox gpoplanturno;
        private Label lblplan;
        private ComboBox cboplan;
        private Label lblturno;
        private Label lblmeses;
        private ComboBox cboturno;
        private TextBox txtmeses;
        private CheckBox chkcasillero;
        private GroupBox gpopago;
        private RadioButton rbotarjeta;
        private RadioButton rbtefectivo;
        private ComboBox cbocuotas;
        private Label label6;
    }
}
