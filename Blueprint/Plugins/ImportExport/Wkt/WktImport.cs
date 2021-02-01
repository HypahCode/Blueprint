using Blueprint.ImportExport.Wkt.WktLoader;
using System.IO;
using System.Windows.Forms;

namespace Blueprint.Plugins.ImportExport.Wkt
{
    [MenuExtensionUsages("Import", "Well Known Text (WKT)...")]
    public class WktImportImport : ImportExtensionBase
    {
        public void Execute(IVectorImageProvider imageProvider)
        {
            WktLoaderDialog wktDlg = new WktLoaderDialog();
            if (wktDlg.ShowDialog() == DialogResult.OK)
            {
                string filename = wktDlg.WktFileName;
                if (File.Exists(filename))
                {
                    if (filename.ToLower().EndsWith("wkb"))
                    {
                        WkbReader wkb = new WkbReader(File.ReadAllText(filename));
                        wkb.LoadIntoImage(imageProvider.CurrImage, wktDlg.FlipYAxis);
                    }
                    else
                    {
                        WktReader.ReadFile(imageProvider.LayeredVectorImage, filename, wktDlg.ScaleDivider, wktDlg.FlipYAxis, wktDlg.IncermentalCoordinates);
                    }
                }

                if (wktDlg.WktFreeText.Length > 1)
                {
                    if (IsHexString(wktDlg.WktFreeText))
                    {
                        WkbReader wkb = new WkbReader(wktDlg.WktFreeText);
                        wkb.LoadIntoImage(imageProvider.CurrImage, wktDlg.FlipYAxis);
                    }
                    else
                    {
                        WktReader.ReadText(imageProvider.LayeredVectorImage, wktDlg.WktFreeText, wktDlg.ScaleDivider, wktDlg.FlipYAxis, wktDlg.IncermentalCoordinates);
                    }
                }
            }
            wktDlg.Dispose();
        }

        private bool IsHexString(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                bool isHex = (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F') || (c == '\r' || c == '\n');
                if (!isHex)
                    return false;
            }
            return (s.Length > 0);
        }
    }
}
