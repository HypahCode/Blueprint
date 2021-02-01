using System.Collections.Generic;
using System.Windows.Forms;

namespace Blueprint.Plugins.ImportExport.WadLoader
{
    public partial class WadLevelSelectionDlg : Form
    {
        public WadLevelSelectionDlg()
        {
            InitializeComponent();
        }

        internal Level Level
        {
            get { return ((Level)comboBox1.SelectedItem); }
        }

        internal void SetLevels(List<Level> levels)
        {
            for (int i = 0; i < levels.Count; i++)
                comboBox1.Items.Add(levels[i]);
            comboBox1.SelectedIndex = 0;
        }
    }
}
