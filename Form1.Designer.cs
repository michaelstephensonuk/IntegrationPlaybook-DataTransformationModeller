using DataMappingDesigner.Controls;

namespace DataMappingDesigner
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem23 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem24 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCentre = new System.Windows.Forms.Panel();
            this.destinationSplitter = new System.Windows.Forms.Splitter();
            this.sourceSplitter = new System.Windows.Forms.Splitter();
            this.destinationTreeImageList = new System.Windows.Forms.ImageList(this.components);
            this.sourceTreeImageList = new System.Windows.Forms.ImageList(this.components);
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem22,
            this.toolStripSeparator1,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripSeparator6,
            this.toolStripMenuItem10});
            this.contextMenuStrip1.Name = "contextMenuStripSourceTree";
            this.contextMenuStrip1.Size = new System.Drawing.Size(325, 206);
            this.contextMenuStrip1.Text = "Source Actions";
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(324, 38);
            this.toolStripMenuItem4.Text = "Add Child";
            // 
            // toolStripMenuItem22
            // 
            this.toolStripMenuItem22.Name = "toolStripMenuItem22";
            this.toolStripMenuItem22.Size = new System.Drawing.Size(324, 38);
            this.toolStripMenuItem22.Text = "Add Multiple Children";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(321, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(324, 38);
            this.toolStripMenuItem5.Text = "Move Up";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(324, 38);
            this.toolStripMenuItem6.Text = "Move Down";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(321, 6);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(324, 38);
            this.toolStripMenuItem10.Text = "Remove Node";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.toolStripSeparator5,
            this.toolStripMenuItem2,
            this.toolStripMenuItem23,
            this.toolStripSeparator2,
            this.toolStripMenuItem1,
            this.toolStripMenuItem3,
            this.toolStripSeparator7,
            this.toolStripMenuItem24});
            this.contextMenuStrip2.Name = "contextMenuStripSourceTree";
            this.contextMenuStrip2.Size = new System.Drawing.Size(325, 250);
            this.contextMenuStrip2.Text = "Source Actions";
            this.contextMenuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip2_ItemClicked);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(324, 38);
            this.toolStripMenuItem7.Text = "Properties";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(321, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(324, 38);
            this.toolStripMenuItem2.Text = "Add Child";
            // 
            // toolStripMenuItem23
            // 
            this.toolStripMenuItem23.Name = "toolStripMenuItem23";
            this.toolStripMenuItem23.Size = new System.Drawing.Size(324, 38);
            this.toolStripMenuItem23.Text = "Add Multiple Children";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(321, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(324, 38);
            this.toolStripMenuItem1.Text = "Move Up";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(324, 38);
            this.toolStripMenuItem3.Text = "Move Down";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(321, 6);
            // 
            // toolStripMenuItem24
            // 
            this.toolStripMenuItem24.Name = "toolStripMenuItem24";
            this.toolStripMenuItem24.Size = new System.Drawing.Size(324, 38);
            this.toolStripMenuItem24.Text = "Remove Node";
            // 
            // panelCentre
            // 
            this.panelCentre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCentre.Location = new System.Drawing.Point(0, 0);
            this.panelCentre.Name = "panelCentre";
            this.panelCentre.Size = new System.Drawing.Size(2129, 1165);
            this.panelCentre.TabIndex = 7;
            this.panelCentre.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCentre_Paint);
            // 
            // destinationSplitter
            // 
            this.destinationSplitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.destinationSplitter.Location = new System.Drawing.Point(1535, 40);
            this.destinationSplitter.Name = "destinationSplitter";
            this.destinationSplitter.Size = new System.Drawing.Size(10, 1125);
            this.destinationSplitter.TabIndex = 5;
            this.destinationSplitter.TabStop = false;
            this.destinationSplitter.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.destinationSplitter_SplitterMoved);
            // 
            // sourceSplitter
            // 
            this.sourceSplitter.Location = new System.Drawing.Point(656, 40);
            this.sourceSplitter.Name = "sourceSplitter";
            this.sourceSplitter.Size = new System.Drawing.Size(10, 1125);
            this.sourceSplitter.TabIndex = 4;
            this.sourceSplitter.TabStop = false;
            this.sourceSplitter.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.sourceSplitter_SplitterMoved);
            // 
            // destinationTreeImageList
            // 
            this.destinationTreeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.destinationTreeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("destinationTreeImageList.ImageStream")));
            this.destinationTreeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.destinationTreeImageList.Images.SetKeyName(0, "QuestionImage");
            this.destinationTreeImageList.Images.SetKeyName(1, "OKImage");
            this.destinationTreeImageList.Images.SetKeyName(2, "AlertImage");
            this.destinationTreeImageList.Images.SetKeyName(3, "WarningImage");
            this.destinationTreeImageList.Images.SetKeyName(4, "BlockedImage");
            this.destinationTreeImageList.Images.SetKeyName(5, "Task_16x.png");
            this.destinationTreeImageList.Images.SetKeyName(6, "ProgressBar_16x.png");
            // 
            // sourceTreeImageList
            // 
            this.sourceTreeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.sourceTreeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("sourceTreeImageList.ImageStream")));
            this.sourceTreeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.sourceTreeImageList.Images.SetKeyName(0, "Document_16x.png");
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem14,
            this.toolStripMenuItem13});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(2129, 40);
            this.mainMenuStrip.TabIndex = 3;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem15,
            this.toolStripMenuItem16,
            this.toolStripSeparator3,
            this.toolStripMenuItem17,
            this.toolStripMenuItem18,
            this.toolStripSeparator4,
            this.toolStripMenuItem19});
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(71, 36);
            this.toolStripMenuItem14.Text = "File";
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(229, 44);
            this.toolStripMenuItem15.Text = "New";
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(229, 44);
            this.toolStripMenuItem16.Text = "Open";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(226, 6);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(229, 44);
            this.toolStripMenuItem17.Text = "Save";
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(229, 44);
            this.toolStripMenuItem18.Text = "Save As";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(226, 6);
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(229, 44);
            this.toolStripMenuItem19.Text = "Exit";
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem20,
            this.toolStripMenuItem21});
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(84, 36);
            this.toolStripMenuItem13.Text = "Help";
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(370, 44);
            this.toolStripMenuItem20.Text = "About";
            // 
            // toolStripMenuItem21
            // 
            this.toolStripMenuItem21.Name = "toolStripMenuItem21";
            this.toolStripMenuItem21.Size = new System.Drawing.Size(370, 44);
            this.toolStripMenuItem21.Text = "Help Documentation";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2129, 1165);
            this.Controls.Add(this.panelCentre);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Integration Playbook - Data Transformation Modeller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        private void ToolStripMenuItem16_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ToolStripMenuItem15_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Panel panelCentre;
        private MyTreeView tvSource;
        private MyTreeView tvDestination;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem19;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem20;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem21;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem22;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem23;
        public System.Windows.Forms.ImageList destinationTreeImageList;
        private System.Windows.Forms.ImageList sourceTreeImageList;
        private System.Windows.Forms.Splitter destinationSplitter;
        private System.Windows.Forms.Splitter sourceSplitter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem24;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}

