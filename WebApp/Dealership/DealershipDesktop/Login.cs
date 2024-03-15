using AdminClasses;
using EntityClasses;
using System.Windows;
namespace DealershipDesktop
{
    public partial class Login : Form
    {
        private IUserManager _userManager = new UserManager();
        private User userToLogin;

        public Login()
        {
            InitializeComponent();
            Text = "CAS Dealership Admin Platform";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            userToLogin = new User(this.tbxEmail.Text, this.tbxPassword.Text);

            userToLogin = _userManager.Login(userToLogin);
            if (userToLogin != null)
            {
                if (_userManager.CheckPermissions(userToLogin))
                {
                    Admin admin = new Admin(userToLogin.Id, userToLogin.Name, userToLogin.Email);

                    MessageBox.Show($"Welcome, {admin.ToString()}");
                    MainPage mainPage = new MainPage(admin);
                    mainPage.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show($"You do not have permission to access this resource.");
                }
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}