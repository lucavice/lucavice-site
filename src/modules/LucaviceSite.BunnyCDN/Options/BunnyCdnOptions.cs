using System;
using System.Collections.Generic;
using System.Text;

namespace Lucavice.BunnyCDN.Options
{
    public class BunnyCdnOptions
    {
        public const string BunnyCdn = "BunnyCdn";

        public string CdnUrl { get; set; }

        public string PurgeEndpoint { get; set; }

        public string ApiBaseAddress { get; set; }

        public string AccessKey { get; set; }
    }
}
