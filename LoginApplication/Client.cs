using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginApplication
{
    public class Client
    {
        internal static object people;

        public string ReturnId { get; set; }
        public string Clientname { get; set; }
        public string Clientid { get; set; }
        public string Preparer { get; set; }
        public string Officegroup { get; set; }
        public string Status { get; set; }
        public string Lastactivity { get; set; }
        public string HyperLink { get; set; }
    }
}
