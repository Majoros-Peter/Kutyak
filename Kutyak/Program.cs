using System.Threading.Channels;

namespace Kutyak;

internal class Program
{
    static void Main(string[] args)
    {
        List<KutyaNev> kutyaNevek = File.ReadAllLines("../../../CsvFajlok/KutyaNevek.csv").Skip(1).Select(G => new KutyaNev(G.Split(';'))).ToList();

        Console.WriteLine($"3. feladat: Kutyanevek száma: {kutyaNevek.Count}");

        List<KutyaFajta> kutyaFajtak = File.ReadAllLines("../../../CsvFajlok/KutyaFajtak.csv").Skip(1).Select(G => new KutyaFajta(G.Split(';'))).ToList();

        List<Kutya> kutyak = File.ReadAllLines("../../../CsvFajlok/Kutyak.csv").Skip(1).Select(G => new Kutya(G.Split(';'))).ToList();

        Console.WriteLine($"6. feladat: Kutyanevek átlag életkora: {Math.Round(kutyak.Average(G => G.Eletkor), 2)}");

        var legidosebbKutya = (from kuty in kutyak

                               join nev in kutyaNevek on kuty.NevId equals nev.Id

                               join fajta in kutyaFajtak on kuty.FajtaId equals fajta.Id

                               where kuty.Eletkor == kutyak.Max(G => G.Eletkor)

                               select new {
                                   Nev = nev.Nev,
                                   Fajta = fajta.Nev
                               }
                          ).ToList()[0];

        Console.WriteLine($"7. feladat: Legidősebb kutya neve és fajtája: {legidosebbKutya.Nev}, {legidosebbKutya.Fajta}");

        Console.WriteLine("8. feladat: Január 10.-én vizsgált kutya fajták:");
        kutyak.Where(G => G.UtolsoOrvosiEllenorzes == new DateTime(2018, 1, 10)).GroupBy(G => G.FajtaId).ToList().ForEach(G => Console.WriteLine($"\t{kutyaFajtak.Where(x => x.Id == G.Key).First().Nev}: {G.Count()} kutya"));

        var feladat9 = kutyak.GroupBy(G => G.UtolsoOrvosiEllenorzes).OrderByDescending(G => G.Count()).First();
        Console.WriteLine($"9. feladat: Legjobban leterhelt nap: {feladat9.Key.ToString("yyyy. MM. dd.")}: {feladat9.Count()} kutya");

        StreamWriter sw = new("../../../névstatisztika.txt");
        foreach (var str in kutyak.GroupBy(G => G.NevId).OrderByDescending(G=>G.Count()))
            sw.WriteLine($"{kutyaNevek.Where(G=>G.Id == str.Key).First().Nev};{str.Count()}");
        sw.Close();
        Console.WriteLine("névstatisztika.txt");
    }
}