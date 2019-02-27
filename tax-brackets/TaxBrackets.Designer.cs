namespace tax_brackets
{
    partial class TaxBrackets
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
            this.incomeLabel = new System.Windows.Forms.Label();
            this.taxRateLabel = new System.Windows.Forms.Label();
            this.taxRate = new System.Windows.Forms.Label();
            this.statusGroup = new System.Windows.Forms.GroupBox();
            this.single = new System.Windows.Forms.RadioButton();
            this.marriedJoint = new System.Windows.Forms.RadioButton();
            this.headOfHousehold = new System.Windows.Forms.RadioButton();
            this.marriedSeparate = new System.Windows.Forms.RadioButton();
            this.calculateButton = new System.Windows.Forms.Button();
            this.income = new System.Windows.Forms.TextBox();
            this.taxOwedLabel = new System.Windows.Forms.Label();
            this.taxOwed = new System.Windows.Forms.Label();
            this.statusGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // incomeLabel
            // 
            this.incomeLabel.AutoSize = true;
            this.incomeLabel.Location = new System.Drawing.Point(12, 9);
            this.incomeLabel.Name = "incomeLabel";
            this.incomeLabel.Size = new System.Drawing.Size(83, 13);
            this.incomeLabel.TabIndex = 0;
            this.incomeLabel.Text = "Taxable Income";
            // 
            // taxRateLabel
            // 
            this.taxRateLabel.AutoSize = true;
            this.taxRateLabel.Location = new System.Drawing.Point(36, 169);
            this.taxRateLabel.Name = "taxRateLabel";
            this.taxRateLabel.Size = new System.Drawing.Size(94, 13);
            this.taxRateLabel.TabIndex = 1;
            this.taxRateLabel.Text = "Marginal Tax Rate";
            // 
            // taxRate
            // 
            this.taxRate.AutoSize = true;
            this.taxRate.Location = new System.Drawing.Point(136, 169);
            this.taxRate.Name = "taxRate";
            this.taxRate.Size = new System.Drawing.Size(24, 13);
            this.taxRate.TabIndex = 2;
            this.taxRate.Text = "0 %";
            // 
            // statusGroup
            // 
            this.statusGroup.Controls.Add(this.marriedSeparate);
            this.statusGroup.Controls.Add(this.headOfHousehold);
            this.statusGroup.Controls.Add(this.marriedJoint);
            this.statusGroup.Controls.Add(this.single);
            this.statusGroup.Location = new System.Drawing.Point(39, 32);
            this.statusGroup.Name = "statusGroup";
            this.statusGroup.Size = new System.Drawing.Size(202, 95);
            this.statusGroup.TabIndex = 3;
            this.statusGroup.TabStop = false;
            this.statusGroup.Text = "Filing Status";
            // 
            // single
            // 
            this.single.AutoSize = true;
            this.single.Location = new System.Drawing.Point(15, 19);
            this.single.Name = "single";
            this.single.Size = new System.Drawing.Size(54, 17);
            this.single.TabIndex = 0;
            this.single.TabStop = true;
            this.single.Text = "Single";
            this.single.UseVisualStyleBackColor = true;
            // 
            // marriedJoint
            // 
            this.marriedJoint.AutoSize = true;
            this.marriedJoint.Location = new System.Drawing.Point(15, 37);
            this.marriedJoint.Name = "marriedJoint";
            this.marriedJoint.Size = new System.Drawing.Size(119, 17);
            this.marriedJoint.TabIndex = 1;
            this.marriedJoint.TabStop = true;
            this.marriedJoint.Text = "Married Filing Jointly";
            this.marriedJoint.UseVisualStyleBackColor = true;
            // 
            // headOfHousehold
            // 
            this.headOfHousehold.AutoSize = true;
            this.headOfHousehold.Location = new System.Drawing.Point(15, 55);
            this.headOfHousehold.Name = "headOfHousehold";
            this.headOfHousehold.Size = new System.Drawing.Size(117, 17);
            this.headOfHousehold.TabIndex = 2;
            this.headOfHousehold.TabStop = true;
            this.headOfHousehold.Text = "Head of Household";
            this.headOfHousehold.UseVisualStyleBackColor = true;
            // 
            // marriedSeparate
            // 
            this.marriedSeparate.AutoSize = true;
            this.marriedSeparate.Location = new System.Drawing.Point(15, 73);
            this.marriedSeparate.Name = "marriedSeparate";
            this.marriedSeparate.Size = new System.Drawing.Size(140, 17);
            this.marriedSeparate.TabIndex = 3;
            this.marriedSeparate.TabStop = true;
            this.marriedSeparate.Text = "Married Filing Separately";
            this.marriedSeparate.UseVisualStyleBackColor = true;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(70, 133);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(124, 23);
            this.calculateButton.TabIndex = 4;
            this.calculateButton.Text = "Calculate Taxes Owed";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // income
            // 
            this.income.Location = new System.Drawing.Point(101, 6);
            this.income.Name = "income";
            this.income.Size = new System.Drawing.Size(140, 20);
            this.income.TabIndex = 5;
            // 
            // taxOwedLabel
            // 
            this.taxOwedLabel.AutoSize = true;
            this.taxOwedLabel.Location = new System.Drawing.Point(36, 188);
            this.taxOwedLabel.Name = "taxOwedLabel";
            this.taxOwedLabel.Size = new System.Drawing.Size(94, 13);
            this.taxOwedLabel.TabIndex = 6;
            this.taxOwedLabel.Text = "Income Tax Owed";
            // 
            // taxOwed
            // 
            this.taxOwed.AutoSize = true;
            this.taxOwed.Location = new System.Drawing.Point(136, 188);
            this.taxOwed.Name = "taxOwed";
            this.taxOwed.Size = new System.Drawing.Size(37, 13);
            this.taxOwed.TabIndex = 7;
            this.taxOwed.Text = "$ 0.00";
            // 
            // TaxBrackets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 215);
            this.Controls.Add(this.taxOwed);
            this.Controls.Add(this.taxOwedLabel);
            this.Controls.Add(this.income);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.statusGroup);
            this.Controls.Add(this.taxRate);
            this.Controls.Add(this.taxRateLabel);
            this.Controls.Add(this.incomeLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TaxBrackets";
            this.Text = "Program 2";
            this.statusGroup.ResumeLayout(false);
            this.statusGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label incomeLabel;
        private System.Windows.Forms.Label taxRateLabel;
        private System.Windows.Forms.Label taxRate;
        private System.Windows.Forms.GroupBox statusGroup;
        private System.Windows.Forms.RadioButton marriedSeparate;
        private System.Windows.Forms.RadioButton headOfHousehold;
        private System.Windows.Forms.RadioButton marriedJoint;
        private System.Windows.Forms.RadioButton single;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.TextBox income;
        private System.Windows.Forms.Label taxOwedLabel;
        private System.Windows.Forms.Label taxOwed;
    }
}

