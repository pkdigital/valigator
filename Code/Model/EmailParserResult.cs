// 
//    Valigator
// 
//    EmailParserResult.cs
// 
// 

using Valigator.Services;

namespace Valigator.Model
{
    public class EmailParserResult
    {
        public EmailParserResult()
        { }

        public EmailParserResult(bool isValid, ParserRule rule)
        {
            IsValid = isValid;
            Rule = rule;
        }

        public string Domain { get; set; }
        public string LocalPart { get; set; }

        public bool IsValid { get; set; }
        public ParserRule Rule { get; set; }

        public EmailParserResult Invalid(ParserRule rule)
        {
            IsValid = false;
            Rule = rule;
            return this;
        }

        public EmailParserResult Valid()
        {
            IsValid = true;
            return this;
        }
    }
}