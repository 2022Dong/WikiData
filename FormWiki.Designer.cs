﻿namespace WikiData
{
    partial class FormWiki
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lvDisplay = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.gbStructure = new System.Windows.Forms.GroupBox();
            this.rdoNonLinear = new System.Windows.Forms.RadioButton();
            this.rdoLinear = new System.Windows.Forms.RadioButton();
            this.txtDefinition = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDefinition = new System.Windows.Forms.Label();
            this.stsMsg = new System.Windows.Forms.StatusStrip();
            this.stsMsglbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbStructure.SuspendLayout();
            this.stsMsg.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(106, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(162, 49);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(282, 396);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(453, 396);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(372, 396);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lvDisplay
            // 
            this.lvDisplay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.category});
            this.lvDisplay.HideSelection = false;
            this.lvDisplay.Location = new System.Drawing.Point(282, 16);
            this.lvDisplay.Name = "lvDisplay";
            this.lvDisplay.Size = new System.Drawing.Size(246, 346);
            this.lvDisplay.TabIndex = 6;
            this.lvDisplay.UseCompatibleStateImageBehavior = false;
            this.lvDisplay.View = System.Windows.Forms.View.Details;
            this.lvDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvDisplay_MouseClick);
            // 
            // name
            // 
            this.name.Text = "Name";
            // 
            // category
            // 
            this.category.Text = "Category";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 51);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(122, 20);
            this.txtSearch.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 96);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(122, 20);
            this.txtName.TabIndex = 8;
            this.txtName.DoubleClick += new System.EventHandler(this.txtName_DoubleClick);
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(13, 142);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(121, 21);
            this.cboCategory.TabIndex = 9;
            // 
            // gbStructure
            // 
            this.gbStructure.Controls.Add(this.rdoNonLinear);
            this.gbStructure.Controls.Add(this.rdoLinear);
            this.gbStructure.Location = new System.Drawing.Point(13, 190);
            this.gbStructure.Name = "gbStructure";
            this.gbStructure.Size = new System.Drawing.Size(200, 100);
            this.gbStructure.TabIndex = 10;
            this.gbStructure.TabStop = false;
            this.gbStructure.Text = "Structure";
            // 
            // rdoNonLinear
            // 
            this.rdoNonLinear.AutoSize = true;
            this.rdoNonLinear.Location = new System.Drawing.Point(31, 66);
            this.rdoNonLinear.Name = "rdoNonLinear";
            this.rdoNonLinear.Size = new System.Drawing.Size(73, 17);
            this.rdoNonLinear.TabIndex = 1;
            this.rdoNonLinear.TabStop = true;
            this.rdoNonLinear.Text = "Non-linear";
            this.rdoNonLinear.UseVisualStyleBackColor = true;
            // 
            // rdoLinear
            // 
            this.rdoLinear.AutoSize = true;
            this.rdoLinear.Location = new System.Drawing.Point(31, 29);
            this.rdoLinear.Name = "rdoLinear";
            this.rdoLinear.Size = new System.Drawing.Size(54, 17);
            this.rdoLinear.TabIndex = 0;
            this.rdoLinear.TabStop = true;
            this.rdoLinear.Text = "Linear";
            this.rdoLinear.UseVisualStyleBackColor = true;
            // 
            // txtDefinition
            // 
            this.txtDefinition.Location = new System.Drawing.Point(13, 319);
            this.txtDefinition.Multiline = true;
            this.txtDefinition.Name = "txtDefinition";
            this.txtDefinition.Size = new System.Drawing.Size(231, 111);
            this.txtDefinition.TabIndex = 11;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(162, 96);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "Name";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(162, 142);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 13;
            this.lblCategory.Text = "Category";
            // 
            // lblDefinition
            // 
            this.lblDefinition.AutoSize = true;
            this.lblDefinition.Location = new System.Drawing.Point(13, 297);
            this.lblDefinition.Name = "lblDefinition";
            this.lblDefinition.Size = new System.Drawing.Size(51, 13);
            this.lblDefinition.TabIndex = 14;
            this.lblDefinition.Text = "Definition";
            // 
            // stsMsg
            // 
            this.stsMsg.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsMsg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsMsglbl});
            this.stsMsg.Location = new System.Drawing.Point(0, 435);
            this.stsMsg.Name = "stsMsg";
            this.stsMsg.Size = new System.Drawing.Size(561, 22);
            this.stsMsg.TabIndex = 15;
            this.stsMsg.Text = "Feedback";
            // 
            // stsMsglbl
            // 
            this.stsMsglbl.Name = "stsMsglbl";
            this.stsMsglbl.Size = new System.Drawing.Size(57, 17);
            this.stsMsglbl.Text = "Feedback";
            // 
            // FormWiki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 457);
            this.Controls.Add(this.stsMsg);
            this.Controls.Add(this.lblDefinition);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtDefinition);
            this.Controls.Add(this.gbStructure);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lvDisplay);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpen);
            this.Name = "FormWiki";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wiki";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWiki_FormClosing);
            this.Load += new System.EventHandler(this.FormWiki_Load);
            this.gbStructure.ResumeLayout(false);
            this.gbStructure.PerformLayout();
            this.stsMsg.ResumeLayout(false);
            this.stsMsg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ListView lvDisplay;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.GroupBox gbStructure;
        private System.Windows.Forms.RadioButton rdoNonLinear;
        private System.Windows.Forms.RadioButton rdoLinear;
        private System.Windows.Forms.TextBox txtDefinition;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDefinition;
        private System.Windows.Forms.StatusStrip stsMsg;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader category;
        private System.Windows.Forms.ToolStripStatusLabel stsMsglbl;
    }
}

