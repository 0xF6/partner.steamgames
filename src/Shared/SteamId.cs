using System;
using System.Collections.Generic;

namespace Steam.Partner.Shared;

public readonly struct SteamId : IEqualityComparer<SteamId>, IComparable, ISpanFormattable, IEquatable<SteamId>
{
    private readonly ulong _value;

    private SteamId(ulong val) => _value = val;


    public static implicit operator ulong(SteamId s) => s._value;
    public static implicit operator SteamId(ulong s) => new(s);


    public bool Equals(SteamId x, SteamId y)
        => x._value.Equals(y._value);

    public int GetHashCode(SteamId obj)
        => _value.GetHashCode();

    public int CompareTo(object? obj) => obj switch
    {
        ulong u => _value.CompareTo(u),
        SteamId s => _value.CompareTo(s._value),
        _ => 0
    };

    public string ToString(string? format, IFormatProvider? formatProvider)
        => $"[SteamId:{_value.ToString(format, formatProvider)}]";

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        => _value.TryFormat(destination, out charsWritten, format, provider);

    public bool Equals(SteamId other)
        => _value.Equals(other._value);

    public override bool Equals(object? obj) => obj switch
    {
        ulong u => _value.Equals(u),
        SteamId s => _value.Equals(s._value),
        _ => false
    };

    public override int GetHashCode()
        => _value.GetHashCode();

    public static bool operator ==(SteamId left, SteamId right)
        => left.Equals(right);

    public static bool operator !=(SteamId left, SteamId right)
        => !(left == right);

    public static bool operator <(SteamId left, SteamId right)
        => left.CompareTo(right) < 0;

    public static bool operator <=(SteamId left, SteamId right)
        => left.CompareTo(right) <= 0;

    public static bool operator >(SteamId left, SteamId right)
        => left.CompareTo(right) > 0;

    public static bool operator >=(SteamId left, SteamId right)
        => left.CompareTo(right) >= 0;
}