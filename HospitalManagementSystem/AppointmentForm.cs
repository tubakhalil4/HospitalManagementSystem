using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HospitalManagementSystem
{
    public partial class AppointmentForm : Form
    {
        string connectionString = "server=localhost;user=root;password=kh@lil1;database=HospitalDB;";
        int selectedAppointmentId = 0;

        public AppointmentForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.AppointmentForm_Load);
        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            LoadAppointments();
            LoadDoctors();
            LoadPatients();
        }

        private void LoadAppointments()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = "SELECT a.AppointmentId, p.Name AS Patient, d.Name AS Doctor, a.AppointmentDate, a.AppointmentTime, a.Reason " +
                                   "FROM Appointment a " +
                                   "JOIN Patient p ON a.PatientID = p.PatientID " +
                                   "JOIN Doctor d ON a.DoctorId = d.DoctorId";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointments: " + ex.Message);
            }
        }

        private void LoadDoctors()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT DoctorId, Name FROM Doctor";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                CmbDoctor.Items.Clear();
                while (reader.Read())
                {
                    CmbDoctor.Items.Add(new ComboBoxItem(reader["Name"].ToString(), Convert.ToInt32(reader["DoctorId"])));
                }
            }
        }

        private void LoadPatients()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT PatientID, Name FROM Patient";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                CmbPatient.Items.Clear();
                while (reader.Read())
                {
                    CmbPatient.Items.Add(new ComboBoxItem(reader["Name"].ToString(), Convert.ToInt32(reader["PatientID"])));
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (CmbPatient.SelectedItem == null || CmbDoctor.SelectedItem == null || string.IsNullOrEmpty(DtpDate.Text) || string.IsNullOrEmpty(TxtTime.Text))
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }

            var patientId = ((ComboBoxItem)CmbPatient.SelectedItem).Value;
            var doctorId = ((ComboBoxItem)CmbDoctor.SelectedItem).Value;

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Appointment (PatientID, DoctorId, AppointmentDate, AppointmentTime, Reason) VALUES (@PatientID, @DoctorId, @Date, @Time, @Reason)";
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@PatientID", patientId);
                cmd.Parameters.AddWithValue("@DoctorId", doctorId);

                // Use DtpDate.Value formatted to yyyy-MM-dd for MySQL
                cmd.Parameters.AddWithValue("@Date", DtpDate.Value.ToString("yyyy-MM-dd"));

                cmd.Parameters.AddWithValue("@Time", TxtTime.Text);
                cmd.Parameters.AddWithValue("@Reason", TxtReason.Text);
                cmd.ExecuteNonQuery();
            }

            LoadAppointments();
            ClearFields();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedAppointmentId == 0)
            {
                MessageBox.Show("Please select an appointment to update.");
                return;
            }

            var patientId = ((ComboBoxItem)CmbPatient.SelectedItem).Value;
            var doctorId = ((ComboBoxItem)CmbDoctor.SelectedItem).Value;

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Appointment SET PatientID=@PatientID, DoctorId=@DoctorId, AppointmentDate=@Date, AppointmentTime=@Time, Reason=@Reason WHERE AppointmentId=@Id";
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@PatientID", patientId);
                cmd.Parameters.AddWithValue("@DoctorId", doctorId);
                cmd.Parameters.AddWithValue("@Date", DtpDate.Value.ToString("yyyy-MM-dd")); // Correct date format
                cmd.Parameters.AddWithValue("@Time", TxtTime.Text);
                cmd.Parameters.AddWithValue("@Reason", TxtReason.Text);
                cmd.Parameters.AddWithValue("@Id", selectedAppointmentId);
                cmd.ExecuteNonQuery();
            }

            LoadAppointments();
            ClearFields();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (selectedAppointmentId == 0)
            {
                MessageBox.Show("Please select an appointment to delete.");
                return;
            }

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM Appointment WHERE AppointmentId=@Id";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", selectedAppointmentId);
                cmd.ExecuteNonQuery();
            }

            LoadAppointments();
            ClearFields();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedAppointmentId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                CmbPatient.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                CmbDoctor.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                // Parse and set DateTimePicker value from the date string
                DateTime appointmentDate;
                if (DateTime.TryParse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), out appointmentDate))
                {
                    DtpDate.Value = appointmentDate;
                }

                TxtTime.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                TxtReason.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void ClearFields()
        {
            CmbPatient.SelectedIndex = -1;
            CmbDoctor.SelectedIndex = -1;
            DtpDate.Value = DateTime.Now; // Reset to today
            TxtTime.Clear();
            TxtReason.Clear();
            selectedAppointmentId = 0;
        }

        // Dummy handlers if needed to avoid errors
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }

    // Helper class for ComboBox
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public ComboBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
