using System;
using System.Collections.Generic;

namespace Steam.Partner.CheatReportingService.Types;

public readonly struct ReportId : IEqualityComparer<ReportId>, IComparable, ISpanFormattable, IEquatable<ReportId>
{
    private readonly ulong _value;

    private ReportId(ulong val) => _value = val;


    public static implicit operator ulong(ReportId s) => s._value;
    public static implicit operator ReportId(ulong s) => new(s);


    public bool Equals(ReportId x, ReportId y)
        => x._value.Equals(y._value);

    public int GetHashCode(ReportId obj)
        => _value.GetHashCode();

    public int CompareTo(object? obj) => obj switch
    {
        ulong u => _value.CompareTo(u),
        ReportId s => _value.CompareTo(s._value),
        _ => 0
    };

    public string ToString(string? format, IFormatProvider? formatProvider)
        => $"[ReportId:{_value.ToString(format, formatProvider)}]";

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        => _value.TryFormat(destination, out charsWritten, format, provider);

    public bool Equals(ReportId other)
        => _value.Equals(other._value);

    public override bool Equals(object? obj) => obj switch
    {
        ulong u => _value.Equals(u),
        ReportId s => _value.Equals(s._value),
        _ => false
    };

    public override int GetHashCode()
        => _value.GetHashCode();

    public static bool operator ==(ReportId left, ReportId right)
        => left.Equals(right);

    public static bool operator !=(ReportId left, ReportId right)
        => !(left == right);

    public static bool operator <(ReportId left, ReportId right)
        => left.CompareTo(right) < 0;

    public static bool operator <=(ReportId left, ReportId right)
        => left.CompareTo(right) <= 0;

    public static bool operator >(ReportId left, ReportId right)
        => left.CompareTo(right) > 0;

    public static bool operator >=(ReportId left, ReportId right)
        => left.CompareTo(right) >= 0;
}