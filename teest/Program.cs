using System.Xml.Linq;
using System.Diagnostics;
using test;

namespace test
{
    internal class Program
    {
        static readonly string message0 = "Введите ваше имя";
        static readonly string message1 = "Добро пожаловать ";
        static readonly string message2 = "Чтобы нажать, нажмите Enter";
        static readonly string message3 = "Чтобы начать заново, нажмите Пробел";
        //static readonly int timeLimit = 60;
        int readedSigns = 0;

        public enum timePosition
        {
            left = 10,
            top = 15
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            User user = new User();
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan ts = new TimeSpan();
            var rand = new Random();
            string filePath;
            string text = "";
            Thread threadText = new Thread(_ => { });
            Thread threadTime = new Thread(_ => { });
            int readedSigns = 0;
            bool threadTimeIsAlive = true;
            bool threadTextIsAlive = true;
            int takenTime = 0;



            threadTime = new Thread(_ => {

                stopwatch.Start();

                do
                {
                    var (left, top) = Console.GetCursorPosition();

                    Console.SetCursorPosition(left: (int)timePosition.left, top: (int)timePosition.top);
                    ts = stopwatch.Elapsed;
                    Console.Write("{0:00}", 60 - ts.Seconds);

                    Console.SetCursorPosition(left, top);

                    Thread.Sleep(1000);
                } while (ts.Minutes < 1 && threadTimeIsAlive);

                threadTextIsAlive = false;

            });

            threadText = new Thread(_ => {
                readedSigns = 0;
                Console.SetCursorPosition(0, 0);

                while (readedSigns < text.Length && threadTextIsAlive)
                {
                    char c = Console.ReadKey(true).KeyChar;

                    if (c == text[readedSigns])
                    {
                        readedSigns++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(c);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                threadTimeIsAlive = false;

            });


            Console.WriteLine(message0);
            user.Name = Console.ReadLine();

            Console.WriteLine(message1 + user.Name);

            do
            {
                Console.WriteLine(message2);

                key = Console.ReadKey();

            }
            while (key.Key != ConsoleKey.Enter);

            Console.Clear();

            filePath = "../../../text.txt";

            text = File.ReadAllText(filePath);

            Console.WriteLine(text);

            threadTextIsAlive = true;
            threadTimeIsAlive = true;

            if (!threadText.IsAlive)
            { threadText.Start(); }

            if (!threadTime.IsAlive)
            { threadTime.Start(); }


            while (threadTime.IsAlive && threadText.IsAlive)
            {

            }

            stopwatch.Stop();

            if (ts.Minutes > 0)
            {
                takenTime = 60;
            }
            else
            {
                takenTime = ts.Seconds;
            }

            Console.Clear();
            Console.WriteLine("Результат: написано символов {0} за {1} секунд", readedSigns, takenTime);

            Thread.Sleep(1000);

            user.Minyt = readedSigns / takenTime * 60;

            user.Sekynd = readedSigns / takenTime;
        }
    }
}
