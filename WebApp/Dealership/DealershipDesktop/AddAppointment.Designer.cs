namespace DealershipDesktop
{
    partial class AddAppointment
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
            cldrAppointment = new MonthCalendar();
            label1 = new Label();
            label2 = new Label();
            btnAddAppointment = new Button();
            cbxCustomer = new ComboBox();
            cbxTimePreference = new ComboBox();
            label3 = new Label();
            cbxBike = new ComboBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // cldrAppointment
            // 
            cldrAppointment.Location = new Point(18, 121);
            cldrAppointment.MaxSelectionCount = 1;
            cldrAppointment.Name = "cldrAppointment";
            cldrAppointment.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 15);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 2;
            label1.Text = "User:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 375);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 3;
            label2.Text = "label2";
            // 
            // btnAddAppointment
            // 
            btnAddAppointment.Location = new Point(96, 340);
            btnAddAppointment.Name = "btnAddAppointment";
            btnAddAppointment.Size = new Size(94, 29);
            btnAddAppointment.TabIndex = 4;
            btnAddAppointment.Text = "Submit";
            btnAddAppointment.UseVisualStyleBackColor = true;
            btnAddAppointment.Click += btnAddAppointment_Click;
            // 
            // cbxCustomer
            // 
            cbxCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxCustomer.FormattingEnabled = true;
            cbxCustomer.Location = new Point(129, 12);
            cbxCustomer.MaxDropDownItems = 10;
            cbxCustomer.Name = "cbxCustomer";
            cbxCustomer.Size = new Size(151, 28);
            cbxCustomer.TabIndex = 5;
            // 
            // cbxTimePreference
            // 
            cbxTimePreference.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTimePreference.FormattingEnabled = true;
            cbxTimePreference.Location = new Point(129, 46);
            cbxTimePreference.Name = "cbxTimePreference";
            cbxTimePreference.Size = new Size(151, 28);
            cbxTimePreference.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 49);
            label3.Name = "label3";
            label3.Size = new Size(119, 20);
            label3.TabIndex = 6;
            label3.Text = "Time Preference:";
            // 
            // cbxBike
            // 
            cbxBike.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxBike.FormattingEnabled = true;
            cbxBike.Location = new Point(129, 80);
            cbxBike.Name = "cbxBike";
            cbxBike.Size = new Size(151, 28);
            cbxBike.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 83);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 8;
            label4.Text = "Bike:";
            // 
            // AddAppointment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(298, 418);
            Controls.Add(cbxBike);
            Controls.Add(label4);
            Controls.Add(cbxTimePreference);
            Controls.Add(label3);
            Controls.Add(cbxCustomer);
            Controls.Add(btnAddAppointment);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cldrAppointment);
            Name = "AddAppointment";
            Text = "AddAppointment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MonthCalendar cldrAppointment;
        private Label label1;
        private Label label2;
        private Button btnAddAppointment;
        private ComboBox cbxCustomer;
        private ComboBox cbxTimePreference;
        private Label label3;
        private ComboBox cbxBike;
        private Label label4;
    }
}