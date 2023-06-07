using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Channels;

namespace _10.RageExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double headsetTrashedPrice = 0;
            double mouseTrashedPrice = 0;
            double keyboardTrashedPrice = 0;
            double displayTrashedPrice = 0;


            int headsetCounter = 0;
            int mouseCounter = 0;
            int keyboardCounter = 0;
            int displayCounter = 0;

            for (int i = 2; i <= lostGamesCount; i = i + 2)
            {
                headsetCounter ++;
            }

            headsetTrashedPrice = headsetCounter * headsetPrice;
            //Console.WriteLine($"Trashed headset → {headsetCounter} times");

            for (int i = 3; i <= lostGamesCount; i = i + 3)
            {
                mouseCounter++;
            }

            mouseTrashedPrice = mouseCounter * mousePrice;
            //Console.WriteLine($"Trashed mouse → {mouseCounter} times");

            for (int i = 6; i <= lostGamesCount; i = i + 6)
            {
                keyboardCounter++;
            }

            keyboardTrashedPrice = keyboardCounter * keyboardPrice;
            //Console.WriteLine($"Trashed keyboard → {keyboardCounter} times");

            

            for (int i = 2; i <= keyboardCounter; i = i + 2)
            {
                displayCounter++;
            }

            displayTrashedPrice = displayCounter * displayPrice;
            //Console.WriteLine($"Trashed display → {displayCounter} times");

            double expenses = headsetTrashedPrice + mouseTrashedPrice + keyboardTrashedPrice + displayTrashedPrice;

            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}