namespace dcnsanplanung.bewertung.M149_3
{
    public class BBB : AbstractCode
    {
        public BBB() : base("Anhaftende Stoffe")
        {
            
        }

        public override int CalculateDK()
        {
            if (Ch1.Equals("A")) return 3;
            return 5;
        }

        public override int CalculateBK()
        {
            switch(Q1)
            {
                case >= 30: return 0;
                case >= 20: return 1;
                case >= 10: return 2;
                case >= 5: return 3;
                default: return 4;
            }
        }
    }

}
