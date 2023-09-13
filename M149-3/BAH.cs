namespace dcnsanplanung.bewertung.M149_3
{
    public class BAH : AbstractCode
    {
        public BAH() : base("Schadhafter Anschluss")
        {
            
        }

        public override int CalculateDK()
        {
            switch(Ch1)
            {
                case "B":
                case "C":
                case "D": return 2;
                case "Z": return 7;
                default: return 5;
            }
        }

        public override int CalculateSK()
        {
            if (Ch1.Equals("Z")) return 7;
            return 5;
        }
    }
}
