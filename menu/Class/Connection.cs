using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoomLibrary;

namespace menu.Class
{
    public class Connection
    {
        public static CSQLConnection CSQLConnection
        {
            get { return new CSQLConnection(Properties.Settings.Default.Host, Properties.Settings.Default.Port, Properties.Settings.Default.Username, Properties.Settings.Default.Password, Properties.Settings.Default.Database); }

        }
    }
}
