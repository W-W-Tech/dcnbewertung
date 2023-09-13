namespace dcnsanplanung.bewertung.M149_3
{
    public class BAC : AbstractCode
    {
        public BAC() : base("Rohrbruch")
        {
        }

        public override int CalculateBK()
        {
            switch (Ch1)
            {
                case "A": return 7;
                case "C": return 0;
            }
            return 5;
        }
        public override int CalculateSK()
        {
            switch(Ch1)
            {
                case "A": return 7;
                case "B": return 7;
                default: return 0;
            }
        }
        public override int CalculateDK()
        {
            switch (Ch1)
            {
                case "A":
                case "B":
                    return 1;
                default: return 0;
            }
        }
    }
}
