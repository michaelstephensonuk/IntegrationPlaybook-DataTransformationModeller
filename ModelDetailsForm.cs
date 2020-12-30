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
    public partial class ModelDetailsForm : Form
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        public DataModel _model { get; set; }
        private IMap _map;

        public ModelDetailsForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            if (!DesignMode)
            {
                _logger = _serviceProvider.GetRequiredService<ILogger<ModelDetailsForm>>();
            }
        }

        public void Initialize(DataModel model, IMap map)
        {
            _map = map;
            _model = model;

            if (_model.ModelDetails == null)
                _model.ModelDetails = new ModelDetails();

                       
        }

        private void ModelDetailsForm_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            nameTextBox.Text = _model.ModelDetails.Name;
            descriptionTextBox.Text = _model.ModelDetails.Description;
            sourceModelTextBox.Text = _model.ModelDetails.SourceModelDescription;
            destinationModelTextBox.Text = _model.ModelDetails.DestinationModelDescription;
        }

        private void ModelDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _model.ModelDetails.Name = nameTextBox.Text;
            _model.ModelDetails.Description = descriptionTextBox.Text;
            _model.ModelDetails.SourceModelDescription = sourceModelTextBox.Text;
            _model.ModelDetails.DestinationModelDescription = destinationModelTextBox.Text;
        }
    }
}
