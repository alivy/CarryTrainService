using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ResponseTicketQuery
    {
        public string httpstatus { get; set; }

        public string messages { get; set; }

        public bool status { get; set; }

        public TrainQueryData data { get; set; }
    }

    public class TrainQueryData
    {
        public string flag { get; set; }

        public object  map { get; set; }

        public string[] result { get; set; }
    }
}
