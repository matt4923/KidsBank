namespace KidsBank
{
    partial class frmNewUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.radBoy = new System.Windows.Forms.RadioButton();
            this.radGirl = new System.Windows.Forms.RadioButton();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.btnSaveAndNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConfPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(15, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(130, 20);
            this.txtName.TabIndex = 0;
            // 
            // radBoy
            // 
            this.radBoy.AutoSize = true;
            this.radBoy.Location = new System.Drawing.Point(15, 210);
            this.radBoy.Name = "radBoy";
            this.radBoy.Size = new System.Drawing.Size(43, 17);
            this.radBoy.TabIndex = 5;
            this.radBoy.TabStop = true;
            this.radBoy.Text = "Boy";
            this.radBoy.UseVisualStyleBackColor = true;
            // 
            // radGirl
            // 
            this.radGirl.AutoSize = true;
            this.radGirl.Location = new System.Drawing.Point(15, 233);
            this.radGirl.Name = "radGirl";
            this.radGirl.Size = new System.Drawing.Size(40, 17);
            this.radGirl.TabIndex = 6;
            this.radGirl.TabStop = true;
            this.radGirl.Text = "Girl";
            this.radGirl.UseVisualStyleBackColor = true;
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Location = new System.Drawing.Point(70, 207);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(96, 23);
            this.btnSaveClose.TabIndex = 7;
            this.btnSaveClose.Text = "Save";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Location = new System.Drawing.Point(70, 236);
            this.btnSaveAndNew.Name = "btnSaveAndNew";
            this.btnSaveAndNew.Size = new System.Drawing.Size(96, 23);
            this.btnSaveAndNew.TabIndex = 8;
            this.btnSaveAndNew.Text = "Save and New";
            this.btnSaveAndNew.UseVisualStyleBackColor = true;
            this.btnSaveAndNew.Click += new System.EventHandler(this.btnSaveAndNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(70, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(15, 69);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(130, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Confirm Password";
            // 
            // txtConfPassword
            // 
            this.txtConfPassword.Location = new System.Drawing.Point(15, 108);
            this.txtConfPassword.Name = "txtConfPassword";
            this.txtConfPassword.Size = new System.Drawing.Size(130, 20);
            this.txtConfPassword.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Beginning Balance";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(15, 165);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(130, 20);
            this.txtBalance.TabIndex = 4;
            this.txtBalance.Text = "$";
            // 
            // frmNewUser
            // 
            this.AcceptButton = this.btnSaveClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(177, 306);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveAndNew);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.radGirl);
            this.Controls.Add(this.radBoy);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.txtConfPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "frmNewUser";
            this.Text = "New User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RadioButton radBoy;
        private System.Windows.Forms.RadioButton radGirl;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Button btnSaveAndNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConfPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBalance;
    }
}