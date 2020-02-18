namespace Elementary.Quarks
{
    using System;
    using UnitsNet;

    public struct UnsafeQuark : 
        IComparable, IComparable<UnsafeQuark>, IComparable<Quark>, 
        IEquatable<UnsafeQuark>, IEquatable<Quark>,
        IFormattable
    {
        public QuarkType Type { get; }
        public QuarkWeakType WeakType { get; }
        public Mass Mass { get; }
        public char Prefix { get; }

        public UnsafeQuark(QuarkType type, bool isAnti, Mass mass, QuarkWeakType weakType)
        {
            Type = type;
            Mass = mass;
            WeakType = weakType;
            Prefix = isAnti ? '-' : ' ';
        }

        public bool IsAnti => Prefix == '-';

        public int CompareTo(object obj)
        {
            if (obj is UnsafeQuark u)
                return CompareTo(u);
            if (obj is Quark q)
                return CompareTo(q);
            return 0;
        }

        public int CompareTo(UnsafeQuark other)
        {
            if (other.Type > this.Type)
                return 1;
            if (other.Type < this.Type)
                return -1;
            return 0;
        }

        public int CompareTo(Quark other)
        {
            if (other.Type > this.Type)
                return 1;
            if (other.Type < this.Type)
                return -1;
            return 0;
        }

        public bool Equals(UnsafeQuark other)
        {
            if (other == default(UnsafeQuark))
                return false;
            return this == other;
        }

        public bool Equals(Quark other)
        {
            if (other is null)
                return false;
            if (other.Type == QuarkType.Unk)
                return false;
            return this == other;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return format switch
            {
                ("f") => $"{ToString()} {Mass} {(WeakType == QuarkWeakType.Up ? "\u21c8" : "\u21ca")}",
                ("d") => ToString(),
                _ => ToString()
            };
        }

        public override bool Equals(object obj) => obj is UnsafeQuark other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)Type;
                hashCode = (hashCode * 397) ^ (int)WeakType;
                hashCode = (hashCode * 397) ^ Mass.GetHashCode();
                hashCode = (hashCode * 397) ^ Prefix.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString() 
            => Prefix == '-' ? $"{Prefix}{Type}" : $"{Type}";

        public static bool operator ==(UnsafeQuark u1, Quark u2)
            => (u1.Type == u2?.Type) && (u1.IsAnti == u2?.IsAnti());
        public static bool operator !=(UnsafeQuark u1, Quark u2)
            => !(u1 == u2);
        public static bool operator ==(UnsafeQuark u1, UnsafeQuark u2) 
            => (u1.Type == u2.Type) && (u1.IsAnti == u2.IsAnti);
        public static bool operator !=(UnsafeQuark u1, UnsafeQuark u2) 
            => !(u1 == u2);
    }
}