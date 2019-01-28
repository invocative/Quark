namespace QuarkParser
{
    using System.Collections.Generic;
    using eV.Measure;
    using Quarks;
    using Sprache;

    public class Quark
    {
        protected Quark()
        {
            this.Mass = new Energy(0.0, Energy.ElectronVolt);
            this.Symbol = '-';
            this.Name = "Unknown";
            this.Type = QuarkType.Unk;
            EChange = "-(0/0)";
        }
        /// <summary>
        /// Quark Name
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// Quark Symbol
        /// </summary>
        public char Symbol { get; protected set; }
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



        private static Quark QuarkBySymbol(char c)
        {
            switch (c)
            {
                case 'd': return new DownQuark();
                case 'u': return new UpQuark();
                case 's': return new StrangeQuark();
                case 'c': return new CharmQuark();
                case 'b': return new BottomQuark();
                case 't': return new TopQuark();
            }
            return new Quark();
        }

        public static readonly Parser<List<Quark>> Token =
            from b1 in Parse.Char('[')
            from q in privateToken.DelimitedBy(Parse.Char('|'))
            from b2 in Parse.Char(']')
            select new List<Quark>(q);


        private static readonly Parser<Quark> privateToken =
            from sym in Parse.Chars("duscbt")
            from dig in Parse.Chars("+-").Optional()
            select QuarkBySymbol(sym);
    }
}