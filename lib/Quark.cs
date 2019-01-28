namespace Elementary.Quarks
{
    using System.Collections.Generic;
    using eV.Measure;
    using Quarks;
    using Sprache;

    public class Quark
    {
        protected Quark(bool isAnti = false)
        {
            this.Mass = new Energy(0.0, Energy.ElectronVolt);
            this.Name = "Unknown";
            this.Type = QuarkType.Unk;
            this.EChange = "-(0/0)";
            this.Prefix = (!isAnti ? '+' : '-');
        }
        /// <summary>
        /// Quark Suffix
        /// </summary>
        protected char Prefix;


        public bool IsAnti() => Prefix == '-';

        /// <summary>
        /// Quark Name
        /// </summary>
        public string Name { get; protected set; }
        
        protected string InternalChar { get; set; }
        protected string InternalAntiChar { get; set; }

        /// <summary>
        /// Quark Symbol
        /// </summary>
        public string Symbol
        {
            get
            {
                if (IsAnti()) return InternalAntiChar;
                return InternalChar;
            }
        }


        /// <summary>
        /// Quark Type
        /// </summary>
        public QuarkType Type { get; protected set; }
        /// <summary>
        /// Electric Change
        /// </summary>
        public ElectricChange EChange { get; protected set; }
        /// <summary>
        /// Quark Mass
        /// </summary>
        public Energy Mass { get; protected set; }

        public override string ToString() => $"{Symbol} {EChange} {Mass[Energy.MegaElectronVolt]}";



        private static Quark QuarkBySymbol(char c, bool isAnti)
        {
            switch (c)
            {
                case 'd': return new DownQuark(isAnti);
                case 'u': return new UpQuark(isAnti);
                case 's': return new StrangeQuark(isAnti);
                case 'c': return new CharmQuark(isAnti);
                case 'b': return new BottomQuark(isAnti);
                case 't': return new TopQuark(isAnti);
            }
            return new Quark();
        }

        public static readonly Parser<List<Quark>> Token =
            from b1 in Parse.Char('[')
            from q in privateToken.DelimitedBy(Parse.Char('|'))
            from b2 in Parse.Char(']')
            select new List<Quark>(q);


        private static readonly Parser<Quark> privateToken =
            from dig in Parse.Chars("+-").Optional()
            from sym in Parse.Chars("duscbt")
            select QuarkBySymbol(sym, dig.GetOrDefault() == '-');
    }
}