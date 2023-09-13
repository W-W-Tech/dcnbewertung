namespace dcnsanplanung.bewertung.M149_3
{
    public class BAJ : AbstractCode
    {
        public BAJ(int DN = -1) : base("Verschobene Verbindung", DN)
        {
        }

        public override int CalculateDK()
        {
            switch (Ch1)
            {
                case "A":
                    {
                        switch (DN)
                        {
                            case <= 400:
                                {
                                    switch (Q1)
                                    {
                                        case >= 70: return 0;
                                        case >= 50: return 1;
                                        case >= 30: return 2;
                                        case >= 20: return 3;
                                        default: return 4;
                                    }
                                }
                            case <= 800:
                                {
                                    switch (Q1)
                                    {
                                        case >= 80: return 0;
                                        case >= 60: return 1;
                                        case >= 40: return 2;
                                        case >= 20: return 3;
                                        default: return 4;
                                    }
                                }
                            default:
                                {
                                    switch (Q1)
                                    {
                                        case >= 90: return 0;
                                        case >= 65: return 1;
                                        case >= 40: return 2;
                                        case >= 20: return 3;
                                        default: return 4;
                                    }
                                }
                        }
                    }
                case "B":
                    {
                        switch (Q1)
                        {
                            case >= 30: return 0;
                            case >= 20: return 1;
                            case >= 15: return 2;
                            case >= 10: return 3;
                            default: return 4;
                        }
                    }
                default:
                    {
                        switch (DN)
                        {
                            case <= 200:
                                {
                                    switch (Q1)
                                    {
                                        case >= 12: return 0;
                                        case >= 9: return 1;
                                        case >= 7: return 2;
                                        case >= 5: return 3;
                                        default: return 4;
                                    }
                                }
                            case <= 500:
                                {
                                    switch (Q1)
                                    {
                                        case >= 6: return 0;
                                        case >= 4: return 1;
                                        case >= 3: return 2;
                                        case >= 2: return 3;
                                        default: return 4;
                                    }
                                }
                            default:
                                {
                                    switch (Q1)
                                    {
                                        case >= 6: return 0;
                                        case >= 4: return 1;
                                        case >= 3: return 2;
                                        case >= 1: return 3;
                                        default: return 4;
                                    }
                                }
                        }
                    }
            }
        }
        public override int CalculateSK()
        {
            return 4;
        }

        public override int CalculateBK()
        {
            if (Ch1.Equals("B")) return 7;
            return 5;
        }
    }


}
