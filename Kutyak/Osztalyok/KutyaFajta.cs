namespace Kutyak;

internal class KutyaFajta
{
    public int Id { get; private set; }
    public string Nev { get; private set; }
    public string EredetiNev { get; private set; }

    public KutyaFajta(string[] adatok)
    {
        Id = Convert.ToInt32(adatok[0]);
        Nev = adatok[1];
        EredetiNev = adatok[2];
    }
}