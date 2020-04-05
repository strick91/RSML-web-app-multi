using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSML_web_app.Models
{
    public class ConfirmedDevicesInStore
    {
        public int Id { get; set; }

        public string DeviceId { get; set; }

        public string SuspiciousActivities { get; set; }

        public string ZoneHistory { get; set; }

        public string LastSeenDepartment { get; set; }

        public double LastSeenTime { get; set; }

        public string StoreName { get; set; }

        public string StoreLocation { get; set; }
    }
}