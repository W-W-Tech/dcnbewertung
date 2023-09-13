namespace dcnsanplanung.bewertung.M149_3
{
    public class BBA : AbstractCode
    {
        public BBA() : base("Wurzeln")
        {
        }
        public override int CalculateDK()
        {
            return 2;
        }
        public override int CalculateBK()
        {
            switch(Q1)
            {
                case >= 30: return 0;
                case >= 20: return 1;
                case >= 10: return 2;
                default: return 3;
            }
        }
    }

}
