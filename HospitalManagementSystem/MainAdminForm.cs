using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    public partial class MainAdminForm : Form
    {
        public MainAdminForm()
        {
            InitializeComponent();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            Patient pf = new Patient();
            pf.FormClosed += (s, args) => this.Show();
            this.Hide();
            pf.Show();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            DoctorForm df = new DoctorForm();
            df.FormClosed += (s, args) => this.Show();
            this.Hide();
            df.Show();
        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            AppointmentForm af = new AppointmentForm();
            af.FormClosed += (s, args) => this.Show();
            this.Hide();
            af.Show();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            BillingForm bf = new BillingForm();
            bf.FormClosed += (s, args) => this.Show();
            this.Hide();
            bf.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MainAdminForm_Load(object sender, EventArgs e)
        {

        }
    }
}
