using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RSML_web_app.Data
{
    public class RSML_web_appdbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RSML_web_appdbContext() : base("name=RSML_web_appdbContext")
        {
        }

        public System.Data.Entity.DbSet<RSML_web_app.Models.Unresolved> Unresolveds { get; set; }

        public System.Data.Entity.DbSet<RSML_web_app.Models.Resolved> Resolveds { get; set; }

        public System.Data.Entity.DbSet<RSML_web_app.Models.ConfirmedDevices> ConfirmedDevices { get; set; }

        public System.Data.Entity.DbSet<RSML_web_app.Models.ConfirmedDevicesInStore> ConfirmedDevicesInStores { get; set; }
    }
}
