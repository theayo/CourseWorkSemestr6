using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace NoCap_nte_framework_
{
    class Program
    {
        private static bool train = false;

        private static int stepsTrain = 15;

        static int Health = 50;
        private static bool fast = false;
        private static char stage = ' ';

        private const int ScreenWidth = 150;
        private const int ScreenHeight = 110;

        private const int MapHeight = 32;
        private const int MapWidth = 32;

        private const double Depth = 16;
        private const double Fov = Math.PI / 3.5;

        private static double _playerX = 1.0;
        private static double _playerY = 3.0;
        private static double _playerA = 1.5;

        private static readonly StringBuilder Map = new StringBuilder();
        private static SoundPlayer END = new SoundPlayer(@"D:\Repos(trap aleks)\NoCap(nte framework)\NoCap(nte framework)\resources\END.wav");

        static async Task Main()
        {
           
            //Console.Beep();
            Console.CursorVisible = false;
            Console.ResetColor();
            Console.SetWindowSize(ScreenWidth, ScreenHeight);
            Console.SetBufferSize(ScreenWidth, ScreenHeight);

            Menu a = new Menu();

            SoundPlayer player = new SoundPlayer    (@"D:\labc\Repos(trap aleks)\NoCap(nte framework)\NoCap(nte framework)\resources\SoundGta4.wav");
            SoundPlayer Ramzes1 = new SoundPlayer   (@"D:\labc\Repos(trap aleks)\NoCap(nte framework)\NoCap(nte framework)\resources\RAMZES1.wav");
            SoundPlayer Ramzes2 = new SoundPlayer   (@"D:\labc\Repos(trap aleks)\NoCap(nte framework)\NoCap(nte framework)\resources\RAMZES2.wav");
            SoundPlayer Pashuk1 = new SoundPlayer   (@"D:\labc\Repos(trap aleks)\NoCap(nte framework)\NoCap(nte framework)\resources\Pashuk1.wav");
            SoundPlayer Alekseev1 = new SoundPlayer (@"D:\labc\Repos(trap aleks)\NoCap(nte framework)\NoCap(nte framework)\resources\ALEKSEEV1.wav");
            SoundPlayer SoundTrack = new SoundPlayer(@"D:\labc\Repos(trap aleks)\NoCap(nte framework)\NoCap(nte framework)\resources\SoundTrack.wav");
            SoundPlayer Flash = new SoundPlayer     (@"D:\labc\Repos(trap aleks)\NoCap(nte framework)\NoCap(nte framework)\resources\Flash.wav");
            SoundPlayer kuzya = new SoundPlayer     (@"D:\labc\Repos(trap aleks)\NoCap(nte framework)\NoCap(nte framework)\resources\Obshaga.wav");
            SoundPlayer cana = new SoundPlayer      (@"D:\labc\Repos(trap aleks)\NoCap(nte framework)\NoCap(nte framework)\resources\Canaryka.wav");
            SoundPlayer metro = new SoundPlayer     (@"D:\labc\Repos(trap aleks)\NoCap(nte framework)\NoCap(nte framework)\resources\Metro.wav");
            SoundPlayer Thanks = new SoundPlayer    (@"D:\labc\Repos(trap aleks)\NoCap(nte framework)\NoCap(nte framework)\resources\PASHUK_thanks.wav");
            SoundPlayer EXEPTION = new SoundPlayer  (@"D:\labc\Repos(trap aleks)\NoCap(nte framework)\NoCap(nte framework)\resources\ALEKSEEV_EXEPTION.wav");
            SoundPlayer QUESTION = new SoundPlayer  (@"D:\labc\Repos(trap aleks)\NoCap(nte framework)\NoCap(nte framework)\resources\ALEKSEEV_QUESTION.wav");
            SoundPlayer BALL = new SoundPlayer      (@"D:\labc\Repos(trap aleks)\NoCap(nte framework)\NoCap(nte framework)\resources\ALEKSEEV_BALL.wav");

            player.PlayLooping();
            while (true)
            {
                string selectedMenuItem = a.drawMenu();//menu

                if (selectedMenuItem == "Start")
                {
                    player.Stop();
                    Load load = new Load();
                    Console.Clear();
                    load.showLoad();
                    Flash.Play();


                    InitMap();

                    var screen = new char[ScreenWidth * ScreenHeight];  //screen buffer

                    DateTime dateTimeFrom = DateTime.Now;
                    DateTime date1 = new DateTime(0, 0);
                    String timeInGame;

                    while (true)
                    {

                        //elapsed time
                        var dateTimeTo = DateTime.Now;
                        double elapsedTime = (dateTimeTo - dateTimeFrom).TotalSeconds;
                        dateTimeFrom = dateTimeTo;

                        if (Console.KeyAvailable)
                        {
                            ConsoleKey consoleKey = Console.ReadKey(true).Key;

                            switch (consoleKey)
                            {
                                case ConsoleKey.Escape:
                                    Console.Clear();
                                    break;
                                case ConsoleKey.A:
                                    _playerA += elapsedTime * 7;
                                    break;
                                case ConsoleKey.D:
                                    _playerA -= elapsedTime * 7;
                                    break;
                                case ConsoleKey.W:
                                    {
                                        _playerX += Math.Sin(_playerA) * 5 * elapsedTime;
                                        _playerY += Math.Cos(_playerA) * 5 * elapsedTime;

                                        if (Map[(int)_playerY * MapWidth + (int)_playerX] == '#')
                                        {
                                            _playerX -= Math.Sin(_playerA) * 5 * elapsedTime;
                                            _playerY -= Math.Cos(_playerA) * 5 * elapsedTime;
                                        }

                                        break;
                                    }

                                case ConsoleKey.S:
                                    {
                                        _playerX -= Math.Sin(_playerA) * 5 * elapsedTime;
                                        _playerY -= Math.Cos(_playerA) * 5 * elapsedTime;

                                        if (Map[(int)_playerY * MapWidth + (int)_playerX] == '#')
                                        {
                                            _playerX += Math.Sin(_playerA) * 5 * elapsedTime;
                                            _playerY += Math.Cos(_playerA) * 5 * elapsedTime;
                                        }

                                        break;
                                    }

                            }       //control buttons

                            if (consoleKey == ConsoleKey.Escape)
                            {
                                break;
                            }
                        }

                        //Ray Casting
                        var rayCastingTasks = new List<Task<Dictionary<int, char>>>();
                        for (int x = 0; x < ScreenWidth; x++)
                        {
                            var x1 = x;
                            rayCastingTasks.Add(Task.Run(() => CastRay(x1)));
                        }
                        foreach (Dictionary<int, char> dictionary in await Task.WhenAll(rayCastingTasks))
                        {
                            foreach (var key in dictionary.Keys)
                            {
                                screen[key] = dictionary[key];
                            }
                        }

                        //Timer
                        date1 = date1.AddSeconds(0.005);
                        timeInGame = date1.ToString("mm:ss");

                        //Stats
                        char[] stats = $"Pashuk Health:{Health}, Time: {timeInGame}, FPS: {(int)(1 / elapsedTime)}"
                            .ToCharArray();
                        stats.CopyTo(screen, 0);
                                                

                        //Dialoge
                        stage = Map[(int)(_playerY + 1) * MapWidth + (int)_playerX];
                       
                        switch (stage)
                        {
                            case '*':
                                Ramzes v = new Ramzes();
                                Console.Clear();
                                Console.SetCursorPosition(0, 0);
                                Map[4 * MapHeight + 8] = '?';
                                Map[3 * MapHeight + 8] = '?';
                                Map[2 * MapHeight + 8] = '?';
                                Ramzes1.Play();
                                v.quest("Доброго дня! Сегодня хорошая погода!", "Доброго дня!", "Хорошая!", v);
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.BackgroundColor = ConsoleColor.Yellow;

                                _playerX = 12.0;
                                _playerY = 3.0;

                                if (fast) {
                                    _playerX = 25.0;
                                    _playerY = 22.0;
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    SoundTrack.Play();
                                    timeInGame = "";
                                }
                                
                                break;
                            case 'r':
                                Ramzes ramzes2 = new Ramzes();
                                Ramzes2.Play();
                                Console.Clear();
                                ramzes2.quest("Сегодня на лифте!Ах да у нас же нет лестницы в общежитии!", "Смешно", "Не смешно", ramzes2);

                                Console.Clear();
                                Console.SetCursorPosition(0, 0);
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Map[3 * MapWidth + 27] = '.';
                                Map[3 * MapWidth + 24] = '.';
                                Map[3 * MapWidth + 23] = '.';
                                Map[3 * MapWidth + 22] = '.';


                                _playerX = 23;
                                _playerY = 3;
                                break;
                            case '+':

                                _playerY = 9.0;
                                _playerX = 2.0;
                                //transition tran = new transition();
                                //tran.trans(0);

                                Console.Clear();
                                Console.SetCursorPosition(0, 0);
                                kuzya.Play();
                                
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.BackgroundColor = ConsoleColor.White;
                                break;
                            case '&':
                                _playerY = 14.0;
                                _playerX = 5.0;
                                _playerA = 2.7;
                                //transition apchi = new transition();
                                //apchi.trans(1);
                                train = true;
                                metro.Play();

                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.BackgroundColor = ConsoleColor.Blue;
                                break;
                            case '^':
                                kuzya.Stop();
                                Pashuk b = new Pashuk();
                                _playerX = 21.0;
                                _playerY = 9.0;
                                Console.Clear();
                                Console.SetCursorPosition(0, 0);
                                Pashuk1.Play();
                                if (b.quest("Я вам даю 40 вы мне даёте 60 %", "У меня есть леньги", "У меня нет денег"))
                                {
                                    Health = 100;
                                }
                                Console.Clear();
                                Thanks.Play();
                                b.quest("Спасибо!!", "Пожалуйста", "Нет");
                                
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.BackgroundColor = ConsoleColor.White;
                                break;
                            case '%':
                                //transition apchi1 = new transition();
                                //apchi1.trans(2);
                                cana.PlayLooping();
                                _playerY = 19.0;
                                _playerX = 2.0;
                                _playerA = 1.5;

                                Console.Clear();
                                Console.SetCursorPosition(0, 0);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.BackgroundColor = ConsoleColor.White;
                                break;
                            case '@':
                               
                                _playerY = 23.0;
                                _playerX = 4.0;
                                _playerA = 0.0;
                                //transition apchi3 = new transition();
                                //apchi3.trans(3);
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                SoundTrack.Play();
                                timeInGame = ""; 

                                break;
                            case '!':
                                cana.Stop();
                                Alekseev alekseev = new Alekseev();
                                Console.Clear();
                                Console.SetCursorPosition(0, 0);
                                Alekseev1.Play();
                                alekseev.quest("Хахахах,ты пришёл но ты не сдашь никогда в жизни","...","...");
                                _playerY = 19.0;
                                _playerX = 24.0;
                                break;
                            case '=':
                                Alekseev alekseev2d = new Alekseev();
                                Console.Clear();
                                Console.SetCursorPosition(0, 0);
                                BALL.Play();
                                alekseev2d.quest("Сколькой баллов","7","что?");
                                _playerY = 22.0;
                                _playerX = 19.0;
                                _playerA = 1.5;
                                SoundTrack.Play();
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case 'g':
                                Alekseev alekseev3d = new Alekseev();
                                Console.Clear();
                                Console.SetCursorPosition(0, 0);
                                EXEPTION.Play();
                                alekseev3d.quest("А исключение это ошибка или ошибка это исключение??", "Вариант ответа один", "Вариант ответа два");
                                _playerY = 27.0;
                                _playerX = 7.0;
                                SoundTrack.Play();
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case 'h':
                                Alekseev alekseev5d = new Alekseev();
                                Console.Clear();
                                Console.SetCursorPosition(0, 0);
                                QUESTION.Play();
                                alekseev5d.quest("Как поймать исключение??", "Нет", "Да");
                                _playerY = 28.0;
                                _playerX = 16.0;
                                SoundTrack.Play();
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case 'b':
                                if (Health == 100)
                                {
                                    Dialog dia = new Dialog();
                                    Console.Clear();
                                    Console.SetCursorPosition(0, 0);

                                    dia.questDialog("Исключения не будет!!!");
                                }
                                break;
                        }
                        
                        if (train)
                        {
                            ConsoleKeyInfo ki = Console.ReadKey(true);
                            if (ki.Key == ConsoleKey.W)
                            {
                                Map[11 * (MapWidth) + (stepsTrain - 1)] = '#';
                                Map[11 * (MapWidth) + (stepsTrain)] = '%';

                                stepsTrain--;

                                if (stepsTrain == 0)
                                {
                                    train = false;
                                }

                            }
                        }

                        ////map
                        for (int x = 0; x < MapWidth; x++)
                        {
                            for (int y = 0; y < MapHeight; y++)
                            {

                                screen[(y + 1) * ScreenWidth + x] = Map[y * MapWidth + x];
                            }
                        }

                        screen[(int)(_playerY + 1) * ScreenWidth + (int)_playerX] = 'P';


                        Console.SetCursorPosition(0, 0);
                        Console.Write(screen, 0, ScreenWidth * ScreenHeight);

                    }
                }                //start
                else if (selectedMenuItem == "Settings")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Fast?0/1");
                        ConsoleKey consoleKey = Console.ReadKey().Key;
                        if (consoleKey == ConsoleKey.Escape)
                        {
                            break;
                        }
                        switch (consoleKey)
                        {
                            case ConsoleKey.D1:
                                fast = true;
                                break;
                            case ConsoleKey.D0:
                                fast = true;
                                break;
                        }

                    }



                }       //set
                else if (selectedMenuItem == "Exit")
                {
                    Console.Clear();
                    Environment.Exit(0);
                }          //exit

            }

        }

        public static void InitMap()
        {
            Map.Clear();
            Map.Append("################################");
            Map.Append("#......##############.rrr..#####");
            Map.Append("#.....*##...........#.rrr#.#++##");
            Map.Append("#....***#.............rrr..#++##");
            Map.Append("#.....*##...........#......#++##");
            Map.Append("#......##############......#####");
            Map.Append("################################");
            Map.Append("#....#...#.#..^^#^.......&&&....");
            Map.Append("#.....#.......^^^^.......&&&....");
            Map.Append("#..#.....#..#.^^^^.......&&&....");
            Map.Append("################################");
            Map.Append("#..............................#");
            Map.Append("#####%%##%%#####################");
            Map.Append("#............##................#");
            Map.Append("#............##................#");
            Map.Append("#####..##..#####################");
            Map.Append("#..............................#");
            Map.Append("################################");
            Map.Append("#......#...#......!!!......@####");
            Map.Append("#.................!!!......@@@##");
            Map.Append("#............#....!!!......@####");
            Map.Append("################################");
            Map.Append("###...##.....##..............#.#");
            Map.Append("###...##.##..##.......##....#..#");
            Map.Append("###...##.##..##...##..##..#...##");
            Map.Append("###......##..##...==..##...###.#");
            Map.Append("###ggg##.##hh###..==..##...#...#");
            Map.Append("###ggg...##hh###......##bb.....#");
            Map.Append("###########.......######bb####.#");
            Map.Append("#..#....#...####..##..##.......#");
            Map.Append("#....#......##........##..#..#.#");
            Map.Append("###########################??###");
        }

        public static Dictionary<int, char> CastRay(int x)
        {
            var result = new Dictionary<int, char>();

            double rayAngle = (_playerA + Fov / 2) - x * Fov / ScreenWidth;

            double distanceToWall = 0;
            bool hitWall = false;
            bool isBound = false;
            double wallSize = 1;

            double rayY = Math.Cos(rayAngle);
            double rayX = Math.Sin(rayAngle);

            while (!hitWall && distanceToWall < Depth)
            {
                distanceToWall += 0.1;

                int testX = (int)(_playerX + rayX * distanceToWall);
                int testY = (int)(_playerY + rayY * distanceToWall);

                if (testX < 0 || testX >= Depth + _playerX || testY < 0 || testY >= Depth + _playerY) //Hit wall
                {
                    hitWall = true;
                    distanceToWall = Depth;
                }
                else
                {
                    char testCell = ' ';
                    try
                    {
                        testCell = Map[testY * MapWidth + testX];
                    }
                    catch
                    {
                        END.Play();
                        MessageBox.Show(
                           "You pass game",
                           "END~",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning,
                           MessageBoxDefaultButton.Button1,
                           MessageBoxOptions.DefaultDesktopOnly);
                        
                        Environment.Exit(0);
                    }


                    if (testCell == '#' || testCell == 'B')
                    {
                        hitWall = true;

                        wallSize = testCell == '#' ? 1 : testCell == 'B' ? 1.2 : wallSize;

                        var boundsVectorsList = new List<(double X, double Y)>();

                        for (int tx = 0; tx < 2; tx++)
                        {
                            for (int ty = 0; ty < 2; ty++)
                            {
                                double vx = testX + tx - _playerX;
                                double vy = testY + ty - _playerY;

                                double vectorModule = Math.Sqrt(vx * vx + vy * vy);
                                double cosAngle = (rayX * vx / vectorModule) + (rayY * vy / vectorModule);
                                boundsVectorsList.Add((vectorModule, cosAngle));
                            }
                        }

                        boundsVectorsList = boundsVectorsList.OrderBy(v => v.X).ToList();

                        double boundAngle = 0.03 / distanceToWall;

                        if (Math.Acos(boundsVectorsList[0].Y) < boundAngle ||
                            Math.Acos(boundsVectorsList[1].Y) < boundAngle)
                            isBound = true;
                    }
                }
            }

            int ceiling = (int)(ScreenHeight / 2.0 - ScreenHeight * Fov / distanceToWall);
            int floor = ScreenHeight - ceiling;

            ceiling += (int)(ScreenHeight - ScreenHeight * wallSize);
            char wallShade;

            if (isBound)
                wallShade = '|';
            else if (distanceToWall <= Depth / 4.0)
                wallShade = '\u2588';
            else if (distanceToWall < Depth / 3.0)
                wallShade = '\u2593';
            else if (distanceToWall < Depth / 2.0)
                wallShade = '\u2592';
            else if (distanceToWall < Depth)
                wallShade = '\u2591';
            else
                wallShade = ' ';

            for (int y = 0; y < ScreenHeight; y++)
            {
                if (y < ceiling)
                {
                    result[y * ScreenWidth + x] = ' ';
                }
                else if (y > ceiling && y <= floor)
                {
                    result[y * ScreenWidth + x] = wallShade;

                }
                else
                {
                    char floorShade;
                    double b = 1.0 - (y - ScreenHeight / 2.0) / (ScreenHeight / 2.0);

                    if (b < 0.25)
                        floorShade = '#';
                    else if (b < 0.5)
                        floorShade = 'x';
                    else if (b < 0.75)
                        floorShade = '-';
                    else if (b < 0.9)
                        floorShade = '.';
                    else
                        floorShade = ' ';

                    result[y * ScreenWidth + x] = floorShade;
                }

            }
            return result;
        }
    }
}
