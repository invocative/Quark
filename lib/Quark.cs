namespace QuarkParser
{
    using Sprache;

    public class Quark
    {
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
        public float Mass { get; protected set; }



        //public static Parser<Quark>
    }
}