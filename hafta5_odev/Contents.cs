using System;
using System.Collections.Generic;
using System.Threading;

namespace hafta5_odev
{
    public static class Contents // Static sınıf örneği
    {
        public static byte Menu()
        {
            byte _chs = 0;
            Console.Clear();
            DrawPC();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("            /----------------------\\");
            Console.WriteLine("            |  Laptop Kütüphanesi  |");
            Console.WriteLine("            \\----------------------/");
            Console.ResetColor();

            Console.WriteLine("\n Laptop Kütüphanesi Uygulamasına Hoş Geldiniz.\n");
            Console.WriteLine("1- Yeni laptop ekle"); // Tamamlandı
            Console.WriteLine("2- Var olanları listele"); // Tamamlandı
            Console.WriteLine("3- Çıkış yap.");

            bool countMenu; // Hatalı girdilerin kontrolü
            do
            { //Hata alacağımız tarzda girdiler varsa daima döner en son doğru girilene kadar.
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" - Yapmak istediğiniz işlemi seçiniz: ");
                    _chs = Convert.ToByte(Console.ReadLine());
                    Console.ResetColor();
                    countMenu = false; // False olduğunda while'dan çıkar
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hatalı girdi yaptınız.");
                    countMenu = true; // true olduğu sürece de dönmeye devam eder.
                }
            } while (countMenu);

            return _chs;
        }
        public static void AddComputer(List<Computer> _comps)
        {
            // NOT: Aşağıdaki bütün try-catch yapıları girdi kontrolü yapmak içindir.  Ayrıntı satır 25 \\
            Console.Clear();
            DrawPC();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("/--------------------------------------------\\");
            Console.WriteLine("                Yeni Bilgisayar");
            Console.ResetColor();
            Computer newComputer; // Değişken olarak bir Computer alıyoruz.
                                  // Satır 86'de markaya uygun nesne türeteceğiz. Markalar miras yoluyla türetildiği için Computer değişkenine Asus nesnesi üretebilirim.

            #region marka
            error:
            Console.WriteLine();
            Console.WriteLine("1- Lenovo");
            Console.WriteLine("2- Asus");
            Console.WriteLine("3- Dell");
            Console.WriteLine("4- Sony");
            byte _chsBrand = 0;
            bool countBrand;
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" - Markası: ");
                    _chsBrand = Convert.ToByte(Console.ReadLine());
                    countBrand = false;
                    Console.ResetColor();
                }
                catch (Exception)
                {
                    Console.WriteLine("Hatalı girdi yaptınız. Yeniden giriniz.");
                    countBrand = true;
                }
            } while (countBrand);

            switch (_chsBrand)
            {
                case 1:
                    newComputer = new Lenovo();
                    break;

                case 2:
                    newComputer = new Asus();
                    break;

                case 3:
                    newComputer = new Dell();
                    break;

                case 4:
                    newComputer = new Sony();
                    break;

                default:
                    Console.WriteLine("Hatalı girdi yaptınız. Lütfen geçerli bir giriş yapınız!");
                    goto error;
            }
            #endregion

            #region İşlemci Tipi
            Console.WriteLine();
            if (_chsBrand != 2) // Asus sadece i7
            {
                if (_chsBrand != 4) // Sony en az i5
                {
                    errorType:
                    Console.WriteLine("1- Intel i3");
                    Console.WriteLine("2- Intel i5");
                    Console.WriteLine("3- Intel i7");
                    Console.WriteLine("4- Intel i9");
                    bool countType;
                    byte _chsPType = 0;
                    do
                    {
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" - İşlemci Tipi: ");
                            _chsPType = Convert.ToByte(Console.ReadLine());
                            countType = false;
                            Console.ResetColor();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Hatalı girdi yaptınız. Yeniden deneyiniz.");
                            countType = true;
                        }
                    } while (countType);
                    

                    switch (_chsPType)
                    {
                        case 1:
                            newComputer.ProcessorType = "i3";
                            break;

                        case 2:
                            newComputer.ProcessorType = "i5";
                            break;

                        case 3:
                            newComputer.ProcessorType = "i7";
                            break;

                        case 4:
                            newComputer.ProcessorType = "i9";
                            break;

                        default:
                            Console.WriteLine("Hatalı giriş yaptınız.");
                            goto errorType;
                    }
                }
                else // Bu durumda Sony olacaktır markası
                {
                    errorType:
                    Console.WriteLine("1- Intel i5");
                    Console.WriteLine("2- Intel i7");
                    Console.WriteLine("3- Intel i9");
                    bool countType;
                    byte _chsPType = 0;
                    do
                    {
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" - İşlemci Tipi: ");
                            _chsPType = Convert.ToByte(Console.ReadLine());
                            countType = false;
                            Console.ResetColor();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Hatalı girdi yaptınız. Lütfen yeniden giriniz.");
                            countType = true;
                        }
                    } while (countType);
                    

                    switch (_chsPType)
                    {
                        case 1:
                            newComputer.ProcessorType = "i5";
                            break;

                        case 2:
                            newComputer.ProcessorType = "i7";
                            break;

                        case 3:
                            newComputer.ProcessorType = "i9";
                            break;

                        default:
                            Console.WriteLine("Hatalı giriş yaptınız.");
                            goto errorType;
                    }
                }
            }
        #endregion

            #region İşlemci Modeli
            errorModel:
            Console.WriteLine();
            Console.WriteLine("1- Intel {0} 10.Nesil", newComputer.ProcessorType);
            Console.WriteLine("2- Intel {0} 11.Nesil", newComputer.ProcessorType);
            Console.WriteLine("3- Intel {0} 12.Nesil", newComputer.ProcessorType);
            Console.WriteLine("4- Intel {0} 13.Nesil", newComputer.ProcessorType);
            bool countModel;
            byte _chsPModel = 0;
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" - İşlemci Tipi: ");
                    _chsPModel = Convert.ToByte(Console.ReadLine());
                    countModel = false;
                    Console.ResetColor();
                }
                catch (Exception)
                {
                    Console.WriteLine("Hatalı giriş yaptınız.");
                    countModel = true;
                }
            } while (countModel);
            

            switch (_chsPModel)
            {   
                case 1:
                    newComputer.ProcessorModel = "10.nesil";
                    break;

                case 2:
                    newComputer.ProcessorModel = "11.nesil";
                    break;

                case 3:
                    newComputer.ProcessorModel = "12.nesil";
                    break;

                case 4:
                    newComputer.ProcessorModel = "13.nesil";
                    break;

                default:
                    Console.WriteLine("Hatalı giriş yaptınız.");
                    goto errorModel;
            }
            #endregion

            #region Bellek
            bool count;
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Console.Write(" - Bellek Boyutu: ");
                    newComputer.Memory = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                    count = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hatalı bir girdi. Giriş yapınız.");
                    count = true;
                }
            } while (count); // Count 0 olduğu sürece yeniden çalışacak

            #endregion

            #region Bellek Hızı
            if (newComputer.Memory == 8)
                newComputer.MemorySpeed = 3200;
            else
            {
                errorSpeed:
                Console.WriteLine();
                Console.WriteLine("1- 3200 MHz");
                Console.WriteLine("2- 5400 Mhz");
                bool countSpeed;
                int _chsSpeed = 0;
                do
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" - Bellek hızı: ");
                        _chsSpeed = Convert.ToInt32(Console.ReadLine());
                        countSpeed = false;
                        Console.ResetColor();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Hatalı girdiniz.");
                        countSpeed = true;
                    }
                } while (countSpeed);
                

                switch (_chsSpeed)
                {
                    case 1:
                        newComputer.MemorySpeed = 3200;
                        break;

                    case 2:
                        newComputer.MemorySpeed = 5400;
                        break;

                    default:
                        Console.WriteLine("Hatalı girdi yaptınız.");
                        goto errorSpeed;
                }
            }
        #endregion

            #region Disk
            if (_chsBrand != 3) // Dell değilse
            {
                errorDisk:
                Console.WriteLine();
                Console.WriteLine("1- SSD");
                Console.WriteLine("2- HDD");
                bool countDisk;
                byte _chsDisk = 0;
                do
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" - Disk: ");
                        _chsDisk = Convert.ToByte(Console.ReadLine());
                        countDisk = false;
                        Console.ResetColor();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Hatalı girdiniz.");
                        countDisk = true;
                    }
                } while (countDisk);

                switch (_chsDisk)
                {
                    case 1:
                        newComputer.Disk = "SSD";
                        break;

                    case 2:
                        newComputer.Disk = "HDD";
                        break;

                    default:
                        Console.WriteLine("Hatalı girdi yaptınız.");
                        goto errorDisk;
                }
            }
        #endregion

            #region Disk Boyutu
            errorDSize:
            Console.WriteLine();
            Console.WriteLine("1-  512 GB");
            Console.WriteLine("2- 1024 GB");
            bool countDSize;
            int _chsDSize = 0;
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" - Bellek Boyutu: ");
                    _chsDSize = Convert.ToInt32(Console.ReadLine());
                    countDSize = false;
                    Console.ResetColor();
                }
                catch (Exception)
                {
                    Console.WriteLine("Hatalı girdiniz.");
                    countDSize = true;
                }
            } while (countDSize);

            switch (_chsDSize)
            {
                case 1:
                    newComputer.DiskSize = 512;
                    break;

                case 2:
                    newComputer.DiskSize = 1024;
                    break;

                default:
                    Console.WriteLine("Hatalı giril yaptınız.");
                    goto errorDSize;
            }
            #endregion

            #region Ekran
            if (_chsBrand != 1) // Lenovo değilse
            {
                bool countScreen;
                do
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.Write(" - Ekran Boyutu: ");
                        newComputer.Screen = Convert.ToDouble(Console.ReadLine());
                        Console.ResetColor();
                        countScreen = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Hatalı bir girdi. Giriş yapınız.");
                        countScreen = true;
                    }
                } while (countScreen); // Count 0 olduğu sürece yeniden çalışacak
            }
            #endregion

            #region Paylaşımlı mı
            errorGPU:
            Console.WriteLine();
            Console.WriteLine("1- Evet");
            Console.WriteLine("2- Hayır");
            bool countGPU;
            byte _chsGPU = 0;
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" - Paylaşımlı mı: ");
                    _chsGPU = Convert.ToByte(Console.ReadLine());
                    countGPU = false;
                    Console.ResetColor();
                }
                catch (Exception)
                {
                    Console.WriteLine("Yanlış girdiniz.");
                    countGPU = true;
                }
            } while (countGPU);


            switch (_chsGPU)
            {
                case 1:
                    newComputer.SharedGraphicCard = true;
                    break;

                case 2:
                    newComputer.SharedGraphicCard = false;
                    break;

                default:
                    Console.WriteLine("Hatalı girdi yaptınız.");
                    goto errorGPU;
            }
            #endregion

            #region Fiyat
            CalculatePrice(newComputer);
            #endregion

            _comps.Add(newComputer);
        }
        public static void ShowComputerDetail(List<Computer> _comps, int index)
        { // Bilgisayar detayları olacak
            if (_comps[index].Brand == "Lenovo")
                DrawPC(0);
            else if (_comps[index].Brand == "Asus")
                DrawPC(1);
            else if (_comps[index].Brand == "Sony")
                DrawPC(2);
            else if (_comps[index].Brand == "Dell")
                DrawPC(3);

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Markası: " + _comps[index].Brand);
            Console.WriteLine("İşlemci: {0} {1}", _comps[index].ProcessorType, _comps[index].ProcessorModel);
            Console.WriteLine("İşletim Sistemi: " + _comps[index].OS);
            Console.WriteLine("Bellek: {0} GB - {1} MHz", _comps[index].Memory, _comps[index].MemorySpeed);
            Console.WriteLine("Depolama: {0} - {1} GB", _comps[index].Disk, _comps[index].DiskSize);
            Console.WriteLine("Ekran Boyutu: " + _comps[index].Screen);
            Console.Write("Ekran kartı paylaşımlı mı: ");
            if (_comps[index].SharedGraphicCard)
                Console.WriteLine("Evet");
            else
                Console.WriteLine("Hayır");
            Console.WriteLine("Sistem değeri: " + CalculatePrice(_comps[index]) + " TL");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nBu bilgisayara bellek eklemek isterseniz lütfen R tuşuna basınız: ");
            string ram = Console.ReadLine();
            if (ram.ToUpper() == "R")
            {
                Console.Write("Kaç GB bellek eklemek istiyorsunuz: ");
                int _ram = Convert.ToInt32(Console.ReadLine());
                _comps[index].Memory += _ram;
                Thread.Sleep(1000);
                Console.ResetColor();
                Console.WriteLine("İşlem tamamlandı.");
            }
        }
        private static long CalculatePrice(Computer _comp)
        {
            long _price = 0;
            // Muhtemelen parametre gerektirmeyecek markasına göre vs otomatik ayarlanmış olacak
            // İç içe ayarlanmış çok sayıda if else ve switch ile
            // Bana göre Sony ve Asus daha güzel markalar olduğu için bu bilgisayarlar daha pahalı ve eklentileri de daha pahalı haline getireceğim.
            // (Sony için markasına da para verelim)

            if (_comp.Brand == "Sony" || _comp.Brand == "Asus")
            {
                if (_comp.Brand == "Sony")
                    _price += 1000;
                switch (_comp.ProcessorType)
                {
                    case "i3":
                        _price += 500;
                        break;
                    case "i5":
                        _price += 750;
                        break;
                    case "i7":
                        _price += 1000;
                        break;
                    case "i9":
                        _price += 1500;
                        break;
                }

                switch (_comp.ProcessorModel)
                {
                    case "10.nesil":
                        _price += 250;
                        break;
                    case "11.nesil":
                        _price += 400;
                        break;
                    case "12.nesil":
                        _price += 600;
                        break;
                    case "13.nesil":
                        _price += 1000;
                        break;
                }

                _price += 1000; // Windows 11 için

                if (_comp.Memory <= 16)
                    _price += 1000;
                else
                    _price += 2000;

                if (_comp.MemorySpeed == 3200)
                    _price += 1000;
                else if (_comp.MemorySpeed == 5400)
                    _price += 1500;

                _price += 450; // Anakart için

                if (_comp.Disk == "SSD")
                    _price += 1000;
                else if (_comp.Disk == "HDD")
                    _price += 400;

                if (_comp.DiskSize == 512)
                    _price += 400;
                else if (_comp.DiskSize == 1024)
                    _price += 650;

                if (_comp.Screen <= 15)
                    _price += 400;
                else if (_comp.Screen > 15)
                    _price += 600;

                if (_comp.SharedGraphicCard)
                    _price += 1450; // Ekran kartı ücrerti
                else if (_comp.SharedGraphicCard)
                    _price += 0;
            }
            else if (_comp.Brand == "Lenovo" || _comp.Brand == "Dell")
            {
                if (_comp.Brand == "Lenovo")
                    _price += 250; // Lenovo ile Dell arasında 250 lira fark olsun.
                switch (_comp.ProcessorType)
                {
                    case "i3":
                        _price += 350;
                        break;
                    case "i5":
                        _price += 450;
                        break;
                    case "i7":
                        _price += 750;
                        break;
                    case "i9":
                        _price += 1000;
                        break;
                }

                switch (_comp.ProcessorModel)
                {
                    case "10.nesil":
                        _price += 200;
                        break;
                    case "11.nesil":
                        _price += 350;
                        break;
                    case "12.nesil":
                        _price += 450;
                        break;
                    case "13.nesil":
                        _price += 600;
                        break;
                }

                _price += 1000; // Windows 11 için

                if (_comp.Memory <= 16)
                    _price += 900;
                else
                    _price += 1800;

                if (_comp.MemorySpeed == 3200)
                    _price += 800;
                else if (_comp.MemorySpeed == 5400)
                    _price += 1600;

                _price += 400; // Anakart için

                if (_comp.Disk == "SSD")
                    _price += 850;
                else if (_comp.Disk == "HDD")
                    _price += 300;

                if (_comp.DiskSize == 512)
                    _price += 350;
                else if (_comp.DiskSize == 1024)
                    _price += 600;

                if (_comp.Screen <= 15)
                    _price += 300;
                else if (_comp.Screen > 15)
                    _price += 500;

                if (_comp.SharedGraphicCard)
                    _price += 1250; // Ekran kartı ücrerti
                else if (_comp.SharedGraphicCard)
                    _price += 0;
            }

            // Bilgisayarda güncelleme olduğunda fiyat göstermek için bile olsa metot gösterdiğinde aşağıda fiyat günvcellemesi yapılıyor.
            _comp.Price = _price;
            return _price;
        }
        private static void DrawPC(byte color)
        {
            if (color == 0)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (color == 1)
                Console.ForegroundColor = ConsoleColor.Blue;
            else if (color == 2)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (color == 3)
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("                  ---------------");
            Console.WriteLine("                  |             |");
            Console.WriteLine("                  |             |");
            Console.WriteLine("                  |             |");
            Console.WriteLine("                  ---------------");
            Console.WriteLine("                 /              /");
            Console.WriteLine("                /              /");
            Console.WriteLine("               ----------------");
            Console.WriteLine();
            Console.ResetColor();
        }
        private static void DrawPC()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("                  ---------------");
            Console.WriteLine("                  |             |");
            Console.WriteLine("                  |             |");
            Console.WriteLine("                  |             |");
            Console.WriteLine("                  ---------------");
            Console.WriteLine("                 /              /");
            Console.WriteLine("                /              /");
            Console.WriteLine("               ----------------");
            Console.WriteLine();
            Console.ResetColor();
        } // overwrite
    }
}
