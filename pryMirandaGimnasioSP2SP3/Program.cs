namespace pryMirandaGimnasioSP2SP3;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new frmInscripcion());
    }
}
