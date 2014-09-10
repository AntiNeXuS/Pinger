using System.Windows.Forms;

namespace Pinger
{
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new TrayWorker();

            Application.Run();
        }
    }
}
