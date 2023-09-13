namespace dcnsanplanung.bewertung.M149_3
{
    public class BAB : AbstractCode
    {
        public BAB() : base("Rissbildung")
        {
        }

        public override int CalculateDK()
        {
            switch(Ch1)
            {
                case "B":
                case "C":
                    {
                        switch(Ch2)
                        {
                            case "A":
                            case "B":
                            case "C":
                            case "D":
                            case "E":
                                {
                                    switch(Q1)
                                    {
                                        case >= 3: return 1;
                                        case >= 2: return 2;
                                        default: return 3;
                                    }
                                }
                        }
                    }
                    break;
            }

            return 5;
        }

        public override int CalculateSK()
        {
            switch(Ch1)
            {
                case "A": return 4;
                case "B":
                case "C":
                    {
                        switch(Ch2)
                        {
                            case "A":
                                {
                                    switch(DN)
                                    {
                                        case <= 300:
                                            {
                                                switch (Q1)
                                                {
                                                    case >= 3: return 0;
                                                    case >= 2: return 1;
                                                    case >= 1: return 2;
                                                    case >= 0.5f: return 3;
                                                    default: return 5;
                                                }
                                            }
                                        case <= 500:
                                            {
                                                switch (Q1)
                                                {
                                                    case >= 5: return 0;
                                                    case >= 3: return 1;
                                                    case >= 2: return 2;
                                                    case >= 1: return 3;
                                                    default: return 4;
                                                }
                                            }
                                        case <= 700:
                                            {
                                                switch (Q1)
                                                {
                                                    case >= 8: return 0;
                                                    case >= 4: return 1;
                                                    case >= 3: return 2;
                                                    case >= 2: return 3;
                                                    default: return 4;
                                                }
                                            }
                                        default:
                                            {
                                                switch(Q1)
                                                {
                                                    case >= 8: return 0;
                                                    case >= 5: return 1;
                                                    case >= 3: return 2;
                                                    case >= 1: return 3;
                                                    default: return 4;
                                                }
                                            }

                                            
                                    }
                                }
                            case "B": return 4;
                            default: return 7;
                        }
                    }
                default: return 7;
            }
        }
    }
}
