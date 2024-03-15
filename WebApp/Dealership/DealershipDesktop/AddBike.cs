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
    public partial class AddBike : Form
    {
        private Admin adminLogged;
        private IBikeManager bikeManager = new BikeManager();
        public AddBike(Admin logged)
        {
            InitializeComponent();
            adminLogged = logged;
            txtPrice.KeyPress += new KeyPressEventHandler(txtPrice_KeyPress);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits (0-9), decimal point, and control keys like Backspace and Delete
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Suppress the key press
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true; // Suppress additional decimal points
            }
        }
        private void btnAddBike_Click(object sender, EventArgs e)
        {
            if (tbxBrand.Text.Trim() == "" || tbxModel.Text.Trim() == "" || txtPrice.Text.Trim() == "")
            {
                MessageBox.Show("Please fill in all the fields");
            }
            else
            {
                if (Convert.ToInt32(txtPrice.Text.Trim()) < 0)
                {
                    MessageBox.Show("The Price cannot be negative.");
                }
                else
                {
                    if (tbxUrl.Text.Trim() == "")
                    {
                        bikeManager.AddBike(new Bike(tbxModel.Text, tbxBrand.Text, adminLogged.Name, Convert.ToDouble(txtPrice.Text.Trim())));
                    }
                    else
                    {
                        bikeManager.AddBike(new Bike(tbxModel.Text, tbxBrand.Text, adminLogged.Name, tbxUrl.Text, Convert.ToDouble(txtPrice.Text.Trim())));
                    }
                }
                this.Close();
            }


        }
    }
}
