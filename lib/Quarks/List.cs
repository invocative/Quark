namespace Elementary.Primitives
{
    using UnitsNet;
    using UnitsNet.Units;
    using static QuarkType;
    public partial struct Quark
    {
        public static readonly Quark Up =
            new Quark(u,
                "+(2/3)",
                "(1/2)",
                new Energy(2.3, EnergyUnit.MegaelectronVolt),
                QuarkWeakType.Up,
                false);
        public static readonly Quark AntiUp =
            new Quark(u,
                "-(2/3)",
                "(1/2)",
                new Energy(2.3, EnergyUnit.MegaelectronVolt),
                QuarkWeakType.Up,
                true);
        public static readonly Quark Down =
            new Quark(d,
                "-(1/3)",
                "(1/2)",
                new Energy(4.8, EnergyUnit.MegaelectronVolt),
                QuarkWeakType.Down,
                false);
        public static readonly Quark AntiDown =
            new Quark(d,
                "+(1/3)",
                "(1/2)",
                new Energy(4.8, EnergyUnit.MegaelectronVolt),
                QuarkWeakType.Down,
                true);
        public static readonly Quark Strange =
            new Quark(s,
                "-(1/3)",
                "(1/2)",
                new Energy(95, EnergyUnit.MegaelectronVolt),
                QuarkWeakType.Down,
                false);
        public static readonly Quark AntiStrange =
            new Quark(s,
                "+(1/3)",
                "(1/2)",
                new Energy(95, EnergyUnit.MegaelectronVolt),
                QuarkWeakType.Down,
                true);

        public static readonly Quark Charm =
            new Quark(c,
                "+(2/3)",
                "(1/2)",
                new Energy(1275, EnergyUnit.MegaelectronVolt),
                QuarkWeakType.Up,
                false);
        public static readonly Quark AntiCharm =
            new Quark(c,
                "-(2/3)",
                "(1/2)",
                new Energy(1275, EnergyUnit.MegaelectronVolt),
                QuarkWeakType.Up,
                true);

        public static readonly Quark Bottom =
            new Quark(b,
                "-(1/3)",
                "(1/2)",
                new Energy(4180, EnergyUnit.MegaelectronVolt),
                QuarkWeakType.Down,
                false);
        public static readonly Quark AntiBottom =
            new Quark(b,
                "+(1/3)",
                "(1/2)",
                new Energy(4180, EnergyUnit.MegaelectronVolt),
                QuarkWeakType.Down,
                true);

        public static readonly Quark Top =
            new Quark(t,
                "+(2/3)",
                "(1/2)",
                new Energy(173210, EnergyUnit.MegaelectronVolt),
                QuarkWeakType.Up,
                false);
        public static readonly Quark AntiTop =
            new Quark(t,
                "-(2/3)",
                "(1/2)",
                new Energy(173210, EnergyUnit.MegaelectronVolt),
                QuarkWeakType.Up,
                true);


        public static Quark BySymbol(char ch, bool isAnti = false)
        {
            return (ch, isAnti) switch
            {
                ('t', false) => Top,
                ('t', true) => AntiTop,

                ('b', false) => Bottom,
                ('b', true) => AntiBottom,

                ('c', false) => Charm,
                ('c', true) => AntiCharm,

                ('s', false) => Strange,
                ('s', true) => AntiStrange,

                ('d', false) => Down,
                ('d', true) => AntiDown,

                ('u', false) => Up,
                ('u', true) => AntiUp,

                _ => default
            };
        }
    }
}
