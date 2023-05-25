namespace Kutyak;

internal class Program
{
    static void Main(string[] args)
    {
        List<KutyaNev> kutyaNevek = File.ReadAllLines("../../../CsvFajlok/KutyaNevek.csv").Skip(1).Select(G=>new KutyaNev(G.Split(';'))).ToList();

        Console.WriteLine($"3. feladat: Kutyanevek száma: {kutyaNevek.Count}");

        List<KutyaFajta> kutyaFajtak = File.ReadAllLines("../../../CsvFajlok/KutyaFajtak.csv").Skip(1).Select(G=>new KutyaFajta(G.Split(';'))).ToList();
        
        List<Kutya> kutyak = File.ReadAllLines("../../../CsvFajlok/Kutyak.csv").Skip(1).Select(G=>new Kutya(G.Split(';'))).ToList();

        Console.WriteLine($"6. feladat: Kutyanevek átlag életkora: {kutyak.Average(G=>G.Eletkor)}");

        //kutyak.Where(G => G.Eletkor == kutyak.Max(G => G.Eletkor)).ToList().ForEach(G => Console.WriteLine($"7. feladat: Legidősebb kutya neve és fajtája: {G.Nev(kutyaNevek)}, {G.Fajta(kutyaFajtak)}"));

        var vegsoLista = kutyak.Join(kutyaFajtak, kutya => kutya.FajtaId, fajta => fajta.Id, (kutya, fajta) => new { kutya, fajta.Nev }).Join(kutyaNevek, kutya => kutya.kutya.NevId, nev => nev.Id, (kutya, nev) => new { kutya, nev }).ToList();
    }
}