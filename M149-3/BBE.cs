namespace dcnsanplanung.bewertung.M149_3
{
    public class BBE : AbstractCode
    {
        public BBE() : base("Andere Hindernisse")
        {
            
        }

        public override int CalculateDK()
        {
            if (Ch1.Equals("D") || Ch1.Equals("G")) return 2;
            return base.CalculateDK();
        }

        public override int CalculateBK()
        {
            switch (Ch1)
            {
                case "A":
                case "B":
                case "C":
                case "D":
                case "E":
                case "F":
                case "G":
                case "H":
                case "Z":
                    {
                        switch(Q1)
                        {
                            case >= 50: return 0;
                            case >= 35: return 1;
                            case >= 20: return 2;
                            case >= 5:  return 3;
                            default:    return 4;
                        }
                    }
            }
            return base.CalculateBK();
        }
    }

}
