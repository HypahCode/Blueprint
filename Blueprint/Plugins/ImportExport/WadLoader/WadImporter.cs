using System.IO;
using System.Windows.Forms;

namespace Blueprint.Plugins.ImportExport.WadLoader
{
    [MenuExtensionUsages("Import", "DOOM WAD...")]
    public class WadImporter : ImportExtensionBase
    {
        public void Execute(IVectorImageProvider imageProvider)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Doom wad files (*.wad)|*.wad";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (BinaryReader reader = new BinaryReader(File.Open(dlg.FileName, FileMode.Open)))
                {
                    WadReader wad = new WadReader();
                    wad.ReadLumps(reader);

                    WadLevelSelectionDlg wadDlg = new WadLevelSelectionDlg();
                    wadDlg.SetLevels(wad.levels);
                    if (wadDlg.ShowDialog() == DialogResult.OK)
                    {

                        LevelReader lvlReader = new LevelReader(wadDlg.Level);
                        lvlReader.ReadData(reader);
                        LevelBuilder.BuildImage(imageProvider.CurrImage, lvlReader, 1.0f);
                    }
                    wadDlg.Dispose();
                }
            }
        }
    }
}
