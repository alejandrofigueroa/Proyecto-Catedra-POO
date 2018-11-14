namespace capaPresentacion
{
    partial class frmDoctor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dvgDoctores = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblIdDoc = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDPersonal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.pbUsuario = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboUsuario = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgDoctores)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1154, 30);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 21);
            this.label1.TabIndex = 26;
            this.label1.Text = "Doctor";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Teal;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Aquamarine;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(0, 560);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(1154, 25);
            this.btnEliminar.TabIndex = 33;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Teal;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Aquamarine;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(0, 535);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(1154, 25);
            this.btnGuardar.TabIndex = 35;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // dvgDoctores
            // 
            this.dvgDoctores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgDoctores.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dvgDoctores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgDoctores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgDoctores.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgDoctores.DefaultCellStyle = dataGridViewCellStyle2;
            this.dvgDoctores.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dvgDoctores.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.dvgDoctores.Location = new System.Drawing.Point(0, 286);
            this.dvgDoctores.Name = "dvgDoctores";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgDoctores.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dvgDoctores.Size = new System.Drawing.Size(1154, 249);
            this.dvgDoctores.TabIndex = 36;
            this.dvgDoctores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgDoctores_CellContentClick_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblIdDoc);
            this.panel2.Controls.Add(this.lblApellido);
            this.panel2.Controls.Add(this.lblNombre);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtDPersonal);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtEspecialidad);
            this.panel2.Controls.Add(this.pbUsuario);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cboUsuario);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1154, 212);
            this.panel2.TabIndex = 37;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lblIdDoc
            // 
            this.lblIdDoc.AutoSize = true;
            this.lblIdDoc.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdDoc.ForeColor = System.Drawing.Color.Black;
            this.lblIdDoc.Location = new System.Drawing.Point(94, 165);
            this.lblIdDoc.Name = "lblIdDoc";
            this.lblIdDoc.Size = new System.Drawing.Size(54, 16);
            this.lblIdDoc.TabIndex = 35;
            this.lblIdDoc.Text = "idDoctor";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.ForeColor = System.Drawing.Color.Black;
            this.lblApellido.Location = new System.Drawing.Point(29, 181);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(51, 16);
            this.lblApellido.TabIndex = 34;
            this.lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(29, 165);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 16);
            this.lblNombre.TabIndex = 33;
            this.lblNombre.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(704, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 17);
            this.label5.TabIndex = 32;
            this.label5.Text = "Descripción Personal";
            // 
            // txtDPersonal
            // 
            this.txtDPersonal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDPersonal.Location = new System.Drawing.Point(702, 36);
            this.txtDPersonal.Multiline = true;
            this.txtDPersonal.Name = "txtDPersonal";
            this.txtDPersonal.Size = new System.Drawing.Size(425, 109);
            this.txtDPersonal.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(176, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "Especialidad";
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.Location = new System.Drawing.Point(174, 97);
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(503, 20);
            this.txtEspecialidad.TabIndex = 29;
            // 
            // pbUsuario
            // 
            this.pbUsuario.ErrorImage = global::capaPresentacion.Properties.Resources.clinic_logo___Buscar_con_Google___Google_Chrome;
            this.pbUsuario.InitialImage = global::capaPresentacion.Properties.Resources.clinic_logo___Buscar_con_Google___Google_Chrome;
            this.pbUsuario.Location = new System.Drawing.Point(27, 16);
            this.pbUsuario.Name = "pbUsuario";
            this.pbUsuario.Size = new System.Drawing.Size(118, 146);
            this.pbUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUsuario.TabIndex = 28;
            this.pbUsuario.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(176, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Usuario";
            // 
            // cboUsuario
            // 
            this.cboUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuario.FormattingEnabled = true;
            this.cboUsuario.Location = new System.Drawing.Point(174, 36);
            this.cboUsuario.Name = "cboUsuario";
            this.cboUsuario.Size = new System.Drawing.Size(503, 21);
            this.cboUsuario.TabIndex = 26;
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
            this.btnLimpiar.TabIndex = 30;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // frmDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 610);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dvgDoctores);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDoctor";
            this.Text = "doctor";
            this.Load += new System.EventHandler(this.frmDoctor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgDoctores)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dvgDoctores;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDPersonal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEspecialidad;
        private System.Windows.Forms.PictureBox pbUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboUsuario;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblIdDoc;
    }
}