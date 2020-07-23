namespace Notebook.Forms
{
    partial class PeopleForm
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
            this.peopleGridView = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.filtersLabel = new System.Windows.Forms.Label();
            this.lastNameFilterlabel = new System.Windows.Forms.Label();
            this.lastNameFilterTextBox = new System.Windows.Forms.TextBox();
            this.birthdayFilterLabel = new System.Windows.Forms.Label();
            this.birthdayFilterStartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.birthdayFilterSeparator = new System.Windows.Forms.Label();
            this.birthdayFilterEndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.countryFilterComboBox = new System.Windows.Forms.ComboBox();
            this.countryFilterLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.peopleGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // peopleGridView
            // 
            this.peopleGridView.AllowUserToAddRows = false;
            this.peopleGridView.AllowUserToDeleteRows = false;
            this.peopleGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.peopleGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.peopleGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.peopleGridView.Location = new System.Drawing.Point(13, 56);
            this.peopleGridView.Name = "peopleGridView";
            this.peopleGridView.ReadOnly = true;
            this.peopleGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.peopleGridView.Size = new System.Drawing.Size(630, 353);
            this.peopleGridView.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addButton.Location = new System.Drawing.Point(12, 415);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editButton.Location = new System.Drawing.Point(94, 415);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.Location = new System.Drawing.Point(175, 415);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // filtersLabel
            // 
            this.filtersLabel.AutoSize = true;
            this.filtersLabel.Location = new System.Drawing.Point(12, 9);
            this.filtersLabel.Name = "filtersLabel";
            this.filtersLabel.Size = new System.Drawing.Size(34, 13);
            this.filtersLabel.TabIndex = 4;
            this.filtersLabel.Text = "Filters";
            // 
            // lastNameFilterlabel
            // 
            this.lastNameFilterlabel.AutoSize = true;
            this.lastNameFilterlabel.Location = new System.Drawing.Point(12, 34);
            this.lastNameFilterlabel.Name = "lastNameFilterlabel";
            this.lastNameFilterlabel.Size = new System.Drawing.Size(59, 13);
            this.lastNameFilterlabel.TabIndex = 5;
            this.lastNameFilterlabel.Text = "Last name:";
            // 
            // lastNameFilterTextBox
            // 
            this.lastNameFilterTextBox.Location = new System.Drawing.Point(69, 31);
            this.lastNameFilterTextBox.Name = "lastNameFilterTextBox";
            this.lastNameFilterTextBox.Size = new System.Drawing.Size(107, 20);
            this.lastNameFilterTextBox.TabIndex = 6;
            this.lastNameFilterTextBox.TextChanged += new System.EventHandler(this.lastNameFilterTextBox_TextChanged);
            // 
            // birthdayFilterLabel
            // 
            this.birthdayFilterLabel.AutoSize = true;
            this.birthdayFilterLabel.Location = new System.Drawing.Point(191, 34);
            this.birthdayFilterLabel.Name = "birthdayFilterLabel";
            this.birthdayFilterLabel.Size = new System.Drawing.Size(48, 13);
            this.birthdayFilterLabel.TabIndex = 7;
            this.birthdayFilterLabel.Text = "Birthday:";
            // 
            // birthdayFilterStartDateTimePicker
            // 
            this.birthdayFilterStartDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.birthdayFilterStartDateTimePicker.Location = new System.Drawing.Point(238, 31);
            this.birthdayFilterStartDateTimePicker.Name = "birthdayFilterStartDateTimePicker";
            this.birthdayFilterStartDateTimePicker.Size = new System.Drawing.Size(107, 20);
            this.birthdayFilterStartDateTimePicker.TabIndex = 8;
            this.birthdayFilterStartDateTimePicker.Value = new System.DateTime(2020, 7, 21, 20, 29, 37, 0);
            this.birthdayFilterStartDateTimePicker.ValueChanged += new System.EventHandler(this.birthdayFilterStartDateTimePicker_ValueChanged);
            // 
            // birthdayFilterSeparator
            // 
            this.birthdayFilterSeparator.AutoSize = true;
            this.birthdayFilterSeparator.Location = new System.Drawing.Point(350, 34);
            this.birthdayFilterSeparator.Name = "birthdayFilterSeparator";
            this.birthdayFilterSeparator.Size = new System.Drawing.Size(10, 13);
            this.birthdayFilterSeparator.TabIndex = 9;
            this.birthdayFilterSeparator.Text = "-";
            // 
            // birthdayFilterEndDateTimePicker
            // 
            this.birthdayFilterEndDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.birthdayFilterEndDateTimePicker.Location = new System.Drawing.Point(363, 31);
            this.birthdayFilterEndDateTimePicker.Name = "birthdayFilterEndDateTimePicker";
            this.birthdayFilterEndDateTimePicker.Size = new System.Drawing.Size(107, 20);
            this.birthdayFilterEndDateTimePicker.TabIndex = 10;
            this.birthdayFilterEndDateTimePicker.Value = new System.DateTime(2020, 7, 21, 20, 29, 37, 0);
            this.birthdayFilterEndDateTimePicker.ValueChanged += new System.EventHandler(this.birthdayFilterEndDateTimePicker_ValueChanged);
            // 
            // countryFilterComboBox
            // 
            this.countryFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryFilterComboBox.FormattingEnabled = true;
            this.countryFilterComboBox.Location = new System.Drawing.Point(536, 31);
            this.countryFilterComboBox.Name = "countryFilterComboBox";
            this.countryFilterComboBox.Size = new System.Drawing.Size(107, 21);
            this.countryFilterComboBox.TabIndex = 11;
            this.countryFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.countryFilterComboBox_SelectedIndexChanged);
            // 
            // countryFilterLabel
            // 
            this.countryFilterLabel.AutoSize = true;
            this.countryFilterLabel.Location = new System.Drawing.Point(490, 34);
            this.countryFilterLabel.Name = "countryFilterLabel";
            this.countryFilterLabel.Size = new System.Drawing.Size(46, 13);
            this.countryFilterLabel.TabIndex = 12;
            this.countryFilterLabel.Text = "Country:";
            // 
            // PeopleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 461);
            this.Controls.Add(this.countryFilterLabel);
            this.Controls.Add(this.countryFilterComboBox);
            this.Controls.Add(this.birthdayFilterEndDateTimePicker);
            this.Controls.Add(this.birthdayFilterSeparator);
            this.Controls.Add(this.birthdayFilterStartDateTimePicker);
            this.Controls.Add(this.birthdayFilterLabel);
            this.Controls.Add(this.lastNameFilterTextBox);
            this.Controls.Add(this.lastNameFilterlabel);
            this.Controls.Add(this.filtersLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.peopleGridView);
            this.MinimumSize = new System.Drawing.Size(671, 250);
            this.Name = "PeopleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notebook";
            ((System.ComponentModel.ISupportInitialize)(this.peopleGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView peopleGridView;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label filtersLabel;
        private System.Windows.Forms.Label lastNameFilterlabel;
        private System.Windows.Forms.TextBox lastNameFilterTextBox;
        private System.Windows.Forms.Label birthdayFilterLabel;
        private System.Windows.Forms.DateTimePicker birthdayFilterStartDateTimePicker;
        private System.Windows.Forms.Label birthdayFilterSeparator;
        private System.Windows.Forms.DateTimePicker birthdayFilterEndDateTimePicker;
        private System.Windows.Forms.ComboBox countryFilterComboBox;
        private System.Windows.Forms.Label countryFilterLabel;
    }
}