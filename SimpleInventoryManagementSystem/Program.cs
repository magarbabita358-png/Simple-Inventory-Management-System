namespace SimpleInventoryManagementSystem;

internal static class Program
{
    // Application entry point
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}