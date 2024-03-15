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
    public partial class AddUser : Form
    {
        IUserManager _userManager = new UserManager();
        public AddUser()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if(tbxNameSelect.Text.Trim() == "" || tbxEmailSelect.Text.Trim() == "" || tbxPasswordSelect.Text.Trim() == "")
            {
                MessageBox.Show("Fill in all the fields.");
            }
            else
            {
                if (RegularExpressions.CheckCredentials(tbxEmailSelect.Text.Trim(), tbxPasswordSelect.Text.Trim()))
                {
                    bool isAdmin = checkBoxAdmin.Checked;
                    bool userRegisted = _userManager.RegisterUser(new User(tbxEmailSelect.Text.Trim(), tbxNameSelect.Text.Trim(), tbxPasswordSelect.Text.Trim(), false));
                    if (isAdmin)
                    {
                        if (userRegisted)
                        {
                            MessageBox.Show($"{tbxNameSelect.Text.Trim()} / {tbxEmailSelect.Text.Trim()} created.");

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show($"Could not create the user.");
                        }
                    }
                } else { MessageBox.Show("E-mail in invalid format or Password is invalid (Password must be at least 8 characters long, may include Capital Letters and cannot contain special characters)."); }
            }
        }
    }
}
