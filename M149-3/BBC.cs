namespace dcnsanplanung.bewertung.M149_3
{
    public class BBC : AbstractCode
    {
        public BBC() : base("Ablagerungen")
        {
            
        }

        public override int CalculateBK()
        {
            switch(Ch1)
            {
                case "C":
                case "Z":
                    {
                        switch(Q1)
                        {
                            case >= 50: return 0;
                            case >= 40: return 1;
                            case >= 25: return 2;
                            case >= 10: return 3;
                            default: return 4;
                        }
                    }
                default: return 4;
            }
        }
    }

}
