using System;
using System.Linq;
using System.Numerics;

namespace OtoGaleriUygulamasi
{
    internal class Program
    {
        static Galeri OtoGaleri = new Galeri();

        static void Main(string[] args)
        {
            // Kullanıcı ile etkileşime gireceğimiz bütün kodlar program sınıfı içerisinde yazılacak.
            //  Uygulama();


            //Console.Write("Sayi girin");
            //string sayi = Console.ReadLine().ToUpper();
            //int x = 0;
            //Sahte();
            Uygulama();


            //bool sonuc = int.TryParse(sayi , out x);



            //Console.WriteLine(sonuc);




        }
        static void Uygulama()
        {
            Menu();

            do
            {// switch-case
                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                string sayi = Console.ReadLine().ToUpper();
                Console.WriteLine();
                switch (sayi)
                {
                    case "1":
                    case "K":
                        ArabaKirala();
                        break;
                    case "2":
                    case "T":
                        ArabaTeslim();
                        break;
                    case "3":
                    case "R":
                        KiradaArabaListe();
                        break;
                    case "4":
                    case "M":
                        GalerideArabaListe();
                        break;
                    case "5":
                    case "A":
                        TumArabaListe();
                        break;
                    case "6":
                    case "I":
                        Kiralamaİptal();
                        break;
                    case "7":
                    case "Y":
                        ArabaEkle();
                        break;
                    case "8":
                    case "S":
                        ArabaSil();
                        break;
                    case "9":
                    case "G":
                        Bilgiler();
                        break;
                    default:
                        Console.WriteLine("Hatali islem gerçeklestirildi. Tekrar deneyin.");
                        break;
                }
            } while (true);
        }

        static void Menu()
        {
            Console.WriteLine("Galeri Otomasyon                        ");
            Console.WriteLine("1 - Araba Kirala(K)                     ");
            Console.WriteLine("2 - Araba Teslim Al(T)                  ");
            Console.WriteLine("3 - Kiradaki Arabaları Listele(R)       ");
            Console.WriteLine("4 - Galerideki Arabaları Listele(M)     ");
            Console.WriteLine("5 - Tüm Arabaları Listele(A)            ");
            Console.WriteLine("6 - Kiralama İptali(I)                  ");
            Console.WriteLine("7 - Araba Ekle(Y)                       ");
            Console.WriteLine("8 - Araba Sil(S)                        ");
            Console.WriteLine("9 - Bilgileri Göster(G)                 ");
        }


        static void ArabaKirala()
        {
            if (OtoGaleri.ToplamAracSayisi == 0)
            {
                Console.WriteLine("Galeride hiç araba yok.");

            }
            else
            {
                string plaka;
                bool var = false;
                Console.WriteLine("-Araba Kirala-");
                do
                {


                    Console.Write("Kiralanacak arabanın plakası: ");
                    plaka = PlakaYazım();
                    var = OtoGaleri.PlakaSorgu(plaka);
                    if (var == false)
                    {
                        Console.WriteLine("Galeriye ait bu plakada bir araba yok.");

                    }
                    // kiralanacak arabanın plakası doğru girilmediği sürece tekrar plaka istenecek.
                } while (var == false);
                Console.Write("Kiralama süresi: ");
                int sure = int.Parse(Console.ReadLine());


                OtoGaleri.ArabaKirala(plaka, sure);
            }
        }

        static void ArabaEkle()
        {
            Console.Write("Plaka: ");

            string plaka = PlakaYazım();
            Console.Write("Marka: ");
            string marka = Console.ReadLine().ToUpper();
            Console.Write("Kiralama Bedeli: ");
            float kiralamaBedeli = float.Parse(Console.ReadLine());
            string aTipi = "";
            Console.Write("Araç Tipi:");
            Console.WriteLine("SUV için 1");
            Console.WriteLine("Hatchback için 2 ");
            Console.WriteLine("Sedan için 3");
            Console.WriteLine("Araba Tipi:      ");
            string arabaTipiSecim = Console.ReadLine().ToUpper();

            switch (arabaTipiSecim)
            {
                case "1":
                    aTipi = "SUV";
                    break;
                case "2":
                    aTipi = "Hatchback";
                    break;
                case "3":
                    aTipi = "Sedan";
                    break;
            }

            OtoGaleri.ArabaEkle(plaka, marka, kiralamaBedeli, aTipi);

        }
        static void ArabaTeslim()
        {
            Console.WriteLine("-Araba Teslim Al-");
            Console.WriteLine();
            string plaka = "";
            bool var = false;
            bool durum = false;
            if (OtoGaleri.ToplamAracSayisi == 0)
            {
                Console.WriteLine("Galeride hiç araba yok.");
            }
            else
            {
                do
                {
                    do
                    {


                        Console.Write("Teslim edilecek arabanin plakasi: ");
                        plaka = PlakaYazım();
                        var = OtoGaleri.PlakaSorgu(plaka);
                        durum = OtoGaleri.KiraSorgu(plaka);
                        if (var == false)
                        {
                            Console.WriteLine("Galeriye ait bu plakada bir araba yok.");

                        }

                    } while (var == false);
                } while (durum != false);
            }


            // kiralanacak arabanın plakası doğru girilmediği sürece tekrar plaka istenecek.





            OtoGaleri.ArabaTeslimAl(plaka);

        }
        static void TumArabaListe()
        {
            if (OtoGaleri.ToplamAracSayisi == 0)
            {
                Console.WriteLine("Galeride hiç araba yok.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("-Tüm Arabalar-");
                Console.WriteLine();
                ListeUst();
                OtoGaleri.TumArabalarListele();
            }
        }
        static void ListeUst()
        {
            Console.WriteLine("Plaka".PadRight(14) + "Marka".PadRight(12) + "K. Bedeli".PadRight(12) + "Araba Tipi".PadRight(12) + "K. Sayisi".PadRight(12) + "Durum");
            Console.WriteLine("----------------------------------------------------------------------");
        }
        static void Bilgiler()
        {
            Console.WriteLine("- Galeri Bilgileri -");
            Console.WriteLine("Toplam araba sayisi: " + OtoGaleri.ToplamAracSayisi);
            Console.WriteLine("Kiradaki araba sayisi: " + OtoGaleri.KiradakiAracSayisi);
            Console.WriteLine("Bekleyen araba sayisi: " + OtoGaleri.GaleridekiAracSayisi);
            Console.WriteLine("Toplam araba kiralama süresi: " + OtoGaleri.ToplamAracKiralamaSuresi);
            Console.WriteLine("Toplam araba kiralama adedi: " + OtoGaleri.ToplamAracKiralamaAdeti);
            Console.WriteLine("Ciro: " + OtoGaleri.Ciro);

        }
        static void Kiralamaİptal()
        {
            Console.WriteLine("-Kiralama Iptali-");
            Console.WriteLine();
            string plaka;
            bool var = false;
            bool durum = false;

            if (OtoGaleri.KiradakiAracSayisi == 0)
            {
                Console.WriteLine("Kirada araba yok.");
            }
            else
            {
                do
                {
                    do
                    {


                        Console.Write("Kiralamasi iptal edilecek arabanin plakasi: ");
                        plaka = PlakaYazım();
                        var = OtoGaleri.PlakaSorgu(plaka);
                        durum = OtoGaleri.KiraSorgu(plaka);
                        if (var == false)
                        {
                            Console.WriteLine("Galeriye ait bu plakada bir araba yok.");

                        }

                    } while (var == false);

                    if (durum == false)
                    {
                        Console.WriteLine("Hatali giris yapildi. Araba zaten galeride.");
                    }
                    else { OtoGaleri.KiralamaIptal(plaka); }

                } while (durum != false);
            }
        }
        static void ArabaSil()
        {
            Console.WriteLine();
            Console.WriteLine("-Araba Sil-");
            Console.WriteLine();
            string plaka;
            bool var = false;
            do
            {


                Console.Write("Silmek istediginiz arabanin plakasini giriniz: ");
                plaka = PlakaYazım();
                var = OtoGaleri.PlakaSorgu(plaka);

                if (var == false)
                {
                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");

                }
                else { OtoGaleri.ArabaSil(plaka); }

            } while (var == false);
        }
        static void GalerideArabaListe()
        {
            if (OtoGaleri.ToplamAracSayisi == 0)
            {
                Console.WriteLine("Galeride hiç araba yok.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("-Tüm Arabalar-");
                Console.WriteLine();
                ListeUst();
                OtoGaleri.GalerideArabalarListele();
            }
        }
        static void KiradaArabaListe()
        {
            if (OtoGaleri.ToplamAracSayisi == 0)
            {
                Console.WriteLine("Galeride hiç araba yok.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("-Tüm Arabalar-");
                Console.WriteLine();
                ListeUst();
                OtoGaleri.KiradaArabalarListele();
            }
        }
        static string PlakaYazım()
        {
            int sayi1, sayi2;
            string harf;
            bool durum = true;
            string a = " ";
            do
            {
                a = Console.ReadLine().ToUpper();
                if (a.Length > 9)
                {
                    durum = false;
                }
                else if (int.TryParse(a.Substring(0, 2), out sayi1) == false)
                {

                    durum = false;

                }
                else if (int.TryParse(a.Substring(a.Length - 3, 3), out sayi1) == false) { durum = false; }
                else if (int.TryParse(a.Substring(2, 1), out sayi1) == true) { durum = false; }
                else if (int.TryParse(a.Substring(3, 1), out sayi1) == true) { durum = false; }
                if (durum == false)
                {
                    Console.WriteLine("Bu sekilde plaka girisi yapamazsiniz. Tekrar deneyin.");
                    Console.Write("Plaka: ");
                }

            } while (durum == false);
            return a;
        }

    }
}
