namespace Elementary.Quarks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using eV.Measure;
    using Quarks;
    using Sprache;
    using static QuarkType;

    public class Quark
    {
        protected Quark(bool isAnti = false)
        {
            this.Mass = new Energy(0.0, Energy.ElectronVolt);
            this.Name = "Unknown";
            this.Type = Unk;
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

        protected QuarkWeakType weakType { get; set; }

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

        /// <summary>
        /// While the process of flavor transformation is the same for all quarks,
        /// each quark has a preference to transform into the quark of its own generation.
        /// </summary>
        /// <returns>
        /// approximate magnitudes
        /// </returns>
        public float GetFlavorTransformationIndexAt(Quark quark)
        {
            ((QuarkType, QuarkType), float?)[,] flavor = {
                { ((u, d), 0.974f), ((u, s), 0.225f),  ((u, b), 0.003f)  },
                { ((c, d), 0.225f), ((c, s), 0.973f),  ((c, b), 0.041f)  },
                { ((t, d), 0.009f), ((t, s), 0.040f),  ((t, b), 0.999f)  },
            };
            return GetDecayDataByPair(quark, this, flavor);
        }
        /// <summary>
        /// While the process of flavor transformation is the same for all quarks,
        /// each quark has a preference to transform into the quark of its own generation.
        /// </summary>
        /// <returns>
        /// approximate magnitudes correlation
        /// </returns>
        public float GetStrengthsСorrelationAt(Quark quark)
        {
            ((QuarkType, QuarkType), float?)[,] сorrelation = {
                { ((u, d), 1.00f), ((u, s), 0.50f),  ((u, b), 0.25f)  },
                { ((c, d), 0.50f), ((c, s), 1.00f),  ((c, b), 0.25f)  },
                { ((t, d), 0.25f), ((t, s), 0.25f),  ((t, b), 1.00f)  },
            };
            return GetDecayDataByPair(quark, this, сorrelation);
        }


        public override string ToString() => $"{Symbol} {EChange} {Mass[Energy.MegaElectronVolt]}";



        private static Quark QuarkBySymbol(char c, bool isAnti) => (c) switch {
            'd' => new DownQuark(isAnti),
            'u' => new UpQuark(isAnti),
            's' => new StrangeQuark(isAnti),
            'c' => new CharmQuark(isAnti),
            'b' => new BottomQuark(isAnti),
            't' => new TopQuark(isAnti),
            _   => new Quark()
        };


        public static readonly Parser<List<Quark>> Token =
            from b1 in Parse.Char('[')
            from q in privateToken.DelimitedBy(Parse.Char('|'))
            from b2 in Parse.Char(']')
            select new List<Quark>(q);


        internal static readonly Parser<Quark> privateToken =
            from dig in Parse.Chars("+-").Optional()
            from sym in Parse.Chars("duscbt")
            select QuarkBySymbol(sym, dig.GetOrDefault() == '-');

        internal static float GetDecayDataByPair(Quark f1, Quark f2, ((QuarkType, QuarkType) pair, float? index)[,] data)
        {
            static IEnumerable<T> Flatten<T>(T[,] matrix) {
                foreach (var item in matrix) yield return item;
            }

            float? select(Func<((QuarkType, QuarkType) pair, float? index), bool> selector) =>
                Flatten(data).FirstOrDefault(selector).index;

            var result =
                select(z => z.pair == (f1.Type, f2.Type)) ??
                select(z => z.pair == (f2.Type, f1.Type));

            return result ?? 0.0f;
        }
    }
}