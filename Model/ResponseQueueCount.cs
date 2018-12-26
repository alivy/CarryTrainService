using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Data;
using Newtonsoft.Json;

namespace Model
{
    [Serializable]
    public class ResponseQueueCount : ResponseBase
    {
        public QueueCountData Data
        {
            get
            {
                QueueCountData data = null;
                if (base.data != null && base.data.ToString() != string.Empty)
                {
                    data = JsonConvert.DeserializeObject<QueueCountData>(base.data.ToString());
                }
                return data;
            }
        }
    }
}
