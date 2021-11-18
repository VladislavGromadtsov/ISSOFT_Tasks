using System.Configuration;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = ConfigurationManager.AppSettings["DefaultConnection"];
            var dl = new DataLoader(connection);

            dl.Load("data.csv");
        }
    }
}
