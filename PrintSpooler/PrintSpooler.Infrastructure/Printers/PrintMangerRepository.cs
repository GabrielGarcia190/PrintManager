using System.Drawing.Printing;
using System.Runtime.Versioning;
using PrintSpooler.Domain.Printers.Repositories;
using System.ServiceProcess;
using System.Diagnostics;
using System.Drawing;

namespace PrintSpooler.Infrastructure.Printers;

public class PrinterRepository : IPrinterRepository
{

    [SupportedOSPlatform("windows")]
    public IEnumerable<string> GetInstalledPrinters()
    {
        foreach (string printer in PrinterSettings.InstalledPrinters)
        {
            yield return printer;
        }
    }

    [SupportedOSPlatform("windows")]
    public string GetSpoolerStatus()
    {
        using var service = new ServiceController("Spooler");

        return service.Status switch
        {
            ServiceControllerStatus.Running => "Spooler está em execução",
            ServiceControllerStatus.Stopped => "Spooler está parado",
            ServiceControllerStatus.Paused => "Spooler está pausado",
            _ => $"Spooler em estado {service.Status}"
        };
    }

    [SupportedOSPlatform("windows")]
    public void PrintFile(string filePath, string printerName)
    {
        if (FIleIsImage(filePath))
        {
            PrintImage(filePath, printerName);

            return;
        }
        var psi = new ProcessStartInfo
        {
            FileName = filePath,
            Verb = "Print",
            UseShellExecute = true,
            CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden
        };

        Process.Start(psi);
    }

    private static readonly string[] imageExtensionsFile = [".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tiff"];

    private static bool FIleIsImage(string filePath)
        => imageExtensionsFile.Contains(Path.GetExtension(filePath).ToLower());

    [SupportedOSPlatform("windows")]
    private static void PrintImage(string filePath, string printerName)
    {
        using var img = Image.FromFile(filePath);

        using PrintDocument pd = new();

        pd.PrinterSettings.PrinterName = printerName;

        pd.PrintPage += (sender, args) =>
        {
            if (args.Graphics != null)
                args.Graphics.DrawImage(img, args.MarginBounds);
        };

        pd.Print();
    }
}