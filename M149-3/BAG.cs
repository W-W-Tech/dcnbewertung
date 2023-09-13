namespace dcnsanplanung.bewertung.M149_3
{
    public class BAG : AbstractCode
    {
        public BAG(int DN) : base("Einragender Anschluss", DN)
        {
            this.DN = DN;
        }

        public override int CalculateBK()
        {
            switch(DN)
            {
                case <= 250:
                    {
                        switch(Q1)
                        {
                            case >= 50: return 0;
                            case >= 30: return 1;
                            case >= 20: return 2;
                            case >= 10: return 3;
                            default: return 4;
                        }
                    }
                case <= 500:
                    {
                        switch(Q1)
                        {
                            case >= 80: return 0;
                            case >= 60: return 1;
                            case >= 40: return 2;
                            case >= 10: return 3;
                            default: return 4;
                        }
                    }
                case <= 800:
                    {
                        switch(Q1)
                        {
                            case >= 70: return 2;
                            case <= 10: return 3;
                            default: return 4;
                        }
                    }
                default:
                    {
                        switch(Q1)
                        {
                            case >= 30: return 3;
                            default: return 4;
                        }
                    }
            }
        }
    }
}
