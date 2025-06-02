using System;
using System.Data;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HospitalManagementSystem
{
    public partial class Patient : Form
    {
        private readonly string connectionString = "server=localhost;user id=root;password=kh@lil1;database= HospitalDB";

        public Patient()
        {
            InitializeComponent();
       

            // Wire events here
            BtnUpdate.Click += BtnUpdate_Click;
            BtnDelete.Click += BtnDelete_Click;
        }


        

        private void Patient_Load(object sender, EventArgs e)
        {
            LoadPatients();
        }

        private void LoadPatients()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM Patient";  // Use correct table name with uppercase P
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    DgvPatients.DataSource = table;  // Make sure your DataGridView name is correct
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void TxtPhone_TextChanged(object sender, EventArgs e)
        {
        }

        private void BtnAdd_Click(object sender, EventArgs e)
      
        {
            string name = TxtName.Text;
            string gender = CmbGender.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("Please select a gender.");
                return;
            }

            string ageText = TxtAge.Text;
            string address = TxtAddress.Text;
            string phone = TxtPhone.Text;

            if (!int.TryParse(ageText, out int age))
            {
                MessageBox.Show("Please enter a valid numeric age.");
                return; // stop processing if age is invalid
            }

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO Patient (Name, Gender, Age, Address, Phone) VALUES (@Name, @Gender, @Age, @Address, @Phone)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Patient added successfully!");
                    LoadPatients();  // Reload DataGridView data
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

    

        private void DgvPatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DgvPatients.Rows[e.RowIndex];

                TxtName.Text = row.Cells["Name"].Value.ToString();
                CmbGender.SelectedItem = row.Cells["Gender"].Value.ToString(); // ✅ Correct

                TxtAge.Text = row.Cells["Age"].Value.ToString();
                TxtAddress.Text = row.Cells["Address"].Value.ToString();
                TxtPhone.Text = row.Cells["Phone"].Value.ToString();
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
{
    if (DgvPatients.CurrentRow != null)
    {
        int id = Convert.ToInt32(DgvPatients.CurrentRow.Cells["PatientID"].Value);
        string name = TxtName.Text;
                string gender = CmbGender.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(gender))
                {
                    MessageBox.Show("Please select a gender.");
                    return;
                }

                int age = int.Parse(TxtAge.Text);
        string address = TxtAddress.Text;
        string phone = TxtPhone.Text;

        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            try
            {
                con.Open();
                string query = "UPDATE Patient SET Name=@Name, Gender=@Gender, Age=@Age, Address=@Address, Phone=@Phone WHERE PatientID=@ID";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Phone", phone);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient updated successfully!");
                LoadPatients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (DgvPatients.CurrentRow != null)
            {
                int id = Convert.ToInt32(DgvPatients.CurrentRow.Cells["PatientID"].Value);

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        string query = "DELETE FROM Patient WHERE PatientID=@ID";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Patient deleted successfully!");
                        LoadPatients();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

    }

}





