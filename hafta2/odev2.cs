using System;

class Program
{
    // Node sınıfı: Her bir düğüm bir veriye ve bir sonraki düğüme işaret eder
    public class Node //düğüm tanımlama
    {
        public int Data;//verimiz
        public Node Next;//sonraki pointırımız

        public Node(int data)//yapıcı metod Node a dönüştürür
        {
            Data = data;
            Next = null;
        }
    }

    // LinkedList sınıfı: Kendi bağlantılı liste yapımızı burada oluşturuyoruz
    public class BagliList
    {
        private Node head;
        private Node tail;

        public BagliList()
        {
            head = null;
            tail = null;
        }

        // Başa eleman ekleme
        public void BasaEkle(int value)
        {
            Node newNode = new Node(value);//noda dönüştür
            newNode.Next = head;
            head = newNode;
            Console.WriteLine($"{value} başa eklendi.");
        }

        // Sona eleman ekleme
        public void SonaEkle(int value)
        {
            Node newNode = new Node(value);//noda dönüştür
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                Console.WriteLine($"{value} sona eklendi.");
                return;
            }

            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
            tail = newNode;
            Console.WriteLine($"{value} sona eklendi.");
        }

        // Belirli bir değerin sonrasına eleman ekleme
        public void sonrasinaEkle(int varolanDeger, int yeniDeger)
        {
            Node current = head;

            // Listede varolanDeger'yi bulana kadar ilerle
            while (current != null && current.Data != varolanDeger)
            {
                current = current.Next;
            }

            // Eğer mevcut değer bulunamadıysa, kullanıcıya bilgi ver
            if (current == null)
            {
                Console.WriteLine($"{varolanDeger} listede bulunamadı.");
                return;
            }

            // Yeni elemanı mevcut elemandan sonrasına ekle
            Node newNode = new Node(yeniDeger);//noda dönüştür
            newNode.Next = current.Next; // Yeni elemanın 'Next' referansını mevcut elemanın 'Next'ine yönlendir
            current.Next = newNode; // Mevcut elemanın 'Next' referansını yeni düğüme yönlendir

            Console.WriteLine($"{yeniDeger}, {varolanDeger}'nin sonrasına eklendi.");
        }

        // İlk elemanı silme
        public void bastanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş, silinecek eleman yok.");
                return;
            }

            head = head.Next;
            Console.WriteLine("İlk eleman silindi.");
        }

        // Son elemanı silme
        public void sondanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş, silinecek eleman yok.");
                return;
            }

            if (head.Next == null)
            {
                head = null;
                Console.WriteLine("Son eleman silindi.");
                return;
            }

            Node current = head;
            while (current.Next != null && current.Next.Next != null)
            {
                current = current.Next;
            }

            current.Next = null;
            Console.WriteLine("Son eleman silindi.");
        }

        // Belirli bir elemanı silme
        public void Remove(int value)
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş, silinecek eleman yok.");
                return;
            }

            if (head.Data == value)
            {
                head = head.Next;
                Console.WriteLine($"{value} listeden silindi.");
                return;
            }

            Node current = head;
            while (current.Next != null && current.Next.Data != value)
            {
                current = current.Next;
            }//ilerlemeyi sağlar

            if (current.Next == null)//bulunmadı
            {
                Console.WriteLine($"{value} listede bulunamadı.");
                return;
            }

            current.Next = current.Next.Next;
            Console.WriteLine($"{value} listeden silindi.");
        }

        // Listeyi yazdırma
        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }

            Node current = head;
            Console.Write("Liste: ");
            while (current != null)
            {
                Console.Write(current.Data + "-->");
                current = current.Next;
            }
            Console.WriteLine();
        }

        // Eleman arama
        public void ara(int value)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data == value)
                {
                    Console.WriteLine($"{value} listede bulunuyor.");
                    return;
                }
                current = current.Next;
            }
            Console.WriteLine($"{value} listede bulunmuyor.");
        }
    }

    static void Main(string[] args)
    {
        BagliList listim = new BagliList();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- LinkedList İşlemleri ---");
            Console.WriteLine("1. Listeyi Göster");
            Console.WriteLine("2. Başa Eleman Ekle");
            Console.WriteLine("3. Sona Eleman Ekle");
            Console.WriteLine("4. Belirli Bir Değerin Sonrasına Eleman Ekle");
            Console.WriteLine("5. İlk Elemanı Sil");
            Console.WriteLine("6. Son Elemanı Sil");
            Console.WriteLine("7. Eleman Sil");
            Console.WriteLine("8. Eleman Ara");
            Console.WriteLine("9. Çıkış");
            Console.Write("Bir işlem seçin (1-9): ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    listim.Display();
                    break;

                case "2":
                    Console.Write("Başa eklenecek değeri girin: ");
                    int BasaEkleValue = Convert.ToInt32(Console.ReadLine());
                    listim.BasaEkle(BasaEkleValue);
                    break;

                case "3":
                    Console.Write("Sona eklenecek değeri girin: ");
                    int DegeriSonaEkle = Convert.ToInt32(Console.ReadLine());
                    listim.SonaEkle(DegeriSonaEkle);
                    break;

                case "4":
                    Console.Write("Sonrasına eklemek istediğiniz değeri girin: ");
                    int varolanDeger = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Yeni değeri girin: ");
                    int yeniDeger = Convert.ToInt32(Console.ReadLine());
                    listim.sonrasinaEkle(varolanDeger, yeniDeger);
                    break;

                case "5":
                    listim.bastanSil();
                    break;

                case "6":
                    listim.sondanSil();
                    break;

                case "7":
                    Console.Write("Silinecek elemanı girin: ");
                    int removeValue = Convert.ToInt32(Console.ReadLine());
                    listim.Remove(removeValue);
                    break;

                case "8":
                    Console.Write("Aranacak elemanı girin: ");
                    int DegerAra = Convert.ToInt32(Console.ReadLine());
                    listim.ara(DegerAra);
                    break;

                case "9":
                    running = false;
                    Console.WriteLine("Çıkılıyor...");
                    break;

                default:
                    Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
                    break;
            }
        }
    }
}
