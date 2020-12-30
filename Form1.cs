using DataMappingDesigner.Controls;
using DataMappingDesigner.Interfaces;
using DataMappingDesigner.Model;
using IntegrationPlaybook.Analysis.DataTransformation.Modeller;
using IntegrationPlaybook.Analysis.DataTransformation.Modeller.Properties;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMappingDesigner
{
       
    
    public partial class Form1 : Form, IMap
    {
        //These are in designer
        //private MyTreeView tvSource;
        //private MyTreeView tvDestination;

        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        private string _lastOpenedFilePath;
        public DataModel _model = new DataModel();
        public SourceTreeviewNode _clickedSourceNode = null;
        public DestinationTreeviewNode _clickedDestinationNode = null;
        public MapLinesManager _mapLinesManager = new MapLinesManager();

        public Form1(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            if (!DesignMode)
            {
                _logger = _serviceProvider.GetRequiredService<ILogger<Form1>>();

            }

            
            InitializeComponent();
            CustomInitializeComponent();

            
        }

        private void CustomInitializeComponent()
        {
            this.tvDestination = new MyTreeView();
            this.tvSource = new MyTreeView();

            this.panelCentre.Controls.Add(this.destinationSplitter);
            this.panelCentre.Controls.Add(this.sourceSplitter);
            this.panelCentre.Controls.Add(this.tvDestination);
            this.panelCentre.Controls.Add(this.tvSource);
            this.panelCentre.Controls.Add(this.mainMenuStrip);

            // 
            // tvDestination
            // 
            this.tvDestination.AllowDrop = true;
            this.tvDestination.ContextMenuStrip = this.contextMenuStrip2;
            this.tvDestination.Dock = System.Windows.Forms.DockStyle.Right;
            this.tvDestination.FullRowSelect = true;
            this.tvDestination.HotTracking = true;
            this.tvDestination.ImageIndex = 5;
            this.tvDestination.ImageList = this.destinationTreeImageList;
            this.tvDestination.ItemHeight = 34;
            this.tvDestination.LabelEdit = true;
            this.tvDestination.Location = new System.Drawing.Point(1545, 40);
            this.tvDestination.Name = "tvDestination";
            this.tvDestination.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tvDestination.SelectedImageIndex = 0;
            this.tvDestination.Size = new System.Drawing.Size(584, 1125);
            this.tvDestination.TabIndex = 2;
            this.tvDestination.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvDestination_AfterCollapse);
            this.tvDestination.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvDestination_AfterExpand);
            this.tvDestination.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDestination_NodeMouseClick);
            this.tvDestination.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDestination_NodeMouseDoubleClick);
            this.tvDestination.DragDrop += new System.Windows.Forms.DragEventHandler(this.tree_DragDrop);
            this.tvDestination.DragOver += new System.Windows.Forms.DragEventHandler(this.tvDEstination_DragOver);
            this.tvDestination.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tvDestination_KeyPress);
            this.tvDestination.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvDestination_MouseDown);
            this.tvDestination.Scroll += new MyTreeView.ScrollEventHandler(this.TvDestination_Scroll);
            this.tvDestination.MouseWheel += TvDestination_MouseWheel;
            // 
            // tvSource
            // 
            this.tvSource.AllowDrop = true;
            this.tvSource.ContextMenuStrip = this.contextMenuStrip1;
            this.tvSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvSource.FullRowSelect = true;
            this.tvSource.HotTracking = true;
            this.tvSource.ImageIndex = 0;
            this.tvSource.ImageList = this.sourceTreeImageList;
            this.tvSource.ItemHeight = 34;
            this.tvSource.LabelEdit = true;
            this.tvSource.Location = new System.Drawing.Point(0, 40);
            this.tvSource.Name = "tvSource";
            this.tvSource.SelectedImageIndex = 0;
            this.tvSource.Size = new System.Drawing.Size(656, 1125);
            this.tvSource.TabIndex = 1;
            this.tvSource.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvSource_AfterCollapse);
            this.tvSource.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvSource_AfterExpand);
            this.tvSource.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvSource_NodeMouseClick);
            this.tvSource.DragDrop += new System.Windows.Forms.DragEventHandler(this.tree_DragDrop);
            this.tvSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvSource_MouseDown);
            this.tvSource.Scroll += new MyTreeView.ScrollEventHandler(this.TvSource_Scroll);
            this.tvSource.MouseWheel += TvSource_MouseWheel;
        }

        private void TvSource_MouseWheel(object sender, MouseEventArgs e)
        {
            RefreshMapLines();
        }

        private void TvDestination_MouseWheel(object sender, MouseEventArgs e)
        {
            RefreshMapLines();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} form loaded");

            this.Text = "Integration Playbook - Data Transformation Modeller";
            BuildMainMenu();
            
            ClearSourceTree();
            ClearDestinationTree();
        }

        #region Destination Tree

        private void tvDEstination_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");
            
            TreeView tree = (TreeView)sender;
            e.Effect = DragDropEffects.Link;

            TreeNode nodeSource = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (nodeSource != null)
            {
                if (nodeSource.TreeView != tree)
                {
                    Point pt = new Point(e.X, e.Y);
                    pt = tree.PointToClient(pt);
                    TreeNode nodeTarget = tree.GetNodeAt(pt);
                    if (nodeTarget != null)
                    {
                        e.Effect = DragDropEffects.Link;
                        tree.SelectedNode = nodeTarget;
                    }
                }
            }
        }

        public void ClearDestinationTree()
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");

            //var savedExpansionState = tvDestination.Nodes.GetExpansionState();
            //tvDestination.BeginUpdate();

            var treeNode = new DestinationTreeviewNode() { Text = "Destination Entities" };
            
            tvDestination.Nodes.Clear();
            tvDestination.Nodes.Add(treeNode);

            //tvDestination.Nodes.SetExpansionState(savedExpansionState);

            //tvDestination.EndUpdate();

        }

        

        private void tvDestination_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");

            _clickedDestinationNode = (DestinationTreeviewNode)e.Node;

            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Items.ChangeAllItemsVisibility(true);

                if (_clickedDestinationNode.Parent == null)
                {
                    contextMenuStrip2.Items.ChangeMenuOptionVisibility("Add Before", false);
                    contextMenuStrip2.Items.ChangeMenuOptionVisibility("Add After", false);
                }

                contextMenuStrip2.Show(tvDestination, e.Location);
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (_clickedDestinationNode != null)
                {
                    _mapLinesManager.UpdateLinesToHighlight(_clickedDestinationNode);
                    RedrawMapPanelLines();
                }
            }
        }

        private void tvDestination_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");

            var clickedNode = e.Node;
            _clickedDestinationNode = (DestinationTreeviewNode)clickedNode;

            if (e.Button == MouseButtons.Left)
            {
                OpenDestinationNodePropertiesForm();
            }
        }


        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");

            if (_clickedDestinationNode == null)
                return;
            //Remove Node
            if(e.ClickedItem.Text == "Properties")
            {
                OpenDestinationNodePropertiesForm();
            }
            else if (e.ClickedItem.Text == "Add Child")
            {
                var newTreeNode = new DestinationTreeviewNode();

                _clickedDestinationNode.Nodes.Add(newTreeNode);
                _clickedDestinationNode.Expand();
                newTreeNode.BeginEdit();
            }
            else if (e.ClickedItem.Text == "Add Multiple Children")
            {
                var form = _serviceProvider.GetRequiredService<AddMultipleChildNodesForm>();
                form.Initialize(_clickedDestinationNode, this);
                form.ShowDialog();

            }
            else if (e.ClickedItem.Text == "Move Down")
            {
                var parentNode = (DestinationTreeviewNode)_clickedDestinationNode.Parent;
                tvDestination.MoveNode(_clickedDestinationNode, false);
            }
            else if (e.ClickedItem.Text == "Move Up")
            {
                var parentNode = (DestinationTreeviewNode)_clickedDestinationNode.Parent;
                tvDestination.MoveNode(_clickedDestinationNode, true);
            }
            else if (e.ClickedItem.Text == "Remove Node")
            {
                var parentNode = (DestinationTreeviewNode)_clickedDestinationNode.Parent;
                parentNode.Nodes.Remove(_clickedDestinationNode);
                _clickedDestinationNode = null;
            }
            else
            {

            }

            RedrawMapPanelLines();
        }

        private void tvDestination_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");
            RefreshMapPanelLines();
        }

        private void tvDestination_AfterExpand(object sender, TreeViewEventArgs e)
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");
            RefreshMapPanelLines();
        }


        private void tvDestination_KeyPress(object sender, KeyPressEventArgs e)
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");
            if (_clickedDestinationNode == null)
                return;

            if (e.KeyChar == char.Parse("C"))
            {
                //Add Child
                var newTreeNode = new DestinationTreeviewNode();

                _clickedDestinationNode.Nodes.Add(newTreeNode);
            }
            if (e.KeyChar == char.Parse("A"))
            {
                //Add After
                var parentNode = (DestinationTreeviewNode)_clickedDestinationNode.Parent;

                var newTreeNode = new DestinationTreeviewNode();

                parentNode.Nodes.Add(newTreeNode);
            }
            else if (e.KeyChar == char.Parse("B"))
            {
                //Add Before
                var parentNode = (DestinationTreeviewNode)_clickedDestinationNode.Parent;

                var newTreeNode = new DestinationTreeviewNode();

                parentNode.Nodes.Add(newTreeNode);
            }
        }



        private void tvDestination_MouseDown(object sender, MouseEventArgs e)
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");

            TreeView tree = (TreeView)sender;
            TreeNode node = tree.GetNodeAt(e.X, e.Y);
            tree.SelectedNode = node;

            _clickedDestinationNode = node as DestinationTreeviewNode;
        }


        #endregion

        #region Source Tree


        private void tvSource_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");
            RefreshMapPanelLines();
        }

        private void tvSource_AfterExpand(object sender, TreeViewEventArgs e)
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");
            RefreshMapPanelLines();
        }


        
        public void ClearSourceTree()
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");

            //var savedExpansionState = tvSource.Nodes.GetExpansionState();
            //tvSource.BeginUpdate();

            var treeNode = new SourceTreeviewNode() { Text = "Source Entities" };
            tvSource.Nodes.Clear();
            tvSource.Nodes.Add(treeNode);

            //tvSource.Nodes.SetExpansionState(savedExpansionState);

            tvSource.EndUpdate();

        }

        

        private void tvSource_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");

            _clickedSourceNode = (SourceTreeviewNode)e.Node;

            if (e.Button == MouseButtons.Right)
            {
                //Manipulate Context Menu Buttons
                contextMenuStrip1.Items.ChangeAllItemsVisibility(true);
                
                if(_clickedSourceNode.Parent == null)
                {
                    contextMenuStrip1.Items.ChangeMenuOptionVisibility("Add Before", false);
                    contextMenuStrip1.Items.ChangeMenuOptionVisibility("Add After", false);
                }

;               contextMenuStrip1.Show(tvSource, e.Location);
            }
            else if(e.Button == MouseButtons.Left)
            {
                _mapLinesManager.UpdateLinesToHighlight(_clickedSourceNode);
                RedrawMapPanelLines();
            }

            
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");

            if (_clickedSourceNode == null)
                return;

            if(e.ClickedItem.Text == "Add Child")
            {
                var newTreeNode = new SourceTreeviewNode();                

                _clickedSourceNode.Nodes.Add(newTreeNode);
                _clickedSourceNode.Expand();
                newTreeNode.BeginEdit();
            }
            if (e.ClickedItem.Text == "Add Multiple Children")
            {
                var form = _serviceProvider.GetRequiredService<AddMultipleChildNodesForm>();
                form.Initialize(_clickedSourceNode, this);
                form.ShowDialog();
            }

            if (e.ClickedItem.Text == "Move Down")
            {
                tvDestination.MoveNode(_clickedSourceNode, false);
            }
            if (e.ClickedItem.Text == "Move Up")
            {
                tvDestination.MoveNode(_clickedSourceNode, true);
            }
            if (e.ClickedItem.Text == "Remove Node")
            {
                var parentNode = (SourceTreeviewNode)_clickedSourceNode.Parent;
                parentNode.Nodes.Remove(_clickedSourceNode);

                tvDestination.RecurseivlyRemoveLinksToSourceNode(_clickedSourceNode);

                _clickedDestinationNode = null;
            }

            
            RedrawMapPanelLines();
        }

        private void tvSource_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");

            TreeView tree = (TreeView)sender;
            TreeNode node = tree.GetNodeAt(e.X, e.Y);
            tree.SelectedNode = node;

            _clickedSourceNode = node as SourceTreeviewNode;
            if (node != null)
            {
                _logger.LogDebug($"Mouse down on source tree node: {node.Tag} - {node.FullPath}");

                _clickedSourceNode = (SourceTreeviewNode)node;

                if (e.Button == MouseButtons.Left)
                {
                    _mapLinesManager.UpdateLinesToHighlight(_clickedSourceNode);
                    RedrawMapPanelLines();
                    tree.DoDragDrop(node, DragDropEffects.Link);
                }
            }


        }

        #endregion


        #region Shared Treeview Methods

        

        private void tree_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");

            
            TreeView tree = (TreeView)sender;
            Point pt = new Point(e.X, e.Y);
            pt = tree.PointToClient(pt);
            TreeNode nodeTarget = tree.GetNodeAt(pt);

            var destinationTreeNode = nodeTarget as DestinationTreeviewNode;
            if(destinationTreeNode != null)
            {
                if (destinationTreeNode.LinkedSourceNodes.Count(x => x.Tag == _clickedSourceNode.Tag) == 0)
                {
                    _logger.LogDebug($"Destination tree node: {destinationTreeNode.Tag} - {destinationTreeNode.FullPath}");
                    _logger.LogDebug($"Source tree node: {_clickedSourceNode.Tag} - {_clickedSourceNode.FullPath}");

                    destinationTreeNode.LinkedSourceNodes.Add(_clickedSourceNode);


                    if (destinationTreeNode.Status == DestinationNodeStatus.TODO)
                        destinationTreeNode.Status = DestinationNodeStatus.InProgress;

                    RefreshMapPanelLines();
                }
            }

            //Redraw panel


            //MessageBox.Show($"Node: {_clickedSourceNode.Text} dropped on node: {nodeTarget.Text}");
            ////nodeTarget.Nodes.Add((TreeNode)nodeSource.Clone());
            ////nodeTarget.Expand();
        }
        //public TreeNode FindTreeNodeByTag(object tag, TreeView tv)
        //{
            
        //    foreach (TreeNode node in tv.Nodes)
        //    {
        //        if (node.Tag.Equals(tag)) 
        //            return node;

        //        //recursion
        //        var next = FindTreeNodeByTag(tag, node);
        //        if (next != null) 
        //            return next;
        //    }
        //    return null;
        //}

        //public TreeNode FindTreeNodeByTag(object tag, TreeNode node)
        //{
        //    foreach (TreeNode childNode in node.Nodes)
        //    {
        //        if (childNode.Tag.Equals(tag)) 
        //            return childNode;

        //        //recursion
        //        var next = FindTreeNodeByTag(tag, childNode);
        //        if (next != null) return next;
        //    }
        //    return null;
        //}


        #endregion


        private void RefreshMapPanelLines()
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");

            _mapLinesManager.Lines.Clear();

            if (tvSource == null
                || tvSource.Nodes == null)
                return;

            if (tvSource.Nodes.Count > 0)
            {
                var sourceNodeDictionary = tvSource.Nodes.RecurseNodeCollectionToDictionary();
                foreach (var node in tvDestination.Nodes)
                {
                    RefreshMapPanelForNode(node as DestinationTreeviewNode, sourceNodeDictionary);
                }
            }
            panelCentre.Invalidate();
        }
        private void RedrawMapPanelLines()
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");

            panelCentre.Invalidate();
        }

        private void RefreshMapPanelForNode(DestinationTreeviewNode node, Dictionary<object, TreeNode> sourceNodeDictionary)
        {            
            foreach (var linkedSourceNodeData in node.LinkedSourceNodes)
            {
                var sourceTreeNode = sourceNodeDictionary[linkedSourceNodeData.Id] as SourceTreeviewNode;
                if (sourceTreeNode != null)
                {
                    _mapLinesManager.Lines.Add(new MapLine()
                    {
                        SourceTreeNode = sourceTreeNode as SourceTreeviewNode,
                        DestinationTreeNode = node as DestinationTreeviewNode
                        //,
                        //DestinationPoint = destinationPoint, 
                        //SourcePoint = sourcePoint 
                    });


                    //var displayLine = true;
                    //if(sourceTreeNode.Parent == null || node.Parent == null)
                    //{
                    //    displayLine = true;
                    //}
                    ////if (sourceTreeNode.Parent != null
                    ////    && sourceTreeNode.Parent.IsExpanded
                    ////    && node.Parent != null
                    ////    && node.Parent.IsExpanded)
                    ////{
                    ////    displayLine = true;
                    ////}

                    //if (displayLine)
                    //{
                    //    //var destinationPoint = node.Bounds.Location;
                    //    //var sourcePoint = sourceTreeNode.Bounds.Location;

                    //    //sourcePoint = new Point(tvSource.Right, sourceTreeNode.Bounds.Top + sourceTreeNode.Bounds.Height / 2 + tvSource.Top);
                    //    //destinationPoint = new Point(tvDestination.Left, node.Bounds.Top + node.Bounds.Height / 2 + tvDestination.Top);

                    //    _mapLinesManager.Lines.Add(new MapLine() 
                    //    { 
                    //        SourceTreeNode = sourceTreeNode as SourceTreeviewNode,
                    //        DestinationTreeNode = node as DestinationTreeviewNode
                    //        //,
                    //        //DestinationPoint = destinationPoint, 
                    //        //SourcePoint = sourcePoint 
                    //    });
                    //}
                }
            }

            //foreach (var childNode in node.Nodes)
            //{
            //    RefreshMapPanelForNode(childNode as DestinationTreeviewNode, sourceNodeDictionary);
            //}

            if (node.IsExpanded)
            {
                foreach (var childNode in node.Nodes)
                {
                    RefreshMapPanelForNode(childNode as DestinationTreeviewNode, sourceNodeDictionary);
                }
            }
        }

        private void panelCentre_Paint(object sender, PaintEventArgs e)
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;            

            _mapLinesManager.ResetNodeColours();
            foreach (var line in _mapLinesManager.Lines)
            {
                if (line.Display)
                {
                    var pen = line.GetPen();
                    e.Graphics.DrawLine(pen, line.GetSourcePoint(tvSource), line.GetDestinationPoint(tvDestination));
                }
            }

            //Adding this here as it will make sure the form name is kept up to date but may move later
            RefreshFormText();
        }



        
        
        private void Form1_Resize(object sender, EventArgs e)
        {
            RefreshMapPanelLines();
        }


        #region Main Menu
        //private void ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ToolStripItem item = (ToolStripItem)sender;

        //    switch (item.Text)
        //    {
        //        case "New":
        //            NewMenuItemClicked();
        //            break;
        //        case "Open":
        //            OpenMenuItemClicked();
        //            break;
        //        case "Save":
        //            SaveMenuItemClicked();
        //            break;
        //        case "Save As":
        //            SaveAsMenuItemClicked();
        //            break;
        //        case "Exit":
        //            ExitMenuItemClicked();
        //            break;
        //        default:
        //            break;
        //    }
        //}


        private void MenuItem_Save_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(_lastOpenedFilePath))
            {
                MenuItem_SaveAs_Clicked(sender, e);
                _lastOpenedFilePath = saveFileDialog1.FileName;
            }
            else
            {
                SaveModel(_lastOpenedFilePath);                    
            }            
        }

        private void MenuItem_Open_Clicked(object sender, EventArgs e)
        {
            openFileDialog1.AddExtension = true;
            
            openFileDialog1.DefaultExt = ".json";
            var dr = openFileDialog1.ShowDialog();
            if(dr == DialogResult.OK)
            {
                var path = openFileDialog1.FileName;
                OpenModel(path);
                _lastOpenedFilePath = path;
            }
        }

        private void MenuItem_New_Clicked(object sender, EventArgs e)
        {
            var dr = MessageBox.Show("Would you like to clear the model and create a new empty one", "New", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                _model = new DataModel();
                _clickedSourceNode = null;
                _clickedDestinationNode = null;
                _mapLinesManager = new MapLinesManager();

                ClearSourceTree();
                ClearDestinationTree();
                RefreshMapPanelLines();

                //Open Model Details form so details of new model can be specified

                var form = _serviceProvider.GetRequiredService<ModelDetailsForm>();
                form.Initialize(_model, this);
                form.ShowDialog(this);
            }
        }

        private void MenuItem_Exit_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Help_Documentation_Clicked(object sender, EventArgs e)
        {
            var url = "https://www.integration-playbook.io/docs/en/data-transformation-modeller";
            System.Diagnostics.Process.Start("explorer", url);
        }

        private void MenuItem_Export_Clicked(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<ExportForm>();
            form.Initialize(_model, this);
            form.ShowDialog();
        }

        private void MenuItem_Help_About_Clicked(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<AboutBox1>();
            form.ShowDialog();
        }

        private void MenuItem_SaveAs_Clicked(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".json";
            saveFileDialog1.AddExtension = true;

            var dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                SaveModel(saveFileDialog1.FileName);
            }
        }

        #endregion


        #region Open and Save Model Methods

        public void OpenModel(string path)
        {
            //var persistModel = new PersistedDataModel();
            //using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            //{
            //    var reader = new StreamReader(fs);
            //    var jsonText = reader.ReadToEnd();

            //    var serializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            //    persistModel = JsonConvert.DeserializeObject<PersistedDataModel>(jsonText, serializerSettings);                
            //}

            //_model = new DataModel();
            //_model.ModelDetails = persistModel.ModelDetails;
            //_model.Source = SourceTreeviewNode.LoadFromData(persistModel.Source);
            //tvSource.Nodes.Clear();
            //tvSource.Nodes.Add(_model.Source);

            //_model.Destination = DestinationTreeviewNode.LoadFromData(persistModel.Destination, tvSource.Nodes);
            //tvDestination.Nodes.Clear();
            //tvDestination.Nodes.Add(_model.Destination);

            _model = DataModel.LoadFrom(path, tvSource.Nodes, tvDestination.Nodes);

            _clickedSourceNode = null;
            _clickedDestinationNode = null;
            tvSource.ExpandAll();
            tvDestination.ExpandAll();
            RefreshMapPanelLines();

            MessageBox.Show("The model has been successfully opened");
        }

        public void SaveModel(string path)
        {
            var rootSourceNode = tvSource.Nodes[0] as SourceTreeviewNode;
            var rootDestinationNode = tvDestination.Nodes[0] as DestinationTreeviewNode;
            _model.Destination = rootDestinationNode;
            _model.Source = rootSourceNode;
            _model.Save(path);

            MessageBox.Show("The model has been saved successfully", "Save", MessageBoxButtons.OK);
        }
        #endregion        


        private static ToolStripMenuItem BuildMenuItem(string Name, EventHandler handler)
        {
            var newMenuItem = new ToolStripMenuItem(Name);
            newMenuItem.Click += handler;
            return newMenuItem;
        }

        private void BuildMainMenu()
        {
            mainMenuStrip.Items.Clear();

            var fileMenuItem = new ToolStripMenuItem("File");
            fileMenuItem.DropDownItems.Add(BuildMenuItem("New", MenuItem_New_Clicked));
            fileMenuItem.DropDownItems.Add(new ToolStripSeparator());
            fileMenuItem.DropDownItems.Add(BuildMenuItem("Open", MenuItem_Open_Clicked));
            fileMenuItem.DropDownItems.Add(new ToolStripSeparator());
            fileMenuItem.DropDownItems.Add(BuildMenuItem("Save", MenuItem_Save_Clicked));
            fileMenuItem.DropDownItems.Add(BuildMenuItem("Save As", MenuItem_SaveAs_Clicked));
            fileMenuItem.DropDownItems.Add(new ToolStripSeparator());
            fileMenuItem.DropDownItems.Add(BuildMenuItem("Exit", MenuItem_Exit_Clicked));

            var modelMenuItem = new ToolStripMenuItem("Model");
            modelMenuItem.DropDownItems.Add(BuildMenuItem("Properties", Model_Properties_MenuItem_Click));


            var toolsMenuItem = new ToolStripMenuItem("Tools");
            toolsMenuItem.DropDownItems.Add(BuildMenuItem("Export", MenuItem_Export_Clicked));

            var helpMenuItem = new ToolStripMenuItem("Help");
            helpMenuItem.DropDownItems.Add(BuildMenuItem("About", MenuItem_Help_About_Clicked));
            helpMenuItem.DropDownItems.Add(BuildMenuItem("Documentation", MenuItem_Help_Documentation_Clicked));


            mainMenuStrip.Items.Add(fileMenuItem);
            mainMenuStrip.Items.Add(modelMenuItem);
            mainMenuStrip.Items.Add(toolsMenuItem);
            mainMenuStrip.Items.Add(helpMenuItem);


        }

        private void Model_Properties_MenuItem_Click(object sender, EventArgs e)
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");

            var form = _serviceProvider.GetRequiredService<ModelDetailsForm>();
            form.Initialize(_model, this);
            form.ShowDialog(this);
        }

        private void FileNewMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void RedrawMap()
        {
            RedrawMapPanelLines();
        }

        public void RefreshMapLines()
        {
            RefreshMapPanelLines();
            
        }

        private void RefreshFormText()
        {
            
            if (_model != null && _model.ModelDetails != null && string.IsNullOrEmpty(_model.ModelDetails.Name) == false)
            {
                this.Text = $"Integration Playbook - Data Transformation Modeller: {_model.ModelDetails.Name}";
            }
            else
                this.Text = "Integration Playbook - Data Transformation Modeller";
        }

        private void sourceSplitter_SplitterMoved(object sender, SplitterEventArgs e)
        {
            RefreshMapLines();
        }

        private void destinationSplitter_SplitterMoved(object sender, SplitterEventArgs e)
        {
            RefreshMapLines();
        }

        

        private void TvSource_Scroll(object sender, DataMappingDesigner.Controls.MyTreeView.ScrollEventArgs e)
        {
            //tvSource.Nodes[e.Top].EnsureVisible();
            RefreshMapLines();
        }

        private void TvDestination_Scroll(object sender, DataMappingDesigner.Controls.MyTreeView.ScrollEventArgs e)
        {
            //tvSource.Nodes[e.Top].EnsureVisible();
            RefreshMapLines();
        }

        private void OpenDestinationNodePropertiesForm()
        {
            _logger.LogDebug($"{MethodBase.GetCurrentMethod().Name} started");

            var form = _serviceProvider.GetRequiredService<DestinationTreeNodePropertiesForm>();
            form.Initialize(_clickedDestinationNode, this);
            form.ShowDialog(this);
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_model != null)
            {
                var dr = MessageBox.Show("You currently have a model open, Are you sure you would like to close it?\r\nAny unsaved changes will be lost", "Confirm close", MessageBoxButtons.YesNo);
                if(dr == DialogResult.Yes)
                {
                    //Do nothing
                }
                else
                {
                    e.Cancel = true;
                }
            }
            
        }
    }
}
