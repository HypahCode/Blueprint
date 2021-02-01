using System.Windows.Forms;

namespace Blueprint.Plugins.ImportExport.CsvLoader
{

    [MenuExtensionUsages("Import", "Comma Seperated Value (CSV)...")]
    public class CsvImporter : ImportExtensionBase
    {
        public void Execute(IVectorImageProvider imageProvider)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Comma Seperated Value (*.csv)|*.csv";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CsvReader loader = new CsvReader(dlg.FileName);
                imageProvider.CurrImage.Add(loader.GetPoints());
            }
        }
    }

}
