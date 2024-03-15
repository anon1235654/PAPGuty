namespace DealershipDesktop
{
    partial class EditBike
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
            label3 = new Label();
            btnSaveUserChanges = new Button();
            label2 = new Label();
            label1 = new Label();
            tbxNewModel = new TextBox();
            tbxNewBrand = new TextBox();
            tbxNewPrice = new TextBox();
            tbxNewImageURL = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 98);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 14;
            label3.Text = "New Price:";
            // 
            // btnSaveUserChanges
            // 
            btnSaveUserChanges.Location = new Point(157, 165);
            btnSaveUserChanges.Name = "btnSaveUserChanges";
            btnSaveUserChanges.Size = new Size(94, 29);
            btnSaveUserChanges.TabIndex = 12;
            btnSaveUserChanges.Text = "Save";
            btnSaveUserChanges.UseVisualStyleBackColor = true;
            btnSaveUserChanges.Click += btnSaveUserChanges_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 15);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 11;
            label2.Text = "New Brand:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 59);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 10;
            label1.Text = "New Model:";
            // 
            // tbxNewModel
            // 
            tbxNewModel.Location = new Point(141, 56);
            tbxNewModel.Name = "tbxNewModel";
            tbxNewModel.Size = new Size(125, 27);
            tbxNewModel.TabIndex = 9;
            // 
            // tbxNewBrand
            // 
            tbxNewBrand.Location = new Point(141, 12);
            tbxNewBrand.Name = "tbxNewBrand";
            tbxNewBrand.Size = new Size(125, 27);
            tbxNewBrand.TabIndex = 8;
            // 
            // tbxNewPrice
            // 
            tbxNewPrice.Location = new Point(141, 95);
            tbxNewPrice.Name = "tbxNewPrice";
            tbxNewPrice.Size = new Size(125, 27);
            tbxNewPrice.TabIndex = 15;
            // 
            // tbxNewImageURL
            // 
            tbxNewImageURL.Location = new Point(141, 132);
            tbxNewImageURL.Name = "tbxNewImageURL";
            tbxNewImageURL.Size = new Size(125, 27);
            tbxNewImageURL.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 135);
            label4.Name = "label4";
            label4.Size = new Size(118, 20);
            label4.TabIndex = 16;
            label4.Text = "New Image URL:";
            // 
            // EditBike
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(283, 201);
            Controls.Add(tbxNewImageURL);
            Controls.Add(label4);
            Controls.Add(tbxNewPrice);
            Controls.Add(label3);
            Controls.Add(btnSaveUserChanges);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbxNewModel);
            Controls.Add(tbxNewBrand);
            Name = "EditBike";
            Text = "EditBike";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Button btnSaveUserChanges;
        private Label label2;
        private Label label1;
        private TextBox tbxNewModel;
        private TextBox tbxNewBrand;
        private TextBox tbxNewPrice;
        private TextBox tbxNewImageURL;
        private Label label4;
    }
}