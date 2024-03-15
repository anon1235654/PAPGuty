namespace DealershipDesktop
{
    partial class AddBike
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
            tbxBrand = new TextBox();
            tbxModel = new TextBox();
            tbxUrl = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnAddBike = new Button();
            label4 = new Label();
            txtPrice = new TextBox();
            SuspendLayout();
            // 
            // tbxBrand
            // 
            tbxBrand.Location = new Point(143, 80);
            tbxBrand.Name = "tbxBrand";
            tbxBrand.Size = new Size(220, 27);
            tbxBrand.TabIndex = 0;
            // 
            // tbxModel
            // 
            tbxModel.Location = new Point(143, 122);
            tbxModel.Name = "tbxModel";
            tbxModel.Size = new Size(220, 27);
            tbxModel.TabIndex = 1;
            // 
            // tbxUrl
            // 
            tbxUrl.Location = new Point(143, 169);
            tbxUrl.Name = "tbxUrl";
            tbxUrl.Size = new Size(220, 27);
            tbxUrl.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 87);
            label1.Name = "label1";
            label1.Size = new Size(48, 20);
            label1.TabIndex = 3;
            label1.Text = "Brand";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 125);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 4;
            label2.Text = "Model";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(56, 172);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 5;
            label3.Text = "Image URL";
            // 
            // btnAddBike
            // 
            btnAddBike.Location = new Point(202, 247);
            btnAddBike.Name = "btnAddBike";
            btnAddBike.Size = new Size(94, 29);
            btnAddBike.TabIndex = 6;
            btnAddBike.Text = "Add Bike";
            btnAddBike.UseVisualStyleBackColor = true;
            btnAddBike.Click += btnAddBike_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(84, 212);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 8;
            label4.Text = "Price";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(143, 209);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(220, 27);
            txtPrice.TabIndex = 7;
            // 
            // AddBike
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(427, 305);
            Controls.Add(label4);
            Controls.Add(txtPrice);
            Controls.Add(btnAddBike);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbxUrl);
            Controls.Add(tbxModel);
            Controls.Add(tbxBrand);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddBike";
            Text = "AddBike";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxBrand;
        private TextBox tbxModel;
        private TextBox tbxUrl;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnAddBike;
        private Label label4;
        private TextBox txtPrice;
    }
}