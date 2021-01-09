using Lucavice.BunnyCDN.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Lucavice.BunnyCDN.Services
{
    public class PurgeService
    {
        private BunnyCdnOptions bunnyCdnOptions { get; set; }
        private readonly HttpClient httpClient;
        private readonly ILogger logger;
        public PurgeService(IOptions<BunnyCdnOptions> options, HttpClient httpClient, ILogger<PurgeService> logger)
        {
            this.bunnyCdnOptions = options.Value;
            this.httpClient = httpClient;
            this.logger = logger;

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("AccessKey", bunnyCdnOptions.AccessKey);
        }

        public async Task PurgeAsync(IEnumerable<string> urls)
        {
            foreach (var url in urls)
            {
                var apiUrl = new UriBuilder($"{bunnyCdnOptions.ApiBaseAddress}/{bunnyCdnOptions.PurgeEndpoint}");
                apiUrl.Query = $"url={bunnyCdnOptions.CdnUrl}/{url}";
                var response = await httpClient.PostAsync(apiUrl.Uri, null);

                if (!response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    logger.LogError($"BunnyCDN purge was not succesful: {responseString}");
                }
            }
        }
    }
}
