using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSML_web_app.Models
{
    public class Resolved
    {
        public int Id { get; set; }

        public string DeviceId { get; set; }

        public string SuspiciousActivities { get; set; }

        public string _Date { get; set; }

        public DateTime TimeResolved { get; set; }

        public string Verdict { get; set; }

        public int StoreNumber { get; set; }

        public string StoreName { get; set; }
    }
}