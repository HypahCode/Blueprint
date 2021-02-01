using System.Windows.Forms;

namespace Blueprint.ImportExport.Wkt.WktLoader
{
    public partial class WktLoaderDialog : Form
    {
        public bool FlipYAxis { get { return flipYAxisCheckBox.Checked; } set { flipYAxisCheckBox.Checked = value; } }
        public bool IncermentalCoordinates { get { return incermentalCoordinatesCheckbox.Checked; } set { incermentalCoordinatesCheckbox.Checked = value; } }
        public double ScaleDivider { get { return (double)scaleNumericUpDown.Value; } set { scaleNumericUpDown.Value = (decimal)value; } }
        public string WktFileName { get { return wktFileNameEdit.Text; } set { wktFileNameEdit.Text = value; } }
        public string WktFreeText { get { return wktFreeTextEdit.Text; } set { wktFreeTextEdit.Text = value; } }

        public WktLoaderDialog()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Well-Known-Text) (*.wkt)|*.wkt|Well-Known-Binary) (*.wkb)|*.wkb|All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                wktFileNameEdit.Text = dlg.FileName;
            }
        }
    }
}
