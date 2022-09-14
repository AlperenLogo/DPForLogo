namespace Constructor
{

    public enum Enerji
    {
        A,
        APlus,
        B,
        C

    }
    public class CamasirMakinesi
    {
        public string Renk { get; set; }
        public Enerji EnerjiSinifi { get; set; }
        public int KgKapasite { get; set; }

        public CamasirMakinesi() : this(Enerji.APlus, 20)
        {
            Renk = "Beyaz";

        }

        public CamasirMakinesi(Enerji istenenEnerjiSinifi)
        {
            EnerjiSinifi = istenenEnerjiSinifi;
        }
        public CamasirMakinesi(int kg)
        {
            KgKapasite = kg;
        }

        public CamasirMakinesi(Enerji istenenEnerjiSinifi, int kg)
        {
            EnerjiSinifi = istenenEnerjiSinifi;
            KgKapasite = kg;
        }
    }
}
