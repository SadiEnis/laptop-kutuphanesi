using System;
using System.Collections.Generic;
using System.Threading;

namespace hafta5_odev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte chs = 0;
            List<Computer> AllComputer = new List<Computer>();

            chs = Contents.Menu(); // Menu bir kez döngü dışında çalışacak sonra içerde, kapanana kadar
            do
            {
                errorInput:
                if (chs == 1)
                {
                    Contents.AddComputer(AllComputer);
                    chs = Contents.Menu();
                }
                else if (chs == 2)
                {
                    if (AllComputer.Count != 0)
                    {
                        e:
                        Console.Write("Kaçıncı bilgisayarı görmek istiyorsunuz (0 - {0}): ", AllComputer.Count - 1);
                        int index = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Kontrol ediliyor..");
                        Thread.Sleep(1500);
                        if (index < AllComputer.Count)
                            Contents.ShowComputerDetail(AllComputer, index);
                        else
                        {
                            Console.WriteLine("Sınır aralığında girdi yapın.");
                            goto e;
                        }
                    }
                    else
                        Console.WriteLine("Sistemde bilgisayar bulunmuyor.");
                    Console.ReadKey();
                    chs = Contents.Menu();
                }
                else if (chs == 3)
                    break;
                else
                    goto errorInput;
            } while (chs != 3);
        }
    }
}
