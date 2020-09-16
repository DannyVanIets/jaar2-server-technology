using System;

namespace ChuckNorrisAPICaller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            var httpClient = new HttpClientClass("https://localhost:44303/", "Chuck");
            Console.WriteLine(httpClient.GetMessageInfo());
            Console.WriteLine();

            ChuckDTO chuck = new ChuckDTO { Id=5, Rating=5, Text= "When Chuck Norris was in middle school, his English teacher assigned an essay: What is courage ?  He received an A+ for turning in a blank page with only his name at the top."};
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(httpClient.CreateChuckFact(chuck));
            Console.WriteLine(httpClient.GetMessageInfo());
            Console.WriteLine();

            chuck.Rating = 1;
            chuck.Text = "Veranderd naar: Chuck Norris sleeps with a pillow under his gun.";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(httpClient.UpdateChuckFact(chuck));
            Console.WriteLine(httpClient.GetMessageInfo());
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(httpClient.DeletechuckFact(chuck));
            Console.WriteLine(httpClient.GetMessageInfo());
            Console.WriteLine();
        }
    }
}
