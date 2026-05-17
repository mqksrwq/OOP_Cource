using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Launcher
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();

            string tempMsi = Path.Combine(Path.GetTempPath(), "OOP_Cource_Setup_" + Guid.NewGuid().ToString("N") + ".msi");

            try
            {
                ExtractMsi(tempMsi);
                RunInstaller(tempMsi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Setup failed to launch:\n\n" + ex.Message,
                    "Setup Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                try { if (File.Exists(tempMsi)) File.Delete(tempMsi); }
                catch { }
            }
        }

        private static void ExtractMsi(string targetPath)
        {
            var asm = Assembly.GetExecutingAssembly();
            using var stream = asm.GetManifestResourceStream("Product.msi");
            if (stream == null)
                throw new InvalidOperationException("Embedded MSI resource not found.");

            using var file = File.Create(targetPath);
            stream.CopyTo(file);
        }

        private static void RunInstaller(string msiPath)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "msiexec.exe",
                Arguments = $"/i \"{msiPath}\"",
                UseShellExecute = true,
            };

            using var proc = Process.Start(psi);
            proc?.WaitForExit();
        }
    }
}
