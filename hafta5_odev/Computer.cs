
namespace hafta5_odev
{
    public class Computer
    {
        public string Brand { get; set; }
        public string ProcessorType { get; set; } // i3 - i5 - i7 - i9
        public string ProcessorModel { get; set; } // 10 - 11 - 12 - 13.nesiller
        public string OS { get; set; } // windows 11
        public int Memory { get; set; } 
        public int MemorySpeed { get; set; } // 3200 - 5400
        public bool Mothercard { get; set; } // true
        public string Disk { get; set; } // SSD - HDD
        public int DiskSize { get; set; } // 512 - 1024
        public double Screen { get; set; } // 14 - 15.6 - 17.3
        public bool SharedGraphicCard { get; set; } // paylaşımlı mı
        public long Price { get; set; }
        // Üstteki özellikler her markada bulunacaktır.
        // Aşağıdaki işlevle tüm bilgisayarlara sonradan bellek eklenebilir.
        public Computer()
        { 
            Mothercard = true;
            OS = "Windows 11";
        }
        public void AddMemory(int _addMemory)
        {
            Memory += _addMemory;
        }
    }
    public class Asus : Computer 
    {
        public Asus()
        {
            Brand = "Asus";
            ProcessorType = "i7";
        }
    }
    public class Dell : Computer
    {
        public Dell()
        {
            Brand = "Dell";
            Disk = "SSD";
        }
    }
    public class Sony : Computer
    {
        public Sony()
        {
            Brand = "Sony";
            // En az i5 olacağını Add metodunda ayarlayacağım...
        }
    }
    public class Lenovo : Computer
    {
        public Lenovo()
        {
            Brand = "Lenovo";
            Screen = 17.3;
        }
    }
}
