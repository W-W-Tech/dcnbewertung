namespace dcnsanplanung.bewertung.M149_3
{
    public class BBD : AbstractCode
    {
        public BBD() : base("Eindringen von Bodenmaterial")
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
