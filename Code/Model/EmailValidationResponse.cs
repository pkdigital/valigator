// 
//    Valigator
// 
//    EmailValidationResponse.cs
// 
// 

using Microsoft.AspNetCore.Mvc;

namespace Valigator.Model
{
    public class EmailValidationResponse : ActionResult
    {
        public bool IsValid { get; set; }
        public bool IsDisposable { get; set; }
        public bool IsRole { get; set; }
        public string Suggestion { get; set; }
        public string Address { get; set; }
        public string Domain { get; set; }
        public string LocalPart { get; set; }
    }
}