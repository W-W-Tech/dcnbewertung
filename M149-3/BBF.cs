namespace dcnsanplanung.bewertung.M149_3
{
    public class BBF : AbstractCode
    {
        public BBF() : base("Infiltration")
        {
            
        }

        public override int CalculateDK()
        {
            switch(Ch1)
            {
                case "A": return 2;
                default: return 1;
            }
        }

        public override int CalculateSK()
        {
            switch(Ch1)
            {
                case "A": return 3;
                case "B":
                case "C": return 2;
                default: return 1;
            }
        }

        public override int CalculateBK()
        {
            if (Ch1.Equals("A")) return 4;
            return 3;
        }
    }

}
