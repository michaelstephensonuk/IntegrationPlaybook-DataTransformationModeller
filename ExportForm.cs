using DataMappingDesigner.Exporters;
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
    public partial class ExportForm : Form
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        public DataModel _model { get; set; }
        private IMap _map;


        public ExportForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            if (!DesignMode)
            {
                _logger = _serviceProvider.GetRequiredService<ILogger<ExportForm>>();
            }
        }

        public void Initialize(DataModel model, IMap map)
        {
            _map = map;
            _model = model;
        }

        private async void exportButton_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;

            if (exportTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select the type of export to perform");
            }

            IModelExporter exporter = null;
            var exportType = (ExportType)exportTypeComboBox.SelectedItem;

            if(exportType == ExportType.Word)
            {
                saveFileDialog.Title = "Export Model to Word";
                saveFileDialog.DefaultExt = "docx";
                saveFileDialog.Filter = "Docx files (*.docx)|*.doc|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.RestoreDirectory = true;

                exporter = _serviceProvider.GetRequiredService<WordExporter>();                    
            }

            var dr = saveFileDialog.ShowDialog();
            if(dr == DialogResult.OK)
            {
                var path = saveFileDialog.FileName;
                exporter.ExportPath = path;
                exporter.Model = _model;
                exporter.ProgressBar = progressBar;
                await exporter.Export().ConfigureAwait(false);
                MessageBox.Show("Export Complete");
            }
        }

        private void ExportForm_Load(object sender, EventArgs e)
        {
            progressBar.Value = 0;

            exportTypeComboBox.DataSource = Enum.GetValues(typeof(ExportType));
        }
    }
}
