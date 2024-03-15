using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminClasses;
using EntityClasses;
namespace DealershipDesktop
{
    public partial class MainPage : Form
    {
        private IUserManager userManager = new UserManager();
        private IBikeManager bikeManager = new BikeManager();
        private IAppointmentManager appointmentManager = new AppointmentManager();
        private Admin loggedUser;
        private int selectedUserIndex;
        private Customer selectedCustomer;
        private void TableUsers()
        {
            UserTable.Rows.Clear();
            foreach (Customer customer in userManager.GetUsers())
            {
                UserTable.Rows.Add(customer.Id.ToString(), customer.Name, customer.Email, customer.IsAdmin.ToString(), customer.IsPremium.ToString());
            }

        }
        private void TableBikes()
        {
            BikeTable.Rows.Clear();
            foreach (Bike bike in bikeManager.GetBikes())
            {
                BikeTable.Rows.Add(bike.Id.ToString(), bike.Brand, bike.Model, bike.AddedBy, bike.Image, $"{bike.Price.ToString()}€");
            }
        }
        private void TableAppointments()
        {
            AppointmentsTable.Rows.Clear();
            foreach (Appointment appointment in appointmentManager.GetAppointments())
            {
                AppointmentsTable.Rows.Add(appointment.ID, appointment.BikeId, appointment.CustomerId, appointment.Date.ToString("d"), appointment.Status, appointment.TimePreference);
            }
        }
        private void ChangeStatus(string status)
        {
            if (AppointmentsTable.SelectedRows != null || AppointmentsTable.SelectedRows.Count > 0)
            {

                try
                {
                    appointmentManager.ChangeStatus(Convert.ToInt32(AppointmentsTable.SelectedRows[0].Cells[0].Value), status);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    TableAppointments();
                }
            }
        }
        public MainPage(Admin logged)
        {
            InitializeComponent();
            loggedUser = logged;
            this.Text = $"Administration platform - {loggedUser.Name}";
            TableUsers();
            TableBikes();
            TableAppointments();
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAddBike_Click(object sender, EventArgs e)
        {
            AddBike addBike = new AddBike(loggedUser);
            addBike.ShowDialog();
        }

        private void RefreshBikes_Click(object sender, EventArgs e)
        {
            TableBikes();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (UserTable.SelectedRows[0].Cells[0].Value != null)
            {
                if (userManager.DeleteUser(Convert.ToInt32(UserTable.SelectedRows[0].Cells[0].Value)))
                {
                    MessageBox.Show("User Deleted");
                }
                else
                {
                    MessageBox.Show("Couldn't delete user.");
                }
            }
            else { MessageBox.Show("You need to select a User first."); };
            TableUsers();

        }

        private void btnAccepted_Click(object sender, EventArgs e)
        {
            ChangeStatus("Accepted");
        }

        private void btnDeclined_Click(object sender, EventArgs e)
        {
            ChangeStatus("Declined");
        }

        private void btnCancelled_Click(object sender, EventArgs e)
        {
            ChangeStatus("Cancelled");
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(AppointmentsTable.SelectedRows[0].Cells[3].Value) > DateTime.Today)
            {
                DialogResult confirmationDone = MessageBox.Show("This appointment is yet to come, are you sure you to mark it as Done?", "Do you want to Proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                switch (confirmationDone)
                {
                    case DialogResult.Yes:
                        ChangeStatus("Done");
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            else
            {
                ChangeStatus("Done");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUser AddUserForm = new AddUser();
            AddUserForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TableUsers();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment();
            addAppointment.ShowDialog();
        }

        private void btnRefreshAppointments_Click(object sender, EventArgs e)
        {
            TableAppointments();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (UserTable.SelectedRows[0].Cells[0].Value != null)
            {
                EditUser editUserForm = new EditUser(userManager.GetUser(Convert.ToInt32(UserTable.SelectedRows[0].Cells[0].Value)));
                editUserForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please choose a valid user.");
            }
        }

        private void btnDeleteBike_Click(object sender, EventArgs e)
        {
            if (BikeTable.SelectedRows[0].Cells[0].Value != null)
            {
                if (bikeManager.DeleteBike(Convert.ToInt32(BikeTable.SelectedRows[0].Cells[0].Value)))
                {
                    MessageBox.Show("Bike Deleted.");
                }
                else
                {
                    MessageBox.Show("Error Deleting Bike");
                }
            }
            else
            {
                MessageBox.Show("Select a Bike First");
            }
        }

        private void btnEditBike_Click(object sender, EventArgs e)
        {
            if (BikeTable.SelectedRows[0].Cells[0].Value != null)
            {
                EditBike editBike = new EditBike(bikeManager.GetBike(Convert.ToInt32(BikeTable.SelectedRows[0].Cells[0].Value)));
                editBike.ShowDialog();
            }
        }
    }
}
