namespace BookStore_HoangNT
{
    partial class BookCategoryForm
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
            lblId = new Label();
            lblName = new Label();
            lblDesc = new Label();
            txtId = new TextBox();
            txtName = new TextBox();
            txtDescription = new TextBox();
            gbBookCategoryInfo = new GroupBox();
            gbTask = new GroupBox();
            btnExit = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            dgvBookCategoryList = new DataGridView();
            lblBookList = new Label();
            lblFormTitle = new Label();
            txtKeyword = new TextBox();
            label1 = new Label();
            btnSearch = new Button();
            gbBookCategoryInfo.SuspendLayout();
            gbTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookCategoryList).BeginInit();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.ForeColor = Color.Yellow;
            lblId.Location = new Point(21, 56);
            lblId.Margin = new Padding(4, 0, 4, 0);
            lblId.Name = "lblId";
            lblId.Size = new Size(30, 25);
            lblId.TabIndex = 0;
            lblId.Text = "ID";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(21, 111);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 25);
            lblName.TabIndex = 1;
            lblName.Text = "Name";
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.Location = new Point(21, 164);
            lblDesc.Margin = new Padding(4, 0, 4, 0);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(102, 25);
            lblDesc.TabIndex = 2;
            lblDesc.Text = "Description";
            // 
            // txtId
            // 
            txtId.BackColor = SystemColors.ControlLightLight;
            txtId.BorderStyle = BorderStyle.FixedSingle;
            txtId.Location = new Point(164, 54);
            txtId.Margin = new Padding(4);
            txtId.Name = "txtId";
            txtId.Size = new Size(156, 31);
            txtId.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(164, 108);
            txtName.Margin = new Padding(4);
            txtName.Name = "txtName";
            txtName.Size = new Size(440, 31);
            txtName.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(164, 160);
            txtDescription.Margin = new Padding(4);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(440, 126);
            txtDescription.TabIndex = 2;
            // 
            // gbBookCategoryInfo
            // 
            gbBookCategoryInfo.Controls.Add(txtDescription);
            gbBookCategoryInfo.Controls.Add(txtName);
            gbBookCategoryInfo.Controls.Add(txtId);
            gbBookCategoryInfo.Controls.Add(lblDesc);
            gbBookCategoryInfo.Controls.Add(lblName);
            gbBookCategoryInfo.Controls.Add(lblId);
            gbBookCategoryInfo.ForeColor = Color.Yellow;
            gbBookCategoryInfo.Location = new Point(31, 114);
            gbBookCategoryInfo.Margin = new Padding(4);
            gbBookCategoryInfo.Name = "gbBookCategoryInfo";
            gbBookCategoryInfo.Padding = new Padding(4);
            gbBookCategoryInfo.Size = new Size(625, 318);
            gbBookCategoryInfo.TabIndex = 18;
            gbBookCategoryInfo.TabStop = false;
            gbBookCategoryInfo.Text = " Book Category Info ";
            // 
            // gbTask
            // 
            gbTask.Controls.Add(btnExit);
            gbTask.Controls.Add(btnDelete);
            gbTask.Controls.Add(btnUpdate);
            gbTask.Controls.Add(btnAdd);
            gbTask.ForeColor = Color.Yellow;
            gbTask.Location = new Point(31, 470);
            gbTask.Margin = new Padding(4);
            gbTask.Name = "gbTask";
            gbTask.Padding = new Padding(4);
            gbTask.Size = new Size(625, 104);
            gbTask.TabIndex = 20;
            gbTask.TabStop = false;
            gbTask.Text = " Task ";
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(192, 0, 0);
            btnExit.Location = new Point(485, 44);
            btnExit.Margin = new Padding(4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(118, 36);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(192, 0, 0);
            btnDelete.Location = new Point(330, 44);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(118, 36);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(192, 0, 0);
            btnUpdate.Location = new Point(176, 44);
            btnUpdate.Margin = new Padding(4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(118, 36);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(192, 0, 0);
            btnAdd.Location = new Point(21, 44);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(118, 36);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvBookCategoryList
            // 
            dgvBookCategoryList.BackgroundColor = Color.White;
            dgvBookCategoryList.BorderStyle = BorderStyle.Fixed3D;
            dgvBookCategoryList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookCategoryList.Location = new Point(683, 310);
            dgvBookCategoryList.Margin = new Padding(4);
            dgvBookCategoryList.Name = "dgvBookCategoryList";
            dgvBookCategoryList.ReadOnly = true;
            dgvBookCategoryList.RowHeadersWidth = 51;
            dgvBookCategoryList.RowTemplate.Height = 29;
            dgvBookCategoryList.Size = new Size(483, 262);
            dgvBookCategoryList.TabIndex = 0;
            dgvBookCategoryList.SelectionChanged += dgvBookCategoryList_SelectionChanged;
            // 
            // lblBookList
            // 
            lblBookList.AutoSize = true;
            lblBookList.ForeColor = Color.Yellow;
            lblBookList.Location = new Point(683, 257);
            lblBookList.Margin = new Padding(4, 0, 4, 0);
            lblBookList.Name = "lblBookList";
            lblBookList.Size = new Size(161, 25);
            lblBookList.TabIndex = 23;
            lblBookList.Text = "Book Category List";
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            lblFormTitle.ForeColor = Color.Yellow;
            lblFormTitle.Location = new Point(31, 22);
            lblFormTitle.Margin = new Padding(4, 0, 4, 0);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(377, 54);
            lblFormTitle.TabIndex = 18;
            lblFormTitle.Text = "Category Manager";
            // 
            // txtKeyword
            // 
            txtKeyword.BackColor = SystemColors.ControlLightLight;
            txtKeyword.BorderStyle = BorderStyle.FixedSingle;
            txtKeyword.Location = new Point(775, 145);
            txtKeyword.Margin = new Padding(4);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(210, 31);
            txtKeyword.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Yellow;
            label1.Location = new Point(686, 147);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(81, 25);
            label1.TabIndex = 4;
            label1.Text = "Keyword";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(192, 0, 0);
            btnSearch.ForeColor = Color.Yellow;
            btnSearch.Location = new Point(1021, 141);
            btnSearch.Margin = new Padding(4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(118, 36);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // BookCategoryForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 0, 0);
            ClientSize = new Size(1192, 602);
            Controls.Add(btnSearch);
            Controls.Add(txtKeyword);
            Controls.Add(label1);
            Controls.Add(lblFormTitle);
            Controls.Add(lblBookList);
            Controls.Add(dgvBookCategoryList);
            Controls.Add(gbTask);
            Controls.Add(gbBookCategoryInfo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookCategoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Book Category Manager";
            Load += BookCategoryForm_Load;
            gbBookCategoryInfo.ResumeLayout(false);
            gbBookCategoryInfo.PerformLayout();
            gbTask.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBookCategoryList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private Label lblName;
        private Label lblDesc;
        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtDescription;
        private GroupBox gbBookCategoryInfo;
        private GroupBox gbTask;
        private Button btnExit;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private DataGridView dgvBookCategoryList;
        private Label lblBookList;
        private Label lblFormTitle;
        private TextBox txtKeyword;
        private Label label1;
        private Button btnSearch;
    }
}