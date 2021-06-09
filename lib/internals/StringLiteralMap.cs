namespace Elementary.Primitives.@internal
{
    using System.Collections.Generic;

    internal static class StringLiteralMap
    {
        private static readonly Dictionary<QuarkType, string> names;
        static StringLiteralMap()
        {
            names = new Dictionary<QuarkType, string>
            {
                {QuarkType.c, "Charm Quark"},
                {QuarkType.s, "Strange Quark"},
                {QuarkType.d, "Down Quark"},
                {QuarkType.u, "Up Quark"},
                {QuarkType.b, "Beauty Quark"},
                {QuarkType.t, "Top Quark"}
            };
        }

        internal static string GetNameByType(QuarkType type) => names[type];
    }
}