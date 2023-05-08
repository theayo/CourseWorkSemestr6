using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;

namespace NoCap_nte_framework_
{
    class Menu
    {
        private static int index = 0;

        List<string> menuItems = new List<string>()
        {
            "Start","Settings","Exit"
        };
        public Menu()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public string drawMenu()
        {
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                int centerX = (1);
                int centerY = (50) + 2 * i;
                //Console.SetCursorPosition(centerX, centerY);
                Console.Write(menuItems[i]);
                Console.ResetColor();
            }

            ConsoleKeyInfo okey = Console.ReadKey();

            if (okey.Key == ConsoleKey.DownArrow)
            {
                if (index == menuItems.Count - 1) index = 0;
                else index++;
            }
            else if (okey.Key == ConsoleKey.UpArrow)
            {
                if (index <= 0) index = menuItems.Count - 1;
                else index--;
            }
            else if (okey.Key == ConsoleKey.Enter)
            {
                return menuItems[index];
            }

            //            Console.Clear();
            Console.SetCursorPosition(0, 0);
            return "";
        }

        public string drawMenu(string str1, string str2, int xy)
        {
            List<string> menuItems = new List<string>()
            {
                str1,str2
            };
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                int centerX = (1);
                int centerY = (xy) + 2 * i;
                Console.SetCursorPosition(centerX, centerY);
                Console.Write(menuItems[i]);
                Console.ResetColor();
            }

            ConsoleKeyInfo okey = Console.ReadKey();

            if (okey.Key == ConsoleKey.DownArrow)
            {
                if (index == menuItems.Count - 1) index = 0;
                else index++;
            }
            else if (okey.Key == ConsoleKey.UpArrow)
            {
                if (index <= 0) index = menuItems.Count - 1;
                else index--;
            }
            else if (okey.Key == ConsoleKey.Enter)
            {
                return menuItems[index];
            }

            //            Console.Clear();
            Console.SetCursorPosition(0, 0);
            return "";
        }
        public string drawMenu(string str1, string str2, string str3, int xy)
        {
            List<string> menuItems = new List<string>()
            {
                str1,str2,str3
            };
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                int centerX = (1);
                int centerY = (xy) + 2 * i;
                Console.SetCursorPosition(centerX, centerY);
                Console.Write(menuItems[i]);
                Console.ResetColor();
            }

            ConsoleKeyInfo okey = Console.ReadKey();

            if (okey.Key == ConsoleKey.DownArrow)
            {
                if (index == menuItems.Count - 1) index = 0;
                else index++;
            }
            else if (okey.Key == ConsoleKey.UpArrow)
            {
                if (index <= 0) index = menuItems.Count - 1;
                else index--;
            }
            else if (okey.Key == ConsoleKey.Enter)
            {
                return "suka";
            }

            //            Console.Clear();
            Console.SetCursorPosition(0, 0);
            return "";

        }


    }
}
