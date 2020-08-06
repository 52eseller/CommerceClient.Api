using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;

namespace CommerceClient.Api.Model.Types
{
    /// <summary>
    /// Key identifying a single Country
    /// </summary>
    [Serializable]
    [ProtoContract]
    public struct CountryKey : IComparable<CountryKey>, IConvertible, ISerializable, IEquatable<CountryKey>
    {
        public CountryKey(int countryID) => _CountryID = countryID;

        private CountryKey([NotNull] SerializationInfo info, StreamingContext text)
            : this()
            => _CountryID = info.GetInt32("i");

        public void GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(
            "i",
            _CountryID
        );

        private static int BuildHashCode(int countryID)
        {
            unchecked // Overflow is fine, just wrap
            {
                var hash = 17;
                hash = hash * 23 + countryID.GetHashCode();
                return hash;
            }
        }

        [ProtoMember(1)] private readonly int _CountryID;

        public int CountryID => _CountryID;

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public string BuildCacheKey() => string.Format(
            "Country:{0}",
            _CountryID
        );

        /// <summary>
        /// <inheritdoc />
        /// </summary>

        public override bool Equals(object obj) => obj is CountryKey && this == (CountryKey)obj;
        public override int GetHashCode() => BuildHashCode(_CountryID);


        public static bool operator ==(CountryKey x, CountryKey y) => x.CountryID == y.CountryID;

        public static bool operator !=(CountryKey x, CountryKey y) => !(x == y);

        public static bool operator <(CountryKey x, CountryKey y) => (x.CountryID < y.CountryID);

        public static bool operator <=(CountryKey x, CountryKey y) => (x.CountryID <= y.CountryID);

        public static bool operator >(CountryKey x, CountryKey y) => (x.CountryID > y.CountryID);

        public static bool operator >=(CountryKey x, CountryKey y) => (x.CountryID >= y.CountryID);

        public static implicit operator int(CountryKey countryKey) => countryKey.CountryID;

        public static implicit operator CountryKey(int countryKey) => new CountryKey(countryKey);

        public static implicit operator long(CountryKey countryKey) => countryKey.CountryID;

        public static explicit operator CountryKey(long countryKey)
        {
            if (countryKey > int.MaxValue || countryKey < int.MinValue)
            {
                throw new InvalidCastException(
                    string.Format(
                        "CountryKey {0} is outside of integer range.",
                        countryKey
                    )
                );
            }

            return new CountryKey((int)countryKey);
        }

        public int CompareTo(CountryKey other) => this == other ? 0 : (this > other ? 1 : -1);

        public override string ToString() => string.Format(
            "[{0}]",
            CountryID
        );

        /// <inheritdoc />
        TypeCode IConvertible.GetTypeCode() => TypeCode.Int32;

        /// <inheritdoc />
        bool IConvertible.ToBoolean(IFormatProvider provider)
            => throw new InvalidOperationException($"Cannot convert {GetType().Name} to bool.");

        /// <inheritdoc />
        char IConvertible.ToChar(IFormatProvider provider)
            => throw new InvalidOperationException($"Cannot convert {GetType().Name} to char.");

        /// <inheritdoc />
        sbyte IConvertible.ToSByte(IFormatProvider provider)
            => throw new InvalidOperationException($"Cannot convert {GetType().Name} to sbyte.");

        /// <inheritdoc />
        byte IConvertible.ToByte(IFormatProvider provider)
            => throw new InvalidOperationException($"Cannot convert {GetType().Name} to byte.");

        /// <inheritdoc />
        short IConvertible.ToInt16(IFormatProvider provider)
            => throw new InvalidOperationException($"Cannot convert {GetType().Name} to short.");

        /// <inheritdoc />
        ushort IConvertible.ToUInt16(IFormatProvider provider)
            => throw new InvalidOperationException($"Cannot convert {GetType().Name} to ushort.");

        /// <inheritdoc />
        int IConvertible.ToInt32(IFormatProvider provider) => CountryID;

        /// <inheritdoc />
        uint IConvertible.ToUInt32(IFormatProvider provider)
            => throw new InvalidOperationException($"Cannot convert {GetType().Name} to uint.");

        /// <inheritdoc />
        long IConvertible.ToInt64(IFormatProvider provider) => CountryID;

        /// <inheritdoc />
        ulong IConvertible.ToUInt64(IFormatProvider provider)
            => throw new InvalidOperationException($"Cannot convert {GetType().Name} to ulong.");

        /// <inheritdoc />
        float IConvertible.ToSingle(IFormatProvider provider)
            => throw new InvalidOperationException($"Cannot convert {GetType().Name} to single.");

        /// <inheritdoc />
        double IConvertible.ToDouble(IFormatProvider provider)
            => throw new InvalidOperationException($"Cannot convert {GetType().Name} to double.");

        /// <inheritdoc />
        decimal IConvertible.ToDecimal(IFormatProvider provider) => CountryID;

        /// <inheritdoc />
        DateTime IConvertible.ToDateTime(IFormatProvider provider)
            => throw new InvalidOperationException($"Cannot convert {GetType().Name} to datetime.");

        /// <inheritdoc />
        string IConvertible.ToString(IFormatProvider provider) => ToString();

        /// <inheritdoc />
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) =>
            throw new InvalidOperationException($"Cannot convert {GetType().Name} to {conversionType.Name}.");

        public bool Equals(CountryKey other)
        {
            throw new NotImplementedException();
        }
    }
}
