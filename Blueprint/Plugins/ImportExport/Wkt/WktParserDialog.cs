using System.Windows.Forms;

namespace Blueprint.ImportExport.Wkt.WktLoader
{
    public partial class WktParserDialog : Form
    {
        public string WktText
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public WktParserDialog()
        {
            InitializeComponent();
        }
    }
}
