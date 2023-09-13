namespace dcnsanplanung.bewertung.M149_3
{
    public abstract class AbstractCode
    {
        string beschreibung;
        protected string Ch1 = "";
        protected string Ch2 = "";
        protected float Q1;
        protected float Q2;
        protected int DN;

        public AbstractCode(string beschreibung, int DN = -1)
        {
            this.beschreibung = beschreibung;
        }

        public virtual int CalculateSK()
        {
            return 5;
        }

        public virtual int CalculateDK()
        {
            return 5;
        }
        public virtual int CalculateBK()
        {
            return 5;
        }

        public virtual void WriteCH1(string Ch1)
        {
            this.Ch1 = Ch1;
        }
        public virtual void WriteCH2(string Ch2)
        {
            this.Ch2 = Ch2;
        }
        public virtual void WriteQ1(float Q1)
        {
            this.Q1 = Q1;
        }

        public virtual void WriteQ2(float Q2)
        {
            this.Q2 = Q2;
        }
    }
}
