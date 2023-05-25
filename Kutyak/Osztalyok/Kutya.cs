namespace Kutyak;

internal class Kutya
{
    public int Id { get; private set; }
    public int FajtaId { get; private set; }
    public int NevId { get; private set; }
    public int Eletkor { get; private set; }
    public DateTime UtolsoOrvosiEllenorzes { get; private set; }

    public Kutya(string[] adatok)
    {
        Id = Convert.ToInt32(adatok[0]);
        FajtaId = Convert.ToInt32(adatok[1]);
        NevId = Convert.ToInt32(adatok[2]);
        Eletkor = Convert.ToInt32(adatok[3]);
        UtolsoOrvosiEllenorzes = Convert.ToDateTime(adatok[4]);
    }

    public string Nev(List<KutyaNev> kutyaNevek) => kutyaNevek.Where(G => G.Id == NevId).First().Nev;
    public string Fajta(List<KutyaFajta> kutyaFajtak) => kutyaFajtak.Where(G => G.Id == NevId).First().Nev;
    public string EredetiFajta(List<KutyaFajta> kutyaFajtak) => kutyaFajtak.Where(G => G.Id == NevId).First().EredetiNev;

}