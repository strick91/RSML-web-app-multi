using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSML_web_app.Models
{
    public class Unresolved
    {
        public int Id { get; set; }

        public string DeviceId { get; set; }

        public string Department { get; set; }

        public string ThreatLevel { get; set; }

        public DateTime TimeOccured { get; set; }

        public int StoreNumber { get; set; }

        public string StoreName { get; set; }
    }
}