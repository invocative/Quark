namespace Elementary.Primitives
{
    using System;
    using System.Runtime.InteropServices;
    using Sprache;

    [StructLayout(LayoutKind.Explicit, Pack = 1), Serializable]
    public struct ElectricCharge
    {
        public const char Unit = '\u212F';

        [FieldOffset(0)]
        public readonly bool IsPositive;
        [FieldOffset(1)]
        public readonly byte Denominator;
        [FieldOffset(2)]
        public readonly byte Numerator;

        public ElectricCharge(bool positive, byte numerator, byte denominator)
        {
            this.IsPositive = positive;
            this.Denominator = denominator;
            this.Numerator = numerator;
        }

        public static Parser<ElectricCharge> Token =
            from first in Parse.Char('+').Or(Parse.Char('-')) // plus '+' or minus '-'
            from _1 in Parse.Char('(')  // open brace
            from n1 in Parse.Number         
            from del in Parse.Char('/') // divider
            from n2 in Parse.Number
            from _2 in Parse.Char(')')  // closed brace
            from unit in Parse.Char(Unit).Optional()
            select new ElectricCharge(first.Equals('+'), byte.Parse(n1), byte.Parse(n2));


        public override string ToString() => $"{(IsPositive ? "+" : "-")}({Numerator}/{Denominator}){Unit}";


        #region Equality members

        public bool Equals(ElectricCharge other)
            => IsPositive == other.IsPositive && Denominator == other.Denominator && Numerator == other.Numerator;

        /// <inheritdoc />
        public override bool Equals(object obj)
            => obj is ElectricCharge other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = IsPositive.GetHashCode();
                hashCode = (hashCode * 397) ^ Denominator.GetHashCode();
                hashCode = (hashCode * 397) ^ Numerator.GetHashCode();
                return hashCode;
            }
        }

       
        public static bool operator ==(ElectricCharge e1, ElectricCharge e2)
        {
            // handle default eq
            if (e1.Denominator == 0 && e1.Numerator == 0 && !e1.IsPositive)
                return false;
            if (e2.Denominator == 0 && e2.Numerator == 0 && !e2.IsPositive)
                return false;

            return (e1.Denominator == e2.Denominator) && (e1.Numerator == e2.Numerator) &&
                   (e1.IsPositive == e2.IsPositive);
        }

        public static bool operator !=(ElectricCharge e1, ElectricCharge e2) => !(e1 == e2);

        public static implicit operator string(ElectricCharge e) => e.ToString();
        public static implicit operator ElectricCharge(string e) => Token.Parse(e);
        #endregion
    }
}
