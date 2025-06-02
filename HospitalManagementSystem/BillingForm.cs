using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HospitalManagementSystem
{
    public partial class BillingForm : Form
    {
        string connectionString = "server=localhost;user id=root;password=kh@lil1;database=HospitalDB";

        public BillingForm()
        {
            InitializeComponent();
            this.Load += BillingForm_Load;
            BtnCalculate.Click += BtnCalculate_Click;
            BtnAddBill.Click += BtnAddBill_Click;
            CmbPatient.SelectedIndexChanged += CmbPatient_SelectedIndexChanged;
        }

        private void BillingForm_Load(object sender, EventArgs e)
        {
            LoadBills();
            LoadPatients();
        }

        private void LoadBills()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM billing";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading bills: " + ex.Message);
                }
            }
        }

        private void LoadPatients()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT PatientId, Name FROM patient";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    CmbPatient.DataSource = dt;
                    CmbPatient.DisplayMember = "Name";
                    CmbPatient.ValueMember = "PatientId";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading patients: " + ex.Message);
                }
            }
        }

        private void CmbPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbPatient.SelectedValue == null || CmbPatient.SelectedValue.ToString() == "System.Data.DataRowView")
                return;

            int patientId;
            if (int.TryParse(CmbPatient.SelectedValue.ToString(), out patientId))
            {
                LoadAppointmentsForPatient(patientId);
            }
        }

        private void LoadAppointmentsForPatient(int patientId)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT AppointmentId FROM appointment WHERE PatientID = @PatientID";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@PatientID", patientId);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    CmbAppointment.DataSource = dt;
                    CmbAppointment.DisplayMember = "AppointmentId";
                    CmbAppointment.ValueMember = "AppointmentId";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading appointments: " + ex.Message);
                }
            }
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal service = string.IsNullOrEmpty(TxtServiceCharges.Text) ? 0 : Convert.ToDecimal(TxtServiceCharges.Text);
                decimal medicine = string.IsNullOrEmpty(TxtMedicineCharges.Text) ? 0 : Convert.ToDecimal(TxtMedicineCharges.Text);
                decimal other = string.IsNullOrEmpty(TxtOtherCharges.Text) ? 0 : Convert.ToDecimal(TxtOtherCharges.Text);

                decimal total = service + medicine + other;
                TxtTotal.Text = total.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating total: " + ex.Message);
            }
        }

        private void BtnAddBill_Click(object sender, EventArgs e)
        {
            if (CmbPatient.SelectedValue == null || CmbAppointment.SelectedValue == null || string.IsNullOrEmpty(TxtTotal.Text))
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = @"INSERT INTO billing 
                        (PatientId, AppointmentId, ServiceCharges, MedicineCharges, OtherCharges, TotalAmount, BillingDate, PatientName)
                        VALUES 
                        (@PatientId, @AppointmentId, @ServiceCharges, @MedicineCharges, @OtherCharges, @TotalAmount, @BillingDate, @PatientName)";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@PatientId", CmbPatient.SelectedValue);
                    cmd.Parameters.AddWithValue("@AppointmentId", CmbAppointment.SelectedValue);
                    cmd.Parameters.AddWithValue("@ServiceCharges", TxtServiceCharges.Text);
                    cmd.Parameters.AddWithValue("@MedicineCharges", TxtMedicineCharges.Text);
                    cmd.Parameters.AddWithValue("@OtherCharges", TxtOtherCharges.Text);
                    cmd.Parameters.AddWithValue("@TotalAmount", TxtTotal.Text);
                    cmd.Parameters.AddWithValue("@BillingDate", DtpBillingDate.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@PatientName", CmbPatient.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill Added Successfully!");
                    LoadBills();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while saving bill: " + ex.Message);
                }
            }
        }

        private void ClearFields()
        {
            CmbPatient.SelectedIndex = -1;
            CmbAppointment.DataSource = null;
            TxtServiceCharges.Clear();
            TxtMedicineCharges.Clear();
            TxtOtherCharges.Clear();
            TxtTotal.Clear();
            DtpBillingDate.Value = DateTime.Now;
        }
    }
}
