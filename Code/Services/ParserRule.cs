// 
//    Valigator
// 
//    ParserRule.cs
// 
// 

namespace Valigator.Services
{
    public enum ParserRule
    {
        Unspecified = 0,
        AddressEmpty = 100,
        AddressTooLong = 101,
        AddressTooShort = 102,
        UnbalancedLiteral = 103,
        AddressLiteralTooShort = 104,
        InvalidIPv6Address = 105,
        InvalidIPv4Address = 106
    }
}