// 
//    Valigator
// 
//    NameServerResult.cs
// 
// 

namespace Valigator.Model
{
    public class NameServerResult
    {
        public bool IsValid { get; set; }
        public bool HasMailExchanger { get; set; }
        public bool HasHostRecord { get; set; }
        public string Message { get; set; }
    }
}