using DataMappingDesigner.Interfaces;
using DataMappingDesigner.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataMappingDesigner
{
    public partial class DestinationTreeNodePropertiesForm : Form
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        public DestinationTreeviewNode DestinationTreeNode { get; set; }
        private IMap _map;

        public DestinationTreeNodePropertiesForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            if (!DesignMode)
            {
                _logger = _serviceProvider.GetRequiredService<ILogger<DestinationTreeNodePropertiesForm>>();
            }
        }

        public void Initialize(DestinationTreeviewNode node, IMap map)
        {
            _map = map;
            DestinationTreeNode = node;
                
            nameTextBox.DataBindings.Add("Text", DestinationTreeNode, "Text");
            richTextBox1.DataBindings.Add("Text", DestinationTreeNode, "TransformationNotes");
            exampleValuesTextBox.DataBindings.Add("Text", DestinationTreeNode, "ExampleValues");
            referenceDataMappingNeededCheckBox.DataBindings.Add("Checked", DestinationTreeNode, "IsReferenceDataMappingRequired");
            dataLookupNeededCheckBox.DataBindings.Add("Checked", DestinationTreeNode, "IsDataLookupRequired");
            
            foreach (var path in DestinationTreeNode.LinkedSourceNodes)
                sourceNodeListBox.Items.Add(path);

            comboBox1.DataSource = Enum.GetValues(typeof(DestinationNodeStatus));
            comboBox1.SelectedItem = DestinationTreeNode.Status;

            transformTypeComboBox.DataSource = Enum.GetValues(typeof(DataTransformationType));
            transformTypeComboBox.SelectedItem = DestinationTreeNode.TransformationType;

            dataTypeComboBox.DataSource = Enum.GetValues(typeof(NodeDataType));
            dataTypeComboBox.SelectedItem = DestinationTreeNode.DataType;

            this.Text = node.Text;
            nodePathLabel.Text = node.FullPath;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null)
                DestinationTreeNode.Status = (DestinationNodeStatus)comboBox1.SelectedItem;

            if(transformTypeComboBox.SelectedItem != null)
                DestinationTreeNode.TransformationType = (DataTransformationType)transformTypeComboBox.SelectedItem;

            if(dataTypeComboBox.SelectedItem != null)
                DestinationTreeNode.DataType = (NodeDataType)dataTypeComboBox.SelectedItem;

            this.Close();
        }

        private void deleteSourceLinkButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select the source node link to delete");
            }


            var sourceNode = (SourceTreeviewNode) sourceNodeListBox.SelectedItem;
            if (sourceNode != null)
            {
                DestinationTreeNode.LinkedSourceNodes.Remove(sourceNode);

                sourceNodeListBox.Items.Clear();
                foreach (var sourceNodePath in DestinationTreeNode.LinkedSourceNodes)
                    sourceNodeListBox.Items.Add(sourceNodePath);

                _map.RefreshMapLines();

                this.Close();
            }
        }

        private void DestinationTreeNodePropertiesForm_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            //tabPage3.Focus();

            AddToolTip(comboBox1, "The status of the node.  Have you completed mapping this node or are there issues");
            AddToolTip(dataLookupNeededCheckBox, "Do we need to perform a look up of data from an external data source to transform this node");
            AddToolTip(this.dataTypeComboBox, "What is the data type for the destination node");
            AddToolTip(this.deleteLinkButton, "Delete the link from this node to the source node which you have selected");
            AddToolTip(this.exampleValuesTextBox, "Sample values which will show what the destination data should look like");
            AddToolTip(this.nameTextBox, "The name of the node in the destination model");
            AddToolTip(this.referenceDataMappingNeededCheckBox, "Do we need to map reference data values between the systems.  \r\nFor example is there a limited list of values which need cross referencing");
            AddToolTip(this.richTextBox1, "Notes which will help describe how data from the source model nodes will be transformed to create the node in the destination model");
            AddToolTip(this.sourceNodeListBox, "The list of nodes in the source model which will map to this node in the destination model");
        }

        private void AddToolTip(Control c, string text)
        {
            var t = new ToolTip();
            t.SetToolTip(c, text);
        }

        private void sourceNodeListBox_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem.Text == "Delete")
            {
                var path = sourceNodeListBox.SelectedItem;
                var sourceNode = DestinationTreeNode.LinkedSourceNodes.SingleOrDefault(x => x.FullPath == (string)path);
                if (sourceNode != null)
                    DestinationTreeNode.LinkedSourceNodes.Remove(sourceNode);
            }

            //sourceNodeListBox.ContextMenuStrip.Visible = false;
        }

        private void sourceNodeListBox_MouseUp(object sender, MouseEventArgs e)
        {
            //sourceNodeListBox.ContextMenuStrip.Visible = false;
            //if (e.Button == MouseButtons.Right)
            //{
            //    sourceNodeListBox.SelectedIndex = sourceNodeListBox.IndexFromPoint(e.X, e.Y);

            //    if (sourceNodeListBox.SelectedItem != null)
            //    {
            //        sourceNodeListBox.ContextMenuStrip.Visible = true;
            //        //sourceNodeListBox.ContextMenuStrip.Show();
            //    }
            //}
        }

        private void sourceNodeListBox_MouseDown(object sender, MouseEventArgs e)
        {
            

            
        }
    }
}
