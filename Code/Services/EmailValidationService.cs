// 
//    Valigator
// 
//    EmailValidationService.cs
// 
// 

using System.Threading.Tasks;
using Valigator.Model;

namespace Valigator.Services
{
    public class EmailValidationService
    {
        public async Task<EmailValidationResponse> Validate(string value, bool verify)
        {
            var response = new EmailValidationResponse
            {
                Address = value
            };

            var parserResult = EmailParser.Validate(value, true, true);

            response.IsValid = parserResult.IsValid;
            response.LocalPart = parserResult.LocalPart;
            response.Domain = parserResult.Domain;

            if (parserResult.IsValid)
            {
                if (!InMemoryCache.SuggestiveDomains.Contains(response.Domain))
                {
                    var suggestionResult = EmailSuggestor.Suggest(InMemoryCache.SuggestiveDomains, parserResult.Domain);
                    if (suggestionResult.Score > 0 && suggestionResult.Score <= 1)
                    {
                        response.Suggestion = string.Concat(response.LocalPart, "@", suggestionResult.Domain);
                    }
                }

                response.IsDisposable = InMemoryCache.DisposableDomains.Contains(response.Domain);
                response.IsRole = InMemoryCache.RoleNames.Contains(response.LocalPart);

                if (verify)
                {
                    var nameServerResult = await NameServer.CheckNameServer(response.Domain);

                    response.IsValid = nameServerResult.IsValid &&
                                       (nameServerResult.HasMailExchanger || nameServerResult.HasHostRecord);
                }
            }

            return response;
        }
    }
}