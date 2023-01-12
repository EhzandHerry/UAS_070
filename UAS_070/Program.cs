using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_070
{
    class Node
    {
        public int idObat;
        public string namaObat;
        public string dosisObat;
        public int hargaObat;
        public Node next;
    }
    class listObat
    {
        Node START;
        public listObat()
        {
            START = null;
        }
        public void inputObat()
        {
            int idObt, hObt;
            string namaObt, dosisObt;

            Console.Write("Masukan ID Obat    : ");
            idObt = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukan Nama Obat  : ");
            namaObt = Console.ReadLine();
            Console.Write("Masukan Dosid Obat : ");
            dosisObt = Console.ReadLine();
            Console.Write("Masukan Harga Obat : ");
            hObt = Convert.ToInt32(Console.ReadLine());

            Node newnode = new Node();

            newnode.idObat = idObt;
            newnode.namaObat = namaObt;
            newnode.dosisObat = dosisObt;
            newnode.hargaObat = hObt;

            if (START == null || idObt <= START.idObat)
            {
                if ((START != null) && (idObt == START.idObat))
                {
                    Console.WriteLine("\nId ini sudah terdaftar, tolong input Id yang lain!");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (idObt >= current.idObat))
            {
                if (idObt == current.idObat)
                {
                    Console.WriteLine("\nId ini sudah terdaftar, tolong input Id yang lain!");
                    return;
                }
                previous = current;
                current = current.next;
            }
            newnode.next = current;
            previous.next = newnode;
        }
        public void cariBarang()
        {
            Node previous, current;
            current = previous = START;
            Console.Write("\nMasukan dosis obat yang ingin anda cari : ");
            string dosisObt = Console.ReadLine();
            if (dosisObt != current.dosisObat)
            {
                Console.WriteLine("Dosis obat yang diinginkan tidak ada.");
            }
            else
                Console.WriteLine("Menampilkan list yang kamu cari : ");
            
            while (current != null)
            {
                if (dosisObt == current.dosisObat)
                {
                    Console.WriteLine("ID obat      : " + current.idObat);
                    Console.WriteLine("Nama obat    : " + current.namaObat);
                    Console.WriteLine("Dosis obat   : " + current.dosisObat);
                    Console.WriteLine("Harga obat   : " + current.hargaObat);
                    
                }
                current = current.next;
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void traverses()
        {
            if (listEmpty())
            {
                Console.WriteLine("\nObat belum ada yang terdaftar.");
                Console.WriteLine("Tekan 'Enter' untuk melanjutkan.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nMenampilkan list : ");
                
                Console.Write("ID Obat" + "   " + "Nama Obat" + "    " + "     " + "Dosis Obat" + "   " + "Harga Obat" + "\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                {
                    Console.Write(currentNode.idObat + "    " + currentNode.namaObat + "    " + currentNode.dosisObat + "     " + currentNode.hargaObat + "\n");
                }
                Console.WriteLine();
                Console.WriteLine("Tekan 'Enter' untuk melanjutkan.");
                Console.ReadKey();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            listObat lb = new listObat();
            while (true)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Pilih Menu Dibawah ini");
                    Console.WriteLine();
                    Console.WriteLine("1. Menginput obat");
                    Console.WriteLine("2. Menampilkan list obat");
                    Console.WriteLine("3. Cari obat berdasarkan dosis obat");
                    Console.WriteLine("4. Selesai");
                    Console.WriteLine();
                    Console.Write("Pilih opsi yang anda inginkan (1-4) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                Console.WriteLine();
                                lb.inputObat();
                            }
                            break;
                        case '2':
                            {
                                Console.WriteLine();
                                lb.traverses();
                            }
                            break;
                        case '3':
                            {
                                Console.WriteLine();
                                if (lb.listEmpty() == true)
                                {
                                    Console.WriteLine("\nJenis obat tidak ada.");
                                    break;
                                }
                                else
                                    lb.cariBarang();
                                Console.WriteLine("");
                                Console.WriteLine("Press Enter to Continue");
                                Console.ReadLine();
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Pilihan anda salah, tolong tekan 'Enter'.");
                                Console.ReadLine();
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Masukan angka yang sesuai dengan pilihan!");
                    Console.WriteLine("Silahkan tekan 'Enter' untuk kembali.");
                    Console.ReadLine();
                }
            }
        }
    }
}

/*
2. Singly linked list, supaya mempermudah mencari obat yang diinginkan
3. Linked list menggunakan Node sedangkan array tidak
4. Rear dan Front
5. a. 5
   b. Jika menggunakan inorder, maka cara membacanya adalah: 25, 16, 42, 46, 55, 53, 41, 62, 64, 63, 70, 65, 74, 60.
 */

