namespace dcnsanplanung.bewertung.M149_3
{
    public class BAP : AbstractCode
    {
        public BAP() : base("Hohlraum sichtbar")
        {

        }

        public override int CalculateDK()
        {
            return 1;
        }

        public override int CalculateSK()
        {
            return 0;
        }
    }

}
