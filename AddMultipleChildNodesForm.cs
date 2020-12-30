using DataMappingDesigner.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataMappingDesigner
{
    public partial class AddMultipleChildNodesForm : Form
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        private IAddMultipleChildNodes _node;
        private IMap _map;

        public AddMultipleChildNodesForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            if (!DesignMode)
            {
                _logger = _serviceProvider.GetRequiredService<ILogger<AddMultipleChildNodesForm>>();
            }
        }

        public void Initialize(IAddMultipleChildNodes node, IMap map)
        {
            _node = node;
            _map = map;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var nodeNames = new List<string>();
            foreach(var line in nodeNamesTextBox.Lines)
            {
                if(string.IsNullOrEmpty(line) == false)
                {
                    nodeNames.Add(line.Trim());
                }
            }
            
            _node.AddMultipleChildNodesByName(nodeNames);
            _map.RedrawMap();

            this.Close();
        }
    }
}
