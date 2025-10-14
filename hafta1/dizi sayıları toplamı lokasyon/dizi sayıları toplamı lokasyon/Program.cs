namespace dizi_sayıları_toplamı_lokasyon
{
    internal class Program
    {
        static int dizitopla(int[] A, int N )
        {
            int toplam = 0;
            for(int i =0;i <N;i++)
            {
                toplam+= A[i];
            }
            return toplam;
        }

        static void Main()
        {
            int[] sayilar = { 2, 4, 6, 8, 10, 12 };
            int sonuc = dizitopla(sayilar, sayilar.Length);
            Console.WriteLine("Dizideki sayıların toplamı :" + sonuc);
     
        }
  
    }
}