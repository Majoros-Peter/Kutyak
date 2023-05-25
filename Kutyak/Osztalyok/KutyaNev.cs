namespace Kutyak;

internal class KutyaNev
{
    public int Id { get; private set; }
    public string Nev { get; private set; }

    public KutyaNev(string[] adatok)
    {
        Id = Convert.ToInt32(adatok[0]);
        Nev = adatok[1];
    }
}