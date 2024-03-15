namespace DealershipDesktop
{
    partial class AddUser
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
            label4 = new Label();
            btnAddUser = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tbxPasswordSelect = new TextBox();
            tbxEmailSelect = new TextBox();
            tbxNameSelect = new TextBox();
            checkBoxAdmin = new CheckBox();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 148);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 17;
            label4.Text = "Is Admin?";
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(165, 166);
            btnAddUser.Margin = new Padding(3, 2, 3, 2);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(82, 22);
            btnAddUser.TabIndex = 15;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 117);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 14;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 82);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 13;
            label2.Text = "E-mail";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 53);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 12;
            label1.Text = "Name";
            // 
            // tbxPasswordSelect
            // 
            tbxPasswordSelect.Location = new Point(119, 115);
            tbxPasswordSelect.Margin = new Padding(3, 2, 3, 2);
            tbxPasswordSelect.Name = "tbxPasswordSelect";
            tbxPasswordSelect.Size = new Size(193, 23);
            tbxPasswordSelect.TabIndex = 11;
            // 
            // tbxEmailSelect
            // 
            tbxEmailSelect.Location = new Point(119, 80);
            tbxEmailSelect.Margin = new Padding(3, 2, 3, 2);
            tbxEmailSelect.Name = "tbxEmailSelect";
            tbxEmailSelect.Size = new Size(193, 23);
            tbxEmailSelect.TabIndex = 10;
            // 
            // tbxNameSelect
            // 
            tbxNameSelect.Location = new Point(119, 48);
            tbxNameSelect.Margin = new Padding(3, 2, 3, 2);
            tbxNameSelect.Name = "tbxNameSelect";
            tbxNameSelect.Size = new Size(193, 23);
            tbxNameSelect.TabIndex = 9;
            // 
            // checkBoxAdmin
            // 
            checkBoxAdmin.AutoSize = true;
            checkBoxAdmin.Location = new Point(119, 149);
            checkBoxAdmin.Name = "checkBoxAdmin";
            checkBoxAdmin.Size = new Size(15, 14);
            checkBoxAdmin.TabIndex = 18;
            checkBoxAdmin.UseVisualStyleBackColor = true;
            // 
            // AddUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 208);
            Controls.Add(checkBoxAdmin);
            Controls.Add(label4);
            Controls.Add(btnAddUser);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbxPasswordSelect);
            Controls.Add(tbxEmailSelect);
            Controls.Add(tbxNameSelect);
            Name = "AddUser";
            Text = "AddUser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private TextBox txtPrice;
        private Button btnAddUser;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox tbxPasswordSelect;
        private TextBox tbxEmailSelect;
        private TextBox tbxNameSelect;
        private CheckBox checkBoxAdmin;
    }
}