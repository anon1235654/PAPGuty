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
    public partial class EditBike : Form
    {
        private IBikeManager _bikeManager;
        private Bike bikeToEdit;
        public EditBike(Bike bike)
        {
            InitializeComponent();
            this.bikeToEdit = bike;
            _bikeManager = new BikeManager();
            tbxNewPrice.KeyPress += new KeyPressEventHandler(tbxNewPrice_KeyPress);
        }

        private void btnSaveUserChanges_Click(object sender, EventArgs e)
        {
            if (tbxNewModel.Text.Trim() != string.Empty)
            {
                if (!_bikeManager.UpdateBikeModel(bikeToEdit, tbxNewModel.Text))
                {
                    MessageBox.Show("Failed to update Model.");
                    
                }
                
            }
            if (tbxNewBrand.Text.Trim() != string.Empty)
            {
                if (!_bikeManager.UpdateBikeBrand(bikeToEdit, tbxNewBrand.Text))
                {
                    MessageBox.Show("Failed to update Brand.");
                }
            }
            if (tbxNewPrice.Text.Trim() != string.Empty)
            {
                if (!_bikeManager.UpdateBikePrice(bikeToEdit, Convert.ToDouble(tbxNewPrice.Text)))
                {
                    MessageBox.Show("Failed to update Price.");
                }
            }
            if (tbxNewImageURL.Text.Trim() != string.Empty)
            {
                if (!_bikeManager.UpdateBikeImage(bikeToEdit, tbxNewImageURL.Text))
                {
                    MessageBox.Show("Failed to update Image.");
                }
            }
        }

        private void tbxNewPrice_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
