// 
//    Valigator
// 
//    NameServer.cs
// 
// 

using System;
using System.Linq;
using System.Threading.Tasks;
using DnsClient;
using Valigator.Model;

namespace Valigator.Services
{
    public static class NameServer
    {
        public static async Task<NameServerResult> CheckNameServer(string domain)
        {
            var result = new NameServerResult();

            try
            {
                var lookup = await new LookupClient
                {
                    UseCache = true,
                    Timeout = TimeSpan.FromSeconds(3)
                }.QueryAsync(domain, QueryType.ANY);

                result.IsValid = !lookup.HasError;
                result.Message = lookup.ErrorMessage;

                if (result.IsValid)
                {
                    result.HasMailExchanger = lookup.Answers.MxRecords().Any();
                    result.HasHostRecord = lookup.Answers.ARecords().Any();
                }
            }
            catch (DnsResponseException exception)
            {
                result.IsValid = false;
                result.Message = exception.Message;
            }

            return result;
        }
    }
}