using System;

namespace double_linked_list
{
    /// <summary>
    /// main class
    /// </summary>
    class Node
    {
        //publik yang bertipekan data apapun yang merepresentasikan bilangan bulat, atau beberapa bagian dari bilangan bulat (integer)
        public int barang;
        //publik yang digunakan untuk menyimpan barisan karakter (string)
        public string name;
        //Untuk menunjuk ke node berikutnya
        public Node next;
        //Untuk mendahului dari node sebelumnya
        public Node prev;
    }

    class DoubleLinkedList
    {
        //Fungsi node adalah untuk mengirimkan data dan informasi dengan memanfaatkan media titik-titik yang terhubung dalam satu jaringan serupa.
        Node START;

        //constructor

        public void addNode()
        {
            /// <summary>
            /// operasi penambahan
            /// </summary>
            int nim;
            string nm;
            //Fungsi Writeline adalah untuk menampilkan teks dalam satu baris atau baris baru
            Console.WriteLine("\nMasukan Number data barang: ");
            //Method ToInt32() digunakan untuk mengubah string menjadi integer. 
            nim = Convert.ToInt32(Console.ReadLine());
            //Fungsi Write adalah untuk menampilkan teks tanpa membuat baris baru
            Console.Write("\nMasukkan Nama Barang: ");
            //Method readline() berfungsi untuk mengembalikan satu baris dari file.
            nm = Console.ReadLine();
            //new digunakan untuk membuat objek. dalam contoh ini sebuah objek dibuat untuk kelas menggunakan yang baru, seperti halnya dibawah ini. Node newNode = new Node();
            Node newNode = new Node();
            newNode.barang = nim;
            newNode.name = nm;

            //Fungsi IFNULL() adalah untuk mengembalikan nilai yang ditentukan jika ekspresinya adalah NULL.
            if (START == null || nim == START.barang)
            {
                if ((START != null) && (nim == START.barang))
                {
                    /// <returns>
                    /// Hasil dari penambahan addNode
                    /// </returns>
                    Console.WriteLine("\nDuplicate number not allowed");
                    //perintah return akan mengakhiri suatu method seperti yang telah dijelaskan sebelumnya di bagian kondisi pada C#
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.next = null;
                START = newNode;
                return;
            }
            //Node yang akan disisipkan diantara dua Node
            Node previous, current;
            for(current = previous = START;
                current != null && nim >= current.barang;
                previous = current, current = current.next)
            {
                if (nim == current.barang)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
            }
            //Pada eksekusi next & prev menrujuk pada node current & previous. di antaranya node baru juga akan disisipkan didalamnya
            newNode.next = current;
            newNode.prev = previous;

           //Jika node akan disisipkan di akhir daftar
           if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        //Tipe data boolean ini berfungsi untuk mengisi salah satu dari 2 nilai, yaitu true atau false.
        //Kata kunci int bagian bilangan bulat dari angka - untuk nilai argumen tunggal (angka apa saja) 0 - tanpa argumen
        //Serta ref dalam C# juga digunakan untuk meneruskan atau mengembalikan referensi nilai ke atau dari Metode.
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            previous = current = START;
            //While digunakan untuk mengulang statement sebanyak satu kali terlebih dahulu, kemudian akan mengecek statement didalam while apakah bernilai benar
            //dan apabila jika bernilai benar maka akan diulang kembali. Jika statement di dalam while bernilai salah maka perulangan akan berakhir.
            while (current != null &&
                rollNo != current.barang)
            {
                previous = current;
                current = current.next;
            }
            return (current != null);
        }
        public bool dellNode(int rollNo)
        {
            Node previous, current;
            //Kata kunci Null adalah literal yang mewakili referensi Null / yang tidak merujuk ke objek apa pun.
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            //Perawalan data
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            //Node masuk di antara dua node dalam daftar
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }

            //jika yang akan dihapus ada di antara daftar maka baris berikut tersebut akan dieksekusi
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }

        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        public void ascending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nTampilan dari data Ascending" + "dari urutan Number:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.barang + currentNode.name + "\n");
            }
        }

        public void descending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("Tampilan dari data Descending" + "dari urutan Number:\n");
                Node currentNode;
                //Fungsinya untuk membawa currentNode ke node paling belakang
                currentNode = START;
                while (currentNode.next != null)
                {
                    currentNode = currentNode.next;
                }

                //Fungsinya untuk membaca data dari last node ke first node
                while (currentNode != null)
                {
                    Console.Write(currentNode.barang + " " + currentNode.name + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
    }

    class Program
    {
        //Method Static void Main adalah titik masuk dari program C #. Di sinilah eksekusi program C# dimulai.
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                //Fungsi try dibawah ini menentukan blok kode yang akan diuji kesalahannya saat dieksekusi. 
                try
                {
                    Console.WriteLine("\nData Barang Toko Elektronik");
                    Console.WriteLine("1. Menambahkan Data Barang");
                    Console.WriteLine("2. Menghapus Data Barang");
                    Console.WriteLine("3. Menampilkan semua data ascending");
                    Console.WriteLine("4. Menampilkan semua data descending");
                    Console.WriteLine("5. Mencari list barang");
                    Console.WriteLine("6. Keluar\n");
                    Console.WriteLine("Masukkan pilihan (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            //Break pada Switch Case bertujuan untuk menghindari eksekusi pada case dibawahnya dan menghentikan program ketika value pada case sama dengan yang diharapkan.
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList Kosong");
                                    break;
                                }
                                Console.Write("\nMasukan data barang" +
                                    "whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.dellNode(rollNo) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Record with roll number" + rollNo + "deleted \n");

                            }
                            break;
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;
                        case '4':
                            {
                                obj.descending();
                            }
                            break;
                        case '5':
                            {
                                if(obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList kosong");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nMasukkan data barang yang ingin kamu cari: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nTidak ditemukan");
                                else
                                {
                                    Console.WriteLine("\nData Ditemukan");
                                    Console.WriteLine("\nNumber Barang: " + curr.barang);
                                    Console.WriteLine("\nNama: " + curr.name);
                                }
                                break;
                            }
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                //Pernyataan catch berfungsi untuk menentukan blok kode yang akan dieksekusi, jika terjadi kesalahan pada blok try.
                catch (Exception e)
                {
                    Console.WriteLine("Check for the values entered.");
                }
            }
        }
    }
}
