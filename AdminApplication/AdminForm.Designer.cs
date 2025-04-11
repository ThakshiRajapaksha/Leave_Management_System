namespace AdminApplication
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtShortLeaves = new System.Windows.Forms.TextBox();
            this.lblShortLeaves = new System.Windows.Forms.Label();
            this.txtCasualLeaves = new System.Windows.Forms.TextBox();
            this.lblCasualLeaves = new System.Windows.Forms.Label();
            this.txtAnnualLeaves = new System.Windows.Forms.TextBox();
            this.lblAnnualLeaves = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.chkPermanent = new System.Windows.Forms.CheckBox();
            this.dtpJoinDate = new System.Windows.Forms.DateTimePicker();
            this.lblJoinDate = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtEmpID = new System.Windows.Forms.TextBox();
            this.lblEmpID = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSetRoster = new System.Windows.Forms.Button();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.txtRosterEmpID = new System.Windows.Forms.TextBox();
            this.lblRosterEmpID = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.dgvPendingLeaves = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.btnAllReport = new System.Windows.Forms.Button();
            this.btnIndividualReport = new System.Windows.Forms.Button();
            this.dtpReportEnd = new System.Windows.Forms.DateTimePicker();
            this.lblReportEnd = new System.Windows.Forms.Label();
            this.dtpReportStart = new System.Windows.Forms.DateTimePicker();
            this.lblReportStart = new System.Windows.Forms.Label();
            this.txtReportEmpID = new System.Windows.Forms.TextBox();
            this.lblReportEmpID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingLeaves)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtShortLeaves);
            this.groupBox1.Controls.Add(this.lblShortLeaves);
            this.groupBox1.Controls.Add(this.txtCasualLeaves);
            this.groupBox1.Controls.Add(this.lblCasualLeaves);
            this.groupBox1.Controls.Add(this.txtAnnualLeaves);
            this.groupBox1.Controls.Add(this.lblAnnualLeaves);
            this.groupBox1.Controls.Add(this.btnRegister);
            this.groupBox1.Controls.Add(this.chkPermanent);
            this.groupBox1.Controls.Add(this.dtpJoinDate);
            this.groupBox1.Controls.Add(this.lblJoinDate);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.txtEmpID);
            this.groupBox1.Controls.Add(this.lblEmpID);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(34, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(785, 346);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Register Employee";
            // 
            // txtShortLeaves
            // 
            this.txtShortLeaves.Location = new System.Drawing.Point(133, 289);
            this.txtShortLeaves.Name = "txtShortLeaves";
            this.txtShortLeaves.Size = new System.Drawing.Size(200, 27);
            this.txtShortLeaves.TabIndex = 15;
            // 
            // lblShortLeaves
            // 
            this.lblShortLeaves.AutoSize = true;
            this.lblShortLeaves.Location = new System.Drawing.Point(8, 295);
            this.lblShortLeaves.Name = "lblShortLeaves";
            this.lblShortLeaves.Size = new System.Drawing.Size(108, 20);
            this.lblShortLeaves.TabIndex = 14;
            this.lblShortLeaves.Text = "Short Leaves";
            // 
            // txtCasualLeaves
            // 
            this.txtCasualLeaves.Location = new System.Drawing.Point(559, 232);
            this.txtCasualLeaves.Name = "txtCasualLeaves";
            this.txtCasualLeaves.Size = new System.Drawing.Size(178, 27);
            this.txtCasualLeaves.TabIndex = 13;
            // 
            // lblCasualLeaves
            // 
            this.lblCasualLeaves.AutoSize = true;
            this.lblCasualLeaves.Location = new System.Drawing.Point(430, 232);
            this.lblCasualLeaves.Name = "lblCasualLeaves";
            this.lblCasualLeaves.Size = new System.Drawing.Size(120, 20);
            this.lblCasualLeaves.TabIndex = 12;
            this.lblCasualLeaves.Text = "Casual Leaves";
            // 
            // txtAnnualLeaves
            // 
            this.txtAnnualLeaves.Location = new System.Drawing.Point(133, 232);
            this.txtAnnualLeaves.Name = "txtAnnualLeaves";
            this.txtAnnualLeaves.Size = new System.Drawing.Size(200, 27);
            this.txtAnnualLeaves.TabIndex = 11;
            // 
            // lblAnnualLeaves
            // 
            this.lblAnnualLeaves.AutoSize = true;
            this.lblAnnualLeaves.Location = new System.Drawing.Point(8, 235);
            this.lblAnnualLeaves.Name = "lblAnnualLeaves";
            this.lblAnnualLeaves.Size = new System.Drawing.Size(119, 20);
            this.lblAnnualLeaves.TabIndex = 10;
            this.lblAnnualLeaves.Text = "Annual Leaves";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(636, 306);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(101, 34);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // chkPermanent
            // 
            this.chkPermanent.AutoSize = true;
            this.chkPermanent.Location = new System.Drawing.Point(471, 177);
            this.chkPermanent.Name = "chkPermanent";
            this.chkPermanent.Size = new System.Drawing.Size(112, 24);
            this.chkPermanent.TabIndex = 8;
            this.chkPermanent.Text = "Permanent";
            this.chkPermanent.UseVisualStyleBackColor = true;
            this.chkPermanent.CheckedChanged += new System.EventHandler(this.chkPermanent_CheckedChanged);
            // 
            // dtpJoinDate
            // 
            this.dtpJoinDate.Location = new System.Drawing.Point(133, 178);
            this.dtpJoinDate.Name = "dtpJoinDate";
            this.dtpJoinDate.Size = new System.Drawing.Size(309, 27);
            this.dtpJoinDate.TabIndex = 7;
            this.dtpJoinDate.ValueChanged += new System.EventHandler(this.dtpJoinDate_ValueChanged);
            // 
            // lblJoinDate
            // 
            this.lblJoinDate.AutoSize = true;
            this.lblJoinDate.Location = new System.Drawing.Point(8, 178);
            this.lblJoinDate.Name = "lblJoinDate";
            this.lblJoinDate.Size = new System.Drawing.Size(81, 20);
            this.lblJoinDate.TabIndex = 6;
            this.lblJoinDate.Text = "Join Date";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(133, 120);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(542, 27);
            this.txtName.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 123);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 20);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(559, 54);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(178, 27);
            this.txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(467, 61);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(83, 20);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // txtEmpID
            // 
            this.txtEmpID.Location = new System.Drawing.Point(133, 61);
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.Size = new System.Drawing.Size(200, 27);
            this.txtEmpID.TabIndex = 1;
            // 
            // lblEmpID
            // 
            this.lblEmpID.AutoSize = true;
            this.lblEmpID.Location = new System.Drawing.Point(8, 61);
            this.lblEmpID.Name = "lblEmpID";
            this.lblEmpID.Size = new System.Drawing.Size(104, 20);
            this.lblEmpID.TabIndex = 0;
            this.lblEmpID.Text = "Employee ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSetRoster);
            this.groupBox2.Controls.Add(this.dtpEndTime);
            this.groupBox2.Controls.Add(this.lblEndTime);
            this.groupBox2.Controls.Add(this.dtpStartTime);
            this.groupBox2.Controls.Add(this.lblStartTime);
            this.groupBox2.Controls.Add(this.txtRosterEmpID);
            this.groupBox2.Controls.Add(this.lblRosterEmpID);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(34, 443);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(785, 375);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set Roster";
            // 
            // btnSetRoster
            // 
            this.btnSetRoster.Location = new System.Drawing.Point(587, 281);
            this.btnSetRoster.Name = "btnSetRoster";
            this.btnSetRoster.Size = new System.Drawing.Size(150, 32);
            this.btnSetRoster.TabIndex = 10;
            this.btnSetRoster.Text = "Set  Roster";
            this.btnSetRoster.UseVisualStyleBackColor = true;
            this.btnSetRoster.Click += new System.EventHandler(this.btnSetRoster_Click);
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(133, 111);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(200, 27);
            this.dtpEndTime.TabIndex = 6;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(7, 111);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(80, 20);
            this.lblEndTime.TabIndex = 5;
            this.lblEndTime.Text = "End Time";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(559, 49);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(178, 27);
            this.dtpStartTime.TabIndex = 4;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(430, 54);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(87, 20);
            this.lblStartTime.TabIndex = 3;
            this.lblStartTime.Text = "Start Time";
            // 
            // txtRosterEmpID
            // 
            this.txtRosterEmpID.Location = new System.Drawing.Point(133, 51);
            this.txtRosterEmpID.Name = "txtRosterEmpID";
            this.txtRosterEmpID.Size = new System.Drawing.Size(200, 27);
            this.txtRosterEmpID.TabIndex = 2;
            // 
            // lblRosterEmpID
            // 
            this.lblRosterEmpID.AutoSize = true;
            this.lblRosterEmpID.Location = new System.Drawing.Point(8, 58);
            this.lblRosterEmpID.Name = "lblRosterEmpID";
            this.lblRosterEmpID.Size = new System.Drawing.Size(104, 20);
            this.lblRosterEmpID.TabIndex = 1;
            this.lblRosterEmpID.Text = "Employee ID";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReject);
            this.groupBox3.Controls.Add(this.btnApprove);
            this.groupBox3.Controls.Add(this.dgvPendingLeaves);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(856, 91);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(935, 344);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Approve/Reject Leaves";
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(452, 292);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(99, 30);
            this.btnReject.TabIndex = 12;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(336, 292);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(99, 30);
            this.btnApprove.TabIndex = 11;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // dgvPendingLeaves
            // 
            this.dgvPendingLeaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingLeaves.Location = new System.Drawing.Point(20, 30);
            this.dgvPendingLeaves.Name = "dgvPendingLeaves";
            this.dgvPendingLeaves.RowHeadersWidth = 51;
            this.dgvPendingLeaves.RowTemplate.Height = 24;
            this.dgvPendingLeaves.Size = new System.Drawing.Size(880, 243);
            this.dgvPendingLeaves.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.AccessibleName = "btnIndividualReport";
            this.groupBox4.Controls.Add(this.dgvReports);
            this.groupBox4.Controls.Add(this.btnAllReport);
            this.groupBox4.Controls.Add(this.btnIndividualReport);
            this.groupBox4.Controls.Add(this.dtpReportEnd);
            this.groupBox4.Controls.Add(this.lblReportEnd);
            this.groupBox4.Controls.Add(this.dtpReportStart);
            this.groupBox4.Controls.Add(this.lblReportStart);
            this.groupBox4.Controls.Add(this.txtReportEmpID);
            this.groupBox4.Controls.Add(this.lblReportEmpID);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(856, 441);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(935, 377);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Individual Report";
            // 
            // dgvReports
            // 
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Location = new System.Drawing.Point(21, 182);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.RowHeadersWidth = 51;
            this.dgvReports.RowTemplate.Height = 24;
            this.dgvReports.Size = new System.Drawing.Size(880, 189);
            this.dgvReports.TabIndex = 14;
            this.dgvReports.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReports_CellContentClick);
            // 
            // btnAllReport
            // 
            this.btnAllReport.AccessibleName = "";
            this.btnAllReport.Location = new System.Drawing.Point(480, 140);
            this.btnAllReport.Name = "btnAllReport";
            this.btnAllReport.Size = new System.Drawing.Size(169, 30);
            this.btnAllReport.TabIndex = 13;
            this.btnAllReport.Text = "All Employees Report";
            this.btnAllReport.UseVisualStyleBackColor = true;
            this.btnAllReport.Click += new System.EventHandler(this.btnAllReport_Click);
            // 
            // btnIndividualReport
            // 
            this.btnIndividualReport.AccessibleName = "";
            this.btnIndividualReport.Location = new System.Drawing.Point(336, 140);
            this.btnIndividualReport.Name = "btnIndividualReport";
            this.btnIndividualReport.Size = new System.Drawing.Size(129, 30);
            this.btnIndividualReport.TabIndex = 12;
            this.btnIndividualReport.Text = "Individual Report";
            this.btnIndividualReport.UseVisualStyleBackColor = true;
            this.btnIndividualReport.Click += new System.EventHandler(this.btnIndividualReport_Click);
            // 
            // dtpReportEnd
            // 
            this.dtpReportEnd.Location = new System.Drawing.Point(140, 104);
            this.dtpReportEnd.Name = "dtpReportEnd";
            this.dtpReportEnd.Size = new System.Drawing.Size(312, 27);
            this.dtpReportEnd.TabIndex = 10;
            // 
            // lblReportEnd
            // 
            this.lblReportEnd.AutoSize = true;
            this.lblReportEnd.Location = new System.Drawing.Point(17, 111);
            this.lblReportEnd.Name = "lblReportEnd";
            this.lblReportEnd.Size = new System.Drawing.Size(79, 20);
            this.lblReportEnd.TabIndex = 9;
            this.lblReportEnd.Text = "End Date";
            // 
            // dtpReportStart
            // 
            this.dtpReportStart.Location = new System.Drawing.Point(554, 47);
            this.dtpReportStart.Name = "dtpReportStart";
            this.dtpReportStart.Size = new System.Drawing.Size(324, 27);
            this.dtpReportStart.TabIndex = 8;
            // 
            // lblReportStart
            // 
            this.lblReportStart.AutoSize = true;
            this.lblReportStart.Location = new System.Drawing.Point(439, 51);
            this.lblReportStart.Name = "lblReportStart";
            this.lblReportStart.Size = new System.Drawing.Size(86, 20);
            this.lblReportStart.TabIndex = 4;
            this.lblReportStart.Text = "Start Date";
            // 
            // txtReportEmpID
            // 
            this.txtReportEmpID.Location = new System.Drawing.Point(140, 49);
            this.txtReportEmpID.Name = "txtReportEmpID";
            this.txtReportEmpID.Size = new System.Drawing.Size(157, 27);
            this.txtReportEmpID.TabIndex = 3;
            // 
            // lblReportEmpID
            // 
            this.lblReportEmpID.AutoSize = true;
            this.lblReportEmpID.Location = new System.Drawing.Point(17, 52);
            this.lblReportEmpID.Name = "lblReportEmpID";
            this.lblReportEmpID.Size = new System.Drawing.Size(104, 20);
            this.lblReportEmpID.TabIndex = 2;
            this.lblReportEmpID.Text = "Employee ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(693, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 32);
            this.label1.TabIndex = 4;
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(738, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(375, 35);
            this.label2.TabIndex = 5;
            this.label2.Text = "Leave Management System";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1840, 853);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingLeaves)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEmpID;
        private System.Windows.Forms.Label lblEmpID;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.CheckBox chkPermanent;
        private System.Windows.Forms.DateTimePicker dtpJoinDate;
        private System.Windows.Forms.Label lblJoinDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblRosterEmpID;
        private System.Windows.Forms.TextBox txtRosterEmpID;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Button btnSetRoster;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.DataGridView dgvPendingLeaves;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblReportEmpID;
        private System.Windows.Forms.Label lblReportStart;
        private System.Windows.Forms.TextBox txtReportEmpID;
        private System.Windows.Forms.Label lblReportEnd;
        private System.Windows.Forms.DateTimePicker dtpReportStart;
        private System.Windows.Forms.Button btnIndividualReport;
        private System.Windows.Forms.DateTimePicker dtpReportEnd;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.Button btnAllReport;
        private System.Windows.Forms.TextBox txtAnnualLeaves;
        private System.Windows.Forms.Label lblAnnualLeaves;
        private System.Windows.Forms.Label lblCasualLeaves;
        private System.Windows.Forms.TextBox txtCasualLeaves;
        private System.Windows.Forms.TextBox txtShortLeaves;
        private System.Windows.Forms.Label lblShortLeaves;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}