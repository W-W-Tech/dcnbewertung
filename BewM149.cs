using dcnsanplanung.bewertung.M149_3;
using System.Diagnostics;

namespace dcnsanplanung.bewertung
{
    public static class BewM149
    {
        
        // input Kürzel
        public static Dictionary<string, int> Klassifiziere(string hauptcode, string ch1, string ch2, string q1, string q2, int dn)
        {
            AbstractCode? abstractCode = null;

            Dictionary<string,int> result = new Dictionary<string,int>();

            switch(hauptcode)
            {
                case "BAA": abstractCode = new BAA(EGeltungsbereich.biegesteif); break;
                case "BAB": abstractCode = new BAB(); break;
                case "BAC": abstractCode = new BAC(); break;
                case "BAD": abstractCode = new BAD(); break;
                case "BAE": abstractCode = new BAE(); break;
                case "BAF": abstractCode = new BAF(); break;
                case "BAG": abstractCode = new BAG(dn); break;
                case "BAH": abstractCode = new BAH(); break;
                case "BAI": abstractCode = new BAI(); break;
                case "BAJ": abstractCode = new BAJ(); break;
                case "BAK": abstractCode = new BAK(); break;
                case "BAL": abstractCode = new BAL(); break;
                case "BAM": abstractCode = new BAM(); break;
                case "BAN": abstractCode = new BAN(); break;
                case "BAO": abstractCode = new BAO(); break;
                case "BAP": abstractCode = new BAP(); break;
                case "BBA": abstractCode = new BBA(); break;
                case "BBB": abstractCode = new BBB(); break;
                case "BBC": abstractCode = new BBC(); break;
                case "BBD": abstractCode = new BBD(); break;
                case "BBE": abstractCode = new BBE(); break;
                case "BBF": abstractCode = new BBF(); break;
                case "BBG": abstractCode = new BBG(); break;
                case "BBH": abstractCode = new BBH(); break;
                case "BDB": abstractCode = new BDB(); break;
                case "BDE": abstractCode = new BDE(); break;
            }

            if (abstractCode == null) return result;

            abstractCode.WriteCH1(ch1);
            abstractCode.WriteCH2(ch2);
            float _q1 = float.Parse(q1);
            //float _q2 = float.Parse(q2);
            abstractCode.WriteQ1(_q1);
            //abstractCode.WriteQ2(_q2);

            result.Add("D", abstractCode.CalculateDK());
            result.Add("B", abstractCode.CalculateBK());
            result.Add("S", abstractCode.CalculateSK());

            return result;
        }
    }
}