using System;

class Program
{
    static int Arama(int[] A, int N, int sayi)
    {
        int i = 0;

        while (i < N)
        {
            if (A[i] == sayi)
                break;
            i++;
        }

        if (i < N)
            return i; 
        else
            return -1; 
    }

    static void Main()
    {
       
        int[] sayilar = { 3, 6, 9, 12, 15 };

        int aranan = 12;
        int sonuc = Arama(sayilar, sayilar.Length, aranan);

        if (sonuc != -1)
            Console.WriteLine($"{aranan} sayısı bulundu. İndeks: {sonuc}");
        else
            Console.WriteLine($"{aranan} sayısı dizide yok.");
    }
}
