using AccessToSQLite.Core;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessToSQLite.UI
{
    public partial class MainForm : Form
    {
        private AccessExportOptions _options;

        public MainForm(AccessExportOptions options) : this()
        {
            _options = options;
            RefreshForm();
        }

        private MainForm()
        {
            InitializeComponent();
            
            var assembly = Assembly.GetExecutingAssembly();
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            Text = $"AccessToSQLite v{fvi.FileMajorPart}.{fvi.FileMinorPart}.{fvi.FileBuildPart}";
        }

        private void RefreshForm()
        {
            _txtAccessFileName.Text = _options.AccessFileName;
            _txtAccessPassword.Text = _options.AccessPassword;
            _txtSQLiteFileName.Text = _options.SQLiteFileName;

            _btnExport.Enabled = _options.CanExport;

            _grpImport.Enabled = !_options.Executing;
            _grpExport.Enabled = !_options.Executing;
        }

        private void _btnAccessSelect_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog
            {
                Filter = "Access Files (*.mdb)|*.mdb|All files (*.*)|*.*"
            })
            {
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _options.AccessFileName = dialog.FileName;
                    RefreshForm();
                }
            }
        }

        private void _btnSQLiteSelect_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog
            {
                Filter = "SQLite Files (*.sqlite3)|*.sqlite3|All files (*.*)|*.*",
                InitialDirectory = _options.SQLiteInitialDirectory,
                FileName = _options.SQLiteDefaultFileName,
            })
            {
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _options.SQLiteFileName = dialog.FileName;
                    RefreshForm();
                }
            }
        }

        private void _btnExport_Click(object sender, EventArgs e)
        {
            _options.Executing = true;
            RefreshForm();

            _rtxLogs.Clear();
            _rtxLogs.Text += "Export Started";

            Task.Factory.StartNew(() =>
            {
                var export = new Export(_options);
                return export.Execute();
            })
            .ContinueWith(t =>
            {
                switch (t.Result)
                {
                    case ExportResult.Success:
                        _rtxLogs.Text += "\nExport Complete";
                        break;
                    case ExportResult.PasswordInvalid:
                        _rtxLogs.Text += "\nPassword Invalid";
                        break;
                    case ExportResult.ImportError:
                        _rtxLogs.Text += "\nImport Error";
                        break;
                }

                _options.Executing = false;
                RefreshForm();

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
