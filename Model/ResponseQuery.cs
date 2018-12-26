using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Data;
using Newtonsoft.Json;

namespace Model
{
    [Serializable]
    public class ResponseQuery : ResponseBase
    {
        public QueryTrainData[] Data
        {
            get
            {
                QueryTrainData[] data = null;
                if (base.data != null && base.data.ToString() != string.Empty)
                {
                    data = JsonConvert.DeserializeObject<QueryTrainData[]>(base.data.ToString());
                }
                return data;
            }
        }
        public string c_url { get; set; }
        public string c_name { get; set; }
    }
}
