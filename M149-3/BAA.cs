using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace dcnsanplanung.bewertung.M149_3
{
    public class BAA : AbstractCode
    {
        EGeltungsbereich geltungsbereich;
        public BAA(EGeltungsbereich geltungsbereich) : base("Verformung")
        {
            this.geltungsbereich = geltungsbereich;
        }

        public override int CalculateSK()
        {
            switch(geltungsbereich)
            {
                case EGeltungsbereich.biegesteif:
                    {
                        switch (Q1)
                        {
                            case >= 7: return 0;
                            case >= 4: return 1;
                            case >= 3: return 2;
                            case >= 1: return 3;
                            default: return 4;
                        }
                    }
                case EGeltungsbereich.biegeweich:
                    {
                        switch (Q1)
                        {
                            case >= 15: return 0;
                            case >= 10: return 1;
                            case >= 6: return 2;
                            case >= 2: return 3;
                            default: return 4;
                        }
                    }

                default: return 6;
            }
        }
        public override int CalculateBK()
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
    }
}
