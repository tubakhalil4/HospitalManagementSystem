namespace HospitalManagementSystem
{
    partial class BillingForm
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
            this.CmbPatient = new System.Windows.Forms.ComboBox();
            this.CmbAppointment = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.TxtServiceCharges = new System.Windows.Forms.TextBox();
            this.TxtMedicineCharges = new System.Windows.Forms.TextBox();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DtpBillingDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnCalculate = new System.Windows.Forms.Button();
            this.BtnAddBill = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TxtOtherCharges = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbPatient
            // 
            this.CmbPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPatient.FormattingEnabled = true;
            this.CmbPatient.Location = new System.Drawing.Point(80, 50);
            this.CmbPatient.Name = "CmbPatient";
            this.CmbPatient.Size = new System.Drawing.Size(121, 21);
            this.CmbPatient.TabIndex = 0;
           // this.CmbPatient.SelectedIndexChanged += new System.EventHandler(this.CmbPatient_SelectedIndexChanged);
            // 
            // CmbAppointment
            // 
            this.CmbAppointment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAppointment.FormattingEnabled = true;
            this.CmbAppointment.Location = new System.Drawing.Point(320, 50);
            this.CmbAppointment.Name = "CmbAppointment";
            this.CmbAppointment.Size = new System.Drawing.Size(121, 21);
            this.CmbAppointment.TabIndex = 1;
            // 
            // TxtServiceCharges
            // 
            this.TxtServiceCharges.Location = new System.Drawing.Point(80, 124);
            this.TxtServiceCharges.Name = "TxtServiceCharges";
            this.TxtServiceCharges.Size = new System.Drawing.Size(100, 20);
            this.TxtServiceCharges.TabIndex = 2;
            // 
            // TxtMedicineCharges
            // 
            this.TxtMedicineCharges.Location = new System.Drawing.Point(320, 124);
            this.TxtMedicineCharges.Name = "TxtMedicineCharges";
            this.TxtMedicineCharges.Size = new System.Drawing.Size(100, 20);
            this.TxtMedicineCharges.TabIndex = 3;
            // 
            // TxtTotal
            // 
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.Location = new System.Drawing.Point(320, 179);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.ReadOnly = true;
            this.TxtTotal.Size = new System.Drawing.Size(100, 20);
            this.TxtTotal.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Enter Service Charges";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select Patient";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Select Appointment Id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Enter Medicine Charges";
            // 
            // DtpBillingDate
            // 
            this.DtpBillingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpBillingDate.Location = new System.Drawing.Point(554, 51);
            this.DtpBillingDate.Name = "DtpBillingDate";
            this.DtpBillingDate.Size = new System.Drawing.Size(200, 20);
            this.DtpBillingDate.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(551, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Billing Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(317, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Total Bill";
            // 
            // BtnCalculate
            // 
            this.BtnCalculate.Location = new System.Drawing.Point(80, 173);
            this.BtnCalculate.Name = "BtnCalculate";
            this.BtnCalculate.Size = new System.Drawing.Size(121, 23);
            this.BtnCalculate.TabIndex = 14;
            this.BtnCalculate.Text = "Calculate Total";
            this.BtnCalculate.UseVisualStyleBackColor = true;
            this.BtnCalculate.Click += new System.EventHandler(this.BtnCalculate_Click);
            // 
            // BtnAddBill
            // 
            this.BtnAddBill.Location = new System.Drawing.Point(557, 176);
            this.BtnAddBill.Name = "BtnAddBill";
            this.BtnAddBill.Size = new System.Drawing.Size(75, 23);
            this.BtnAddBill.TabIndex = 15;
            this.BtnAddBill.Text = "Add Bill";
            this.BtnAddBill.UseVisualStyleBackColor = true;
            this.BtnAddBill.Click += new System.EventHandler(this.BtnAddBill_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(46, 269);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(708, 150);
            this.dataGridView1.TabIndex = 16;
            // 
            // TxtOtherCharges
            // 
            this.TxtOtherCharges.Location = new System.Drawing.Point(554, 124);
            this.TxtOtherCharges.Name = "TxtOtherCharges";
            this.TxtOtherCharges.Size = new System.Drawing.Size(100, 20);
            this.TxtOtherCharges.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(554, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Enter Other Charges";
            // 
            // BillingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtOtherCharges);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BtnAddBill);
            this.Controls.Add(this.BtnCalculate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DtpBillingDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtTotal);
            this.Controls.Add(this.TxtMedicineCharges);
            this.Controls.Add(this.TxtServiceCharges);
            this.Controls.Add(this.CmbAppointment);
            this.Controls.Add(this.CmbPatient);
            this.Name = "BillingForm";
            this.Text = "BillingForm";
            this.Load += new System.EventHandler(this.BillingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbPatient;
        private System.Windows.Forms.ComboBox CmbAppointment;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox TxtServiceCharges;
        private System.Windows.Forms.TextBox TxtMedicineCharges;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DtpBillingDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnCalculate;
        private System.Windows.Forms.Button BtnAddBill;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox TxtOtherCharges;
        private System.Windows.Forms.Label label7;
    }
}