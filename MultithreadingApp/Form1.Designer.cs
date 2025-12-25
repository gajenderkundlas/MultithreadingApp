namespace MultithreadingApp
{
    partial class frmMultiThread
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMultiThread));
            btnStart = new Button();
            lblStatus = new Label();
            btnStop = new Button();
            btnGetData = new Button();
            dgvUser = new DataGridView();
            FirstName = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            UserType = new DataGridViewTextBoxColumn();
            CreatedOn = new DataGridViewTextBoxColumn();
            label1 = new Label();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUser).BeginInit();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(108, 351);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(150, 46);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start Timer";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += button1_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(108, 273);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(78, 32);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Status";
            // 
            // btnStop
            // 
            btnStop.Location = new Point(292, 351);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(150, 46);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop Timer";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnGetData
            // 
            btnGetData.Location = new Point(471, 351);
            btnGetData.Name = "btnGetData";
            btnGetData.Size = new Size(150, 46);
            btnGetData.TabIndex = 3;
            btnGetData.Text = "Get Data";
            btnGetData.UseVisualStyleBackColor = true;
            btnGetData.Click += btnGetData_Click;
            // 
            // dgvUser
            // 
            dgvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUser.Columns.AddRange(new DataGridViewColumn[] { FirstName, LastName, Email, UserType, CreatedOn });
            dgvUser.Location = new Point(-1, 434);
            dgvUser.Name = "dgvUser";
            dgvUser.RowHeadersWidth = 82;
            dgvUser.Size = new Size(1085, 469);
            dgvUser.TabIndex = 4;
            // 
            // FirstName
            // 
            FirstName.DataPropertyName = "firstName";
            FirstName.HeaderText = "First Name";
            FirstName.MinimumWidth = 10;
            FirstName.Name = "FirstName";
            FirstName.Width = 200;
            // 
            // LastName
            // 
            LastName.DataPropertyName = "lastName";
            LastName.HeaderText = "Last Name";
            LastName.MinimumWidth = 10;
            LastName.Name = "LastName";
            LastName.Width = 200;
            // 
            // Email
            // 
            Email.DataPropertyName = "email";
            Email.HeaderText = "Email";
            Email.MinimumWidth = 10;
            Email.Name = "Email";
            Email.Width = 200;
            // 
            // UserType
            // 
            UserType.DataPropertyName = "userType";
            UserType.HeaderText = "User Type";
            UserType.MinimumWidth = 10;
            UserType.Name = "UserType";
            UserType.Width = 200;
            // 
            // CreatedOn
            // 
            CreatedOn.DataPropertyName = "createdOn";
            CreatedOn.HeaderText = "Created On";
            CreatedOn.MinimumWidth = 10;
            CreatedOn.Name = "CreatedOn";
            CreatedOn.Width = 200;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(108, 66);
            label1.Name = "label1";
            label1.Size = new Size(837, 192);
            label1.TabIndex = 5;
            label1.Text = resources.GetString("label1.Text");
            // 
            // btnReset
            // 
            btnReset.Location = new Point(651, 351);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(150, 46);
            btnReset.TabIndex = 6;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // frmMultiThread
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1088, 904);
            Controls.Add(btnReset);
            Controls.Add(label1);
            Controls.Add(dgvUser);
            Controls.Add(btnGetData);
            Controls.Add(btnStop);
            Controls.Add(lblStatus);
            Controls.Add(btnStart);
            Name = "frmMultiThread";
            Text = "Multithread App";
            ((System.ComponentModel.ISupportInitialize)dgvUser).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Label lblStatus;
        private Button btnStop;
        private Button btnGetData;
        private DataGridView dgvUser;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn UserType;
        private DataGridViewTextBoxColumn CreatedOn;
        private Label label1;
        private Button btnReset;
    }
}
