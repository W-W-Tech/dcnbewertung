namespace dcnsanplanung.bewertung.M149_3
{
    public class BAO : AbstractCode
    {
        public BAO() : base("Boden sichtbar")
        {
            
        }

        public override int CalculateDK()
        {
            return 1;
        }

        public override int CalculateSK()
        {
            return 1;
        }
    }


}
