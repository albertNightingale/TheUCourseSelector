namespace Courses
{
    partial class SelectCourses
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


        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.runButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.yearLabel = new System.Windows.Forms.Label();
            this.semesterLabel = new System.Windows.Forms.Label();
            this.yearTextbox = new System.Windows.Forms.TextBox();
            this.limitTextbox = new System.Windows.Forms.TextBox();
            this.limitLabel = new System.Windows.Forms.Label();
            this.semesterDropdown = new System.Windows.Forms.ComboBox();
            this.courseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enrollment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultTable = new System.Windows.Forms.DataGridView();
            this.searchButton = new System.Windows.Forms.Button();
            this.courseNumberLabel = new System.Windows.Forms.Label();
            this.courseTextbox = new System.Windows.Forms.TextBox();
            this.descriptionTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.resultTable)).BeginInit();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(20, 20);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(250, 150);
            this.runButton.TabIndex = 0;
            this.runButton.Text = "Start Searching";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.runButton_MouseClick);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(1000, 100);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(200, 46);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save To CSV";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.saveButton_MouseClick);
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(300, 25);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(126, 32);
            this.yearLabel.TabIndex = 2;
            this.yearLabel.Text = "        Year: ";
            // 
            // semesterLabel
            // 
            this.semesterLabel.AutoSize = true;
            this.semesterLabel.Location = new System.Drawing.Point(300, 100);
            this.semesterLabel.Name = "semesterLabel";
            this.semesterLabel.Size = new System.Drawing.Size(125, 32);
            this.semesterLabel.TabIndex = 3;
            this.semesterLabel.Text = "Semester: ";
            // 
            // yearTextbox
            // 
            this.yearTextbox.Location = new System.Drawing.Point(450, 20);
            this.yearTextbox.Name = "yearTextbox";
            this.yearTextbox.Size = new System.Drawing.Size(200, 39);
            this.yearTextbox.TabIndex = 4;
            // 
            // limitTextbox
            // 
            this.limitTextbox.Location = new System.Drawing.Point(1100, 20);
            this.limitTextbox.Name = "limitTextbox";
            this.limitTextbox.Size = new System.Drawing.Size(200, 39);
            this.limitTextbox.TabIndex = 5;
            this.limitTextbox.Text = "50";
            // 
            // limitLabel
            // 
            this.limitLabel.AutoSize = true;
            this.limitLabel.Location = new System.Drawing.Point(1000, 20);
            this.limitLabel.Name = "limitLabel";
            this.limitLabel.Size = new System.Drawing.Size(78, 32);
            this.limitLabel.TabIndex = 6;
            this.limitLabel.Text = "Limit: ";
            // 
            // semesterDropdown
            // 
            this.semesterDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.semesterDropdown.FormattingEnabled = true;
            this.semesterDropdown.Location = new System.Drawing.Point(450, 100);
            this.semesterDropdown.Name = "semesterDropdown";
            this.semesterDropdown.Size = new System.Drawing.Size(242, 40);
            this.semesterDropdown.TabIndex = 7;
            // 
            // courseName
            // 
            this.courseName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.courseName.HeaderText = "Course Name\\";
            this.courseName.MinimumWidth = 10;
            this.courseName.Name = "courseName";
            this.courseName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.courseName.Width = 200;
            // 
            // number
            // 
            this.number.HeaderText = "Course Number";
            this.number.MinimumWidth = 10;
            this.number.Name = "number";
            this.number.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.number.Width = 200;
            // 
            // title
            // 
            this.title.HeaderText = "Course Title";
            this.title.MinimumWidth = 10;
            this.title.Name = "title";
            this.title.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.title.Width = 300;
            // 
            // credit
            // 
            this.credit.HeaderText = "Credit";
            this.credit.MinimumWidth = 10;
            this.credit.Name = "credit";
            this.credit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.credit.Width = 200;
            // 
            // enrollment
            // 
            this.enrollment.HeaderText = "Enrollment";
            this.enrollment.MinimumWidth = 10;
            this.enrollment.Name = "enrollment";
            this.enrollment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.enrollment.Width = 150;
            // 
            // description
            // 
            this.description.HeaderText = "Description";
            this.description.MinimumWidth = 10;
            this.description.Name = "description";
            this.description.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.description.Width = 600;
            // 
            // resultTable
            // 
            this.resultTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.title,
            this.credit,
            this.enrollment,
            this.description});
            this.resultTable.Location = new System.Drawing.Point(20, 199);
            this.resultTable.Name = "resultTable";
            this.resultTable.RowHeadersWidth = 82;
            this.resultTable.Size = new System.Drawing.Size(1450, 500);
            this.resultTable.TabIndex = 8;
            this.resultTable.Text = "dataGridView1";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(20, 750);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(250, 150);
            this.searchButton.TabIndex = 9;
            this.searchButton.Text = "Search Courses";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.searchButton_MouseClick);
            // 
            // courseNumberLabel
            // 
            this.courseNumberLabel.AutoSize = true;
            this.courseNumberLabel.Location = new System.Drawing.Point(20, 950);
            this.courseNumberLabel.Name = "courseNumberLabel";
            this.courseNumberLabel.Size = new System.Drawing.Size(251, 32);
            this.courseNumberLabel.TabIndex = 10;
            this.courseNumberLabel.Text = "        Course Number: ";
            // 
            // courseTextbox
            // 
            this.courseTextbox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.courseTextbox.Location = new System.Drawing.Point(80, 1000);
            this.courseTextbox.Name = "courseTextbox";
            this.courseTextbox.Size = new System.Drawing.Size(200, 39);
            this.courseTextbox.TabIndex = 11;
            // 
            // descriptionTextbox
            // 
            this.descriptionTextbox.Location = new System.Drawing.Point(350, 750);
            this.descriptionTextbox.Multiline = true;
            this.descriptionTextbox.Name = "descriptionTextbox";
            this.descriptionTextbox.Size = new System.Drawing.Size(1000, 400);
            this.descriptionTextbox.TabIndex = 12;
            this.descriptionTextbox.Text = " ";
            // 
            // SelectCourses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 1229);
            this.Controls.Add(this.descriptionTextbox);
            this.Controls.Add(this.courseTextbox);
            this.Controls.Add(this.courseNumberLabel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.resultTable);
            this.Controls.Add(this.semesterDropdown);
            this.Controls.Add(this.limitLabel);
            this.Controls.Add(this.limitTextbox);
            this.Controls.Add(this.yearTextbox);
            this.Controls.Add(this.semesterLabel);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.runButton);
            this.Name = "SelectCourses";
            this.Text = "Select";
            ((System.ComponentModel.ISupportInitialize)(this.resultTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }




        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label semesterLabel;
        private System.Windows.Forms.TextBox yearTextbox;
        private System.Windows.Forms.TextBox limitTextbox;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label limitLabel;
        private System.Windows.Forms.ComboBox semesterDropdown;
        private System.Windows.Forms.DataGridView resultTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn enrollment;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label courseNumberLabel;
        private System.Windows.Forms.TextBox courseTextbox;
        private System.Windows.Forms.TextBox descriptionTextbox;
    }
}

