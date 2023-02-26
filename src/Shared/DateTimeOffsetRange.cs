using System;

namespace Steam.Partner.Shared;

public record struct DateTimeOffsetRange(DateTimeOffset Start, DateTimeOffset End);