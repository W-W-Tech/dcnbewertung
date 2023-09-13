namespace dcnsanplanung.bewertung.M149_3
{
    public class BDE : AbstractCode
    {
        public BDE() : base("Zufluss aus einem Anschluss")
        {
            
        }

        public override int CalculateBK()
        {
            switch(Ch2)
            {
                case "A": return 1;
                default: return 2;
            }
        }
    }

}
