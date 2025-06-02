using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HospitalManagementSystem
{
    public partial class DoctorForm : Form
    {
        private int selectedDoctorId = -1;

        private string connectionString = "server=localhost;user=root;password=kh@lil1;database=HospitalDB;";
        private MySqlConnection connection;

        public DoctorForm()
        {
            InitializeComponent();

            BtnAdd.Click += BtnAdd_Click;
            BtnUpdate.Click += BtnUpdate_Click;
            BtnDelete.Click += BtnDelete_Click;
            DgvDoctors.CellClick += DgvDoctors_CellClick;

            LoadDoctors();

            connection = new MySqlConnection(connectionString);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string name = TxtName.Text.Trim();
            string specialization = TxtSpecialization.Text.Trim();
            string phone = TxtPhone.Text.Trim();
            string gender = CmbGender.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(specialization) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO Doctor (Name, Specialization, Phone, Gender) VALUES (@Name, @Specialization, @Phone, @Gender)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Specialization", specialization);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Gender", gender);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Doctor added successfully!");
                LoadDoctors();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

     

        private void DgvDoctors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DgvDoctors.Rows[e.RowIndex];

                // Use "DoctorId" column to get selectedDoctorId
                selectedDoctorId = Convert.ToInt32(row.Cells["DoctorId"].Value);

                TxtName.Text = row.Cells["Name"].Value.ToString();
                TxtSpecialization.Text = row.Cells["Specialization"].Value.ToString();
                TxtPhone.Text = row.Cells["Phone"].Value.ToString();
                CmbGender.SelectedItem = row.Cells["Gender"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            TxtName.Clear();
            TxtSpecialization.Clear();
            TxtPhone.Clear();
            CmbGender.SelectedIndex = -1;
        }

        private void LoadDoctors()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM Doctor";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            DgvDoctors.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading doctors: " + ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedDoctorId == -1)
            {
                MessageBox.Show("Please select a doctor to update.");
                return;
            }

            string name = TxtName.Text.Trim();
            string specialization = TxtSpecialization.Text.Trim();
            string phone = TxtPhone.Text.Trim();
            string gender = CmbGender.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(specialization) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Doctor SET Name=@Name, Specialization=@Specialization, Phone=@Phone, Gender=@Gender WHERE DoctorId=@DoctorId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Specialization", specialization);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@DoctorId", selectedDoctorId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Doctor updated successfully!");
                LoadDoctors();
                ClearFields();
                selectedDoctorId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (selectedDoctorId == -1)
            {
                MessageBox.Show("Please select a doctor to delete.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this doctor?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Doctor WHERE DoctorId=@DoctorId";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@DoctorId", selectedDoctorId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Doctor deleted successfully!");
                    LoadDoctors();
                    ClearFields();
                    selectedDoctorId = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void DoctorForm_Load(object sender, EventArgs e)
        {
            // You can keep it empty or call LoadDoctors() here if you want
        }
        private void label3_Click(object sender, EventArgs e)
        {
            // You can leave it empty if no action needed
        }

        private void DgvDoctors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Unused method, leave empty or remove if not needed
        }
    }
}



