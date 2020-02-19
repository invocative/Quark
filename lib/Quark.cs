namespace Elementary.Primitives
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using @internal;
    using Sprache;
    using UnitsNet;
    using UnitsNet.Units;
    using static @internal.Constants;
    using static QuarkType;

    [Serializable]
    public partial struct Quark : IComparable, IComparable<Quark>, IEquatable<Quark>
    {
        internal const char MinusSuffix = '\u0304';

        private readonly QuarkType _type;
        private readonly ElectricCharge _electricCharge;
        private readonly Spin _spin;
        private readonly Energy _entryMass;
        private readonly Mass _naturalMass;
        private readonly QuarkWeakType _weakType;
        private bool _isAntiQuark;

        private Quark(QuarkType type, ElectricCharge ec, Spin spin, Energy e, QuarkWeakType weakType, bool isAnti)
        {
            this._type = type;
            this._electricCharge = ec;
            this._spin = spin;
            this._entryMass = e;
            this._weakType = weakType;
            this._isAntiQuark = isAnti;
            this._naturalMass = new Mass((e.ElectronVolts * SpeedOfLightSquared) / ElectronMassPlank,
                MassUnit.Kilogram);
        }

        public string Name => StringLiteralMap.GetNameByType(_type);

        /// <summary>
        /// Quark Type
        /// </summary>
        public QuarkType Type => _type;
        /// <summary>
        /// Quark weak type
        /// </summary>
        public QuarkWeakType WeakType => _weakType;
        /// <summary>
        /// Quark Electric Charge
        /// </summary>
        public ElectricCharge ElectricCharge => _electricCharge;
        /// <summary>
        /// Quark Spin
        /// </summary>
        public Spin Spin => _spin;
        /// <summary>
        /// Quark State
        /// </summary>
        public bool IsAnti => _isAntiQuark;
        /// <summary>
        /// Quark Mass (pure, eV)
        /// </summary>
        public Energy EntryMass => _entryMass;
        /// <summary>
        /// Quark Mass (kg) = (eV * c^2) / 1.6*10^-16
        /// </summary>
        public Mass Mass => _naturalMass;
        /// <summary>
        /// Quark Symbol
        /// </summary>
        public string Symbol 
            => IsAnti ? $"{this._type}{MinusSuffix}" : $"{this._type}";

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
        public float GetStrengthsCorrelationAt(Quark quark)
        {
            ((QuarkType, QuarkType), float?)[,] correlation = {
                { ((u, d), 1.00f), ((u, s), 0.50f),  ((u, b), 0.25f)  },
                { ((c, d), 0.50f), ((c, s), 1.00f),  ((c, b), 0.25f)  },
                { ((t, d), 0.25f), ((t, s), 0.25f),  ((t, b), 1.00f)  },
            };
            return GetDecayDataByPair(quark, this, correlation);
        }

        #region private functions

        internal static float GetDecayDataByPair(Quark f1, Quark f2, ((QuarkType, QuarkType) pair, float? index)[,] data)
        {
            static IEnumerable<T> Flatten<T>(T[,] matrix) {
                foreach (var item in matrix) yield return item;
            }

            float? select(Func<((QuarkType, QuarkType) pair, float? index), bool> selector) =>
                Flatten(data).FirstOrDefault(selector).index;

            var result =
                select(z => z.pair == (f1._type, f2._type)) ??
                select(z => z.pair == (f2._type, f1._type));

            return result ?? 0.0f;
        }


        public static readonly Parser<List<Quark>> Token =
            from b1 in Parse.Char('[')
            from q in privateToken.DelimitedBy(Parse.Char('|'))
            from b2 in Parse.Char(']')
            select new List<Quark>(q);


        internal static readonly Parser<Quark> privateToken =
            from dig in Parse.Chars("+-").Optional()
            from sym in Parse.Chars("duscbt")
            select BySymbol(sym, dig.GetOrDefault() == '-');



        #region Equality members

        /// <inheritdoc />
        public override bool Equals(object obj) 
            => obj is Quark other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)_type;
                hashCode = (hashCode * 397) ^ _electricCharge.GetHashCode();
                hashCode = (hashCode * 397) ^ _spin.GetHashCode();
                hashCode = (hashCode * 397) ^ _entryMass.GetHashCode();
                hashCode = (hashCode * 397) ^ _naturalMass.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)_weakType;
                return hashCode;
            }
        }

        /// <inheritdoc />
        public int CompareTo(Quark other)
        {
            if (other._type > this._type)
                return 1;
            if (other._type < this._type)
                return -1;
            return 0;
        }

        /// <inheritdoc />
        public bool Equals(Quark other)
        {
            if (other == default)
                return false;
            if (this == default)
                return false;
            return this == other;
        }
        /// <inheritdoc />
        public int CompareTo(object other)
        {
            if (other is Quark q)
                return CompareTo(q);
            return 0;
        }

        #endregion


        public override string ToString() => $"{(IsAnti ? $"{_type}{MinusSuffix}" : $"{_type}")} {_electricCharge} {_entryMass}/c\u00B2";


        public static bool operator ==(Quark q1, Quark q2)
        {
            // handle 'quark == default'
            if (q1.Type == Unk || q2.Type == Unk)
                return false;
            return (q1.Type == q2.Type) && (q1.IsAnti == q2.IsAnti);
        }

        public static bool operator !=(Quark q1, Quark q2) => !(q1 == q2);

        #endregion
    }
}