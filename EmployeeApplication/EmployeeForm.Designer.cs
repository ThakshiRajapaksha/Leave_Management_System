namespace EmployeeApplication
{
    partial class EmployeeForm
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
            this.gbLeaveBalances = new System.Windows.Forms.GroupBox();
            this.lblShortLeaves = new System.Windows.Forms.Label();
            this.lblCasualLeaves = new System.Windows.Forms.Label();
            this.lblAnnualLeaves = new System.Windows.Forms.Label();
            this.gbApplyLeave = new System.Windows.Forms.GroupBox();
            this.btnApplyLeave = new System.Windows.Forms.Button();
            this.cmbTimeSlot = new System.Windows.Forms.ComboBox();
            this.lblTimeSlot = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.cmbLeaveType = new System.Windows.Forms.ComboBox();
            this.lblLeaveType = new System.Windows.Forms.Label();
            this.gbLeaveStatus = new System.Windows.Forms.GroupBox();
            this.btnDeleteLeave = new System.Windows.Forms.Button();
            this.dgvLeaveHistory = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.gbLeaveBalances.SuspendLayout();
            this.gbApplyLeave.SuspendLayout();
            this.gbLeaveStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaveHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // gbLeaveBalances
            // 
            this.gbLeaveBalances.Controls.Add(this.lblShortLeaves);
            this.gbLeaveBalances.Controls.Add(this.lblCasualLeaves);
            this.gbLeaveBalances.Controls.Add(this.lblAnnualLeaves);
            this.gbLeaveBalances.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLeaveBalances.Location = new System.Drawing.Point(74, 97);
            this.gbLeaveBalances.Name = "gbLeaveBalances";
            this.gbLeaveBalances.Size = new System.Drawing.Size(601, 266);
            this.gbLeaveBalances.TabIndex = 0;
            this.gbLeaveBalances.TabStop = false;
            this.gbLeaveBalances.Text = "Leave Balances";
            // 
            // lblShortLeaves
            // 
            this.lblShortLeaves.AutoSize = true;
            this.lblShortLeaves.Location = new System.Drawing.Point(20, 177);
            this.lblShortLeaves.Name = "lblShortLeaves";
            this.lblShortLeaves.Size = new System.Drawing.Size(113, 20);
            this.lblShortLeaves.TabIndex = 2;
            this.lblShortLeaves.Text = "Short Leaves:";
            this.lblShortLeaves.Click += new System.EventHandler(this.lblShortLeaves_Click);
            // 
            // lblCasualLeaves
            // 
            this.lblCasualLeaves.AutoSize = true;
            this.lblCasualLeaves.Location = new System.Drawing.Point(20, 118);
            this.lblCasualLeaves.Name = "lblCasualLeaves";
            this.lblCasualLeaves.Size = new System.Drawing.Size(125, 20);
            this.lblCasualLeaves.TabIndex = 1;
            this.lblCasualLeaves.Text = "Casual Leaves:";
            // 
            // lblAnnualLeaves
            // 
            this.lblAnnualLeaves.AutoSize = true;
            this.lblAnnualLeaves.Location = new System.Drawing.Point(21, 57);
            this.lblAnnualLeaves.Name = "lblAnnualLeaves";
            this.lblAnnualLeaves.Size = new System.Drawing.Size(124, 20);
            this.lblAnnualLeaves.TabIndex = 0;
            this.lblAnnualLeaves.Text = "Annual Leaves:";
            // 
            // gbApplyLeave
            // 
            this.gbApplyLeave.Controls.Add(this.btnApplyLeave);
            this.gbApplyLeave.Controls.Add(this.cmbTimeSlot);
            this.gbApplyLeave.Controls.Add(this.lblTimeSlot);
            this.gbApplyLeave.Controls.Add(this.dtpEndDate);
            this.gbApplyLeave.Controls.Add(this.lblEndDate);
            this.gbApplyLeave.Controls.Add(this.dtpStartDate);
            this.gbApplyLeave.Controls.Add(this.lblStartDate);
            this.gbApplyLeave.Controls.Add(this.cmbLeaveType);
            this.gbApplyLeave.Controls.Add(this.lblLeaveType);
            this.gbApplyLeave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbApplyLeave.Location = new System.Drawing.Point(74, 382);
            this.gbApplyLeave.Name = "gbApplyLeave";
            this.gbApplyLeave.Size = new System.Drawing.Size(601, 361);
            this.gbApplyLeave.TabIndex = 1;
            this.gbApplyLeave.TabStop = false;
            this.gbApplyLeave.Text = "Apply for Leave";
            // 
            // btnApplyLeave
            // 
            this.btnApplyLeave.Location = new System.Drawing.Point(460, 286);
            this.btnApplyLeave.Name = "btnApplyLeave";
            this.btnApplyLeave.Size = new System.Drawing.Size(121, 36);
            this.btnApplyLeave.TabIndex = 11;
            this.btnApplyLeave.Text = "Apply Leave";
            this.btnApplyLeave.UseVisualStyleBackColor = true;
            this.btnApplyLeave.Click += new System.EventHandler(this.btnApplyLeave_Click);
            // 
            // cmbTimeSlot
            // 
            this.cmbTimeSlot.FormattingEnabled = true;
            this.cmbTimeSlot.Items.AddRange(new object[] {
            "09:00-10:30",
            "9.30- 11.00",
            "10.00-11.30",
            "10:30-12:00",
            "13:00-14:30",
            "14:30-16:00"});
            this.cmbTimeSlot.Location = new System.Drawing.Point(143, 230);
            this.cmbTimeSlot.Name = "cmbTimeSlot";
            this.cmbTimeSlot.Size = new System.Drawing.Size(331, 28);
            this.cmbTimeSlot.TabIndex = 10;
            // 
            // lblTimeSlot
            // 
            this.lblTimeSlot.AutoSize = true;
            this.lblTimeSlot.Location = new System.Drawing.Point(20, 191);
            this.lblTimeSlot.Name = "lblTimeSlot";
            this.lblTimeSlot.Size = new System.Drawing.Size(187, 20);
            this.lblTimeSlot.TabIndex = 9;
            this.lblTimeSlot.Text = "Time Slot (Short Leave)";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(143, 136);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(331, 27);
            this.dtpEndDate.TabIndex = 8;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(20, 141);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(79, 20);
            this.lblEndDate.TabIndex = 7;
            this.lblEndDate.Text = "End Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(143, 86);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(331, 27);
            this.dtpStartDate.TabIndex = 6;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(20, 86);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(86, 20);
            this.lblStartDate.TabIndex = 5;
            this.lblStartDate.Text = "Start Date";
            // 
            // cmbLeaveType
            // 
            this.cmbLeaveType.FormattingEnabled = true;
            this.cmbLeaveType.Items.AddRange(new object[] {
            "Annual",
            "Casual",
            "Short"});
            this.cmbLeaveType.Location = new System.Drawing.Point(143, 30);
            this.cmbLeaveType.Name = "cmbLeaveType";
            this.cmbLeaveType.Size = new System.Drawing.Size(331, 28);
            this.cmbLeaveType.TabIndex = 4;
            // 
            // lblLeaveType
            // 
            this.lblLeaveType.AutoSize = true;
            this.lblLeaveType.Location = new System.Drawing.Point(20, 30);
            this.lblLeaveType.Name = "lblLeaveType";
            this.lblLeaveType.Size = new System.Drawing.Size(95, 20);
            this.lblLeaveType.TabIndex = 3;
            this.lblLeaveType.Text = "Leave Type";
            // 
            // gbLeaveStatus
            // 
            this.gbLeaveStatus.Controls.Add(this.btnDeleteLeave);
            this.gbLeaveStatus.Controls.Add(this.dgvLeaveHistory);
            this.gbLeaveStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLeaveStatus.Location = new System.Drawing.Point(729, 97);
            this.gbLeaveStatus.Name = "gbLeaveStatus";
            this.gbLeaveStatus.Size = new System.Drawing.Size(1053, 646);
            this.gbLeaveStatus.TabIndex = 2;
            this.gbLeaveStatus.TabStop = false;
            this.gbLeaveStatus.Text = "Leave Status and History";
            // 
            // btnDeleteLeave
            // 
            this.btnDeleteLeave.Location = new System.Drawing.Point(20, 571);
            this.btnDeleteLeave.Name = "btnDeleteLeave";
            this.btnDeleteLeave.Size = new System.Drawing.Size(259, 36);
            this.btnDeleteLeave.TabIndex = 12;
            this.btnDeleteLeave.Text = "Delete Selected Leave";
            this.btnDeleteLeave.UseVisualStyleBackColor = true;
            this.btnDeleteLeave.Click += new System.EventHandler(this.btnDeleteLeave_Click);
            // 
            // dgvLeaveHistory
            // 
            this.dgvLeaveHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeaveHistory.Location = new System.Drawing.Point(20, 30);
            this.dgvLeaveHistory.Name = "dgvLeaveHistory";
            this.dgvLeaveHistory.RowHeadersWidth = 51;
            this.dgvLeaveHistory.RowTemplate.Height = 24;
            this.dgvLeaveHistory.Size = new System.Drawing.Size(980, 509);
            this.dgvLeaveHistory.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(714, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(383, 35);
            this.label2.TabIndex = 4;
            this.label2.Text = "Leave Management System ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1811, 792);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbLeaveStatus);
            this.Controls.Add(this.gbApplyLeave);
            this.Controls.Add(this.gbLeaveBalances);
            this.Name = "EmployeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Dashboard - [EmployeeID]";
            this.gbLeaveBalances.ResumeLayout(false);
            this.gbLeaveBalances.PerformLayout();
            this.gbApplyLeave.ResumeLayout(false);
            this.gbApplyLeave.PerformLayout();
            this.gbLeaveStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaveHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLeaveBalances;
        private System.Windows.Forms.Label lblShortLeaves;
        private System.Windows.Forms.Label lblCasualLeaves;
        private System.Windows.Forms.Label lblAnnualLeaves;
        private System.Windows.Forms.GroupBox gbApplyLeave;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.ComboBox cmbLeaveType;
        private System.Windows.Forms.Label lblLeaveType;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblTimeSlot;
        private System.Windows.Forms.ComboBox cmbTimeSlot;
        private System.Windows.Forms.Button btnApplyLeave;
        private System.Windows.Forms.GroupBox gbLeaveStatus;
        private System.Windows.Forms.DataGridView dgvLeaveHistory;
        private System.Windows.Forms.Button btnDeleteLeave;
        private System.Windows.Forms.Label label2;
    }
}