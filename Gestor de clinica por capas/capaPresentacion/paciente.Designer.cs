namespace capaPresentacion
{
    partial class frmPaciente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblClinica = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvPaciente = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaciente)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblClinica);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1154, 33);
            this.panel1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(63, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 27;
            this.label1.Text = ">Paciente";
            // 
            // lblClinica
            // 
            this.lblClinica.AutoSize = true;
            this.lblClinica.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblClinica.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lblClinica.ForeColor = System.Drawing.Color.White;
            this.lblClinica.Location = new System.Drawing.Point(0, 0);
            this.lblClinica.Name = "lblClinica";
            this.lblClinica.Size = new System.Drawing.Size(63, 21);
            this.lblClinica.TabIndex = 20;
            this.lblClinica.Text = "Clinica";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lblPaciente);
            this.panel3.Controls.Add(this.txtNombre);
            this.panel3.Controls.Add(this.txtApellido);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtDireccion);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtTelefono);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtEmail);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.dtpFecha);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cmbSexo);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1154, 273);
            this.panel3.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(248, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nombre";
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.ForeColor = System.Drawing.Color.Black;
            this.lblPaciente.Location = new System.Drawing.Point(1091, 260);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(60, 13);
            this.lblPaciente.TabIndex = 19;
            this.lblPaciente.Text = "IDPaciente";
            this.lblPaciente.Visible = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(251, 38);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(312, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(583, 38);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(350, 20);
            this.txtApellido.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(249, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Sexo";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(252, 81);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(312, 20);
            this.txtDireccion.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(580, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Fecha de nacimiento";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(583, 81);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(350, 20);
            this.txtTelefono.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(249, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(252, 124);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(312, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(580, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Telefono";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(583, 124);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(350, 20);
            this.dtpFecha.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(249, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Direccion";
            // 
            // cmbSexo
            // 
            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Location = new System.Drawing.Point(251, 167);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(312, 21);
            this.cmbSexo.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(580, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Apellido";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Teal;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Aquamarine;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(0, 585);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(1154, 25);
            this.btnLimpiar.TabIndex = 38;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Teal;
            this.btnEliminar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(0, 560);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(1154, 25);
            this.btnEliminar.TabIndex = 39;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Teal;
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(0, 535);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(1154, 25);
            this.btnGuardar.TabIndex = 40;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvPaciente
            // 
            this.dgvPaciente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPaciente.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPaciente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaciente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPaciente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPaciente.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPaciente.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPaciente.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dgvPaciente.Location = new System.Drawing.Point(0, 312);
            this.dgvPaciente.Name = "dgvPaciente";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaciente.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPaciente.Size = new System.Drawing.Size(1154, 223);
            this.dgvPaciente.TabIndex = 41;
            this.dgvPaciente.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPaciente_CellDoubleClick);
            // 
            // frmPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 610);
            this.Controls.Add(this.dgvPaciente);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPaciente";
            this.Text = "paciente";
            this.Load += new System.EventHandler(this.frmPaciente_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaciente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClinica;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvPaciente;
    }
}