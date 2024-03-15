namespace DealershipDesktop
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAddBike = new Button();
            tabUsers = new TabControl();
            tabPage1 = new TabPage();
            btnEditUser = new Button();
            btnRefreshUsers = new Button();
            btnDeleteUser = new Button();
            btnAddUser = new Button();
            UserTable = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            UserName = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Premium = new DataGridViewTextBoxColumn();
            isAdmin = new DataGridViewTextBoxColumn();
            tabPage2 = new TabPage();
            btnEditBike = new Button();
            btnDeleteBike = new Button();
            RefreshBikes = new Button();
            BikeTable = new DataGridView();
            BikeID = new DataGridViewTextBoxColumn();
            Brand = new DataGridViewTextBoxColumn();
            Model = new DataGridViewTextBoxColumn();
            AddedBy = new DataGridViewTextBoxColumn();
            ImageURL = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            tabPage3 = new TabPage();
            btnRefreshAppointments = new Button();
            btnAddAppointment = new Button();
            btnDeclined = new Button();
            btnDone = new Button();
            btnCancelled = new Button();
            btnAccepted = new Button();
            AppointmentsTable = new DataGridView();
            AppointmentID = new DataGridViewTextBoxColumn();
            AppointedBikeID = new DataGridViewTextBoxColumn();
            AppointedUserID = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            TimePreference = new DataGridViewTextBoxColumn();
            splitter1 = new Splitter();
            tabUsers.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UserTable).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BikeTable).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AppointmentsTable).BeginInit();
            SuspendLayout();
            // 
            // btnAddBike
            // 
            btnAddBike.Location = new Point(8, 352);
            btnAddBike.Name = "btnAddBike";
            btnAddBike.Size = new Size(141, 23);
            btnAddBike.TabIndex = 4;
            btnAddBike.Text = "Add Bike";
            btnAddBike.UseVisualStyleBackColor = true;
            btnAddBike.Click += btnAddBike_Click;
            // 
            // tabUsers
            // 
            tabUsers.Controls.Add(tabPage1);
            tabUsers.Controls.Add(tabPage2);
            tabUsers.Controls.Add(tabPage3);
            tabUsers.Location = new Point(10, 9);
            tabUsers.Margin = new Padding(3, 2, 3, 2);
            tabUsers.Name = "tabUsers";
            tabUsers.SelectedIndex = 0;
            tabUsers.Size = new Size(973, 405);
            tabUsers.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnEditUser);
            tabPage1.Controls.Add(btnRefreshUsers);
            tabPage1.Controls.Add(btnDeleteUser);
            tabPage1.Controls.Add(btnAddUser);
            tabPage1.Controls.Add(UserTable);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(965, 377);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Users";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnEditUser
            // 
            btnEditUser.Location = new Point(318, 328);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(143, 23);
            btnEditUser.TabIndex = 10;
            btnEditUser.Text = "Edit User";
            btnEditUser.UseVisualStyleBackColor = true;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // btnRefreshUsers
            // 
            btnRefreshUsers.Location = new Point(466, 328);
            btnRefreshUsers.Name = "btnRefreshUsers";
            btnRefreshUsers.Size = new Size(135, 23);
            btnRefreshUsers.TabIndex = 9;
            btnRefreshUsers.Text = "Refresh";
            btnRefreshUsers.UseVisualStyleBackColor = true;
            btnRefreshUsers.Click += button3_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(161, 328);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(151, 23);
            btnDeleteUser.TabIndex = 8;
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(6, 328);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(150, 23);
            btnAddUser.TabIndex = 7;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += button1_Click;
            // 
            // UserTable
            // 
            UserTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UserTable.Columns.AddRange(new DataGridViewColumn[] { ID, UserName, Email, Premium, isAdmin });
            UserTable.Location = new Point(6, 5);
            UserTable.MultiSelect = false;
            UserTable.Name = "UserTable";
            UserTable.ReadOnly = true;
            UserTable.RowHeadersWidth = 51;
            UserTable.RowTemplate.Height = 25;
            UserTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            UserTable.Size = new Size(637, 317);
            UserTable.TabIndex = 0;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 125;
            // 
            // UserName
            // 
            UserName.HeaderText = "UserName";
            UserName.MinimumWidth = 6;
            UserName.Name = "UserName";
            UserName.ReadOnly = true;
            UserName.Width = 125;
            // 
            // Email
            // 
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.ReadOnly = true;
            Email.Width = 125;
            // 
            // Premium
            // 
            Premium.HeaderText = "isPremium";
            Premium.MinimumWidth = 6;
            Premium.Name = "Premium";
            Premium.ReadOnly = true;
            Premium.Width = 125;
            // 
            // isAdmin
            // 
            isAdmin.HeaderText = "isAdmin";
            isAdmin.MinimumWidth = 6;
            isAdmin.Name = "isAdmin";
            isAdmin.ReadOnly = true;
            isAdmin.Width = 125;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnEditBike);
            tabPage2.Controls.Add(btnDeleteBike);
            tabPage2.Controls.Add(RefreshBikes);
            tabPage2.Controls.Add(BikeTable);
            tabPage2.Controls.Add(btnAddBike);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(965, 377);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Bikes";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnEditBike
            // 
            btnEditBike.Location = new Point(300, 352);
            btnEditBike.Name = "btnEditBike";
            btnEditBike.Size = new Size(141, 23);
            btnEditBike.TabIndex = 8;
            btnEditBike.Text = "Edit Bike";
            btnEditBike.UseVisualStyleBackColor = true;
            btnEditBike.Click += btnEditBike_Click;
            // 
            // btnDeleteBike
            // 
            btnDeleteBike.Location = new Point(154, 352);
            btnDeleteBike.Name = "btnDeleteBike";
            btnDeleteBike.Size = new Size(141, 23);
            btnDeleteBike.TabIndex = 7;
            btnDeleteBike.Text = "Delete Bike";
            btnDeleteBike.UseVisualStyleBackColor = true;
            btnDeleteBike.Click += btnDeleteBike_Click;
            // 
            // RefreshBikes
            // 
            RefreshBikes.Location = new Point(446, 352);
            RefreshBikes.Name = "RefreshBikes";
            RefreshBikes.Size = new Size(141, 23);
            RefreshBikes.TabIndex = 6;
            RefreshBikes.Text = "Refresh";
            RefreshBikes.UseVisualStyleBackColor = true;
            RefreshBikes.Click += RefreshBikes_Click;
            // 
            // BikeTable
            // 
            BikeTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BikeTable.Columns.AddRange(new DataGridViewColumn[] { BikeID, Brand, Model, AddedBy, ImageURL, Price });
            BikeTable.Location = new Point(8, 8);
            BikeTable.MultiSelect = false;
            BikeTable.Name = "BikeTable";
            BikeTable.ReadOnly = true;
            BikeTable.RowHeadersWidth = 51;
            BikeTable.RowTemplate.Height = 25;
            BikeTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BikeTable.Size = new Size(704, 338);
            BikeTable.TabIndex = 5;
            // 
            // BikeID
            // 
            BikeID.HeaderText = "ID";
            BikeID.MinimumWidth = 6;
            BikeID.Name = "BikeID";
            BikeID.ReadOnly = true;
            BikeID.Width = 125;
            // 
            // Brand
            // 
            Brand.HeaderText = "Brand";
            Brand.MinimumWidth = 6;
            Brand.Name = "Brand";
            Brand.ReadOnly = true;
            Brand.Width = 125;
            // 
            // Model
            // 
            Model.HeaderText = "Model";
            Model.MinimumWidth = 6;
            Model.Name = "Model";
            Model.ReadOnly = true;
            Model.Width = 125;
            // 
            // AddedBy
            // 
            AddedBy.HeaderText = "Added By";
            AddedBy.MinimumWidth = 6;
            AddedBy.Name = "AddedBy";
            AddedBy.ReadOnly = true;
            AddedBy.Width = 125;
            // 
            // ImageURL
            // 
            ImageURL.HeaderText = "ImageURL";
            ImageURL.MinimumWidth = 6;
            ImageURL.Name = "ImageURL";
            ImageURL.ReadOnly = true;
            ImageURL.Width = 125;
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.ReadOnly = true;
            Price.Width = 125;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnRefreshAppointments);
            tabPage3.Controls.Add(btnAddAppointment);
            tabPage3.Controls.Add(btnDeclined);
            tabPage3.Controls.Add(btnDone);
            tabPage3.Controls.Add(btnCancelled);
            tabPage3.Controls.Add(btnAccepted);
            tabPage3.Controls.Add(AppointmentsTable);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 3, 3, 3);
            tabPage3.Size = new Size(965, 377);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Appointments";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnRefreshAppointments
            // 
            btnRefreshAppointments.Location = new Point(788, 346);
            btnRefreshAppointments.Name = "btnRefreshAppointments";
            btnRefreshAppointments.Size = new Size(150, 23);
            btnRefreshAppointments.TabIndex = 10;
            btnRefreshAppointments.Text = "Refresh";
            btnRefreshAppointments.UseVisualStyleBackColor = true;
            btnRefreshAppointments.Click += btnRefreshAppointments_Click;
            // 
            // btnAddAppointment
            // 
            btnAddAppointment.Location = new Point(5, 346);
            btnAddAppointment.Name = "btnAddAppointment";
            btnAddAppointment.Size = new Size(150, 23);
            btnAddAppointment.TabIndex = 9;
            btnAddAppointment.Text = "Add Appointment";
            btnAddAppointment.UseVisualStyleBackColor = true;
            btnAddAppointment.Click += btnAddAppointment_Click;
            // 
            // btnDeclined
            // 
            btnDeclined.Location = new Point(160, 346);
            btnDeclined.Name = "btnDeclined";
            btnDeclined.Size = new Size(150, 23);
            btnDeclined.TabIndex = 8;
            btnDeclined.Text = "Mark as Declined";
            btnDeclined.UseVisualStyleBackColor = true;
            btnDeclined.Click += btnDeclined_Click;
            // 
            // btnDone
            // 
            btnDone.Location = new Point(625, 346);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(150, 23);
            btnDone.TabIndex = 7;
            btnDone.Text = "Mark as Done";
            btnDone.UseVisualStyleBackColor = true;
            btnDone.Click += btnDone_Click;
            // 
            // btnCancelled
            // 
            btnCancelled.Location = new Point(470, 346);
            btnCancelled.Name = "btnCancelled";
            btnCancelled.Size = new Size(150, 23);
            btnCancelled.TabIndex = 6;
            btnCancelled.Text = "Mark as Cancelled";
            btnCancelled.UseVisualStyleBackColor = true;
            btnCancelled.Click += btnCancelled_Click;
            // 
            // btnAccepted
            // 
            btnAccepted.Location = new Point(315, 346);
            btnAccepted.Name = "btnAccepted";
            btnAccepted.Size = new Size(150, 23);
            btnAccepted.TabIndex = 5;
            btnAccepted.Text = "Mark as Accepted";
            btnAccepted.UseVisualStyleBackColor = true;
            btnAccepted.Click += btnAccepted_Click;
            // 
            // AppointmentsTable
            // 
            AppointmentsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AppointmentsTable.Columns.AddRange(new DataGridViewColumn[] { AppointmentID, AppointedBikeID, AppointedUserID, Date, Status, TimePreference });
            AppointmentsTable.Location = new Point(0, 0);
            AppointmentsTable.MultiSelect = false;
            AppointmentsTable.Name = "AppointmentsTable";
            AppointmentsTable.ReadOnly = true;
            AppointmentsTable.RowHeadersWidth = 51;
            AppointmentsTable.RowTemplate.Height = 25;
            AppointmentsTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AppointmentsTable.Size = new Size(704, 340);
            AppointmentsTable.TabIndex = 0;
            // 
            // AppointmentID
            // 
            AppointmentID.HeaderText = "ID";
            AppointmentID.MinimumWidth = 6;
            AppointmentID.Name = "AppointmentID";
            AppointmentID.ReadOnly = true;
            AppointmentID.Width = 125;
            // 
            // AppointedBikeID
            // 
            AppointedBikeID.HeaderText = "BikeID";
            AppointedBikeID.MinimumWidth = 6;
            AppointedBikeID.Name = "AppointedBikeID";
            AppointedBikeID.ReadOnly = true;
            AppointedBikeID.Width = 125;
            // 
            // AppointedUserID
            // 
            AppointedUserID.HeaderText = "UserID";
            AppointedUserID.MinimumWidth = 6;
            AppointedUserID.Name = "AppointedUserID";
            AppointedUserID.ReadOnly = true;
            AppointedUserID.Width = 125;
            // 
            // Date
            // 
            Date.HeaderText = "Date";
            Date.MinimumWidth = 6;
            Date.Name = "Date";
            Date.ReadOnly = true;
            Date.Width = 125;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 125;
            // 
            // TimePreference
            // 
            TimePreference.HeaderText = "TimePreference";
            TimePreference.MinimumWidth = 6;
            TimePreference.Name = "TimePreference";
            TimePreference.ReadOnly = true;
            TimePreference.Width = 125;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 423);
            splitter1.TabIndex = 7;
            splitter1.TabStop = false;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 423);
            Controls.Add(splitter1);
            Controls.Add(tabUsers);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainPage";
            Text = "Form1";
            tabUsers.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)UserTable).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)BikeTable).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AppointmentsTable).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnAddBike;
        private TabControl tabUsers;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView UserTable;
        private DataGridView BikeTable;
        private DataGridViewTextBoxColumn BikeID;
        private DataGridViewTextBoxColumn Brand;
        private DataGridViewTextBoxColumn Model;
        private DataGridViewTextBoxColumn AddedBy;
        private DataGridViewTextBoxColumn ImageURL;
        private DataGridViewTextBoxColumn Price;
        private Button RefreshBikes;
        private Button btnRefreshUsers;
        private Button btnDeleteUser;
        private Button btnAddUser;
        private TabPage tabPage3;
        private DataGridView AppointmentsTable;
        private DataGridViewTextBoxColumn AppointmentID;
        private DataGridViewTextBoxColumn AppointedBikeID;
        private DataGridViewTextBoxColumn AppointedUserID;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn TimePreference;
        private Button btnAccepted;
        private Button btnDeclined;
        private Button btnDone;
        private Button btnCancelled;
        private Button btnAddAppointment;
        private Button btnRefreshAppointments;
        private Button btnEditUser;
        private Splitter splitter1;
        private Button btnDeleteBike;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn UserName;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Premium;
        private DataGridViewTextBoxColumn isAdmin;
        private Button btnEditBike;
    }
}