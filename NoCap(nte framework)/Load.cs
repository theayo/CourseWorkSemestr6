using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace NoCap_nte_framework_
{
    class Load
    {
        public Load(){

        }

        public string screen = "";
        public string LoadBar = "/";
        public void init()
        {
        }
        public void showLoad()
        {
            SoundPlayer player = new SoundPlayer(@"H:\sofuck\sralk\CourseWorkSemestr6\NoCap(nte framework)\resources\CyberPunk.wav");
            SoundPlayer Alarm = new SoundPlayer(@" H:\sofuck\sralk\CourseWorkSemestr6\NoCap(nte framework)\resources\Alarm.wav");
            player.Play();
            Pashuk pashuk = new Pashuk();
            Alekseev alekseev= new Alekseev();
            Ramzes ramzes = new Ramzes();
            Tesluk tesluk= new Tesluk();

            int i = 0;
            while (i != 100)
            {

                if (i < 15)
                {

                    Console.SetCursorPosition(0, 0);
                    pashuk.paintPashuk();
                        //Console.SetCursorPosition(19, 50);
                }
                if (15 < i && i < 30)
                {
                    Console.SetCursorPosition(0, 0);
                    alekseev.paintAlekseev();
                    Console.SetCursorPosition(19, 70);
                }
                System.Threading.Thread.Sleep(100);
                if (i == 31 || i == 55)
                    Console.Clear();
                if (30 < i && i < 45)
                {
                    Console.SetCursorPosition(0, 0);
                    ramzes.paintRamzes();
                    Console.SetCursorPosition(19, 60);
                    if (i == 44)
                    {
                        System.Threading.Thread.Sleep(300);
                        LoadBar += "/";
                    }
                }
                if (45 < i && i < 55)
                {
                    Console.SetCursorPosition(0, 0);
                    tesluk.paintTesluk();
                    Console.SetCursorPosition(19, 80);
                    /*if (i == 44)
                        System.Threading.Thread.Sleep(200);*/
                }
                if (55 < i && i < 101)
                {
                    Console.SetCursorPosition(0, 0);
                    pashuk.paintPashuk();
                    Console.SetCursorPosition(19, 50);
                }
                if (i % 10 == 0)
                    LoadBar += "/";

                if (i % 8 == 0 || i % 7 == 0)
                    System.Threading.Thread.Sleep(300);
                Console.WriteLine(i + "% " + LoadBar);
                i ++;
                if (i == 100)
                {
                    Alarm.Play();
                    Console.SetCursorPosition(19, 50);
                    Console.WriteLine(i + "% " + LoadBar);
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}
