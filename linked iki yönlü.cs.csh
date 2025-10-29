
using System;

class Program
{
    // 🔹 Düğüm (Node) sınıfı: her düğümde veri, bir sonraki ve bir önceki düğüm referansı bulunur
    public class Node
    {
        public int Data;     // düğümdeki veri
        public Node Next;    // sonraki düğüm referansı
        public Node Prev;    // önceki düğüm referansı

        public Node(int data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }

    // 🔹 Çift yönlü bağlı liste sınıfı
    public class CiftYonluList
    {
        private Node head; // listenin başı
        private Node tail; // listenin sonu

        public CiftYonluList()
        {
            head = null;
            tail = null;
        }

        // 🔸 Başa eleman ekleme
        public void BasaEkle(int value)
        {
            Node newNode = new Node(value);

            if (head == null) // liste boşsa
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head; // yeni düğümün sonrakisi eski head olur
                head.Prev = newNode; // eski head’in öncekisi yeni düğüm olur
                head = newNode;      // head artık yeni düğüm olur
            }

            Console.WriteLine($"{value} başa eklendi.");
        }

        // 🔸 Sona eleman ekleme
        public void SonaEkle(int value)
        {
            Node newNode = new Node(value);

            if (tail == null) // liste boşsa
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode; // eski tail’in sonrakisi yeni düğüm olur
                newNode.Prev = tail; // yeni düğümün öncekisi eski tail olur
                tail = newNode;      // tail artık yeni düğüm olur
            }

            Console.WriteLine($"{value} sona eklendi.");
        }

        // 🔸 Belirli bir değerin sonrasına eleman ekleme
        public void SonrasinaEkle(int varolanDeger, int yeniDeger)
        {
            Node current = head;

            // varolan değeri bul
            while (current != null && current.Data != varolanDeger)
                current = current.Next;

            if (current == null)
            {
                Console.WriteLine($"{varolanDeger} listede bulunamadı.");
                return;
            }

            Node newNode = new Node(yeniDeger);

            // bağlantıları düzenle
            newNode.Next = current.Next;
            newNode.Prev = current;

            if (current.Next != null)
                current.Next.Prev = newNode;
            else
                tail = newNode; // sona ekleniyorsa tail güncellenmeli

            current.Next = newNode;

            Console.WriteLine($"{yeniDeger}, {varolanDeger}'nin sonrasına eklendi.");
        }

        // 🔸 Baştan eleman silme
        public void BastanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş, silinecek eleman yok.");
                return;
            }

            head = head.Next; // ikinci düğüm yeni head olur

            if (head != null)
                head.Prev = null; // yeni head’in önceki referansı sıfırlanır
            else
                tail = null; // liste tamamen boşaldıysa tail de null olur

            Console.WriteLine("İlk eleman silindi.");
        }

        // 🔸 Sondan eleman silme
        public void SondanSil()
        {
            if (tail == null)
            {
                Console.WriteLine("Liste boş, silinecek eleman yok.");
                return;
            }

            tail = tail.Prev; // bir önceki düğüm yeni tail olur

            if (tail != null)
                tail.Next = null; // tail’in sonrakisi artık null
            else
                head = null; // liste boşaldıysa head de null olur

            Console.WriteLine("Son eleman silindi.");
        }

        // 🔸 Belirli değeri silme
        public void Sil(int value)
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }

            Node current = head;

            while (current != null && current.Data != value)
                current = current.Next;

            if (current == null)
            {
                Console.WriteLine($"{value} listede bulunamadı.");
                return;
            }

            if (current == head)
            {
                BastanSil();
                return;
            }

            if (current == tail)
            {
                SondanSil();
                return;
            }

            // bağlantıları yeniden düzenle
            current.Prev.Next = current.Next;
            current.Next.Prev = current.Prev;

            Console.WriteLine($"{value} listeden silindi.");
        }

        // 🔸 Listeyi baştan sona göster
        public void ListeyiYazdir()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }

            Node current = head;
            Console.Write("Liste (baştan → sona): ");
            while (current != null)
            {
                Console.Write(current.Data + " <-> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        // 🔸 Listeyi sondan başa göster
        public void TersYazdir()
        {
            if (tail == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }

            Node current = tail;
            Console.Write("Liste (sondan → başa): ");
            while (current != null)
            {
                Console.Write(current.Data + " <-> ");
                current = current.Prev;
            }
            Console.WriteLine("null");
        }
    }

    // 🔹 Main metodu: menü sistemi
    static void Main(string[] args)
    {
        CiftYonluList listem = new CiftYonluList();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Çift Yönlü LinkedList İşlemleri ---");
            Console.WriteLine("1. Listeyi Göster (baştan → sona)");
            Console.WriteLine("2. Listeyi Ters Göster (sondan → başa)");
            Console.WriteLine("3. Başa Eleman Ekle");
            Console.WriteLine("4. Sona Eleman Ekle");
            Console.WriteLine("5. Belirli Değerin Sonrasına Ekle");
            Console.WriteLine("6. Baştan Sil");
            Console.WriteLine("7. Sondan Sil");
            Console.WriteLine("8. Eleman Sil");
            Console.WriteLine("9. Çıkış");
            Console.Write("Seçiminiz: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    listem.ListeyiYazdir();
                    break;
                case "2":
                    listem.TersYazdir();
                    break;
                case "3":
                    Console.Write("Başa eklenecek değeri girin: ");
                    listem.BasaEkle(Convert.ToInt32(Console.ReadLine()));
                    break;
                case "4":
                    Console.Write("Sona eklenecek değeri girin: ");
                    listem.SonaEkle(Convert.ToInt32(Console.ReadLine()));
                    break;
                case "5":
                    Console.Write("Sonrasına eklemek istediğiniz değeri girin: ");
                    int varolan = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Yeni değeri girin: ");
                    int yeni = Convert.ToInt32(Console.ReadLine());
                    listem.SonrasinaEkle(varolan, yeni);
                    break;
                case "6":
                    listem.BastanSil();
                    break;
                case "7":
                    listem.SondanSil();
                    break;
                case "8":
                    Console.Write("Silinecek değeri girin: ");
                    listem.Sil(Convert.ToInt32(Console.ReadLine()));
                    break;
                case "9":
                    running = false;
                    Console.WriteLine("Program sonlandırıldı.");
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }
    }
}
