using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityClasses;
using AdminClasses;
namespace DealershipDesktop
{
    public partial class EditUser : Form
    {
        IUserManager _userManager = new UserManager();
        private User userToEdit = new User();
        public EditUser(User userToPass)
        {
            InitializeComponent();
            userToEdit = userToPass;
            
            for(int length = 8; length < 30; length++)
            {
                cbxPasswordLength.Items.Add(length.ToString());
            }
        }


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            tbxNewPass.Text = "";
            tbxNewPass.Text = Algorythm.GenerateString(Convert.ToInt32(cbxPasswordLength.SelectedItem));
        }

        private void btnSaveUserChanges_Click(object sender, EventArgs e)
        {
            if (tbxNewEmail.Text.Trim() != string.Empty && tbxNewPass.Text.Trim() == string.Empty)
            {
                if (RegularExpressions.CheckEmail(tbxNewEmail.Text.Trim()))
                {
                    if (_userManager.UpdateUserEmail(userToEdit.Id, tbxNewEmail.Text))
                    {
                        MessageBox.Show("Updated User E-mail");
                    }
                    else
                    {
                        MessageBox.Show("An error has ocurred.");
                    }
                }
            }
            if (tbxNewPass.Text.Trim() != "" && tbxNewEmail.Text.Trim() == string.Empty)
            {
                if (RegularExpressions.CheckPassword(tbxNewPass.Text.Trim()))
                {
                    if (_userManager.UpdateUserPassword(userToEdit.Id, tbxNewPass.Text))
                    {
                        MessageBox.Show("Updated User Password.");
                    }
                    else
                    {
                        MessageBox.Show("An error has ocurred.");
                    }
                }
            }
            if (tbxNewPass.Text.Trim() != string.Empty && tbxNewEmail.Text.Trim() != string.Empty)
            {
                if (RegularExpressions.CheckCredentials(tbxNewEmail.Text.Trim(), tbxNewPass.Text.Trim()))
                {
                    if (_userManager.UpdateUserEmail(userToEdit.Id, tbxNewEmail.Text) && _userManager.UpdateUserPassword(userToEdit.Id, tbxNewPass.Text))
                    {
                        MessageBox.Show("Updated User Credentials.");
                    }
                    else
                    {
                        MessageBox.Show("An error has ocurred.");
                    }
                }
            }
        }
    }
}
