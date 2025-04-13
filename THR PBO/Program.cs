using System;

class Karyawan
{
    private string nama;
    private string id;
    private double gajiPokok;

    public string Nama
    {
        get => nama;
        set => nama = value;
    }

    public string ID
    {
        get => id;
        set => id = value;
    }

    public double GajiPokok
    {
        get => gajiPokok;
        set => gajiPokok = value;
    }

    public virtual double HitungGaji()
    {
        return gajiPokok;
    }
}

class KaryawanTetap : Karyawan
{
    private double bonusTetap = 500000;

    public override double HitungGaji()
    {
        return GajiPokok + bonusTetap;
    }
}

class KaryawanKontrak : Karyawan
{
    private double potonganKontrak = 200000;

    public override double HitungGaji()
    {
        return GajiPokok - potonganKontrak;
    }
}

class KaryawanMagang : Karyawan
{
    public override double HitungGaji()
    {
        return GajiPokok;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Masukkan jenis karyawan (tetap/kontrak/magang): ");
        string jenis = Console.ReadLine().ToLower();

        Console.Write("Masukkan nama: ");
        string nama = Console.ReadLine();

        Console.Write("Masukkan ID: ");
        string id = Console.ReadLine();

        Console.Write("Masukkan gaji pokok: ");
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        Karyawan karyawan;

        switch (jenis)
        {
            case "tetap":
                karyawan = new KaryawanTetap();
                break;
            case "kontrak":
                karyawan = new KaryawanKontrak();
                break;
            case "magang":
                karyawan = new KaryawanMagang();
                break;
            default:
                Console.WriteLine("Jenis karyawan tidak valid.");
                return;
        }

        karyawan.Nama = nama;
        karyawan.ID = id;
        karyawan.GajiPokok = gajiPokok;

        Console.WriteLine("\nDetail Karyawan:");
        Console.WriteLine($"Nama       : {karyawan.Nama}");
        Console.WriteLine($"ID         : {karyawan.ID}");
        Console.WriteLine($"Gaji Pokok : {karyawan.GajiPokok}");
        Console.WriteLine($"Gaji Akhir : {karyawan.HitungGaji()}");
    }
}
