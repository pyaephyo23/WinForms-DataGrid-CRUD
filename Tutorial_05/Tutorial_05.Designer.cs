namespace Tutorial_05
{
    partial class Tutorial_05
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
            txtAddress = new TextBox();
            label2 = new Label();
            lblDOB = new Label();
            dtpBirth = new DateTimePicker();
            txtEmail = new TextBox();
            txtPhNo = new TextBox();
            txtName = new TextBox();
            dgvEmployee = new DataGridView();
            rdoFemale = new RadioButton();
            rdoMale = new RadioButton();
            cboEmployeeType = new ComboBox();
            btnClear = new Button();
            btnAdd = new Button();
            lblEmail = new Label();
            lblGender = new Label();
            lblPhNo = new Label();
            lblEmployeeType = new Label();
            lblName = new Label();
            imgBox = new PictureBox();
            btnUpload = new Button();
            btnPrev = new Button();
            btnNext = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgBox).BeginInit();
            SuspendLayout();
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(817, 142);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(270, 107);
            txtAddress.TabIndex = 38;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(649, 141);
            label2.Name = "label2";
            label2.Size = new Size(79, 25);
            label2.TabIndex = 50;
            label2.Text = "Address";
            // 
            // lblDOB
            // 
            lblDOB.AutoSize = true;
            lblDOB.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblDOB.Location = new Point(649, 81);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(118, 25);
            lblDOB.TabIndex = 49;
            lblDOB.Text = "Date of Birth";
            // 
            // dtpBirth
            // 
            dtpBirth.Location = new Point(817, 81);
            dtpBirth.Name = "dtpBirth";
            dtpBirth.Size = new Size(270, 27);
            dtpBirth.TabIndex = 37;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(303, 141);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(270, 27);
            txtEmail.TabIndex = 33;
            // 
            // txtPhNo
            // 
            txtPhNo.Location = new Point(303, 81);
            txtPhNo.Name = "txtPhNo";
            txtPhNo.Size = new Size(270, 27);
            txtPhNo.TabIndex = 32;
            // 
            // txtName
            // 
            txtName.Location = new Point(303, 22);
            txtName.Name = "txtName";
            txtName.Size = new Size(270, 27);
            txtName.TabIndex = 31;
            // 
            // dgvEmployee
            // 
            dgvEmployee.AllowUserToAddRows = false;
            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployee.BackgroundColor = SystemColors.ButtonHighlight;
            dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployee.Location = new Point(74, 346);
            dgvEmployee.Margin = new Padding(3, 4, 3, 4);
            dgvEmployee.Name = "dgvEmployee";
            dgvEmployee.RowHeadersWidth = 51;
            dgvEmployee.RowTemplate.Height = 25;
            dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployee.Size = new Size(1383, 300);
            dgvEmployee.TabIndex = 48;
            dgvEmployee.CellContentClick += dgvEmployee_CellContentClick;
            // 
            // rdoFemale
            // 
            rdoFemale.AutoSize = true;
            rdoFemale.Cursor = Cursors.Hand;
            rdoFemale.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            rdoFemale.Location = new Point(384, 201);
            rdoFemale.Margin = new Padding(3, 4, 3, 4);
            rdoFemale.Name = "rdoFemale";
            rdoFemale.Size = new Size(93, 29);
            rdoFemale.TabIndex = 35;
            rdoFemale.TabStop = true;
            rdoFemale.Text = "Female";
            rdoFemale.UseVisualStyleBackColor = true;
            // 
            // rdoMale
            // 
            rdoMale.AutoSize = true;
            rdoMale.Cursor = Cursors.Hand;
            rdoMale.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            rdoMale.Location = new Point(303, 201);
            rdoMale.Margin = new Padding(3, 4, 3, 4);
            rdoMale.Name = "rdoMale";
            rdoMale.Size = new Size(75, 29);
            rdoMale.TabIndex = 34;
            rdoMale.TabStop = true;
            rdoMale.Text = "Male";
            rdoMale.UseVisualStyleBackColor = true;
            // 
            // cboEmployeeType
            // 
            cboEmployeeType.FormattingEnabled = true;
            cboEmployeeType.Location = new Point(817, 21);
            cboEmployeeType.Margin = new Padding(3, 4, 3, 4);
            cboEmployeeType.Name = "cboEmployeeType";
            cboEmployeeType.Size = new Size(270, 28);
            cboEmployeeType.TabIndex = 36;
            cboEmployeeType.Text = "Select Employe Type";
            // 
            // btnClear
            // 
            btnClear.BackColor = SystemColors.MenuHighlight;
            btnClear.Cursor = Cursors.Hand;
            btnClear.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(649, 278);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(222, 44);
            btnClear.TabIndex = 40;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.MenuHighlight;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(351, 278);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(222, 44);
            btnAdd.TabIndex = 39;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmail.Location = new Point(118, 141);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 47;
            lblEmail.Text = "Email";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblGender.Location = new Point(118, 201);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(74, 25);
            lblGender.TabIndex = 46;
            lblGender.Text = "Gender";
            // 
            // lblPhNo
            // 
            lblPhNo.AutoSize = true;
            lblPhNo.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblPhNo.Location = new Point(118, 81);
            lblPhNo.Name = "lblPhNo";
            lblPhNo.Size = new Size(140, 25);
            lblPhNo.TabIndex = 45;
            lblPhNo.Text = "Phone Number";
            // 
            // lblEmployeeType
            // 
            lblEmployeeType.AutoSize = true;
            lblEmployeeType.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmployeeType.Location = new Point(649, 21);
            lblEmployeeType.Name = "lblEmployeeType";
            lblEmployeeType.Size = new Size(138, 25);
            lblEmployeeType.TabIndex = 44;
            lblEmployeeType.Text = "Employee Type";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.Location = new Point(118, 21);
            lblName.Name = "lblName";
            lblName.Size = new Size(149, 25);
            lblName.TabIndex = 43;
            lblName.Text = "Employee Name";
            // 
            // imgBox
            // 
            imgBox.BackColor = SystemColors.ActiveCaption;
            imgBox.Location = new Point(1148, 22);
            imgBox.Name = "imgBox";
            imgBox.Size = new Size(309, 227);
            imgBox.TabIndex = 51;
            imgBox.TabStop = false;
            // 
            // btnUpload
            // 
            btnUpload.BackColor = SystemColors.GrayText;
            btnUpload.Cursor = Cursors.Hand;
            btnUpload.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpload.ForeColor = Color.White;
            btnUpload.Location = new Point(1235, 278);
            btnUpload.Margin = new Padding(3, 4, 3, 4);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(222, 44);
            btnUpload.TabIndex = 52;
            btnUpload.Text = "Upload Photo";
            btnUpload.UseVisualStyleBackColor = false;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(693, 664);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(94, 29);
            btnPrev.TabIndex = 53;
            btnPrev.Text = "Previous";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(817, 664);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 29);
            btnNext.TabIndex = 54;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // Tutorial_05
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1533, 724);
            Controls.Add(btnNext);
            Controls.Add(btnPrev);
            Controls.Add(btnUpload);
            Controls.Add(imgBox);
            Controls.Add(txtAddress);
            Controls.Add(label2);
            Controls.Add(lblDOB);
            Controls.Add(dtpBirth);
            Controls.Add(txtEmail);
            Controls.Add(txtPhNo);
            Controls.Add(txtName);
            Controls.Add(dgvEmployee);
            Controls.Add(rdoFemale);
            Controls.Add(rdoMale);
            Controls.Add(cboEmployeeType);
            Controls.Add(btnClear);
            Controls.Add(btnAdd);
            Controls.Add(lblEmail);
            Controls.Add(lblGender);
            Controls.Add(lblPhNo);
            Controls.Add(lblEmployeeType);
            Controls.Add(lblName);
            Name = "Tutorial_05";
            Text = "Form1";
            Load += Tutorial_05_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtAddress;
        private Label label2;
        private Label lblDOB;
        private DateTimePicker dtpBirth;
        private TextBox txtEmail;
        private TextBox txtPhNo;
        private TextBox txtName;
        private DataGridView dgvEmployee;
        private RadioButton rdoFemale;
        private RadioButton rdoMale;
        private ComboBox cboEmployeeType;
        private Button btnClear;
        private Button btnAdd;
        private Label lblEmail;
        private Label lblGender;
        private Label lblPhNo;
        private Label lblEmployeeType;
        private Label lblName;
        private PictureBox imgBox;
        private Button btnUpload;
        private Button btnPrev;
        private Button btnNext;
    }
}