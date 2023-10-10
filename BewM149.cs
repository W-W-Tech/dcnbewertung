using dcnsanplanung.bewertung.M149_3;
using dcnsanplanung.shared.Model;
using Syncfusion.XlsIO;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace dcnsanplanung.bewertung
{
    public static class BewM149
    {
        private static int counter = 0;
        public static Dictionary<int, int> StartWert = new Dictionary<int, int>()
        {
            {0,400 },
            {1,300 },
            {2,200 },
            {3,100 },
            {4,0 },
            {5,0 }
        };

        public static decimal SXj(int sk,decimal length)
        {
            return (5 - sk) * length;
        }

        public static Dictionary<string, int> ObjektKlasse(List<Schaden> schaeden)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            result.Add("B", schaeden.Select(x => x.KB).Min());
            result.Add("D", schaeden.Select(x => x.KD).Min());
            result.Add("S", schaeden.Select(x => x.KS).Min());

            return result;
        }

        public static void CalculateHaltung(List<Haltung> haltung)
        {
            //MjcwMjkwMEAzMjMzMmUzMDJlMzBZSE9jRFVFZlYyNXhBMFE2Y2pkd0pReVJHcmtlaFlVaUh1aTBlWW80WVZNPQ==
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjcwMjkwMEAzMjMzMmUzMDJlMzBZSE9jRFVFZlYyNXhBMFE2Y2pkd0pReVJHcmtlaFlVaUh1aTBlWW80WVZNPQ==");
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;

            application.DefaultVersion = ExcelVersion.Xlsx;
            IWorkbook workbook = application.Workbooks.Create(haltung.Count);
            for(int i = 0; i < haltung.Count; i++)
            {
                IWorksheet worksheet = workbook.Worksheets[i];
                Haltung halt = haltung[i];
                CalculateHaltung(halt, worksheet);

            }

            FileStream stream = new FileStream("beurteilung.xlsx", FileMode.Create, FileAccess.ReadWrite);
            workbook.SaveAs(stream);
            stream.Dispose();

        }

        private static void CalculateHaltung(Haltung haltung, IWorksheet worksheet)
        {
            BewM149.counter++;
            var k = ObjektKlasse(haltung.Kodierungen);
            List<Schaden> streckenSchaeden = new List<Schaden>();

            worksheet.Name = string.Format("{0} ({1})", haltung.Objektbezeichnung, BewM149.counter);

            worksheet.Range[1, 1].Text = "Haltung";
            worksheet.Range[1, 3].Text = haltung.Objektbezeichnung;
            worksheet.Range[2, 1].Text = "Durchmesser";
            worksheet.Range[2, 3].Text = haltung.DN.ToString();
            worksheet.Range[3, 1].Text = "Material";
            worksheet.Range[3, 3].Text = haltung.Material;
            

            int i = 7;
            worksheet.Range[i, 1].Text = "Entfernung";
            worksheet.Range[i, 2].Text = "Streckenschaden";
            worksheet.Range[i, 3].Text = "Hauptcode";
            worksheet.Range[i, 4].Text = "CH1";
            worksheet.Range[i, 5].Text = "CH2";
            worksheet.Range[i, 6].Text = "Q1";
            worksheet.Range[i, 7].Text = "Q2";
            worksheet.Range[i, 8].Text = "SK D";
            worksheet.Range[i, 9].Text = "SK S";
            worksheet.Range[i, 10].Text = "SK B";
            worksheet.Range[i, 11].Text = "D";
            worksheet.Range[i, 12].Text = "S";
            worksheet.Range[i, 13].Text = "B";

            foreach (var schaden in haltung.Kodierungen)
            {
                i++;
                decimal entfernung = 2.5m;
                bool streckenschaden = false;
                if(schaden.IsStreckenSchaden)
                {
                    if (schaden.StreckenschadenCode.Substring(0, 1).Equals("A"))
                    {
                        streckenSchaeden.Add(schaden);
                        streckenschaden = true;
                    }
                    else
                    {
                        //Code
                        string code = schaden.StreckenschadenCode.Substring(1);
                        var schaeden = streckenSchaeden.Where(x => x.StreckenschadenCode.Contains(code)).Last();
                        entfernung = schaden.Entfernung - schaeden.Entfernung;        
                    }
                }

                if (!streckenschaden)
                {
                    if (entfernung < 2.5m) entfernung = 2.5m;
                }
                else
                {
                    entfernung = 0m;
                }
                schaden.KBj = SXj(schaden.KB, entfernung);
                schaden.KDj = SXj(schaden.KD, entfernung);
                schaden.KSj = SXj(schaden.KS, entfernung);
                    
                worksheet.Range[i, 1].Text = schaden.Entfernung.ToString();
                worksheet.Range[i, 2].Text = schaden.StreckenschadenCode;
                worksheet.Range[i, 3].Text = schaden.Hauptcode;
                worksheet.Range[i, 4].Text = schaden.CH1;
                worksheet.Range[i, 5].Text = schaden.CH2;
                worksheet.Range[i, 6].Text = schaden.Q1;
                worksheet.Range[i, 7].Text = schaden.Q2;
                worksheet.Range[i, 8].Number = schaden.KD;
                worksheet.Range[i, 9].Number = schaden.KS;
                worksheet.Range[i, 10].Number = schaden.KB;
                worksheet.Range[i, 11].Text = schaden.KDj.ToString();
                worksheet.Range[i, 12].Text = schaden.KSj.ToString();
                worksheet.Range[i, 13].Text = schaden.KBj.ToString();
            }

            
            
            decimal Haltungslaenge = haltung.Kodierungen.Select(x => x.Entfernung).Max();

            decimal KBSumme = haltung.Kodierungen.Select(x => x.KBj).Sum();
            decimal KSSumme = haltung.Kodierungen.Select(x => x.KSj).Sum();
            decimal KDSumme = haltung.Kodierungen.Select(x => x.KDj).Sum();

            i++;
            worksheet.Range[i, 6].Text = "Summe";
            worksheet.Range[i, 11].Text = KDSumme.ToString();
            worksheet.Range[i, 12].Text = KSSumme.ToString();
            worksheet.Range[i, 13].Text = KBSumme.ToString();

            i++;
            worksheet.Range[i, 6].Text = "Objektklasse";
            worksheet.Range[i, 8].Text = k["D"].ToString();
            worksheet.Range[i, 9].Text = k["S"].ToString();
            worksheet.Range[i, 10].Text = k["B"].ToString();

            decimal ObjektDSumme = SXj(k["D"],Haltungslaenge);
            decimal ObjektSSumme = SXj(k["S"],Haltungslaenge);
            decimal ObjektBSumme = SXj(k["B"],Haltungslaenge);

            decimal SchadensDichteB = 0m;
            decimal SchadensDichteD = 0m;
            decimal SchadensDichteS = 0m;

            decimal zuschlagD = 0m;
            decimal zuschlagS = 0m;
            decimal zuschlagB = 0m;

            if (ObjektBSumme > 0)
                SchadensDichteB = Decimal.Round(KBSumme / ObjektBSumme, 2);
            if (ObjektDSumme > 0)
                SchadensDichteD = Decimal.Round(KDSumme / ObjektDSumme,2);
            if (ObjektSSumme > 0)
                SchadensDichteS = Decimal.Round(KSSumme / ObjektSSumme,2);


            if (ObjektDSumme > 0)
                zuschlagD = 50 * SchadensDichteD;
            if (ObjektDSumme > 0)
                zuschlagS = 50 * SchadensDichteS;
            if (ObjektBSumme > 0)
                zuschlagB = 50 * SchadensDichteB;
            i++;
            worksheet.Range[i, 6].Text = "Zuschlag";
            worksheet.Range[i, 11].Text = String.Format("{0:0.}",zuschlagD);
            worksheet.Range[i, 12].Text = String.Format("{0:0.}",zuschlagS);
            worksheet.Range[i, 13].Text = String.Format("{0:0.}",zuschlagB);

            int startWertD = StartWert[k["D"]];
            int startWertB = StartWert[k["B"]];
            int startWertS = StartWert[k["S"]];
            i++;
            worksheet.Range[i, 6].Text = "Startwert";
            worksheet.Range[i, 11].Number = startWertD;
            worksheet.Range[i, 12].Number = startWertS;
            worksheet.Range[i, 13].Number = startWertB;

            int ZustandPunkteD = startWertD + (int)zuschlagD;
            int ZustandPunkteB = startWertB + (int)zuschlagB;
            int ZustandPunkteS = startWertS + (int)zuschlagS;
            i++;
            worksheet.Range[i, 11].Number = ZustandPunkteD;
            worksheet.Range[i, 12].Number = ZustandPunkteS;
            worksheet.Range[i, 13].Number = ZustandPunkteB;


            int BewertungspunkteD = 0;
            int BewertungspunkteS = 0;
            int BewertungspunkteB = 0;
            if(ZustandPunkteD > 0)
                BewertungspunkteD = ZustandPunkteD + 500 + RD(EBaujahr.VOR1965, EEinstau.NICHTEINGEHALTEN, ELageGrundWasser.IM);
            if(ZustandPunkteS > 0)
                BewertungspunkteS = ZustandPunkteS + 500 + RS(EUeberdeckung.KLEINER25, EBodenGruppe.BG4);
            if(ZustandPunkteB >0)
                BewertungspunkteB = ZustandPunkteB + 500 + RB(EEinstau.NICHTEINGEHALTEN, EUeberdeckung.KLEINER25);
            i++;
            worksheet.Range[i, 11].Number = BewertungspunkteD;
            worksheet.Range[i, 12].Number = BewertungspunkteS;
            worksheet.Range[i, 13].Number = BewertungspunkteB;


            // Sanierungsbedarfzahl errechnen
            List<int> ints = new List<int>();
            ints.Add(BewertungspunkteB);
            ints.Add(BewertungspunkteS);
            ints.Add(BewertungspunkteD);

            int bp1 = ints.Max();
            int bp3 = ints.Min();
            int bp2 = ints.Sum() - bp1 - bp3;

            int restbp1 = 0;
            int restbp2 = 0;
            int restbp3 = 0;
            if(bp1 > 0) restbp1 = Convert.ToInt32(bp1.ToString().Substring(1));
            if(bp2 > 0) restbp2 = Convert.ToInt32(bp2.ToString().Substring(1));
            if(bp3 > 0) restbp3 = Convert.ToInt32(bp3.ToString().Substring(1));

            int rest = (restbp1 + restbp2 + restbp3) / 30;

            string sanierungszahl = string.Format("{0}{1}{2}{3}",(int)(bp1 / 100),(int)(bp2 /100),(int)(bp3 / 100),rest);

            int sanzahl = Convert.ToInt32(sanierungszahl);

            
            worksheet.Range[1, 5].Number = sanzahl;

            var mk = Beurteilung(sanzahl);
            
            worksheet.Range[2, 5].Text = mk.Item1;
            
            worksheet.Range[3, 5].Text = mk.Item2;
        }

        public static Tuple<string,string> Beurteilung(int sanierungsbedarfzahl)
        {
            switch(sanierungsbedarfzahl)
            {
                case >= 9000: return new Tuple<string, string>("sofort", "sehr starker Mangel / Gefahr im Verzuge");
                case >= 8000: return new Tuple<string, string>("kurzfristig", "starker Mangel");
                case >= 7000: return new Tuple<string, string>("mittelfristig", "mittlere Mangel");
                case >= 6000: return new Tuple<string, string>("langfristig", "leichter Mangel");
                case >= 5000: return new Tuple<string, string>("keiner (geringfügige Schäden", "geringfügiger Mangel");
                default: return new Tuple<string, string>("schadensfrei", "kein Mangel");
            }
        }

        public enum EBaujahr
        {
            VOR1965,
            NACH1965
        }
        public enum EEinstau
        {
            EINGEHALTEN,
            NICHTEINGEHALTEN
        }
        public enum ELageGrundWasser
        {
            IM,
            AUSSER, 
            WECHSEL
        }
        public enum EUeberdeckung
        {
            KLEINER25,
            ZWISCHEN25UND4,
            GROESSER4

        }
        public enum EBodenGruppe
        {
            BG1,
            BG2,
            BG3,
            BG4
        }
        public static int RD(EBaujahr eBaujahr, EEinstau eEinstau, ELageGrundWasser eLageGrundWasser)
        {
            int ver1 = eBaujahr == EBaujahr.VOR1965 ? 1 : 0;
            int ver2 = eEinstau == EEinstau.EINGEHALTEN ? 0 : 1;
            decimal ver3 = eLageGrundWasser == ELageGrundWasser.IM ? 1 : eLageGrundWasser == ELageGrundWasser.WECHSEL ? 0.5m : 0;
            decimal summe = ((ver1+ver2+ver3) / 3) * 50;
            return (int)Math.Ceiling(summe);
        }
        public static int RB(EEinstau eEinstau, EUeberdeckung eUeberdeckung)
        {
            int ver1 = eEinstau == EEinstau.EINGEHALTEN ? 0 : 1;
            decimal ver2 = eUeberdeckung == EUeberdeckung.KLEINER25 ? 1 : eUeberdeckung == EUeberdeckung.ZWISCHEN25UND4 ? 0.5m : 0;
            decimal summe = ((ver1+ ver2) / 2)*50;
            return (int)Math.Ceiling(summe);
        }

       
        public static int RS(EUeberdeckung eUeberdeckung, EBodenGruppe eBodenGruppe)
        {
            decimal ver1 = eUeberdeckung == EUeberdeckung.KLEINER25 ? 1 : eUeberdeckung == EUeberdeckung.ZWISCHEN25UND4 ? 0.5m : 0;
            decimal ver2 = eBodenGruppe == EBodenGruppe.BG1 ? 0 : eBodenGruppe == EBodenGruppe.BG2 ? 0 : eBodenGruppe == EBodenGruppe.BG3 ? 0.5m : 1;
            decimal summe = ((ver1 + ver2) / 2) * 50;
            return (int)Math.Ceiling(summe);
        }
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

            if (abstractCode == null)
            {
                result.Add("D", 5);
                result.Add("B", 5);
                result.Add("S", 5);
                return result;
            }

            abstractCode.WriteCH1(ch1);
            abstractCode.WriteCH2(ch2);
            float _q1 = 0;
            if (!q1.Equals(string.Empty))
                _q1 = float.Parse(q1);
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