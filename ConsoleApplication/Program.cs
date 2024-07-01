using System.Diagnostics;

namespace ConsoleApplication
{
    internal class Program
    {
        static void Main()
        {
            string childProcessPath = "notepad.exe";
            Process childProcess = new Process();

            childProcess.StartInfo.FileName = childProcessPath;
            childProcess.StartInfo.UseShellExecute = false;
            childProcess.StartInfo.RedirectStandardOutput = true;
            childProcess.StartInfo.RedirectStandardError = true;
            childProcess.StartInfo.CreateNoWindow = true;
            childProcess.EnableRaisingEvents = true;

            childProcess.Exited += (sender, EventArgs) =>
            {
                int exiteCode = childProcess.ExitCode;

                Console.WriteLine($"Дочерний процесс завершился кодом {exiteCode}");
                childProcess.Dispose();
            };
            childProcess.Start();
            childProcess.WaitForExit();
        }
    }
}
