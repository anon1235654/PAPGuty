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

    public partial class AddAppointment : Form
    {
        private IUserManager userManager = new UserManager();
        private IBikeManager bikeManager = new BikeManager();
        private IAppointmentManager appointmentManager = new AppointmentManager();
        List<Customer> users = new List<Customer>();
        List<Bike> bikes = new List<Bike>();

        public AddAppointment()
        {
            InitializeComponent();
            users = userManager.GetUsers();
            bikes = bikeManager.GetBikes();
            foreach (User user in users)
            {
                cbxCustomer.Items.Add(user.Name);
            }
            foreach (Bike bike in bikes)
            {
                cbxBike.Items.Add($"{bike.Brand} {bike.Model}");
            }
            for (int i = 9; i <= 17; i++)
            {
                cbxTimePreference.Items.Add($"{i} - {i + 1}");
            }
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            if (cbxCustomer.Text.Trim() != "")
            {
                if (cldrAppointment.SelectionStart >= DateTime.Today)
                {
                    if (cbxTimePreference.Text.Trim() != "")
                    {
                        if (cbxBike.Text.Trim() != "")
                        {
                            
                            foreach (User user in users)
                            {
                                if (user.Name == cbxCustomer.SelectedItem.ToString().Trim())
                                {
                                    foreach (Bike bike in bikes)
                                    {
                                        if ($"{bike.Brand} {bike.Model}" == cbxBike.SelectedItem.ToString().Trim())
                                        {
                                            appointmentManager.CreateAppointment(new AdminAppointment(user.Id, bike.Id, cldrAppointment.SelectionStart, cbxTimePreference.Text.Trim()));
                                            this.Close();
                                        }
                                    }
                                    }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please choose a bike");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Choose a time Preference.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Date.");
                }
            }
            else
            {
                MessageBox.Show("Choose a Customer.");
            }
        }
    }
}
