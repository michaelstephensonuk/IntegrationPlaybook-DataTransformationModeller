namespace DataMappingDesigner
{
    partial class DestinationTreeNodePropertiesForm
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
            this.components = new System.ComponentModel.Container();
            this.saveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nodePathLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.sourceNodeListBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.exampleValuesTextBox = new System.Windows.Forms.TextBox();
            this.dataTypeComboBox = new System.Windows.Forms.ComboBox();
            this.referenceDataMappingNeededCheckBox = new System.Windows.Forms.CheckBox();
            this.dataLookupNeededCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.transformTypeComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.deleteLinkButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(1898, 21);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(150, 46);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "Node:";
            // 
            // nodePathLabel
            // 
            this.nodePathLabel.AutoSize = true;
            this.nodePathLabel.Location = new System.Drawing.Point(288, 20);
            this.nodePathLabel.Name = "nodePathLabel";
            this.nodePathLabel.Size = new System.Drawing.Size(78, 32);
            this.nodePathLabel.TabIndex = 5;
            this.nodePathLabel.Text = "label4";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(288, 128);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(877, 40);
            this.comboBox1.TabIndex = 6;
            // 
            // sourceNodeListBox
            // 
            this.sourceNodeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceNodeListBox.ContextMenuStrip = this.contextMenuStrip1;
            this.sourceNodeListBox.FormattingEnabled = true;
            this.sourceNodeListBox.ItemHeight = 32;
            this.sourceNodeListBox.Location = new System.Drawing.Point(13, 99);
            this.sourceNodeListBox.Name = "sourceNodeListBox";
            this.sourceNodeListBox.ScrollAlwaysVisible = true;
            this.sourceNodeListBox.Size = new System.Drawing.Size(2017, 836);
            this.sourceNodeListBox.TabIndex = 7;
            this.sourceNodeListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sourceNodeListBox_MouseClick);
            this.sourceNodeListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sourceNodeListBox_MouseDown);
            this.sourceNodeListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sourceNodeListBox_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Text = "Delete";
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            this.contextMenuStrip1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.contextMenuStrip1_MouseClick);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(288, 71);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(877, 39);
            this.nameTextBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 32);
            this.label5.TabIndex = 10;
            this.label5.Text = "Status:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 90);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 2;
            this.tabControl1.Size = new System.Drawing.Size(2049, 998);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.exampleValuesTextBox);
            this.tabPage3.Controls.Add(this.dataTypeComboBox);
            this.tabPage3.Controls.Add(this.referenceDataMappingNeededCheckBox);
            this.tabPage3.Controls.Add(this.dataLookupNeededCheckBox);
            this.tabPage3.Controls.Add(this.nodePathLabel);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.nameTextBox);
            this.tabPage3.Controls.Add(this.transformTypeComboBox);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(8, 46);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(2033, 944);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Overview";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(146, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 32);
            this.label6.TabIndex = 19;
            this.label6.Text = "Data Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 422);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 32);
            this.label2.TabIndex = 18;
            this.label2.Text = "Example Values:";
            // 
            // exampleValuesTextBox
            // 
            this.exampleValuesTextBox.Location = new System.Drawing.Point(288, 422);
            this.exampleValuesTextBox.Multiline = true;
            this.exampleValuesTextBox.Name = "exampleValuesTextBox";
            this.exampleValuesTextBox.Size = new System.Drawing.Size(877, 292);
            this.exampleValuesTextBox.TabIndex = 17;
            // 
            // dataTypeComboBox
            // 
            this.dataTypeComboBox.FormattingEnabled = true;
            this.dataTypeComboBox.Location = new System.Drawing.Point(288, 248);
            this.dataTypeComboBox.Name = "dataTypeComboBox";
            this.dataTypeComboBox.Size = new System.Drawing.Size(877, 40);
            this.dataTypeComboBox.TabIndex = 16;
            // 
            // referenceDataMappingNeededCheckBox
            // 
            this.referenceDataMappingNeededCheckBox.AutoSize = true;
            this.referenceDataMappingNeededCheckBox.Location = new System.Drawing.Point(288, 313);
            this.referenceDataMappingNeededCheckBox.Name = "referenceDataMappingNeededCheckBox";
            this.referenceDataMappingNeededCheckBox.Size = new System.Drawing.Size(426, 36);
            this.referenceDataMappingNeededCheckBox.TabIndex = 13;
            this.referenceDataMappingNeededCheckBox.Text = "Is Reference Data Mapping Needed";
            this.referenceDataMappingNeededCheckBox.UseVisualStyleBackColor = true;
            // 
            // dataLookupNeededCheckBox
            // 
            this.dataLookupNeededCheckBox.AutoSize = true;
            this.dataLookupNeededCheckBox.Location = new System.Drawing.Point(288, 366);
            this.dataLookupNeededCheckBox.Name = "dataLookupNeededCheckBox";
            this.dataLookupNeededCheckBox.Size = new System.Drawing.Size(296, 36);
            this.dataLookupNeededCheckBox.TabIndex = 14;
            this.dataLookupNeededCheckBox.Text = "Is Data Lookup Needed";
            this.dataLookupNeededCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "Transformation Type:";
            // 
            // transformTypeComboBox
            // 
            this.transformTypeComboBox.FormattingEnabled = true;
            this.transformTypeComboBox.Location = new System.Drawing.Point(288, 188);
            this.transformTypeComboBox.Name = "transformTypeComboBox";
            this.transformTypeComboBox.Size = new System.Drawing.Size(877, 40);
            this.transformTypeComboBox.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(8, 46);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(2033, 944);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Transformation Notes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(2027, 938);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.deleteLinkButton);
            this.tabPage2.Controls.Add(this.sourceNodeListBox);
            this.tabPage2.Location = new System.Drawing.Point(8, 46);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(2033, 944);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mapped Source Nodes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // deleteLinkButton
            // 
            this.deleteLinkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteLinkButton.Location = new System.Drawing.Point(1731, 33);
            this.deleteLinkButton.Name = "deleteLinkButton";
            this.deleteLinkButton.Size = new System.Drawing.Size(287, 46);
            this.deleteLinkButton.TabIndex = 0;
            this.deleteLinkButton.Text = "Delete Source Link";
            this.deleteLinkButton.UseVisualStyleBackColor = true;
            this.deleteLinkButton.Click += new System.EventHandler(this.deleteSourceLinkButton_Click);
            // 
            // DestinationTreeNodePropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2073, 1100);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.saveButton);
            this.MinimumSize = new System.Drawing.Size(1939, 788);
            this.Name = "DestinationTreeNodePropertiesForm";
            this.Text = "DestinationTreeNodePropertiesForm";
            this.Load += new System.EventHandler(this.DestinationTreeNodePropertiesForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label nodePathLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox sourceNodeListBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox transformTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox referenceDataMappingNeededCheckBox;
        private System.Windows.Forms.CheckBox dataLookupNeededCheckBox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox exampleValuesTextBox;
        private System.Windows.Forms.ComboBox dataTypeComboBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button deleteLinkButton;
    }
}