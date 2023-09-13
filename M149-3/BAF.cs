namespace dcnsanplanung.bewertung.M149_3
{
    public class BAF : AbstractCode
    {
        public BAF() : base("Oberflächenschaden")
        {
        }

        public override int CalculateBK()
        {
            if (Ch1.Equals("K")) return 3;
            return 4;
        }

        public override int CalculateDK()
        {
            switch(Ch1)
            {
                case "I": return 1;
                case "Z": return 7;
                default: return 5;
            }
        }

        public override int CalculateSK()
        {
            switch(Ch1)
            {
                case "A": return 4;
                case "B":
                case "C": return 3;
                case "D": return 2;
                case "E": return 1;
                case "F": return 3;
                case "G": return 2;
                case "H": return 1;
                case "I": 
                case "J": 
                case "Z": return 7;
                default: return 5;
            }
        }
    }
}
