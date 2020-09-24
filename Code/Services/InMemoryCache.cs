// 
//    Valigator
// 
//    InMemoryCache.cs
// 
// 

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace Valigator.Services
{
    public static class InMemoryCache
    {
        public static HashSet<string> SuggestiveDomains { get; set; } = new HashSet<string>();
        public static HashSet<string> DisposableDomains { get; set; } = new HashSet<string>();
        public static HashSet<string> TopLevelDomains { get; set; } = new HashSet<string>();
        public static HashSet<string> RoleNames { get; set; } = new HashSet<string>();

        public static async Task Load(string bucket)
        {
            using (var client = new AmazonS3Client(new AmazonS3Config
            {
                RegionEndpoint = RegionEndpoint.EUWest1
            }))
            {
                DisposableDomains = await LoadData(client, bucket, "disposable_domains.txt");
                SuggestiveDomains = await LoadData(client, bucket, "domain_suggestions.txt");
                TopLevelDomains = await LoadData(client, bucket, "iana_tld.txt");
                RoleNames = await LoadData(client, bucket, "role_names.txt");
            }

            Console.WriteLine("Cache initialised");
            Console.WriteLine($"\tDisposable Domains: {DisposableDomains.Count}");
            Console.WriteLine($"\tSuggestive Domains: {SuggestiveDomains.Count}");
            Console.WriteLine($"\tTop Level Domains: {TopLevelDomains.Count}");
            Console.WriteLine($"\tRole Names: {RoleNames.Count}");
        }

        private static async Task<HashSet<string>> LoadData(IAmazonS3 client, string bucket, string key)
        {
            Console.WriteLine($"Loading data from {key} ...");

            var request = new GetObjectRequest
            {
                BucketName = bucket,
                Key = key
            };

            using (var response = await client.GetObjectAsync(request))
            using (var responseStream = response.ResponseStream)
            using (var reader = new StreamReader(responseStream))
            {
                var data = await reader.ReadToEndAsync();
                Console.WriteLine($"\t{key}:{data.Length} bytes loaded");

                return new HashSet<string>(data.Split(
                    new[] {"\r\n", "\r", "\n"}
                    , StringSplitOptions.RemoveEmptyEntries));
            }
        }
    }
}