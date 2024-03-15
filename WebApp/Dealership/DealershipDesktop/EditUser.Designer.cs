namespace DealershipDesktop
{
    partial class EditUser
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
            tbxNewEmail = new TextBox();
            tbxNewPass = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnSaveUserChanges = new Button();
            btnGenerate = new Button();
            label3 = new Label();
            cbxPasswordLength = new ComboBox();
            SuspendLayout();
            // 
            // tbxNewEmail
            // 
            tbxNewEmail.Location = new Point(232, 70);
            tbxNewEmail.Name = "tbxNewEmail";
            tbxNewEmail.Size = new Size(125, 27);
            tbxNewEmail.TabIndex = 0;
            // 
            // tbxNewPass
            // 
            tbxNewPass.Location = new Point(232, 118);
            tbxNewPass.Name = "tbxNewPass";
            tbxNewPass.Size = new Size(125, 27);
            tbxNewPass.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(137, 73);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 2;
            label1.Text = "New E-mail:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(119, 121);
            label2.Name = "label2";
            label2.Size = new Size(107, 20);
            label2.TabIndex = 3;
            label2.Text = "New Password:";
            // 
            // btnSaveUserChanges
            // 
            btnSaveUserChanges.Location = new Point(174, 233);
            btnSaveUserChanges.Name = "btnSaveUserChanges";
            btnSaveUserChanges.Size = new Size(94, 29);
            btnSaveUserChanges.TabIndex = 4;
            btnSaveUserChanges.Text = "Save";
            btnSaveUserChanges.UseVisualStyleBackColor = true;
            btnSaveUserChanges.Click += btnSaveUserChanges_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(110, 198);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(158, 29);
            btnGenerate.TabIndex = 5;
            btnGenerate.Text = "Generate Password";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 166);
            label3.Name = "label3";
            label3.Size = new Size(196, 20);
            label3.TabIndex = 6;
            label3.Text = "Length of the new Password:";
            // 
            // cbxPasswordLength
            // 
            cbxPasswordLength.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxPasswordLength.FormattingEnabled = true;
            cbxPasswordLength.Location = new Point(232, 163);
            cbxPasswordLength.Name = "cbxPasswordLength";
            cbxPasswordLength.Size = new Size(125, 28);
            cbxPasswordLength.TabIndex = 7;
            // 
            // EditUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 274);
            Controls.Add(cbxPasswordLength);
            Controls.Add(label3);
            Controls.Add(btnGenerate);
            Controls.Add(btnSaveUserChanges);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbxNewPass);
            Controls.Add(tbxNewEmail);
            Name = "EditUser";
            Text = "EditUser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxNewEmail;
        private TextBox tbxNewPass;
        private Label label1;
        private Label label2;
        private Button btnSaveUserChanges;
        private Button btnGenerate;
        private Label label3;
        private ComboBox cbxPasswordLength;
    }
}