namespace dcnsanplanung.bewertung.M149_3
{
    public class BAI : AbstractCode
    {
        public BAI() : base("Einragendes Dichtungsmaterial")
        {
        }

        public override int CalculateDK()
        {
            return 2;
        }

        public override int CalculateBK()
        {
            if(Ch1.Equals("A"))
            {
                if (Ch2.Equals("A")) return 4;
                return 3;
            }

            switch(Q1)
            {
                case >= 50: return 0;
                case >= 35: return 1;
                case >= 20: return 2;
                case >= 5: return 3;
                default: return 4;
            }
        }

    }
}
